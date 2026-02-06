using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using HFASpeedTest.Models;

namespace HFASpeedTest.Services
{
    /// <summary>
    /// Tipos de notificación del sistema de monitoreo
    /// </summary>
    public enum NotificationType
    {
        SpeedIncrease,
        SpeedDecrease,
        LatencySpike,
        PacketLoss,
        ConnectionChange,
        MonitoringStarted,
        MonitoringStopped
    }

    /// <summary>
    /// Evento de notificación del monitoreo
    /// </summary>
    public class MonitoringNotificationEventArgs : EventArgs
    {
        public NotificationType Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public SpeedTestRecord CurrentTest { get; set; }
        public SpeedTestRecord PreviousTest { get; set; }
        public DateTime Timestamp { get; set; }

        public MonitoringNotificationEventArgs()
        {
            Timestamp = DateTime.Now;
        }
    }

    /// <summary>
    /// Servicio de monitoreo continuo de la conexión
    /// </summary>
    public class MonitoringService
    {
        private System.Windows.Forms.Timer _timer;
        private MonitoringConfig _config;
        private readonly HistoryService _historyService;
        private bool _isMonitoring;
        private CancellationTokenSource _cts;

        public bool IsMonitoring => _isMonitoring;
        public MonitoringConfig Config => _config;

        public event EventHandler<MonitoringNotificationEventArgs> OnNotification;
        public event EventHandler<SpeedTestRecord> OnTestCompleted;

        public MonitoringService(HistoryService historyService)
        {
            _historyService = historyService;
            _config = new MonitoringConfig();
            _isMonitoring = false;
        }

        /// <summary>
        /// Inicia el monitoreo continuo
        /// </summary>
        public void Start(MonitoringConfig config = null)
        {
            if (_isMonitoring)
            {
                Debug.WriteLine("El monitoreo ya está activo");
                return;
            }

            _config = config ?? _config;
            _isMonitoring = true;
            _cts = new CancellationTokenSource();

            Debug.WriteLine($"Iniciando monitoreo cada {_config.IntervalMinutes} minutos");

            // Notificar inicio
            RaiseNotification(new MonitoringNotificationEventArgs
            {
                Type = NotificationType.MonitoringStarted,
                Title = "Monitoreo Iniciado",
                Message = $"El monitoreo automático se ejecutará cada {_config.IntervalMinutes} minutos"
            });

            // Ejecutar primer test inmediatamente
            Task.Run(() => ExecuteMonitoringTestAsync(_cts.Token));

            // Configurar timer para tests periódicos
            var intervalMs = _config.IntervalMinutes * 60 * 1000;
            /*_timer = new Timer(
                async _ => await ExecuteMonitoringTestAsync(_cts.Token),
                null,
                intervalMs,
                intervalMs
            );*/
        }

        /// <summary>
        /// Detiene el monitoreo continuo
        /// </summary>
        public void Stop()
        {
            if (!_isMonitoring)
                return;

            Debug.WriteLine("Deteniendo monitoreo");

            _isMonitoring = false;
            _timer?.Dispose();
            _timer = null;
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;

            // Notificar detención
            RaiseNotification(new MonitoringNotificationEventArgs
            {
                Type = NotificationType.MonitoringStopped,
                Title = "Monitoreo Detenido",
                Message = "El monitoreo automático ha sido detenido"
            });
        }

        /// <summary>
        /// Ejecuta un test completo durante el monitoreo
        /// </summary>
        private async Task ExecuteMonitoringTestAsync(CancellationToken ct)
        {
            if (!_isMonitoring)
                return;

            try
            {
                Debug.WriteLine("Ejecutando test de monitoreo...");

                // Obtener test anterior para comparación
                var previousTest = _historyService.GetLastRecord();

                // Ejecutar test completo
                var connectionInfo = await ConnectionInfoService.GetConnectionInfoAsync();
                var latency = await LatencyService.MeasureLatencyAsync("8.8.8.8", count: 10);
                var speed = await SpeedTestService.RunSpeedTestAsync(ct);

                // Crear registro
                var record = new SpeedTestRecord
                {
                    ConnectionType = connectionInfo.ConnectionType,
                    LocalIP = connectionInfo.LocalIP,
                    PublicIP = connectionInfo.PublicIP,
                    IPType = connectionInfo.IPType,

                    DownloadMbps = speed.DownloadMbps,
                    UploadMbps = speed.UploadMbps,
                    IsSymmetric = speed.IsSymmetric,
                    SymmetryRatio = speed.SymmetryRatio,

                    LatencyMinMs = latency.MinMs,
                    LatencyMaxMs = latency.MaxMs,
                    LatencyAvgMs = latency.AvgMs,
                    JitterMs = latency.JitterMs,
                    PacketLoss = latency.PacketLoss,

                    Notes = "Test automático (monitoreo)"
                };

                // Guardar en historial
                await _historyService.AddRecordAsync(record);

                // Notificar test completado
                OnTestCompleted?.Invoke(this, record);

                // Analizar y notificar cambios
                if (previousTest != null)
                {
                    AnalyzeAndNotify(record, previousTest);
                }

                Debug.WriteLine($"Test de monitoreo completado: {speed.DownloadMbps:F2} Mbps down, {speed.UploadMbps:F2} Mbps up");
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("Test de monitoreo cancelado");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en test de monitoreo: {ex.Message}");
            }
        }

