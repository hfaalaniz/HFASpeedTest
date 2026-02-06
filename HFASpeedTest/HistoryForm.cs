using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HFASpeedTest.Models;
using HFASpeedTest.Services;

namespace HFASpeedTest
{
    public partial class HistoryForm : Form
    {
        private readonly HistoryService _historyService;
        private List<SpeedTestRecord> _displayedRecords;

        public HistoryForm(HistoryService historyService)
        {
            _historyService = historyService;
            _displayedRecords = new List<SpeedTestRecord>();

            InitializeComponent();
            LoadHistory();
            UpdateStatistics();
        }

        private void CreateStatisticsPanel()
        {
            var titleLabel = new Label
            {
                Text = "📊 Estadísticas Generales",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 200, 255),
                AutoSize = true,
                Location = new Point(0, 0)
            };

            _lblTotalTests = CreateStatLabel("Total de Tests: -", 0, 30);
            _lblAvgDownload = CreateStatLabel("Promedio Descarga: -", 0, 50);
            _lblAvgUpload = CreateStatLabel("Promedio Subida: -", 250, 50);
            _lblAvgLatency = CreateStatLabel("Promedio Latencia: -", 500, 50);
            _lblTrend = CreateStatLabel("Tendencia: -", 0, 70);

            _statsPanel.Controls.AddRange(new Control[]
            {
                titleLabel, _lblTotalTests, _lblAvgDownload,
                _lblAvgUpload, _lblAvgLatency, _lblTrend
            });
        }

