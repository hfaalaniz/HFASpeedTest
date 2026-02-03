using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HFASpeedTest.Services
{
    public class LatencyResult
    {
        public double MinMs { get; set; }
        public double MaxMs { get; set; }
        public double AvgMs { get; set; }
        public double JitterMs { get; set; }
        public int PacketLoss { get; set; }
        public List<double> Samples { get; set; } = new();
    }

    public static class LatencyService
    {
        public static async Task<LatencyResult> MeasureLatencyAsync(string host, int count = 10, int timeoutMs = 2000)
        {
            var result = new LatencyResult();
            var samples = new List<double>();
            int lost = 0;

            using var ping = new System.Net.NetworkInformation.Ping();
            var sw = new Stopwatch();

            for (int i = 0; i < count; i++)
            {
                try
                {
                    sw.Restart();
                    var reply = await ping.SendPingAsync(host, timeoutMs);
                    sw.Stop();

                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                        samples.Add(sw.Elapsed.TotalMilliseconds);
                    else
                        lost++;
                }
                catch
                {
                    lost++;
                }

                await Task.Delay(50);
            }

            result.Samples = samples;
            result.PacketLoss = count > 0 ? (int)Math.Round((lost / (double)count) * 100) : 100;

            if (samples.Count > 0)
            {
                result.MinMs = Math.Round(samples.Min(), 2);
                result.MaxMs = Math.Round(samples.Max(), 2);
                result.AvgMs = Math.Round(samples.Average(), 2);

                double avg = result.AvgMs;
                double variance = samples.Average(s => Math.Pow(s - avg, 2));
                result.JitterMs = Math.Round(Math.Sqrt(variance), 2);
            }

            return result;
        }
    }
}