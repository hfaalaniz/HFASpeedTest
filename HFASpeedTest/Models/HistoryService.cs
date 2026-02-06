using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HFASpeedTest.Models;

namespace HFASpeedTest.Services
{
    /// <summary>
    /// Gestiona el historial de tests con persistencia en JSON
    /// </summary>
    public class HistoryService
    {
        private const string HistoryFileName = "speedtest_history.json";
        private readonly string _historyFilePath;
        private List<SpeedTestRecord> _records;

        public HistoryService()
        {
            // Guardar en carpeta AppData del usuario
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appFolder = Path.Combine(appDataPath, "HFASpeedTest");

            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);

            _historyFilePath = Path.Combine(appFolder, HistoryFileName);
            _records = new List<SpeedTestRecord>();

            LoadHistory();
        }

        /// <summary>
        /// Carga el historial desde el archivo JSON
        /// </summary>
        private void LoadHistory()
        {
            try
            {
                if (File.Exists(_historyFilePath))
                {
                    var json = File.ReadAllText(_historyFilePath);
                    _records = JsonSerializer.Deserialize<List<SpeedTestRecord>>(json) ?? new List<SpeedTestRecord>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando historial: {ex.Message}");
                _records = new List<SpeedTestRecord>();
            }
        }

        /// <summary>
        /// Guarda el historial en el archivo JSON
        /// </summary>
        private async Task SaveHistoryAsync()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(_records, options);
                await File.WriteAllTextAsync(_historyFilePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error guardando historial: {ex.Message}");
            }
        }

        /// <summary>
        /// Agrega un nuevo test al historial
        /// </summary>
        public async Task AddRecordAsync(SpeedTestRecord record)
        {
            _records.Add(record);
            await SaveHistoryAsync();
        }

        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        public List<SpeedTestRecord> GetAllRecords()
        {
            return _records.OrderByDescending(r => r.Timestamp).ToList();
        }

        /// <summary>
        /// Obtiene registros filtrados por rango de fechas
        /// </summary>
        public List<SpeedTestRecord> GetRecordsByDateRange(DateTime start, DateTime end)
        {
            return _records
                .Where(r => r.Timestamp >= start && r.Timestamp <= end)
                .OrderBy(r => r.Timestamp)
                .ToList();
        }

        /// <summary>
        /// Obtiene los últimos N registros
        /// </summary>
        public List<SpeedTestRecord> GetRecentRecords(int count = 10)
        {
            return _records
                .OrderByDescending(r => r.Timestamp)
                .Take(count)
                .Reverse()
                .ToList();
        }

        /// <summary>
        /// Elimina un registro por ID
        /// </summary>
        public async Task DeleteRecordAsync(Guid id)
        {
            _records.RemoveAll(r => r.Id == id);
            await SaveHistoryAsync();
        }

        /// <summary>
        /// Limpia todo el historial
        /// </summary>
        public async Task ClearHistoryAsync()
        {
            _records.Clear();
            await SaveHistoryAsync();
        }