        private Label CreateStatLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(220, 220, 230),
                AutoSize = true,
                Location = new Point(x, y)
            };
        }

        private void CreateControlPanel(Panel panel)
        {
            // Filtro de rango de tiempo
            var lblTimeRange = new Label
            {
                Text = "Mostrar:",
                AutoSize = true,
                Location = new Point(0, 15),
                ForeColor = Color.FromArgb(140, 140, 160)
            };

            _cmbTimeRange = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(60, 12),
                Width = 150,
                BackColor = Color.FromArgb(28, 28, 38),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            _cmbTimeRange.Items.AddRange(new object[]
            {
                "Últimos 10 tests",
                "Última semana",
                "Último mes",
                "Últimos 3 meses",
                "Todo el historial"
            });
            _cmbTimeRange.SelectedIndex = 0;
            _cmbTimeRange.SelectedIndexChanged += (s, e) => LoadHistory();

            // Botones de acción
            _btnExportCsv = CreateActionButton("Exportar CSV", 230, ExportToCsv);
            _btnExportJson = CreateActionButton("Exportar JSON", 360, ExportToJson);
            _btnDeleteSelected = CreateActionButton("Eliminar Seleccionado", 490, DeleteSelected);
            _btnClearHistory = CreateActionButton("Limpiar Historial", 660, ClearHistory);

            panel.Controls.AddRange(new Control[]
            {
                lblTimeRange, _cmbTimeRange,
                _btnExportCsv, _btnExportJson,
                _btnDeleteSelected, _btnClearHistory
            });
        }

        private Button CreateActionButton(string text, int x, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(40, 160, 220),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => onClick();

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(50, 180, 240);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(40, 160, 220);

            return btn;
        }

        private void ConfigureGridColumns()
        {
            _gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                HeaderText = "Fecha/Hora",
                DataPropertyName = "Timestamp",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            _gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Download",
                HeaderText = "Download (Mbps)",
                DataPropertyName = "DownloadMbps",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });

            _gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Upload",
                HeaderText = "Upload (Mbps)",
                DataPropertyName = "UploadMbps",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });

            _gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Latency",
                HeaderText = "Latencia (ms)",
                DataPropertyName = "LatencyAvgMs",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F1" }
            });

            _gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PacketLoss",
                HeaderText = "Pérdida (%)",
                DataPropertyName = "PacketLoss"
            });

            _gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quality",
                HeaderText = "Calidad",
                Width = 100
            });
        }

        private void LoadHistory()
        {
            _displayedRecords = _cmbTimeRange.SelectedIndex switch
            {
                0 => _historyService.GetRecentRecords(10),
                1 => _historyService.GetRecordsByDateRange(DateTime.Now.AddDays(-7), DateTime.Now),
                2 => _historyService.GetRecordsByDateRange(DateTime.Now.AddMonths(-1), DateTime.Now),
                3 => _historyService.GetRecordsByDateRange(DateTime.Now.AddMonths(-3), DateTime.Now),
                4 => _historyService.GetAllRecords().OrderByDescending(r => r.Timestamp).ToList(),
                _ => _historyService.GetRecentRecords(10)
            };

            _gridHistory.Rows.Clear();

            foreach (var record in _displayedRecords)
            {
                var row = _gridHistory.Rows[_gridHistory.Rows.Add()];
                row.Tag = record;
                row.Cells["Fecha"].Value = record.Timestamp;
                row.Cells["Download"].Value = record.DownloadMbps;
                row.Cells["Upload"].Value = record.UploadMbps;
                row.Cells["Latency"].Value = record.LatencyAvgMs;
                row.Cells["PacketLoss"].Value = record.PacketLoss;
                row.Cells["Quality"].Value = record.GetQualityCategory();

                // Colorear según calidad
                var qualityScore = record.GetQualityScore();
                var qualityColor = qualityScore >= 80 ? Color.FromArgb(80, 220, 150) :
                                  qualityScore >= 60 ? Color.FromArgb(255, 180, 60) :
                                                       Color.FromArgb(255, 80, 80);

                row.Cells["Quality"].Style.ForeColor = qualityColor;
            }

            DrawCharts();
        }

        private void DrawCharts()
        {
            _chartPanel.Controls.Clear();

            if (_displayedRecords.Count < 2)
            {
                var noDataLabel = new Label
                {
                    Text = "Necesitas al menos 2 tests para mostrar gráficos",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.FromArgb(140, 140, 160),
                    AutoSize = true,
                    Location = new Point(150, 200)
                };
                _chartPanel.Controls.Add(noDataLabel);
                return;
            }

            // Gráfico de velocidades
            DrawSpeedChart(10, 10, 750, 250);

            // Gráfico de latencia
            DrawLatencyChart(10, 280, 750, 250);
        }

        private void DrawSpeedChart(int x, int y, int width, int height)
        {
            var chartPanel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.FromArgb(28, 28, 38),
                BorderStyle = BorderStyle.FixedSingle
            };

            chartPanel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Título
                g.DrawString("Velocidades en el Tiempo",
                    new Font("Segoe UI", 11F, FontStyle.Bold),
                    new SolidBrush(Color.FromArgb(100, 180, 220)),
                    10, 10);

                if (_displayedRecords.Count < 2)
                    return;

                var margin = 50;
                var chartWidth = width - margin * 2;
                var chartHeight = height - margin * 2 - 30;
                var chartX = margin;
                var chartY = margin + 30;

                // Encontrar max para escala
                var maxSpeed = Math.Max(
                    _displayedRecords.Max(r => r.DownloadMbps),
                    _displayedRecords.Max(r => r.UploadMbps)
                );

                var scaleY = chartHeight / maxSpeed;
                var scaleX = chartWidth / (double)(_displayedRecords.Count - 1);

                // Líneas de grid horizontal
                var gridPen = new Pen(Color.FromArgb(50, 50, 60), 1);
                for (int i = 0; i <= 4; i++)
                {
                    var gridY = chartY + chartHeight - (i * chartHeight / 4);
                    g.DrawLine(gridPen, chartX, (int)gridY, chartX + chartWidth, (int)gridY);

                    var value = i * maxSpeed / 4;
                    g.DrawString($"{value:F0}",
                        new Font("Segoe UI", 7F),
                        Brushes.Gray,
                        chartX - 40, (int)gridY - 7);
                }

                // Dibujar líneas
                DrawLine(g, _displayedRecords, r => r.DownloadMbps,
                    Color.FromArgb(40, 200, 120), chartX, chartY, scaleX, scaleY, chartHeight);

                DrawLine(g, _displayedRecords, r => r.UploadMbps,
                    Color.FromArgb(80, 140, 255), chartX, chartY, scaleX, scaleY, chartHeight);

                // Leyenda
                g.FillRectangle(new SolidBrush(Color.FromArgb(40, 200, 120)),
                    chartX, chartY + chartHeight + 10, 15, 10);
                g.DrawString("Download", new Font("Segoe UI", 8F), Brushes.White,
                    chartX + 20, chartY + chartHeight + 8);

                g.FillRectangle(new SolidBrush(Color.FromArgb(80, 140, 255)),
                    chartX + 100, chartY + chartHeight + 10, 15, 10);
                g.DrawString("Upload", new Font("Segoe UI", 8F), Brushes.White,
                    chartX + 120, chartY + chartHeight + 8);
            };

            _chartPanel.Controls.Add(chartPanel);
        }

        private void DrawLatencyChart(int x, int y, int width, int height)
        {
            var chartPanel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.FromArgb(28, 28, 38),
                BorderStyle = BorderStyle.FixedSingle
            };

            chartPanel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.DrawString("Latencia en el Tiempo",
                    new Font("Segoe UI", 11F, FontStyle.Bold),
                    new SolidBrush(Color.FromArgb(100, 180, 220)),
                    10, 10);

                if (_displayedRecords.Count < 2)
                    return;

                var margin = 50;
                var chartWidth = width - margin * 2;
                var chartHeight = height - margin * 2 - 30;
                var chartX = margin;
                var chartY = margin + 30;

                var maxLatency = _displayedRecords.Max(r => r.LatencyAvgMs);
                var scaleY = chartHeight / maxLatency;
                var scaleX = chartWidth / (double)(_displayedRecords.Count - 1);

                // Grid
                var gridPen = new Pen(Color.FromArgb(50, 50, 60), 1);
                for (int i = 0; i <= 4; i++)
                {
                    var gridY = chartY + chartHeight - (i * chartHeight / 4);
                    g.DrawLine(gridPen, chartX, (int)gridY, chartX + chartWidth, (int)gridY);

                    var value = i * maxLatency / 4;
                    g.DrawString($"{value:F0} ms",
                        new Font("Segoe UI", 7F),
                        Brushes.Gray,
                        chartX - 45, (int)gridY - 7);
                }

                // Línea de latencia
                DrawLine(g, _displayedRecords, r => r.LatencyAvgMs,
                    Color.FromArgb(255, 180, 60), chartX, chartY, scaleX, scaleY, chartHeight);
            };

            _chartPanel.Controls.Add(chartPanel);
        }

        private void DrawLine(Graphics g, List<SpeedTestRecord> records,
            Func<SpeedTestRecord, double> getValue, Color color,
            int chartX, int chartY, double scaleX, double scaleY, int chartHeight)
        {
            var points = new List<PointF>();

            for (int i = 0; i < records.Count; i++)
            {
                var value = getValue(records[i]);
                var pointX = chartX + (i * scaleX);
                var pointY = chartY + chartHeight - (value * scaleY);
                points.Add(new PointF((float)pointX, (float)pointY));
            }

            if (points.Count >= 2)
            {
                g.DrawLines(new Pen(color, 2), points.ToArray());

                // Puntos
                foreach (var point in points)
                {
                    g.FillEllipse(new SolidBrush(color),
                        point.X - 3, point.Y - 3, 6, 6);
                }
            }
        }

        private void UpdateStatistics()
        {
            var stats = _historyService.GetStatistics();

            if (stats == null)
            {
                _lblTotalTests.Text = "Total de Tests: 0";
                _lblAvgDownload.Text = "Promedio Descarga: -";
                _lblAvgUpload.Text = "Promedio Subida: -";
                _lblAvgLatency.Text = "Promedio Latencia: -";
                _lblTrend.Text = "Tendencia: Sin datos";
                return;
            }

            _lblTotalTests.Text = $"Total de Tests: {stats.TotalTests}";
            _lblAvgDownload.Text = $"Promedio Descarga: {stats.AvgDownloadMbps:F2} Mbps";
            _lblAvgUpload.Text = $"Promedio Subida: {stats.AvgUploadMbps:F2} Mbps";
            _lblAvgLatency.Text = $"Promedio Latencia: {stats.AvgLatencyMs:F1} ms";
            _lblTrend.Text = $"Tendencia Download: {stats.DownloadTrend} | Latencia: {stats.LatencyTrend}";
        }

        private async void ExportToCsv()
        {
            try
            {
                var filePath = await _historyService.ExportToCsvAsync();
                MessageBox.Show($"Historial exportado exitosamente a:\n{filePath}",
                    "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ExportToJson()
        {
            try
            {
                var filePath = await _historyService.ExportToJsonAsync();
                MessageBox.Show($"Historial exportado exitosamente a:\n{filePath}",
                    "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DeleteSelected()
        {
            if (_gridHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un registro para eliminar",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("¿Estás seguro de eliminar este registro?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var record = (SpeedTestRecord)_gridHistory.SelectedRows[0].Tag;
                await _historyService.DeleteRecordAsync(record.Id);
                LoadHistory();
                UpdateStatistics();
            }
        }

        private async void ClearHistory()
        {
            var result = MessageBox.Show(
                "¿Estás seguro de eliminar TODO el historial?\nEsta acción no se puede deshacer.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                await _historyService.ClearHistoryAsync();
                LoadHistory();
                UpdateStatistics();
            }
        }
    }
}