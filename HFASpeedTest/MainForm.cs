using System;
using System.Diagnostics;
using System.Drawing;
using HFASpeedTest.Services;

namespace HFASpeedTest
{
    public partial class MainForm : Form
    {
        private bool _isRunning;
        private System.Threading.CancellationTokenSource _cts;

        public MainForm()
        {
            InitializeComponent();

            // CRÍTICO: Suscribir al evento ANTES de cualquier test
            SpeedTestService.OnProgress += OnSpeedProgress;

            Debug.WriteLine("MainForm inicializado, evento OnProgress suscrito");
        }

        private void BtnTest_MouseEnter(object sender, EventArgs e)
        {
            _btnTest.BackColor = Color.FromArgb(50, 180, 240);
        }

        private void BtnTest_MouseLeave(object sender, EventArgs e)
        {
            _btnTest.BackColor = Color.FromArgb(40, 160, 220);
        }

        private async void BtnTest_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                Debug.WriteLine("Test ya está corriendo, ignorando click");
                return;
            }

            _isRunning = true;
            Debug.WriteLine("=== INICIANDO TEST ===");

            _btnTest.Enabled = false;
            _btnTest.Text = "Ejecutando...";
            ResetValues();

            _cts = new System.Threading.CancellationTokenSource();

            try
            {
                // 1. Info de conexión
                SetStatus("Detectando información de red...");
                Debug.WriteLine("Obteniendo info de conexión...");
                var connInfo = await ConnectionInfoService.GetConnectionInfoAsync();
                UpdateConnectionUI(connInfo);

                // 2. Latencia
                SetStatus("Midiendo latencia...");
                Debug.WriteLine("Midiendo latencia...");
                var latency = await LatencyService.MeasureLatencyAsync("8.8.8.8", count: 10);
                UpdateLatencyUI(latency);

                // 3. Speed test
                SetStatus("Iniciando test de velocidad...");
                Debug.WriteLine("Iniciando speed test...");

                var speed = await SpeedTestService.RunSpeedTestAsync(_cts.Token);

                Debug.WriteLine($"Speed test completado: Download={speed.DownloadMbps} Mbps, Upload={speed.UploadMbps} Mbps");
                UpdateSpeedUI(speed);

                SetStatus("✓ Test completado exitosamente.");
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("Test cancelado");
                SetStatus("✗ Test cancelado por el usuario.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en test: {ex}");
                SetStatus($"✗ Error durante el test: {ex.Message}");
            }
            finally
            {
                _btnTest.Enabled = true;
                _btnTest.Text = "Iniciar Test";
                _isRunning = false;
                _cts?.Dispose();
                _cts = null;
                Debug.WriteLine("=== TEST FINALIZADO ===");
            }
        }

        private void OnSpeedProgress(object sender, SpeedProgressEventArgs e)
        {
            // CRÍTICO: Debug para verificar que el evento se está llamando
            Debug.WriteLine($"OnSpeedProgress llamado: IsDownload={e.IsDownload}, Mbps={e.CurrentMbps:F2}, Bytes={e.BytesTransferred}");

            if (InvokeRequired)
            {
                try
                {
                    Invoke(() => OnSpeedProgress(sender, e));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error en Invoke: {ex.Message}");
                }
                return;
            }

            try
            {
                if (e.IsDownload)
                {
                    // Actualizar descarga
                    if (e.CurrentMbps > 0)
                    {
                        _lblDownSpeed.Text = e.CurrentMbps.ToString("F2");
                        _lblDownSpeed.ForeColor = Color.FromArgb(40, 200, 120);
                        Debug.WriteLine($"UI actualizada - Download: {e.CurrentMbps:F2} Mbps");
                    }
                    SetStatus($"📥 Descargando... {FormatBytes(e.BytesTransferred)} - {e.CurrentMbps:F2} Mbps");
                }
                else
                {
                    // Actualizar subida
                    if (e.CurrentMbps > 0)
                    {
                        _lblUpSpeed.Text = e.CurrentMbps.ToString("F2");
                        _lblUpSpeed.ForeColor = Color.FromArgb(80, 140, 255);
                        Debug.WriteLine($"UI actualizada - Upload: {e.CurrentMbps:F2} Mbps");
                    }
                    SetStatus($"📤 Subiendo... {FormatBytes(e.BytesTransferred)} - {e.CurrentMbps:F2} Mbps");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error actualizando UI en OnSpeedProgress: {ex}");
            }
        }

        private void UpdateConnectionUI(ConnectionInfo info)
        {
            if (InvokeRequired) { Invoke(() => UpdateConnectionUI(info)); return; }

            _valTipoConexion.Text = info.ConnectionType ?? "—";
            _valIPLocal.Text = info.LocalIP ?? "—";
            _valIPPublica.Text = info.PublicIP ?? "—";
            _valTipoIP.Text = info.IPType ?? "—";
            _valMAC.Text = FormatMAC(info.MacAddress);

            _valTipoIP.ForeColor = (info.IPType?.Contains("Estática") == true)
                ? Color.FromArgb(80, 220, 150)
                : Color.FromArgb(255, 180, 60);

            Debug.WriteLine($"Conexión actualizada: {info.ConnectionType}, {info.LocalIP}");
        }

        private void UpdateLatencyUI(LatencyResult lat)
        {
            if (InvokeRequired) { Invoke(() => UpdateLatencyUI(lat)); return; }

            _valLatMin.Text = lat.Samples.Count > 0 ? $"{lat.MinMs} ms" : "—";
            _valLatMax.Text = lat.Samples.Count > 0 ? $"{lat.MaxMs} ms" : "—";
            _valLatAvg.Text = lat.Samples.Count > 0 ? $"{lat.AvgMs:F1} ms" : "—";
            _valLatJitter.Text = lat.Samples.Count > 0 ? $"{lat.JitterMs:F1} ms" : "—";
            _valLatLoss.Text = $"{lat.PacketLoss}%";

            _valLatAvg.ForeColor = lat.AvgMs < 50 ? Color.FromArgb(80, 220, 150) :
                                   lat.AvgMs < 100 ? Color.FromArgb(255, 180, 60) :
                                                     Color.FromArgb(255, 80, 80);

            _valLatLoss.ForeColor = lat.PacketLoss == 0 ? Color.FromArgb(80, 220, 150) :
                                    lat.PacketLoss < 5 ? Color.FromArgb(255, 180, 60) :
                                                         Color.FromArgb(255, 80, 80);

            Debug.WriteLine($"Latencia actualizada: Avg={lat.AvgMs:F1}ms, Loss={lat.PacketLoss}%");
        }

        private void UpdateSpeedUI(SpeedResult speed)
        {
            if (InvokeRequired) { Invoke(() => UpdateSpeedUI(speed)); return; }

            Debug.WriteLine($"Actualizando UI final: Download={speed.DownloadMbps}, Upload={speed.UploadMbps}");

            // Valores finales
            _lblDownSpeed.Text = speed.DownloadMbps.ToString("F2");
            _lblDownSpeed.ForeColor = Color.White;

            _lblUpSpeed.Text = speed.UploadMbps.ToString("F2");
            _lblUpSpeed.ForeColor = Color.White;

            // Simetría
            _lblSimetriaVal.Text = $"{speed.SymmetryRatio:F1}%";

            if (speed.IsSymmetric)
            {
                _lblSimetriaDesc.Text = "✓ Conexión simétrica (upload y download similares)";
                _lblSimetriaVal.ForeColor = Color.FromArgb(80, 220, 150);
                _lblSimetriaDesc.ForeColor = Color.FromArgb(80, 220, 150);
            }
            else if (speed.SymmetryRatio < 85)
            {
                _lblSimetriaDesc.Text = "⚠ Conexión asimétrica (upload menor que download)";
                _lblSimetriaVal.ForeColor = Color.FromArgb(255, 180, 60);
                _lblSimetriaDesc.ForeColor = Color.FromArgb(255, 180, 60);
            }
            else
            {
                _lblSimetriaDesc.Text = "⚠ Conexión asimétrica (upload mayor que download)";
                _lblSimetriaVal.ForeColor = Color.FromArgb(255, 180, 60);
                _lblSimetriaDesc.ForeColor = Color.FromArgb(255, 180, 60);
            }

            // Barras
            double maxVal = Math.Max(speed.DownloadMbps, speed.UploadMbps);
            int barW = _barContainer.Width;

            if (maxVal > 0)
            {
                int downW = (int)((speed.DownloadMbps / maxVal) * barW);
                int upW = (int)((speed.UploadMbps / maxVal) * barW);

                _barDown.Width = Math.Max(2, downW);
                _barUp.Width = Math.Max(2, upW);

                Debug.WriteLine($"Barras actualizadas: Down={downW}px, Up={upW}px");
            }
            else
            {
                _barDown.Width = 0;
                _barUp.Width = 0;
            }
        }

        private void SetStatus(string msg)
        {
            if (InvokeRequired) { Invoke(() => SetStatus(msg)); return; }
            _lblStatus.Text = msg;
            Debug.WriteLine($"Status: {msg}");
        }

        private void ResetValues()
        {
            Debug.WriteLine("Reseteando valores UI");

            _valTipoConexion.Text = "—";
            _valIPLocal.Text = "—";
            _valIPPublica.Text = "—";
            _valTipoIP.Text = "—";
            _valMAC.Text = "—";
            _lblDownSpeed.Text = "—";
            _lblUpSpeed.Text = "—";
            _lblSimetriaVal.Text = "—";
            _lblSimetriaDesc.Text = "Pendiente...";
            _valLatMin.Text = "—";
            _valLatMax.Text = "—";
            _valLatAvg.Text = "—";
            _valLatJitter.Text = "—";
            _valLatLoss.Text = "—";

            _barDown.Width = 0;
            _barUp.Width = 0;

            _valTipoIP.ForeColor = Color.FromArgb(140, 140, 160);
            _valLatAvg.ForeColor = Color.FromArgb(140, 140, 160);
            _valLatLoss.ForeColor = Color.FromArgb(140, 140, 160);
            _lblSimetriaVal.ForeColor = Color.FromArgb(80, 200, 255);
            _lblSimetriaDesc.ForeColor = Color.FromArgb(140, 140, 160);
            _lblDownSpeed.ForeColor = Color.White;
            _lblUpSpeed.ForeColor = Color.White;
        }

        private static string FormatMAC(string raw)
        {
            if (string.IsNullOrEmpty(raw) || raw.Length < 12) return "—";
            return $"{raw[0]}{raw[1]}:{raw[2]}{raw[3]}:{raw[4]}{raw[5]}:{raw[6]}{raw[7]}:{raw[8]}{raw[9]}:{raw[10]}{raw[11]}";
        }

        private static string FormatBytes(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            if (bytes < 1024L * 1024 * 1024) return $"{bytes / (1024.0 * 1024):F2} MB";
            return $"{bytes / (1024.0 * 1024 * 1024):F2} GB";
        }

        private void _grpLatencia_Enter(object sender, EventArgs e)
        {
        }

        private void _lblTipoIP_Click(object sender, EventArgs e)
        {
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Debug.WriteLine("Formulario cerrándose, cancelando test...");
            _cts?.Cancel();
            base.OnFormClosing(e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abre la página web en el navegador predeterminado

            // Marca el enlace como visitado
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/hfaalaniz/HFASpeedTest/blob/main/README.md",
                        UseShellExecute = true
            });

            ((LinkLabel)sender).LinkVisited = true;
        }
    }
}