        /// <summary>
        /// Calcula estadísticas del historial
        /// </summary>
        public HistoryStatistics GetStatistics()
        {
            if (_records.Count == 0)
                return null;

            var stats = new HistoryStatistics
            {
                TotalTests = _records.Count,
                FirstTestDate = _records.Min(r => r.Timestamp),
                LastTestDate = _records.Max(r => r.Timestamp),

                AvgDownloadMbps = Math.Round(_records.Average(r => r.DownloadMbps), 2),
                AvgUploadMbps = Math.Round(_records.Average(r => r.UploadMbps), 2),
                AvgLatencyMs = Math.Round(_records.Average(r => r.LatencyAvgMs), 2),
                AvgJitterMs = Math.Round(_records.Average(r => r.JitterMs), 2),

                MaxDownloadMbps = Math.Round(_records.Max(r => r.DownloadMbps), 2),
                MaxUploadMbps = Math.Round(_records.Max(r => r.UploadMbps), 2),

                MinDownloadMbps = Math.Round(_records.Min(r => r.DownloadMbps), 2),
                MinUploadMbps = Math.Round(_records.Min(r => r.UploadMbps), 2),

                AvgQualityScore = (int)_records.Average(r => r.GetQualityScore()),
                BestQualityScore = _records.Max(r => r.GetQualityScore()),
                WorstQualityScore = _records.Min(r => r.GetQualityScore())
            };

            // Calcular tendencias (últimos 5 tests vs anteriores)
            if (_records.Count >= 10)
            {
                var recent = _records.OrderByDescending(r => r.Timestamp).Take(5).ToList();
                var previous = _records.OrderByDescending(r => r.Timestamp).Skip(5).Take(5).ToList();

                var recentAvgDown = recent.Average(r => r.DownloadMbps);
                var previousAvgDown = previous.Average(r => r.DownloadMbps);

                var recentAvgLat = recent.Average(r => r.LatencyAvgMs);
                var previousAvgLat = previous.Average(r => r.LatencyAvgMs);

                // Tendencia de descarga
                var downloadChange = ((recentAvgDown - previousAvgDown) / previousAvgDown) * 100;
                stats.DownloadTrend = downloadChange > 5 ? "Mejorando" :
                                     downloadChange < -5 ? "Empeorando" : "Estable";

                // Tendencia de latencia (inverso: menor es mejor)
                var latencyChange = ((recentAvgLat - previousAvgLat) / previousAvgLat) * 100;
                stats.LatencyTrend = latencyChange < -5 ? "Mejorando" :
                                    latencyChange > 5 ? "Empeorando" : "Estable";
            }
            else
            {
                stats.DownloadTrend = "Insuficientes datos";
                stats.LatencyTrend = "Insuficientes datos";
            }

            return stats;
        }

        /// <summary>
        /// Exporta el historial completo a JSON
        /// </summary>
        public async Task<string> ExportToJsonAsync(string filePath = null)
        {
            filePath ??= Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"SpeedTest_Export_{DateTime.Now:yyyyMMdd_HHmmss}.json"
            );

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var export = new
            {
                ExportDate = DateTime.Now,
                Version = "1.0",
                TotalRecords = _records.Count,
                Statistics = GetStatistics(),
                Records = _records.OrderBy(r => r.Timestamp)
            };

            var json = JsonSerializer.Serialize(export, options);
            await File.WriteAllTextAsync(filePath, json);

            return filePath;
        }

        /// <summary>
        /// Exporta el historial a CSV
        /// </summary>
        public async Task<string> ExportToCsvAsync(string filePath = null)
        {
            filePath ??= Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"SpeedTest_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            );

            using var writer = new StreamWriter(filePath);

            // Header
            await writer.WriteLineAsync(
                "Fecha,Hora,Tipo Conexión,IP Local,IP Pública," +
                "Download (Mbps),Upload (Mbps),Simetría (%),Es Simétrica," +
                "Latencia Min (ms),Latencia Max (ms),Latencia Avg (ms),Jitter (ms),Pérdida Paquetes (%)," +
                "Score Calidad,Categoría,Notas"
            );

            // Data
            foreach (var record in _records.OrderBy(r => r.Timestamp))
            {
                await writer.WriteLineAsync(
                    $"{record.Timestamp:yyyy-MM-dd}," +
                    $"{record.Timestamp:HH:mm:ss}," +
                    $"{EscapeCsv(record.ConnectionType)}," +
                    $"{EscapeCsv(record.LocalIP)}," +
                    $"{EscapeCsv(record.PublicIP)}," +
                    $"{record.DownloadMbps:F2}," +
                    $"{record.UploadMbps:F2}," +
                    $"{record.SymmetryRatio:F1}," +
                    $"{(record.IsSymmetric ? "Sí" : "No")}," +
                    $"{record.LatencyMinMs:F2}," +
                    $"{record.LatencyMaxMs:F2}," +
                    $"{record.LatencyAvgMs:F2}," +
                    $"{record.JitterMs:F2}," +
                    $"{record.PacketLoss}," +
                    $"{record.GetQualityScore()}," +
                    $"{record.GetQualityCategory()}," +
                    $"{EscapeCsv(record.Notes)}"
                );
            }

            return filePath;
        }

        private string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
                return $"\"{value.Replace("\"", "\"\"")}\"";

            return value;
        }

        /// <summary>
        /// Obtiene el último test realizado (para comparación en monitoreo)
        /// </summary>
        public SpeedTestRecord GetLastRecord()
        {
            return _records.OrderByDescending(r => r.Timestamp).FirstOrDefault();
        }
    }
}