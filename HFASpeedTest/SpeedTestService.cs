using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HFASpeedTest.Services
{
    public class SpeedResult
    {
        public double DownloadMbps { get; set; }
        public double UploadMbps { get; set; }
        public bool IsSymmetric { get; set; }
        public double SymmetryRatio { get; set; }
    }

    public class SpeedProgressEventArgs : EventArgs
    {
        public double CurrentMbps { get; set; }
        public long BytesTransferred { get; set; }
        public bool IsDownload { get; set; }
    }

    public static class SpeedTestService
    {
        private static readonly (string Url, long ApproxBytes)[] DownloadSources = new[]
        {
            ("https://speedtest.tele2.net/10MB.zip",  10L * 1024 * 1024),
            ("https://speedtest.tele2.net/5MB.zip",    5L * 1024 * 1024),
            ("https://proof.ovh.net/files/10Mb.dat", 10L * 1024 * 1024),
        };

        private const string WarmupUrl = "https://speedtest.tele2.net/1MB.zip";
        private static readonly string[] UploadEndpoints = new[]
        {
            "https://httpbin.org/post",
            "https://httpbingo.org/post",
        };

        private const int ParallelStreams = 4;
        private const double TrimPercent = 0.1;
        private const int MinTestDurationSeconds = 10;

        public static event EventHandler<SpeedProgressEventArgs> OnProgress;

        public static async Task<SpeedResult> RunSpeedTestAsync(CancellationToken ct = default)
        {
            var result = new SpeedResult();

            // IMPORTANTE: Reportar inicio de descarga
            ReportProgress(0, 0, true);

            result.DownloadMbps = await MeasureDownloadAsync(ct);

            // IMPORTANTE: Reportar inicio de subida
            ReportProgress(0, 0, false);

            result.UploadMbps = await MeasureUploadAsync(ct);

            if (result.DownloadMbps > 0)
            {
                result.SymmetryRatio = Math.Round((result.UploadMbps / result.DownloadMbps) * 100, 1);
                result.IsSymmetric = result.SymmetryRatio >= 85 && result.SymmetryRatio <= 115;
            }

            return result;
        }

        private static void ReportProgress(double mbps, long bytes, bool isDownload)
        {
            try
            {
                OnProgress?.Invoke(null, new SpeedProgressEventArgs
                {
                    CurrentMbps = Math.Round(mbps, 2),
                    BytesTransferred = bytes,
                    IsDownload = isDownload
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reportando progreso: {ex.Message}");
            }
        }

        private static async Task<double> MeasureDownloadAsync(CancellationToken ct)
        {
            using var http = CreateHttpClient();

            // Warm-up
            await DoWarmupAsync(http, ct);

            // Encontrar servidor funcional
            string? workingUrl = null;
            foreach (var (url, _) in DownloadSources)
            {
                try
                {
                    using var probe = await http.SendAsync(
                        new HttpRequestMessage(HttpMethod.Head, url),
                        HttpCompletionOption.ResponseHeadersRead, ct);

                    if (probe.IsSuccessStatusCode)
                    {
                        workingUrl = url;
                        Debug.WriteLine($"Servidor seleccionado: {url}");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Servidor {url} falló: {ex.Message}");
                    continue;
                }
            }

            if (workingUrl == null)
            {
                Debug.WriteLine("No se encontró ningún servidor funcional");
                return 0;
            }

            // Variables compartidas entre threads
            var samples = new List<double>();
            long totalBytes = 0;
            var sw = Stopwatch.StartNew();
            var lastReport = DateTime.UtcNow;
            long chunkBytes = 0;
            var lockObj = new object();
            bool shouldStop = false;

            var streamCts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            var tasks = new List<Task>();

            // Crear streams de descarga paralelos
            for (int i = 0; i < ParallelStreams; i++)
            {
                int streamId = i;
                tasks.Add(Task.Run(async () =>
                {
                    Debug.WriteLine($"Stream {streamId} iniciado");
                    while (!shouldStop && !streamCts.Token.IsCancellationRequested)
                    {
                        try
                        {
                            using var resp = await http.GetAsync(workingUrl,
                                HttpCompletionOption.ResponseHeadersRead, streamCts.Token);
                            resp.EnsureSuccessStatusCode();

                            using var stream = await resp.Content.ReadAsStreamAsync(streamCts.Token);
                            var buffer = new byte[65536];

                            while (!shouldStop && !streamCts.Token.IsCancellationRequested)
                            {
                                int read = await stream.ReadAsync(buffer, 0, buffer.Length, streamCts.Token);
                                if (read == 0) break;

                                lock (lockObj)
                                {
                                    totalBytes += read;
                                    chunkBytes += read;
                                }
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Stream {streamId} error: {ex.Message}");
                            await Task.Delay(100, streamCts.Token);
                        }
                    }
                    Debug.WriteLine($"Stream {streamId} finalizado");
                }, streamCts.Token));
            }

            // Task de reporte de progreso
            var reportTask = Task.Run(async () =>
            {
                while (!shouldStop && !ct.IsCancellationRequested)
                {
                    await Task.Delay(250, ct);

                    var now = DateTime.UtcNow;
                    double elapsedSec;
                    long chunkNow;
                    long currentTotal;

                    lock (lockObj)
                    {
                        elapsedSec = (now - lastReport).TotalSeconds;
                        chunkNow = chunkBytes;
                        chunkBytes = 0;
                        lastReport = now;
                        currentTotal = totalBytes;
                    }

                    if (elapsedSec > 0 && chunkNow > 0)
                    {
                        double mbps = (chunkNow * 8.0) / (elapsedSec * 1_000_000);
                        samples.Add(mbps);

                        Debug.WriteLine($"Download: {mbps:F2} Mbps, Total: {currentTotal / 1024.0 / 1024:F2} MB");

                        // REPORTE IMPORTANTE
                        ReportProgress(mbps, currentTotal, true);
                    }

                    // Detener después del tiempo mínimo
                    if (sw.Elapsed.TotalSeconds >= MinTestDurationSeconds && samples.Count >= 10)
                    {
                        Debug.WriteLine($"Test completado: {sw.Elapsed.TotalSeconds:F1}s, {samples.Count} muestras");
                        shouldStop = true;
                        streamCts.Cancel();
                    }
                }
            }, ct);

            await reportTask;

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en streams: {ex.Message}");
            }

            sw.Stop();
            streamCts.Dispose();

            // Calcular velocidad final
            if (samples.Count == 0)
            {
                Debug.WriteLine("No se obtuvieron muestras de velocidad");
                return 0;
            }

            double finalMbps = TrimmedMean(samples);

            if (samples.Count < 3 && totalBytes > 0)
            {
                finalMbps = (totalBytes * 8.0) / (sw.Elapsed.TotalSeconds * 1_000_000);
            }

            Debug.WriteLine($"Download final: {finalMbps:F2} Mbps");
            return Math.Round(finalMbps, 2);
        }

        private static async Task<double> MeasureUploadAsync(CancellationToken ct)
        {
            const int uploadSize = 5 * 1024 * 1024;
            var data = new byte[uploadSize];
            Random.Shared.NextBytes(data);

            using var http = CreateHttpClient();

            Debug.WriteLine("Iniciando upload...");
            ReportProgress(0, 0, false);

            foreach (var endpoint in UploadEndpoints)
            {
                try
                {
                    Debug.WriteLine($"Intentando upload a: {endpoint}");
                    var sw = Stopwatch.StartNew();

                    using var memStream = new MemoryStream(data);
                    using var progStream = new UploadProgressStream(memStream, uploadSize);

                    progStream.OnChunkSent += (bytesSent) =>
                    {
                        double elapsed = sw.Elapsed.TotalSeconds;
                        double mbps = elapsed > 0 ? (bytesSent * 8.0) / (elapsed * 1_000_000) : 0;

                        Debug.WriteLine($"Upload: {mbps:F2} Mbps, {bytesSent / 1024.0 / 1024:F2} MB");
                        ReportProgress(mbps, bytesSent, false);
                    };

                    var content = new StreamContent(progStream, 65536);
                    content.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                    var response = await http.PostAsync(endpoint, content, ct);
                    sw.Stop();

                    if (response.IsSuccessStatusCode && sw.Elapsed.TotalSeconds > 0)
                    {
                        double mbps = (uploadSize * 8.0) / (sw.Elapsed.TotalSeconds * 1_000_000);

                        Debug.WriteLine($"Upload final: {mbps:F2} Mbps");
                        ReportProgress(mbps, uploadSize, false);

                        return Math.Round(mbps, 2);
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Upload a {endpoint} falló: {ex.Message}");
                    continue;
                }
            }

            Debug.WriteLine("Upload falló en todos los endpoints");
            return 0;
        }

        private static HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler
            {
                MaxConnectionsPerServer = ParallelStreams + 2,
                AllowAutoRedirect = true,
                AutomaticDecompression = System.Net.DecompressionMethods.None
            };
            return new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(120)
            };
        }

        private static async Task DoWarmupAsync(HttpClient http, CancellationToken ct)
        {
            try
            {
                Debug.WriteLine("Warm-up iniciado...");
                using var resp = await http.GetAsync(WarmupUrl,
                    HttpCompletionOption.ResponseHeadersRead, ct);
                using var stream = await resp.Content.ReadAsStreamAsync(ct);
                var buf = new byte[65536];

                long downloaded = 0;
                while (downloaded < 256 * 1024)
                {
                    int read = await stream.ReadAsync(buf, 0, buf.Length, ct);
                    if (read == 0) break;
                    downloaded += read;
                }
                Debug.WriteLine("Warm-up completado");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Warm-up falló: {ex.Message}");
            }
        }

        private static double TrimmedMean(List<double> samples)
        {
            if (samples.Count < 3) return samples.Average();

            var sorted = samples.OrderBy(s => s).ToList();
            int trimCount = Math.Max(1, (int)(sorted.Count * TrimPercent));

            var trimmed = sorted.Skip(trimCount).Take(sorted.Count - trimCount * 2).ToList();

            return trimmed.Count > 0 ? trimmed.Average() : sorted.Average();
        }

        private class UploadProgressStream : Stream
        {
            private readonly Stream _inner;
            private long _totalRead;
            private readonly long _totalSize;
            private DateTime _lastReport;

            public event Action<long> OnChunkSent;

            public UploadProgressStream(Stream inner, long totalSize)
            {
                _inner = inner;
                _totalSize = totalSize;
                _lastReport = DateTime.UtcNow;
            }

            public override bool CanRead => _inner.CanRead;
            public override bool CanSeek => _inner.CanSeek;
            public override bool CanWrite => _inner.CanWrite;
            public override long Length => _inner.Length;
            public override long Position { get => _inner.Position; set => _inner.Position = value; }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int read = _inner.Read(buffer, offset, count);
                if (read > 0)
                {
                    _totalRead += read;

                    var now = DateTime.UtcNow;
                    if ((now - _lastReport).TotalMilliseconds >= 100)
                    {
                        OnChunkSent?.Invoke(_totalRead);
                        _lastReport = now;
                    }
                }
                return read;
            }

            public override void Write(byte[] buffer, int offset, int count) => _inner.Write(buffer, offset, count);
            public override void Flush() => _inner.Flush();
            public override long Seek(long offset, SeekOrigin origin) => _inner.Seek(offset, origin);
            public override void SetLength(long value) => _inner.SetLength(value);

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    OnChunkSent?.Invoke(_totalRead);
                    _inner.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
}