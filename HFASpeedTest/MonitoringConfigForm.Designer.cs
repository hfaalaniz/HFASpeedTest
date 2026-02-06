namespace HFASpeedTest
{
    partial class MonitoringConfigForm
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
            headerLabel = new Label();
            statusPanel = new Panel();
            _btnCancel = new Button();
            _btnSave = new Button();
            _lblNextTest = new Label();
            _lblStatus = new Label();
            grpGeneral = new GroupBox();
            _numInterval = new NumericUpDown();
            lblInterval = new Label();
            _chkEnabled = new CheckBox();
            grpNotifications = new GroupBox();
            _numLatencyThreshold = new NumericUpDown();
            _numPacketLossThreshold = new NumericUpDown();
            _numSpeedThreshold = new NumericUpDown();
            lblLatencyThreshold = new Label();
            lblPacketLossThreshold = new Label();
            lblSpeedThreshold = new Label();
            _chkNotifyLatency = new CheckBox();
            _chkNotifyPacketLoss = new CheckBox();
            _chkNotifySpeed = new CheckBox();
            statusPanel.SuspendLayout();
            grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_numInterval).BeginInit();
            grpNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_numLatencyThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_numPacketLossThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_numSpeedThreshold).BeginInit();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.ForeColor = Color.FromArgb(20, 200, 255);
            headerLabel.Location = new Point(29, 19);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(384, 25);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "⚙️ Configuración de Monitoreo Continuo";
            // 
            // statusPanel
            // 
            statusPanel.BackColor = Color.FromArgb(22, 22, 30);
            statusPanel.BorderStyle = BorderStyle.FixedSingle;
            statusPanel.Controls.Add(_btnCancel);
            statusPanel.Controls.Add(_btnSave);
            statusPanel.Controls.Add(_lblNextTest);
            statusPanel.Controls.Add(_lblStatus);
            statusPanel.Location = new Point(3, 53);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(643, 80);
            statusPanel.TabIndex = 1;
            // 
            // _btnCancel
            // 
            _btnCancel.BackColor = Color.FromArgb(50, 180, 240);
            _btnCancel.Cursor = Cursors.Hand;
            _btnCancel.FlatStyle = FlatStyle.Flat;
            _btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _btnCancel.Location = new Point(533, 14);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(97, 33);
            _btnCancel.TabIndex = 1;
            _btnCancel.Text = "Cancelar";
            _btnCancel.UseVisualStyleBackColor = false;
            _btnCancel.Click += _btnCancel_Click;
            // 
            // _btnSave
            // 
            _btnSave.BackColor = Color.FromArgb(40, 160, 220);
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.FlatStyle = FlatStyle.Flat;
            _btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _btnSave.Location = new Point(396, 14);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(97, 33);
            _btnSave.TabIndex = 1;
            _btnSave.Text = "Guardar";
            _btnSave.UseVisualStyleBackColor = false;
            _btnSave.Click += _btnSave_Click;
            // 
            // _lblNextTest
            // 
            _lblNextTest.AutoSize = true;
            _lblNextTest.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _lblNextTest.ForeColor = Color.FromArgb(140, 140, 160);
            _lblNextTest.Location = new Point(15, 51);
            _lblNextTest.Name = "_lblNextTest";
            _lblNextTest.Size = new Size(85, 15);
            _lblNextTest.TabIndex = 0;
            _lblNextTest.Text = "Próximo test: -";
            // 
            // _lblStatus
            // 
            _lblStatus.AutoSize = true;
            _lblStatus.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblStatus.ForeColor = Color.FromArgb(255, 180, 60);
            _lblStatus.Location = new Point(8, 22);
            _lblStatus.Name = "_lblStatus";
            _lblStatus.Size = new Size(163, 25);
            _lblStatus.TabIndex = 0;
            _lblStatus.Text = "Estado: Detenido";
            // 
            // grpGeneral
            // 
            grpGeneral.Controls.Add(_numInterval);
            grpGeneral.Controls.Add(lblInterval);
            grpGeneral.Controls.Add(_chkEnabled);
            grpGeneral.ForeColor = Color.FromArgb(100, 180, 220);
            grpGeneral.Location = new Point(4, 148);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new Size(642, 100);
            grpGeneral.TabIndex = 2;
            grpGeneral.TabStop = false;
            grpGeneral.Text = "Configuración General";
            // 
            // _numInterval
            // 
            _numInterval.BackColor = Color.FromArgb(28, 28, 38);
            _numInterval.ForeColor = Color.White;
            _numInterval.Location = new Point(289, 59);
            _numInterval.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            _numInterval.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            _numInterval.Name = "_numInterval";
            _numInterval.Size = new Size(120, 23);
            _numInterval.TabIndex = 1;
            _numInterval.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblInterval
            // 
            lblInterval.AutoSize = true;
            lblInterval.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInterval.ForeColor = Color.FromArgb(140, 140, 160);
            lblInterval.Location = new Point(264, 37);
            lblInterval.Name = "lblInterval";
            lblInterval.Size = new Size(168, 15);
            lblInterval.TabIndex = 0;
            lblInterval.Text = "Intervalo entre tests (minutos):";
            // 
            // _chkEnabled
            // 
            _chkEnabled.AutoSize = true;
            _chkEnabled.Location = new Point(25, 37);
            _chkEnabled.Name = "_chkEnabled";
            _chkEnabled.Size = new Size(173, 19);
            _chkEnabled.TabIndex = 0;
            _chkEnabled.Text = "Activar monitoreo continuo";
            _chkEnabled.UseVisualStyleBackColor = true;
            // 
            // grpNotifications
            // 
            grpNotifications.Controls.Add(_numLatencyThreshold);
            grpNotifications.Controls.Add(_numPacketLossThreshold);
            grpNotifications.Controls.Add(_numSpeedThreshold);
            grpNotifications.Controls.Add(lblLatencyThreshold);
            grpNotifications.Controls.Add(lblPacketLossThreshold);
            grpNotifications.Controls.Add(lblSpeedThreshold);
            grpNotifications.Controls.Add(_chkNotifyLatency);
            grpNotifications.Controls.Add(_chkNotifyPacketLoss);
            grpNotifications.Controls.Add(_chkNotifySpeed);
            grpNotifications.ForeColor = Color.FromArgb(100, 180, 220);
            grpNotifications.Location = new Point(3, 275);
            grpNotifications.Name = "grpNotifications";
            grpNotifications.Size = new Size(643, 100);
            grpNotifications.TabIndex = 2;
            grpNotifications.TabStop = false;
            grpNotifications.Text = "Configuración General";
            // 
            // _numLatencyThreshold
            // 
            _numLatencyThreshold.BackColor = Color.FromArgb(28, 28, 38);
            _numLatencyThreshold.ForeColor = Color.White;
            _numLatencyThreshold.Location = new Point(433, 68);
            _numLatencyThreshold.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            _numLatencyThreshold.Name = "_numLatencyThreshold";
            _numLatencyThreshold.Size = new Size(120, 23);
            _numLatencyThreshold.TabIndex = 1;
            _numLatencyThreshold.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // _numPacketLossThreshold
            // 
            _numPacketLossThreshold.BackColor = Color.FromArgb(28, 28, 38);
            _numPacketLossThreshold.ForeColor = Color.White;
            _numPacketLossThreshold.Location = new Point(21, 68);
            _numPacketLossThreshold.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _numPacketLossThreshold.Name = "_numPacketLossThreshold";
            _numPacketLossThreshold.Size = new Size(120, 23);
            _numPacketLossThreshold.TabIndex = 1;
            _numPacketLossThreshold.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // _numSpeedThreshold
            // 
            _numSpeedThreshold.BackColor = Color.FromArgb(28, 28, 38);
            _numSpeedThreshold.ForeColor = Color.White;
            _numSpeedThreshold.Location = new Point(242, 68);
            _numSpeedThreshold.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            _numSpeedThreshold.Name = "_numSpeedThreshold";
            _numSpeedThreshold.Size = new Size(120, 23);
            _numSpeedThreshold.TabIndex = 1;
            _numSpeedThreshold.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // lblLatencyThreshold
            // 
            lblLatencyThreshold.AutoSize = true;
            lblLatencyThreshold.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLatencyThreshold.ForeColor = Color.FromArgb(140, 140, 160);
            lblLatencyThreshold.Location = new Point(438, 52);
            lblLatencyThreshold.Name = "lblLatencyThreshold";
            lblLatencyThreshold.Size = new Size(129, 15);
            lblLatencyThreshold.TabIndex = 0;
            lblLatencyThreshold.Text = "Umbral de cambio (%):";
            // 
            // lblPacketLossThreshold
            // 
            lblPacketLossThreshold.AutoSize = true;
            lblPacketLossThreshold.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPacketLossThreshold.ForeColor = Color.FromArgb(140, 140, 160);
            lblPacketLossThreshold.Location = new Point(17, 49);
            lblPacketLossThreshold.Name = "lblPacketLossThreshold";
            lblPacketLossThreshold.Size = new Size(129, 15);
            lblPacketLossThreshold.TabIndex = 0;
            lblPacketLossThreshold.Text = "Umbral de pérdida (%):";
            // 
            // lblSpeedThreshold
            // 
            lblSpeedThreshold.AutoSize = true;
            lblSpeedThreshold.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpeedThreshold.ForeColor = Color.FromArgb(140, 140, 160);
            lblSpeedThreshold.Location = new Point(221, 49);
            lblSpeedThreshold.Name = "lblSpeedThreshold";
            lblSpeedThreshold.Size = new Size(129, 15);
            lblSpeedThreshold.TabIndex = 0;
            lblSpeedThreshold.Text = "Umbral de cambio (%):";
            // 
            // _chkNotifyLatency
            // 
            _chkNotifyLatency.AutoSize = true;
            _chkNotifyLatency.Location = new Point(438, 21);
            _chkNotifyLatency.Name = "_chkNotifyLatency";
            _chkNotifyLatency.Size = new Size(163, 19);
            _chkNotifyLatency.TabIndex = 0;
            _chkNotifyLatency.Text = "Notificar picos de latencia";
            _chkNotifyLatency.UseVisualStyleBackColor = true;
            // 
            // _chkNotifyPacketLoss
            // 
            _chkNotifyPacketLoss.AutoSize = true;
            _chkNotifyPacketLoss.Location = new Point(221, 22);
            _chkNotifyPacketLoss.Name = "_chkNotifyPacketLoss";
            _chkNotifyPacketLoss.Size = new Size(182, 19);
            _chkNotifyPacketLoss.TabIndex = 0;
            _chkNotifyPacketLoss.Text = "Notificar pérdida de paquetes";
            _chkNotifyPacketLoss.UseVisualStyleBackColor = true;
            // 
            // _chkNotifySpeed
            // 
            _chkNotifySpeed.AutoSize = true;
            _chkNotifySpeed.Location = new Point(16, 22);
            _chkNotifySpeed.Name = "_chkNotifySpeed";
            _chkNotifySpeed.Size = new Size(190, 19);
            _chkNotifySpeed.TabIndex = 0;
            _chkNotifySpeed.Text = "Notificar cambios de velocidad";
            _chkNotifySpeed.UseVisualStyleBackColor = true;
            // 
            // MonitoringConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 24);
            ClientSize = new Size(660, 396);
            Controls.Add(grpNotifications);
            Controls.Add(grpGeneral);
            Controls.Add(statusPanel);
            Controls.Add(headerLabel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MonitoringConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración de Monitoreo - HFASpeedTest Pro";
            statusPanel.ResumeLayout(false);
            statusPanel.PerformLayout();
            grpGeneral.ResumeLayout(false);
            grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_numInterval).EndInit();
            grpNotifications.ResumeLayout(false);
            grpNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_numLatencyThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)_numPacketLossThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)_numSpeedThreshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Panel statusPanel;
        private GroupBox grpGeneral;
        private Label lblInterval;
        private GroupBox grpNotifications;
        private NumericUpDown _numSpeedThreshold;
        private Label lblSpeedThreshold;
        private CheckBox _chkNotifySpeed;
        private NumericUpDown _numLatencyThreshold;
        private Label lblLatencyThreshold;
        private Label lblPacketLossThreshold;
        private Button _btnCancel;
        private Button _btnSave;
        private CheckBox _chkEnabled;
        private NumericUpDown _numInterval;
        private CheckBox _chkNotifyLatency;
        private CheckBox _chkNotifyPacketLoss;
        private NumericUpDown _numPacketLossThreshold;
        private Label _lblNextTest;
        private Label _lblStatus;

    }
}