        /// <summary>
        /// Analiza los cambios entre tests y genera notificaciones
        /// </summary>
        private void AnalyzeAndNotify(SpeedTestRecord current, SpeedTestRecord previous)
        {
            // Verificar cambio en velocidad de descarga
            if (_config.NotifyOnSpeedChange)
            {
                var downloadChange = ((current.DownloadMbps - previous.DownloadMbps) / previous.DownloadMbps) * 100;

                if (Math.Abs(downloadChange) >= _config.SpeedChangeThresholdPercent)
                {
                    var type = downloadChange > 0 ? NotificationType.SpeedIncrease : NotificationType.SpeedDecrease;
                    var direction = downloadChange > 0 ? "aumentado" : "disminuido";

                    RaiseNotification(new MonitoringNotificationEventArgs
                    {
                        Type = type,
                        Title = $"Cambio de Velocidad Detectado",
                        Message = $"La velocidad de descarga ha {direction} {Math.Abs(downloadChange):F1}%\n" +
                                 $"Anterior: {previous.DownloadMbps:F2} Mbps → Actual: {current.DownloadMbps:F2} Mbps",
                        CurrentTest = current,
                        PreviousTest = previous
                    });
                }
            }

            // Verificar pico de latencia
            if (_config.NotifyOnLatencySpike)
            {
                var latencyIncrease = current.LatencyAvgMs - previous.LatencyAvgMs;

                if (latencyIncrease >= _config.LatencySpikeThresholdMs)
                {
                    RaiseNotification(new MonitoringNotificationEventArgs
                    {
                        Type = NotificationType.LatencySpike,
                        Title = "Pico de Latencia Detectado",
                        Message = $"La latencia ha aumentado {latencyIncrease:F1} ms\n" +
                                 $"Anterior: {previous.LatencyAvgMs:F1} ms → Actual: {current.LatencyAvgMs:F1} ms",
                        CurrentTest = current,
                        PreviousTest = previous
                    });
                }
            }

            // Verificar pérdida de paquetes
            if (_config.NotifyOnPacketLoss)
            {
                if (current.PacketLoss > _config.PacketLossThresholdPercent &&
                    current.PacketLoss > previous.PacketLoss)
                {
                    RaiseNotification(new MonitoringNotificationEventArgs
                    {
                        Type = NotificationType.PacketLoss,
                        Title = "Pérdida de Paquetes Detectada",
                        Message = $"Pérdida de paquetes: {current.PacketLoss}%\n" +
                                 $"La conexión puede estar experimentando problemas",
                        CurrentTest = current,
                        PreviousTest = previous
                    });
                }
            }

            // Verificar cambio en tipo de conexión
            if (current.ConnectionType != previous.ConnectionType)
            {
                RaiseNotification(new MonitoringNotificationEventArgs
                {
                    Type = NotificationType.ConnectionChange,
                    Title = "Cambio de Conexión",
                    Message = $"Tipo de conexión cambió: {previous.ConnectionType} → {current.ConnectionType}",
                    CurrentTest = current,
                    PreviousTest = previous
                });
            }
        }

        /// <summary>
        /// Dispara un evento de notificación
        /// </summary>
        private void RaiseNotification(MonitoringNotificationEventArgs args)
        {
            Debug.WriteLine($"Notificación: {args.Title} - {args.Message}");
            OnNotification?.Invoke(this, args);
        }

        /// <summary>
        /// Actualiza la configuración del monitoreo
        /// </summary>
        public void UpdateConfig(MonitoringConfig config)
        {
            _config = config;

            // Si está activo, reiniciar con nueva configuración
            if (_isMonitoring)
            {
                Stop();
                Start(_config);
            }
        }

        /// <summary>
        /// Obtiene el tiempo restante hasta el próximo test
        /// </summary>
        public TimeSpan GetTimeUntilNextTest()
        {
            if (!_isMonitoring || _historyService.GetLastRecord() == null)
                return TimeSpan.Zero;

            var lastTest = _historyService.GetLastRecord().Timestamp;
            var nextTest = lastTest.AddMinutes(_config.IntervalMinutes);
            var remaining = nextTest - DateTime.Now;

            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }
    }
}