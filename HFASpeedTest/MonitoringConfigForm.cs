using System;
using System.Drawing;
using System.Windows.Forms;
using HFASpeedTest.Models;
using HFASpeedTest.Services;

namespace HFASpeedTest
{
    public partial class MonitoringConfigForm : Form
    {
        private readonly MonitoringService _monitoringService;
        private MonitoringConfig _config;

        public MonitoringConfigForm(MonitoringService monitoringService)
        {
            _monitoringService = monitoringService;
            _config = new MonitoringConfig
            {
                Enabled = monitoringService.Config.Enabled,
                IntervalMinutes = monitoringService.Config.IntervalMinutes,
                NotifyOnSpeedChange = monitoringService.Config.NotifyOnSpeedChange,
                SpeedChangeThresholdPercent = monitoringService.Config.SpeedChangeThresholdPercent,
                NotifyOnLatencySpike = monitoringService.Config.NotifyOnLatencySpike,
                LatencySpikeThresholdMs = monitoringService.Config.LatencySpikeThresholdMs,
                NotifyOnPacketLoss = monitoringService.Config.NotifyOnPacketLoss,
                PacketLossThresholdPercent = monitoringService.Config.PacketLossThresholdPercent
            };

            InitializeComponent();
            LoadConfig();
            UpdateStatusInfo();
        }

        private void LoadConfig()
        {
            _chkEnabled.Checked = _config.Enabled;
            _numInterval.Value = _config.IntervalMinutes;
            _chkNotifySpeed.Checked = _config.NotifyOnSpeedChange;
            _numSpeedThreshold.Value = (decimal)_config.SpeedChangeThresholdPercent;
            _chkNotifyLatency.Checked = _config.NotifyOnLatencySpike;
            _numLatencyThreshold.Value = (decimal)_config.LatencySpikeThresholdMs;
            _chkNotifyPacketLoss.Checked = _config.NotifyOnPacketLoss;
           // _numPacketLossThreshold.Value = _config.PacketLossThresholdPercent;
        }

        private void SaveConfig()
        {
            _config.Enabled = _chkEnabled.Checked;
            _config.IntervalMinutes = (int)_numInterval.Value;
            _config.NotifyOnSpeedChange = _chkNotifySpeed.Checked;
            _config.SpeedChangeThresholdPercent = (double)_numSpeedThreshold.Value;
            _config.NotifyOnLatencySpike = _chkNotifyLatency.Checked;
            _config.LatencySpikeThresholdMs = (double)_numLatencyThreshold.Value;
            _config.NotifyOnPacketLoss = _chkNotifyPacketLoss.Checked;
            _config.PacketLossThresholdPercent = (int)_numPacketLossThreshold.Value;

            // Aplicar configuración
            if (_config.Enabled)
            {
                _monitoringService.Start(_config);
            }
            else
            {
                _monitoringService.Stop();
            }

            MessageBox.Show("Configuración guardada exitosamente",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void UpdateStatusInfo()
        {
            if (_monitoringService.IsMonitoring)
            {
                _lblStatus.Text = "Estado: ✓ Activo";
                _lblStatus.ForeColor = Color.FromArgb(80, 220, 150);

                var timeUntilNext = _monitoringService.GetTimeUntilNextTest();
                if (timeUntilNext > TimeSpan.Zero)
                {
                    _lblNextTest.Text = $"Próximo test en: {timeUntilNext.Hours:D2}:{timeUntilNext.Minutes:D2}:{timeUntilNext.Seconds:D2}";
                }
                else
                {
                    _lblNextTest.Text = "Próximo test: Ejecutando ahora...";
                }
            }
            else
            {
                _lblStatus.Text = "Estado: ○ Detenido";
                _lblStatus.ForeColor = Color.FromArgb(255, 180, 60);
                _lblNextTest.Text = "Próximo test: -";
            }
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}