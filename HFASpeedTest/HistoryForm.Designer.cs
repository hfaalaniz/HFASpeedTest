namespace HFASpeedTest
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            _statsPanel = new Panel();
            _lblTrend = new Label();
            _lblAvgLatency = new Label();
            _lblAvgUpload = new Label();
            _lblAvgDownload = new Label();
            _lblTotalTests = new Label();
            titleLabel = new Label();
            controlPanel = new Panel();
            _btnClearHistory = new Button();
            _btnDeleteSelected = new Button();
            _btnExportJson = new Button();
            _btnExportCsv = new Button();
            lblTimeRange = new Label();
            _cmbTimeRange = new ComboBox();
            splitContainer1 = new SplitContainer();
            _gridHistory = new DataGridView();
            Fecha = new DataGridViewTextBoxColumn();
            Download = new DataGridViewTextBoxColumn();
            Upload = new DataGridViewTextBoxColumn();
            Latency = new DataGridViewTextBoxColumn();
            PacketLoss = new DataGridViewTextBoxColumn();
            Quality = new DataGridViewTextBoxColumn();
            _chartPanel = new Panel();
            _statsPanel.SuspendLayout();
            controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_gridHistory).BeginInit();
            SuspendLayout();
            // 
            // _statsPanel
            // 
            _statsPanel.BackColor = Color.FromArgb(22, 22, 30);
            _statsPanel.Controls.Add(_lblTrend);
            _statsPanel.Controls.Add(_lblAvgLatency);
            _statsPanel.Controls.Add(_lblAvgUpload);
            _statsPanel.Controls.Add(_lblAvgDownload);
            _statsPanel.Controls.Add(_lblTotalTests);
            _statsPanel.Controls.Add(titleLabel);
            _statsPanel.Dock = DockStyle.Top;
            _statsPanel.Location = new Point(0, 0);
            _statsPanel.Name = "_statsPanel";
            _statsPanel.Size = new Size(1031, 92);
            _statsPanel.TabIndex = 0;
            // 
            // _lblTrend
            // 
            _lblTrend.AutoSize = true;
            _lblTrend.ForeColor = Color.FromArgb(80, 200, 255);
            _lblTrend.Location = new Point(439, 48);
            _lblTrend.Name = "_lblTrend";
            _lblTrend.Size = new Size(78, 17);
            _lblTrend.TabIndex = 0;
            _lblTrend.Text = "Tendencia: -";
            // 
            // _lblAvgLatency
            // 
            _lblAvgLatency.AutoSize = true;
            _lblAvgLatency.ForeColor = Color.FromArgb(80, 200, 255);
            _lblAvgLatency.Location = new Point(864, 48);
            _lblAvgLatency.Name = "_lblAvgLatency";
            _lblAvgLatency.Size = new Size(128, 17);
            _lblAvgLatency.TabIndex = 0;
            _lblAvgLatency.Text = "Promedio Latencia: -";
            // 
            // _lblAvgUpload
            // 
            _lblAvgUpload.AutoSize = true;
            _lblAvgUpload.ForeColor = Color.FromArgb(80, 200, 255);
            _lblAvgUpload.Location = new Point(238, 48);
            _lblAvgUpload.Name = "_lblAvgUpload";
            _lblAvgUpload.Size = new Size(121, 17);
            _lblAvgUpload.TabIndex = 0;
            _lblAvgUpload.Text = "Promedio Subida: -";
            // 
            // _lblAvgDownload
            // 
            _lblAvgDownload.AutoSize = true;
            _lblAvgDownload.ForeColor = Color.FromArgb(80, 200, 255);
            _lblAvgDownload.Location = new Point(617, 48);
            _lblAvgDownload.Name = "_lblAvgDownload";
            _lblAvgDownload.Size = new Size(136, 17);
            _lblAvgDownload.TabIndex = 0;
            _lblAvgDownload.Text = "Promedio Descarga: -";
            // 
            // _lblTotalTests
            // 
            _lblTotalTests.AutoSize = true;
            _lblTotalTests.ForeColor = Color.FromArgb(80, 200, 255);
            _lblTotalTests.Location = new Point(36, 48);
            _lblTotalTests.Name = "_lblTotalTests";
            _lblTotalTests.Size = new Size(100, 17);
            _lblTotalTests.TabIndex = 0;
            _lblTotalTests.Text = "Total de Tests: -";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.ForeColor = Color.FromArgb(80, 200, 255);
            titleLabel.Location = new Point(36, 17);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(158, 17);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "📊 Estadísticas Generales";
            // 
            // controlPanel
            // 
            controlPanel.BackColor = Color.FromArgb(22, 22, 30);
            controlPanel.Controls.Add(_btnClearHistory);
            controlPanel.Controls.Add(_btnDeleteSelected);
            controlPanel.Controls.Add(_btnExportJson);
            controlPanel.Controls.Add(_btnExportCsv);
            controlPanel.Controls.Add(lblTimeRange);
            controlPanel.Controls.Add(_cmbTimeRange);
            controlPanel.Dock = DockStyle.Top;
            controlPanel.Location = new Point(0, 92);
            controlPanel.Name = "controlPanel";
            controlPanel.Padding = new Padding(20, 10, 20, 10);
            controlPanel.Size = new Size(1031, 60);
            controlPanel.TabIndex = 1;
            // 
            // _btnClearHistory
            // 
            _btnClearHistory.Location = new Point(707, 11);
            _btnClearHistory.Name = "_btnClearHistory";
            _btnClearHistory.Size = new Size(161, 36);
            _btnClearHistory.TabIndex = 2;
            _btnClearHistory.Text = "Limpiar Historial";
            _btnClearHistory.UseVisualStyleBackColor = true;
            // 
            // _btnDeleteSelected
            // 
            _btnDeleteSelected.Location = new Point(530, 11);
            _btnDeleteSelected.Name = "_btnDeleteSelected";
            _btnDeleteSelected.Size = new Size(159, 36);
            _btnDeleteSelected.TabIndex = 2;
            _btnDeleteSelected.Text = "Eliminar Seleccionado";
            _btnDeleteSelected.UseVisualStyleBackColor = true;
            // 
            // _btnExportJson
            // 
            _btnExportJson.Location = new Point(406, 11);
            _btnExportJson.Name = "_btnExportJson";
            _btnExportJson.Size = new Size(111, 36);
            _btnExportJson.TabIndex = 2;
            _btnExportJson.Text = "Exportar JSON";
            _btnExportJson.UseVisualStyleBackColor = true;
            // 
            // _btnExportCsv
            // 
            _btnExportCsv.Location = new Point(289, 11);
            _btnExportCsv.Name = "_btnExportCsv";
            _btnExportCsv.Size = new Size(111, 36);
            _btnExportCsv.TabIndex = 2;
            _btnExportCsv.Text = "Exportar CSV";
            _btnExportCsv.UseVisualStyleBackColor = true;
            // 
            // lblTimeRange
            // 
            lblTimeRange.AutoSize = true;
            lblTimeRange.ForeColor = Color.FromArgb(140, 140, 160);
            lblTimeRange.Location = new Point(11, 18);
            lblTimeRange.Name = "lblTimeRange";
            lblTimeRange.Size = new Size(58, 17);
            lblTimeRange.TabIndex = 1;
            lblTimeRange.Text = "Mostrar:";
            // 
            // _cmbTimeRange
            // 
            _cmbTimeRange.BackColor = Color.FromArgb(28, 28, 38);
            _cmbTimeRange.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbTimeRange.FlatStyle = FlatStyle.Flat;
            _cmbTimeRange.ForeColor = Color.White;
            _cmbTimeRange.FormattingEnabled = true;
            _cmbTimeRange.Items.AddRange(new object[] { "Últimos 10 tests", "Última semana", "Último mes", "Últimos 3 meses", "Todo el historial" });
            _cmbTimeRange.Location = new Point(73, 15);
            _cmbTimeRange.Name = "_cmbTimeRange";
            _cmbTimeRange.Size = new Size(176, 25);
            _cmbTimeRange.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 152);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(_gridHistory);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(_chartPanel);
            splitContainer1.Size = new Size(1031, 489);
            splitContainer1.SplitterDistance = 597;
            splitContainer1.TabIndex = 2;
            // 
            // _gridHistory
            // 
            _gridHistory.AllowUserToAddRows = false;
            _gridHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(32, 32, 42);
            _gridHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            _gridHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _gridHistory.BackgroundColor = Color.FromArgb(28, 28, 38);
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(40, 40, 50);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(100, 180, 220);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(40, 40, 50);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            _gridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            _gridHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _gridHistory.Columns.AddRange(new DataGridViewColumn[] { Fecha, Download, Upload, Latency, PacketLoss, Quality });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(28, 28, 38);
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle12.ForeColor = Color.White;
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(40, 160, 220);
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            _gridHistory.DefaultCellStyle = dataGridViewCellStyle12;
            _gridHistory.Dock = DockStyle.Fill;
            _gridHistory.EnableHeadersVisualStyles = false;
            _gridHistory.GridColor = Color.FromArgb(60, 60, 70);
            _gridHistory.Location = new Point(0, 0);
            _gridHistory.Name = "_gridHistory";
            _gridHistory.RowHeadersVisible = false;
            _gridHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _gridHistory.Size = new Size(597, 489);
            _gridHistory.TabIndex = 0;
            // 
            // Fecha
            // 
            Fecha.DataPropertyName = "Timestamp";
            dataGridViewCellStyle9.Format = "dd/MM/yyyy HH:mm";
            Fecha.DefaultCellStyle = dataGridViewCellStyle9;
            Fecha.HeaderText = "Fecha/Hora";
            Fecha.Name = "Fecha";
            // 
            // Download
            // 
            Download.DataPropertyName = "UploadMbps";
            dataGridViewCellStyle10.Format = "F2";
            Download.DefaultCellStyle = dataGridViewCellStyle10;
            Download.HeaderText = "Download (Mbps)";
            Download.Name = "Download";
            // 
            // Upload
            // 
            Upload.HeaderText = "Upload (Mbps)";
            Upload.Name = "Upload";
            // 
            // Latency
            // 
            Latency.DataPropertyName = "LatencyAvgMs";
            dataGridViewCellStyle11.Format = "F2";
            Latency.DefaultCellStyle = dataGridViewCellStyle11;
            Latency.HeaderText = "Latencia (ms)";
            Latency.Name = "Latency";
            // 
            // PacketLoss
            // 
            PacketLoss.DataPropertyName = "PacketLoss";
            PacketLoss.HeaderText = "Perdida (%)";
            PacketLoss.Name = "PacketLoss";
            // 
            // Quality
            // 
            Quality.HeaderText = "Calidad";
            Quality.Name = "Quality";
            // 
            // _chartPanel
            // 
            _chartPanel.AutoScroll = true;
            _chartPanel.BackColor = Color.FromArgb(22, 22, 30);
            _chartPanel.Dock = DockStyle.Fill;
            _chartPanel.Location = new Point(0, 0);
            _chartPanel.Name = "_chartPanel";
            _chartPanel.Size = new Size(430, 489);
            _chartPanel.TabIndex = 0;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 641);
            Controls.Add(splitContainer1);
            Controls.Add(controlPanel);
            Controls.Add(_statsPanel);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HistoryForm";
            Text = "Historial de Tests - HFASpeedTest Pro";
            _statsPanel.ResumeLayout(false);
            _statsPanel.PerformLayout();
            controlPanel.ResumeLayout(false);
            controlPanel.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_gridHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel _statsPanel;
        private Panel controlPanel;
        private SplitContainer splitContainer1;
        private DataGridView _gridHistory;
        private Panel _chartPanel;
        private Label titleLabel;
        private Label _lblTotalTests;
        private Label _lblAvgDownload;
        private Label _lblAvgUpload;
        private Label _lblAvgLatency;
        private Label _lblTrend;
        private ComboBox _cmbTimeRange;
        private Label lblTimeRange;
        private Button _btnClearHistory;
        private Button _btnDeleteSelected;
        private Button _btnExportJson;
        private Button _btnExportCsv;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Download;
        private DataGridViewTextBoxColumn Upload;
        private DataGridViewTextBoxColumn Latency;
        private DataGridViewTextBoxColumn PacketLoss;
        private DataGridViewTextBoxColumn Quality;
    }
}