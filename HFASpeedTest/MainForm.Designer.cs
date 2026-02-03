namespace HFASpeedTest
{
    partial class MainForm
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
            _headerPanel = new Panel();
            _subtitleLabel = new Label();
            _titleLabel = new Label();
            _btnTest = new Button();
            _lblStatus = new Label();
            _grpConexion = new GroupBox();
            _lblTipoConexion = new Label();
            _valTipoConexion = new Label();
            _lblIPLocal = new Label();
            _valIPLocal = new Label();
            _lblIPPublica = new Label();
            _valIPPublica = new Label();
            _lblTipoIP = new Label();
            _valTipoIP = new Label();
            _lblMAC = new Label();
            _valMAC = new Label();
            _grpVelocidad = new GroupBox();
            _panelDownBox = new Panel();
            _lblDownIcon = new Label();
            _lblDownLabel = new Label();
            _lblDownSpeed = new Label();
            _lblDownUnit = new Label();
            _panelUpBox = new Panel();
            _lblUpIcon = new Label();
            _lblUpLabel = new Label();
            _lblUpSpeed = new Label();
            _lblUpUnit = new Label();
            _grpSimetria = new GroupBox();
            _lblSimetriaVal = new Label();
            _lblSimetriaDesc = new Label();
            _barContainer = new Panel();
            _barDown = new Panel();
            _barUp = new Panel();
            _grpLatencia = new GroupBox();
            _lblLatMin = new Label();
            _valLatMin = new Label();
            _lblLatMax = new Label();
            _valLatMax = new Label();
            _lblLatAvg = new Label();
            _valLatAvg = new Label();
            _lblLatJitter = new Label();
            _valLatJitter = new Label();
            _lblLatLoss = new Label();
            _valLatLoss = new Label();
            _headerPanel.SuspendLayout();
            _grpConexion.SuspendLayout();
            _grpVelocidad.SuspendLayout();
            _panelDownBox.SuspendLayout();
            _panelUpBox.SuspendLayout();
            _grpSimetria.SuspendLayout();
            _barContainer.SuspendLayout();
            _grpLatencia.SuspendLayout();
            SuspendLayout();
            // 
            // _headerPanel
            // 
            _headerPanel.BackColor = Color.FromArgb(24, 24, 32);
            _headerPanel.Controls.Add(_subtitleLabel);
            _headerPanel.Controls.Add(_titleLabel);
            _headerPanel.Dock = DockStyle.Top;
            _headerPanel.Location = new Point(0, 0);
            _headerPanel.Name = "_headerPanel";
            _headerPanel.Size = new Size(1210, 90);
            _headerPanel.TabIndex = 0;
            // 
            // _subtitleLabel
            // 
            _subtitleLabel.AutoSize = true;
            _subtitleLabel.Font = new Font("Segoe UI", 10F);
            _subtitleLabel.ForeColor = Color.FromArgb(140, 140, 160);
            _subtitleLabel.Location = new Point(30, 48);
            _subtitleLabel.Name = "_subtitleLabel";
            _subtitleLabel.Size = new Size(272, 19);
            _subtitleLabel.TabIndex = 1;
            _subtitleLabel.Text = "Analiza tu conexión a internet en segundos";
            // 
            // _titleLabel
            // 
            _titleLabel.AutoSize = true;
            _titleLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            _titleLabel.ForeColor = Color.FromArgb(80, 200, 255);
            _titleLabel.Location = new Point(28, 12);
            _titleLabel.Name = "_titleLabel";
            _titleLabel.Size = new Size(323, 41);
            _titleLabel.TabIndex = 0;
            _titleLabel.Text = "⚡ HFASpeedTest Pro";
            // 
            // _btnTest
            // 
            _btnTest.BackColor = Color.FromArgb(40, 160, 220);
            _btnTest.Cursor = Cursors.Hand;
            _btnTest.FlatAppearance.BorderColor = Color.FromArgb(40, 160, 220);
            _btnTest.FlatAppearance.BorderSize = 0;
            _btnTest.FlatStyle = FlatStyle.Flat;
            _btnTest.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            _btnTest.ForeColor = Color.White;
            _btnTest.Location = new Point(30, 100);
            _btnTest.Name = "_btnTest";
            _btnTest.Size = new Size(1150, 46);
            _btnTest.TabIndex = 1;
            _btnTest.Text = "Iniciar Test";
            _btnTest.UseVisualStyleBackColor = false;
            _btnTest.Click += BtnTest_Click;
            _btnTest.MouseEnter += BtnTest_MouseEnter;
            _btnTest.MouseLeave += BtnTest_MouseLeave;
            // 
            // _lblStatus
            // 
            _lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            _lblStatus.ForeColor = Color.FromArgb(140, 140, 160);
            _lblStatus.Location = new Point(30, 154);
            _lblStatus.Name = "_lblStatus";
            _lblStatus.Size = new Size(1150, 24);
            _lblStatus.TabIndex = 2;
            _lblStatus.Text = "Presiona \"Iniciar Test\" para comenzar...";
            _lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _grpConexion
            // 
            _grpConexion.BackColor = Color.FromArgb(22, 22, 30);
            _grpConexion.Controls.Add(_lblTipoConexion);
            _grpConexion.Controls.Add(_valTipoConexion);
            _grpConexion.Controls.Add(_lblIPLocal);
            _grpConexion.Controls.Add(_valIPLocal);
            _grpConexion.Controls.Add(_lblIPPublica);
            _grpConexion.Controls.Add(_valIPPublica);
            _grpConexion.Controls.Add(_lblTipoIP);
            _grpConexion.Controls.Add(_valTipoIP);
            _grpConexion.Controls.Add(_lblMAC);
            _grpConexion.Controls.Add(_valMAC);
            _grpConexion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _grpConexion.ForeColor = Color.FromArgb(100, 180, 220);
            _grpConexion.Location = new Point(30, 190);
            _grpConexion.Name = "_grpConexion";
            _grpConexion.Size = new Size(570, 170);
            _grpConexion.TabIndex = 3;
            _grpConexion.TabStop = false;
            _grpConexion.Text = "Información de Conexión";
            // 
            // _lblTipoConexion
            // 
            _lblTipoConexion.AutoSize = true;
            _lblTipoConexion.Font = new Font("Segoe UI", 9F);
            _lblTipoConexion.ForeColor = Color.FromArgb(140, 140, 160);
            _lblTipoConexion.Location = new Point(15, 22);
            _lblTipoConexion.Name = "_lblTipoConexion";
            _lblTipoConexion.Size = new Size(100, 15);
            _lblTipoConexion.TabIndex = 0;
            _lblTipoConexion.Text = "Tipo de Conexión";
            // 
            // _valTipoConexion
            // 
            _valTipoConexion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valTipoConexion.ForeColor = Color.FromArgb(220, 220, 230);
            _valTipoConexion.Location = new Point(170, 22);
            _valTipoConexion.Name = "_valTipoConexion";
            _valTipoConexion.Size = new Size(380, 22);
            _valTipoConexion.TabIndex = 1;
            _valTipoConexion.Text = "—";
            // 
            // _lblIPLocal
            // 
            _lblIPLocal.AutoSize = true;
            _lblIPLocal.Font = new Font("Segoe UI", 9F);
            _lblIPLocal.ForeColor = Color.FromArgb(140, 140, 160);
            _lblIPLocal.Location = new Point(15, 52);
            _lblIPLocal.Name = "_lblIPLocal";
            _lblIPLocal.Size = new Size(48, 15);
            _lblIPLocal.TabIndex = 2;
            _lblIPLocal.Text = "IP Local";
            // 
            // _valIPLocal
            // 
            _valIPLocal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valIPLocal.ForeColor = Color.FromArgb(220, 220, 230);
            _valIPLocal.Location = new Point(170, 52);
            _valIPLocal.Name = "_valIPLocal";
            _valIPLocal.Size = new Size(380, 22);
            _valIPLocal.TabIndex = 3;
            _valIPLocal.Text = "—";
            // 
            // _lblIPPublica
            // 
            _lblIPPublica.AutoSize = true;
            _lblIPPublica.Font = new Font("Segoe UI", 9F);
            _lblIPPublica.ForeColor = Color.FromArgb(140, 140, 160);
            _lblIPPublica.Location = new Point(15, 82);
            _lblIPPublica.Name = "_lblIPPublica";
            _lblIPPublica.Size = new Size(59, 15);
            _lblIPPublica.TabIndex = 4;
            _lblIPPublica.Text = "IP Pública";
            // 
            // _valIPPublica
            // 
            _valIPPublica.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valIPPublica.ForeColor = Color.FromArgb(220, 220, 230);
            _valIPPublica.Location = new Point(170, 82);
            _valIPPublica.Name = "_valIPPublica";
            _valIPPublica.Size = new Size(380, 22);
            _valIPPublica.TabIndex = 5;
            _valIPPublica.Text = "—";
            // 
            // _lblTipoIP
            // 
            _lblTipoIP.AutoSize = true;
            _lblTipoIP.Font = new Font("Segoe UI", 9F);
            _lblTipoIP.ForeColor = Color.FromArgb(140, 140, 160);
            _lblTipoIP.Location = new Point(15, 112);
            _lblTipoIP.Name = "_lblTipoIP";
            _lblTipoIP.Size = new Size(59, 15);
            _lblTipoIP.TabIndex = 6;
            _lblTipoIP.Text = "Tipo de IP";
            // 
            // _valTipoIP
            // 
            _valTipoIP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valTipoIP.ForeColor = Color.FromArgb(140, 140, 160);
            _valTipoIP.Location = new Point(170, 112);
            _valTipoIP.Name = "_valTipoIP";
            _valTipoIP.Size = new Size(380, 22);
            _valTipoIP.TabIndex = 7;
            _valTipoIP.Text = "—";
            // 
            // _lblMAC
            // 
            _lblMAC.AutoSize = true;
            _lblMAC.Font = new Font("Segoe UI", 9F);
            _lblMAC.ForeColor = Color.FromArgb(140, 140, 160);
            _lblMAC.Location = new Point(15, 142);
            _lblMAC.Name = "_lblMAC";
            _lblMAC.Size = new Size(87, 15);
            _lblMAC.TabIndex = 8;
            _lblMAC.Text = "Dirección MAC";
            // 
            // _valMAC
            // 
            _valMAC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valMAC.ForeColor = Color.FromArgb(220, 220, 230);
            _valMAC.Location = new Point(170, 142);
            _valMAC.Name = "_valMAC";
            _valMAC.Size = new Size(380, 22);
            _valMAC.TabIndex = 9;
            _valMAC.Text = "—";
            // 
            // _grpVelocidad
            // 
            _grpVelocidad.BackColor = Color.FromArgb(22, 22, 30);
            _grpVelocidad.Controls.Add(_panelDownBox);
            _grpVelocidad.Controls.Add(_panelUpBox);
            _grpVelocidad.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _grpVelocidad.ForeColor = Color.FromArgb(100, 180, 220);
            _grpVelocidad.Location = new Point(30, 375);
            _grpVelocidad.Name = "_grpVelocidad";
            _grpVelocidad.Size = new Size(570, 200);
            _grpVelocidad.TabIndex = 4;
            _grpVelocidad.TabStop = false;
            _grpVelocidad.Text = "Velocidad";
            // 
            // _panelDownBox
            // 
            _panelDownBox.BackColor = Color.FromArgb(28, 28, 38);
            _panelDownBox.BorderStyle = BorderStyle.FixedSingle;
            _panelDownBox.Controls.Add(_lblDownIcon);
            _panelDownBox.Controls.Add(_lblDownLabel);
            _panelDownBox.Controls.Add(_lblDownSpeed);
            _panelDownBox.Controls.Add(_lblDownUnit);
            _panelDownBox.Location = new Point(15, 30);
            _panelDownBox.Name = "_panelDownBox";
            _panelDownBox.Size = new Size(260, 155);
            _panelDownBox.TabIndex = 0;
            // 
            // _lblDownIcon
            // 
            _lblDownIcon.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            _lblDownIcon.ForeColor = Color.FromArgb(40, 200, 120);
            _lblDownIcon.Location = new Point(10, 10);
            _lblDownIcon.Name = "_lblDownIcon";
            _lblDownIcon.Size = new Size(40, 40);
            _lblDownIcon.TabIndex = 0;
            _lblDownIcon.Text = "▼";
            _lblDownIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _lblDownLabel
            // 
            _lblDownLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblDownLabel.ForeColor = Color.FromArgb(40, 200, 120);
            _lblDownLabel.Location = new Point(55, 20);
            _lblDownLabel.Name = "_lblDownLabel";
            _lblDownLabel.Size = new Size(100, 20);
            _lblDownLabel.TabIndex = 1;
            _lblDownLabel.Text = "DESCARGA";
            // 
            // _lblDownSpeed
            // 
            _lblDownSpeed.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            _lblDownSpeed.ForeColor = Color.White;
            _lblDownSpeed.Location = new Point(10, 50);
            _lblDownSpeed.Name = "_lblDownSpeed";
            _lblDownSpeed.Size = new Size(235, 65);
            _lblDownSpeed.TabIndex = 2;
            _lblDownSpeed.Text = "—";
            _lblDownSpeed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblDownUnit
            // 
            _lblDownUnit.Font = new Font("Segoe UI", 12F);
            _lblDownUnit.ForeColor = Color.FromArgb(100, 100, 120);
            _lblDownUnit.Location = new Point(10, 120);
            _lblDownUnit.Name = "_lblDownUnit";
            _lblDownUnit.Size = new Size(80, 22);
            _lblDownUnit.TabIndex = 3;
            _lblDownUnit.Text = "Mbps";
            // 
            // _panelUpBox
            // 
            _panelUpBox.BackColor = Color.FromArgb(28, 28, 38);
            _panelUpBox.BorderStyle = BorderStyle.FixedSingle;
            _panelUpBox.Controls.Add(_lblUpIcon);
            _panelUpBox.Controls.Add(_lblUpLabel);
            _panelUpBox.Controls.Add(_lblUpSpeed);
            _panelUpBox.Controls.Add(_lblUpUnit);
            _panelUpBox.Location = new Point(290, 30);
            _panelUpBox.Name = "_panelUpBox";
            _panelUpBox.Size = new Size(260, 155);
            _panelUpBox.TabIndex = 1;
            // 
            // _lblUpIcon
            // 
            _lblUpIcon.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            _lblUpIcon.ForeColor = Color.FromArgb(80, 140, 255);
            _lblUpIcon.Location = new Point(10, 10);
            _lblUpIcon.Name = "_lblUpIcon";
            _lblUpIcon.Size = new Size(40, 40);
            _lblUpIcon.TabIndex = 0;
            _lblUpIcon.Text = "▲";
            _lblUpIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _lblUpLabel
            // 
            _lblUpLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblUpLabel.ForeColor = Color.FromArgb(80, 140, 255);
            _lblUpLabel.Location = new Point(55, 20);
            _lblUpLabel.Name = "_lblUpLabel";
            _lblUpLabel.Size = new Size(100, 20);
            _lblUpLabel.TabIndex = 1;
            _lblUpLabel.Text = "SUBIDA";
            // 
            // _lblUpSpeed
            // 
            _lblUpSpeed.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            _lblUpSpeed.ForeColor = Color.White;
            _lblUpSpeed.Location = new Point(10, 50);
            _lblUpSpeed.Name = "_lblUpSpeed";
            _lblUpSpeed.Size = new Size(235, 65);
            _lblUpSpeed.TabIndex = 2;
            _lblUpSpeed.Text = "—";
            _lblUpSpeed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblUpUnit
            // 
            _lblUpUnit.Font = new Font("Segoe UI", 12F);
            _lblUpUnit.ForeColor = Color.FromArgb(100, 100, 120);
            _lblUpUnit.Location = new Point(10, 120);
            _lblUpUnit.Name = "_lblUpUnit";
            _lblUpUnit.Size = new Size(80, 22);
            _lblUpUnit.TabIndex = 3;
            _lblUpUnit.Text = "Mbps";
            // 
            // _grpSimetria
            // 
            _grpSimetria.BackColor = Color.FromArgb(22, 22, 30);
            _grpSimetria.Controls.Add(_lblSimetriaVal);
            _grpSimetria.Controls.Add(_lblSimetriaDesc);
            _grpSimetria.Controls.Add(_barContainer);
            _grpSimetria.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _grpSimetria.ForeColor = Color.FromArgb(100, 180, 220);
            _grpSimetria.Location = new Point(620, 190);
            _grpSimetria.Name = "_grpSimetria";
            _grpSimetria.Size = new Size(560, 170);
            _grpSimetria.TabIndex = 5;
            _grpSimetria.TabStop = false;
            _grpSimetria.Text = "Simetría de Conexión";
            // 
            // _lblSimetriaVal
            // 
            _lblSimetriaVal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            _lblSimetriaVal.ForeColor = Color.FromArgb(80, 200, 255);
            _lblSimetriaVal.Location = new Point(15, 30);
            _lblSimetriaVal.Name = "_lblSimetriaVal";
            _lblSimetriaVal.Size = new Size(100, 40);
            _lblSimetriaVal.TabIndex = 0;
            _lblSimetriaVal.Text = "—";
            _lblSimetriaVal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblSimetriaDesc
            // 
            _lblSimetriaDesc.Font = new Font("Segoe UI", 10F);
            _lblSimetriaDesc.ForeColor = Color.FromArgb(140, 140, 160);
            _lblSimetriaDesc.Location = new Point(120, 38);
            _lblSimetriaDesc.Name = "_lblSimetriaDesc";
            _lblSimetriaDesc.Size = new Size(425, 24);
            _lblSimetriaDesc.TabIndex = 1;
            _lblSimetriaDesc.Text = "Pendiente...";
            // 
            // _barContainer
            // 
            _barContainer.BackColor = Color.FromArgb(30, 30, 40);
            _barContainer.Controls.Add(_barDown);
            _barContainer.Controls.Add(_barUp);
            _barContainer.Location = new Point(15, 80);
            _barContainer.Name = "_barContainer";
            _barContainer.Size = new Size(530, 30);
            _barContainer.TabIndex = 2;
            // 
            // _barDown
            // 
            _barDown.BackColor = Color.FromArgb(40, 200, 120);
            _barDown.Location = new Point(0, 0);
            _barDown.Name = "_barDown";
            _barDown.Size = new Size(0, 14);
            _barDown.TabIndex = 0;
            // 
            // _barUp
            // 
            _barUp.BackColor = Color.FromArgb(80, 140, 255);
            _barUp.Location = new Point(0, 14);
            _barUp.Name = "_barUp";
            _barUp.Size = new Size(0, 16);
            _barUp.TabIndex = 1;
            // 
            // _grpLatencia
            // 
            _grpLatencia.BackColor = Color.FromArgb(22, 22, 30);
            _grpLatencia.Controls.Add(_lblLatMin);
            _grpLatencia.Controls.Add(_valLatMin);
            _grpLatencia.Controls.Add(_lblLatMax);
            _grpLatencia.Controls.Add(_valLatMax);
            _grpLatencia.Controls.Add(_lblLatAvg);
            _grpLatencia.Controls.Add(_valLatAvg);
            _grpLatencia.Controls.Add(_lblLatJitter);
            _grpLatencia.Controls.Add(_valLatJitter);
            _grpLatencia.Controls.Add(_lblLatLoss);
            _grpLatencia.Controls.Add(_valLatLoss);
            _grpLatencia.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _grpLatencia.ForeColor = Color.FromArgb(100, 180, 220);
            _grpLatencia.Location = new Point(620, 375);
            _grpLatencia.Name = "_grpLatencia";
            _grpLatencia.Size = new Size(560, 200);
            _grpLatencia.TabIndex = 6;
            _grpLatencia.TabStop = false;
            _grpLatencia.Text = "Latencia (Ping a 8.8.8.8)";
            _grpLatencia.Enter += _grpLatencia_Enter;
            // 
            // _lblLatMin
            // 
            _lblLatMin.AutoSize = true;
            _lblLatMin.Font = new Font("Segoe UI", 9F);
            _lblLatMin.ForeColor = Color.FromArgb(140, 140, 160);
            _lblLatMin.Location = new Point(20, 35);
            _lblLatMin.Name = "_lblLatMin";
            _lblLatMin.Size = new Size(95, 15);
            _lblLatMin.TabIndex = 0;
            _lblLatMin.Text = "Latencia Mínima";
            // 
            // _valLatMin
            // 
            _valLatMin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valLatMin.ForeColor = Color.FromArgb(220, 220, 230);
            _valLatMin.Location = new Point(175, 35);
            _valLatMin.Name = "_valLatMin";
            _valLatMin.Size = new Size(370, 22);
            _valLatMin.TabIndex = 1;
            _valLatMin.Text = "—";
            // 
            // _lblLatMax
            // 
            _lblLatMax.AutoSize = true;
            _lblLatMax.Font = new Font("Segoe UI", 9F);
            _lblLatMax.ForeColor = Color.FromArgb(140, 140, 160);
            _lblLatMax.Location = new Point(20, 65);
            _lblLatMax.Name = "_lblLatMax";
            _lblLatMax.Size = new Size(97, 15);
            _lblLatMax.TabIndex = 2;
            _lblLatMax.Text = "Latencia Máxima";
            // 
            // _valLatMax
            // 
            _valLatMax.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valLatMax.ForeColor = Color.FromArgb(220, 220, 230);
            _valLatMax.Location = new Point(175, 65);
            _valLatMax.Name = "_valLatMax";
            _valLatMax.Size = new Size(370, 22);
            _valLatMax.TabIndex = 3;
            _valLatMax.Text = "—";
            // 
            // _lblLatAvg
            // 
            _lblLatAvg.AutoSize = true;
            _lblLatAvg.Font = new Font("Segoe UI", 9F);
            _lblLatAvg.ForeColor = Color.FromArgb(140, 140, 160);
            _lblLatAvg.Location = new Point(20, 95);
            _lblLatAvg.Name = "_lblLatAvg";
            _lblLatAvg.Size = new Size(106, 15);
            _lblLatAvg.TabIndex = 4;
            _lblLatAvg.Text = "Latencia Promedio";
            // 
            // _valLatAvg
            // 
            _valLatAvg.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valLatAvg.ForeColor = Color.FromArgb(140, 140, 160);
            _valLatAvg.Location = new Point(175, 95);
            _valLatAvg.Name = "_valLatAvg";
            _valLatAvg.Size = new Size(370, 22);
            _valLatAvg.TabIndex = 5;
            _valLatAvg.Text = "—";
            // 
            // _lblLatJitter
            // 
            _lblLatJitter.AutoSize = true;
            _lblLatJitter.Font = new Font("Segoe UI", 9F);
            _lblLatJitter.ForeColor = Color.FromArgb(140, 140, 160);
            _lblLatJitter.Location = new Point(20, 125);
            _lblLatJitter.Name = "_lblLatJitter";
            _lblLatJitter.Size = new Size(32, 15);
            _lblLatJitter.TabIndex = 6;
            _lblLatJitter.Text = "Jitter";
            // 
            // _valLatJitter
            // 
            _valLatJitter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valLatJitter.ForeColor = Color.FromArgb(220, 220, 230);
            _valLatJitter.Location = new Point(175, 125);
            _valLatJitter.Name = "_valLatJitter";
            _valLatJitter.Size = new Size(370, 22);
            _valLatJitter.TabIndex = 7;
            _valLatJitter.Text = "—";
            // 
            // _lblLatLoss
            // 
            _lblLatLoss.AutoSize = true;
            _lblLatLoss.Font = new Font("Segoe UI", 9F);
            _lblLatLoss.ForeColor = Color.FromArgb(140, 140, 160);
            _lblLatLoss.Location = new Point(20, 155);
            _lblLatLoss.Name = "_lblLatLoss";
            _lblLatLoss.Size = new Size(114, 15);
            _lblLatLoss.TabIndex = 8;
            _lblLatLoss.Text = "Pérdida de Paquetes";
            // 
            // _valLatLoss
            // 
            _valLatLoss.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _valLatLoss.ForeColor = Color.FromArgb(140, 140, 160);
            _valLatLoss.Location = new Point(175, 155);
            _valLatLoss.Name = "_valLatLoss";
            _valLatLoss.Size = new Size(370, 22);
            _valLatLoss.TabIndex = 9;
            _valLatLoss.Text = "—";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 24);
            ClientSize = new Size(1210, 600);
            Controls.Add(_headerPanel);
            Controls.Add(_btnTest);
            Controls.Add(_lblStatus);
            Controls.Add(_grpConexion);
            Controls.Add(_grpVelocidad);
            Controls.Add(_grpSimetria);
            Controls.Add(_grpLatencia);
            Font = new Font("Segoe UI", 9.5F);
            ForeColor = Color.White;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HFASpeedTest Pro";
            _headerPanel.ResumeLayout(false);
            _headerPanel.PerformLayout();
            _grpConexion.ResumeLayout(false);
            _grpConexion.PerformLayout();
            _grpVelocidad.ResumeLayout(false);
            _panelDownBox.ResumeLayout(false);
            _panelUpBox.ResumeLayout(false);
            _grpSimetria.ResumeLayout(false);
            _barContainer.ResumeLayout(false);
            _grpLatencia.ResumeLayout(false);
            _grpLatencia.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // ── Declaración de controles ──
        private Panel _headerPanel;
        private Label _titleLabel;
        private Label _subtitleLabel;

        private Button _btnTest;
        private Label _lblStatus;

        // Conexión
        private GroupBox _grpConexion;
        private Label _lblTipoConexion, _valTipoConexion;
        private Label _lblIPLocal, _valIPLocal;
        private Label _lblIPPublica, _valIPPublica;
        private Label _lblTipoIP, _valTipoIP;
        private Label _lblMAC, _valMAC;

        // Velocidad
        private GroupBox _grpVelocidad;
        private Panel _panelDownBox;
        private Label _lblDownIcon, _lblDownLabel, _lblDownSpeed, _lblDownUnit;
        private Panel _panelUpBox;
        private Label _lblUpIcon, _lblUpLabel, _lblUpSpeed, _lblUpUnit;

        // Simetría
        private GroupBox _grpSimetria;
        private Label _lblSimetriaVal;
        private Label _lblSimetriaDesc;
        private Panel _barContainer;
        private Panel _barDown, _barUp;

        // Latencia
        private GroupBox _grpLatencia;
        private Label _lblLatMin, _valLatMin;
        private Label _lblLatMax, _valLatMax;
        private Label _lblLatAvg, _valLatAvg;
        private Label _lblLatJitter, _valLatJitter;
        private Label _lblLatLoss, _valLatLoss;
    }
}