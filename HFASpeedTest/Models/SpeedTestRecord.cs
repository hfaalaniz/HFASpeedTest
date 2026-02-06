using System;
using System.Collections.Generic;

namespace HFASpeedTest.Models
{
    /// <summary>
    /// Representa un test individual guardado en el historial
    /// </summary>
    public class SpeedTestRecord
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }

        // Información de conexión
        public string ConnectionType { get; set; }
        public string LocalIP { get; set; }
        public string PublicIP { get; set; }
        public string IPType { get; set; }

        // Velocidades
        public double DownloadMbps { get; set; }
        public double UploadMbps { get; set; }
        public bool IsSymmetric { get; set; }
        public double SymmetryRatio { get; set; }

        // Latencia
        public double LatencyMinMs { get; set; }
        public double LatencyMaxMs { get; set; }
        public double LatencyAvgMs { get; set; }
        public double JitterMs { get; set; }
        public int PacketLoss { get; set; }

        // Metadata
        public string Notes { get; set; }
        public List<string> Tags { get; set; }

        public SpeedTestRecord()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
            Tags = new List<string>();
        }

        /// <summary>
        /// Calcula un score general de calidad de conexión (0-100)
        /// </summary>
        public int GetQualityScore()
        {
            int score = 0;

            // Velocidad de descarga (40 puntos max)
            if (DownloadMbps >= 100) score += 40;
            else if (DownloadMbps >= 50) score += 30;
            else if (DownloadMbps >= 25) score += 20;
            else if (DownloadMbps >= 10) score += 10;

            // Velocidad de subida (30 puntos max)
            if (UploadMbps >= 50) score += 30;
            else if (UploadMbps >= 25) score += 20;
            else if (UploadMbps >= 10) score += 15;
            else if (UploadMbps >= 5) score += 10;

            // Latencia (20 puntos max)
            if (LatencyAvgMs < 20) score += 20;
            else if (LatencyAvgMs < 50) score += 15;
            else if (LatencyAvgMs < 100) score += 10;
            else if (LatencyAvgMs < 150) score += 5;

            // Pérdida de paquetes (10 puntos max)
            if (PacketLoss == 0) score += 10;
            else if (PacketLoss <= 1) score += 7;
            else if (PacketLoss <= 3) score += 5;
            else if (PacketLoss <= 5) score += 2;

            return Math.Min(score, 100);
        }

        /// <summary>
        /// Obtiene categoría de calidad basada en el score
        /// </summary>
        public string GetQualityCategory()
        {
            int score = GetQualityScore();

            if (score >= 80) return "Excelente";
            if (score >= 60) return "Buena";
            if (score >= 40) return "Regular";
            return "Deficiente";
        }
    }

    /// <summary>
    /// Configuración para el modo de monitoreo continuo
    /// </summary>
    public class MonitoringConfig
    {
        public bool Enabled { get; set; }
        public int IntervalMinutes { get; set; }
        public bool NotifyOnSpeedChange { get; set; }
        public double SpeedChangeThresholdPercent { get; set; }
        public bool NotifyOnLatencySpike { get; set; }
        public double LatencySpikeThresholdMs { get; set; }
        public bool NotifyOnPacketLoss { get; set; }
        public int PacketLossThresholdPercent { get; set; }

        public MonitoringConfig()
        {
            Enabled = false;
            IntervalMinutes = 30;
            NotifyOnSpeedChange = true;
            SpeedChangeThresholdPercent = 20.0; // 20% de cambio
            NotifyOnLatencySpike = true;
            LatencySpikeThresholdMs = 50.0; // +50ms de latencia
            NotifyOnPacketLoss = true;
            PacketLossThresholdPercent = 1; // >1% pérdida
        }
    }

    /// <summary>
    /// Estadísticas agregadas del historial
    /// </summary>
    public class HistoryStatistics
    {
        public int TotalTests { get; set; }
        public DateTime FirstTestDate { get; set; }
        public DateTime LastTestDate { get; set; }

        // Promedios
        public double AvgDownloadMbps { get; set; }
        public double AvgUploadMbps { get; set; }
        public double AvgLatencyMs { get; set; }
        public double AvgJitterMs { get; set; }

        // Máximos
        public double MaxDownloadMbps { get; set; }
        public double MaxUploadMbps { get; set; }

        // Mínimos
        public double MinDownloadMbps { get; set; }
        public double MinUploadMbps { get; set; }

        // Calidad
        public int AvgQualityScore { get; set; }
        public int BestQualityScore { get; set; }
        public int WorstQualityScore { get; set; }

        // Tendencias
        public string DownloadTrend { get; set; } // "Mejorando", "Estable", "Empeorando"
        public string LatencyTrend { get; set; }
    }
}