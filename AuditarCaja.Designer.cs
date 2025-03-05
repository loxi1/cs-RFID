namespace RFIDPrendas
{
    partial class AuditarCaja
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
            this.components = new System.ComponentModel.Container();
            this.tbContMatHM = new System.Windows.Forms.TableLayoutPanel();
            this.readButton = new System.Windows.Forms.Button();
            this.tbContentNumPrendas = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.tbFormHM = new System.Windows.Forms.TableLayoutPanel();
            this.tbContCronoEstados = new System.Windows.Forms.TableLayoutPanel();
            this.tbContentEstados = new System.Windows.Forms.TableLayoutPanel();
            this.ReportaIncidente = new System.Windows.Forms.Button();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.tbContentCronometro = new System.Windows.Forms.TableLayoutPanel();
            this.SeConEnSegundos = new System.Windows.Forms.Label();
            this.panelCronometro = new System.Windows.Forms.Panel();
            this.m0Cronometro = new System.Windows.Forms.Label();
            this.dGVCajasAuditadas = new System.Windows.Forms.DataGridView();
            this.nro_op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_hm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_prendas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timerCronome_tro = new System.Windows.Forms.Timer(this.components);
            this.tbContMatHM.SuspendLayout();
            this.tbContentNumPrendas.SuspendLayout();
            this.tbFormHM.SuspendLayout();
            this.tbContCronoEstados.SuspendLayout();
            this.tbContentEstados.SuspendLayout();
            this.tbContentCronometro.SuspendLayout();
            this.panelCronometro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCajasAuditadas)).BeginInit();
            this.SuspendLayout();
            // 
            // tbContMatHM
            // 
            this.tbContMatHM.ColumnCount = 2;
            this.tbContMatHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbContMatHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbContMatHM.Controls.Add(this.readButton, 0, 1);
            this.tbContMatHM.Controls.Add(this.tbContentNumPrendas, 0, 0);
            this.tbContMatHM.Controls.Add(this.tbFormHM, 1, 0);
            this.tbContMatHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContMatHM.Location = new System.Drawing.Point(0, 0);
            this.tbContMatHM.Name = "tbContMatHM";
            this.tbContMatHM.RowCount = 2;
            this.tbContMatHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tbContMatHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tbContMatHM.Size = new System.Drawing.Size(1370, 584);
            this.tbContMatHM.TabIndex = 2;
            // 
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.readButton.Enabled = false;
            this.readButton.FlatAppearance.BorderSize = 0;
            this.readButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(0, 321);
            this.readButton.Margin = new System.Windows.Forms.Padding(0);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(685, 263);
            this.readButton.TabIndex = 2;
            this.readButton.Tag = "Start Reading";
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // tbContentNumPrendas
            // 
            this.tbContentNumPrendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContentNumPrendas.BackColor = System.Drawing.Color.Transparent;
            this.tbContentNumPrendas.ColumnCount = 2;
            this.tbContentNumPrendas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbContentNumPrendas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbContentNumPrendas.Controls.Add(this.label13, 0, 0);
            this.tbContentNumPrendas.Controls.Add(this.totalTagValueLabel, 0, 0);
            this.tbContentNumPrendas.Location = new System.Drawing.Point(3, 3);
            this.tbContentNumPrendas.Name = "tbContentNumPrendas";
            this.tbContentNumPrendas.RowCount = 1;
            this.tbContentNumPrendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentNumPrendas.Size = new System.Drawing.Size(679, 315);
            this.tbContentNumPrendas.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(546, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 31);
            this.label13.TabIndex = 49;
            this.label13.Text = "Pds";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagValueLabel.ForeColor = System.Drawing.Color.Red;
            this.totalTagValueLabel.Location = new System.Drawing.Point(0, 0);
            this.totalTagValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(543, 315);
            this.totalTagValueLabel.TabIndex = 48;
            this.totalTagValueLabel.Text = "0";
            this.totalTagValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFormHM
            // 
            this.tbFormHM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFormHM.BackgroundImage = global::RFIDPrendas.Properties.Resources.salida_embalaje;
            this.tbFormHM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbFormHM.ColumnCount = 1;
            this.tbFormHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbFormHM.Controls.Add(this.tbContCronoEstados, 0, 1);
            this.tbFormHM.Controls.Add(this.dGVCajasAuditadas, 0, 0);
            this.tbFormHM.Location = new System.Drawing.Point(685, 0);
            this.tbFormHM.Margin = new System.Windows.Forms.Padding(0);
            this.tbFormHM.Name = "tbFormHM";
            this.tbFormHM.RowCount = 2;
            this.tbContMatHM.SetRowSpan(this.tbFormHM, 2);
            this.tbFormHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbFormHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbFormHM.Size = new System.Drawing.Size(685, 584);
            this.tbFormHM.TabIndex = 4;
            // 
            // tbContCronoEstados
            // 
            this.tbContCronoEstados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbContCronoEstados.BackColor = System.Drawing.Color.Transparent;
            this.tbContCronoEstados.ColumnCount = 3;
            this.tbContCronoEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tbContCronoEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tbContCronoEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbContCronoEstados.Controls.Add(this.tbContentEstados, 2, 0);
            this.tbContCronoEstados.Controls.Add(this.tbContentCronometro, 0, 0);
            this.tbContCronoEstados.Location = new System.Drawing.Point(0, 467);
            this.tbContCronoEstados.Margin = new System.Windows.Forms.Padding(0);
            this.tbContCronoEstados.Name = "tbContCronoEstados";
            this.tbContCronoEstados.RowCount = 1;
            this.tbContCronoEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContCronoEstados.Size = new System.Drawing.Size(606, 117);
            this.tbContCronoEstados.TabIndex = 0;
            // 
            // tbContentEstados
            // 
            this.tbContentEstados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContentEstados.BackColor = System.Drawing.Color.White;
            this.tbContentEstados.ColumnCount = 1;
            this.tbContentEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentEstados.Controls.Add(this.ReportaIncidente, 0, 0);
            this.tbContentEstados.Controls.Add(this.autonomous_CB, 0, 1);
            this.tbContentEstados.Location = new System.Drawing.Point(302, 0);
            this.tbContentEstados.Margin = new System.Windows.Forms.Padding(0);
            this.tbContentEstados.Name = "tbContentEstados";
            this.tbContentEstados.RowCount = 3;
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tbContentEstados.Size = new System.Drawing.Size(304, 117);
            this.tbContentEstados.TabIndex = 3;
            // 
            // ReportaIncidente
            // 
            this.ReportaIncidente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReportaIncidente.AutoSize = true;
            this.ReportaIncidente.BackColor = System.Drawing.Color.Red;
            this.ReportaIncidente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportaIncidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportaIncidente.ForeColor = System.Drawing.Color.White;
            this.ReportaIncidente.Location = new System.Drawing.Point(27, 2);
            this.ReportaIncidente.Margin = new System.Windows.Forms.Padding(0);
            this.ReportaIncidente.Name = "ReportaIncidente";
            this.ReportaIncidente.Size = new System.Drawing.Size(250, 30);
            this.ReportaIncidente.TabIndex = 50;
            this.ReportaIncidente.Text = "⚠️ INCIDENTE";
            this.ReportaIncidente.UseVisualStyleBackColor = false;
            this.ReportaIncidente.Visible = false;
            // 
            // autonomous_CB
            // 
            this.autonomous_CB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.autonomous_CB.BackColor = System.Drawing.Color.White;
            this.autonomous_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autonomous_CB.Location = new System.Drawing.Point(32, 35);
            this.autonomous_CB.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.autonomous_CB.Name = "autonomous_CB";
            this.autonomous_CB.Padding = new System.Windows.Forms.Padding(0);
            this.autonomous_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autonomous_CB.Size = new System.Drawing.Size(250, 76);
            this.autonomous_CB.TabIndex = 42;
            this.autonomous_CB.TabStop = false;
            this.autonomous_CB.Text = "Estado de las Antenas";
            // 
            // tbContentCronometro
            // 
            this.tbContentCronometro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbContentCronometro.BackColor = System.Drawing.Color.White;
            this.tbContentCronometro.ColumnCount = 1;
            this.tbContentCronometro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentCronometro.Controls.Add(this.SeConEnSegundos, 0, 0);
            this.tbContentCronometro.Controls.Add(this.panelCronometro, 0, 1);
            this.tbContentCronometro.Location = new System.Drawing.Point(0, 0);
            this.tbContentCronometro.Margin = new System.Windows.Forms.Padding(0);
            this.tbContentCronometro.Name = "tbContentCronometro";
            this.tbContentCronometro.RowCount = 3;
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tbContentCronometro.Size = new System.Drawing.Size(235, 117);
            this.tbContentCronometro.TabIndex = 2;
            // 
            // SeConEnSegundos
            // 
            this.SeConEnSegundos.BackColor = System.Drawing.Color.White;
            this.SeConEnSegundos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeConEnSegundos.Font = new System.Drawing.Font("Arial", 12F);
            this.SeConEnSegundos.ForeColor = System.Drawing.Color.Black;
            this.SeConEnSegundos.Location = new System.Drawing.Point(0, 0);
            this.SeConEnSegundos.Margin = new System.Windows.Forms.Padding(0);
            this.SeConEnSegundos.Name = "SeConEnSegundos";
            this.SeConEnSegundos.Size = new System.Drawing.Size(235, 35);
            this.SeConEnSegundos.TabIndex = 0;
            this.SeConEnSegundos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCronometro
            // 
            this.panelCronometro.BackColor = System.Drawing.Color.DarkRed;
            this.panelCronometro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCronometro.Controls.Add(this.m0Cronometro);
            this.panelCronometro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCronometro.Location = new System.Drawing.Point(0, 35);
            this.panelCronometro.Margin = new System.Windows.Forms.Padding(0);
            this.panelCronometro.Name = "panelCronometro";
            this.panelCronometro.Size = new System.Drawing.Size(235, 76);
            this.panelCronometro.TabIndex = 1;
            // 
            // m0Cronometro
            // 
            this.m0Cronometro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m0Cronometro.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.m0Cronometro.ForeColor = System.Drawing.Color.Transparent;
            this.m0Cronometro.Location = new System.Drawing.Point(0, 0);
            this.m0Cronometro.Name = "m0Cronometro";
            this.m0Cronometro.Size = new System.Drawing.Size(233, 74);
            this.m0Cronometro.TabIndex = 0;
            this.m0Cronometro.Text = "00:00:00";
            this.m0Cronometro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dGVCajasAuditadas
            // 
            this.dGVCajasAuditadas.AllowUserToAddRows = false;
            this.dGVCajasAuditadas.AllowUserToDeleteRows = false;
            this.dGVCajasAuditadas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dGVCajasAuditadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVCajasAuditadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dGVCajasAuditadas.BackgroundColor = System.Drawing.Color.White;
            this.dGVCajasAuditadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCajasAuditadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nro_op,
            this.nro_hm,
            this.cantidad_prendas});
            this.dGVCajasAuditadas.Location = new System.Drawing.Point(142, 3);
            this.dGVCajasAuditadas.Name = "dGVCajasAuditadas";
            this.dGVCajasAuditadas.Size = new System.Drawing.Size(400, 150);
            this.dGVCajasAuditadas.TabIndex = 1;
            // 
            // nro_op
            // 
            this.nro_op.HeaderText = "OP";
            this.nro_op.Name = "nro_op";
            // 
            // nro_hm
            // 
            this.nro_hm.HeaderText = "Hoja Marcación";
            this.nro_hm.Name = "nro_hm";
            // 
            // cantidad_prendas
            // 
            this.cantidad_prendas.HeaderText = "Cantidad";
            this.cantidad_prendas.Name = "cantidad_prendas";
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            this.accessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AccessBackgroundWorker_DoWork);
            this.accessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AccessBackgroundWorker_RunWorkerCompleted);
            // 
            // timerCronome_tro
            // 
            this.timerCronome_tro.Interval = 1000;
            this.timerCronome_tro.Tick += new System.EventHandler(this.TimerCronome_tro_Tick);
            // 
            // AuditarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 584);
            this.Controls.Add(this.tbContMatHM);
            this.Name = "AuditarCaja";
            this.Text = "AuditarCaja";
            this.Activated += new System.EventHandler(this.AuditarCaja_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuditarCaja_FormClosing);
            this.Load += new System.EventHandler(this.AuditarCaja_Load);
            this.Shown += new System.EventHandler(this.AuditarCaja_Shown);
            this.Resize += new System.EventHandler(this.AuditarCaja_Resize);
            this.tbContMatHM.ResumeLayout(false);
            this.tbContentNumPrendas.ResumeLayout(false);
            this.tbContentNumPrendas.PerformLayout();
            this.tbFormHM.ResumeLayout(false);
            this.tbContCronoEstados.ResumeLayout(false);
            this.tbContentEstados.ResumeLayout(false);
            this.tbContentEstados.PerformLayout();
            this.tbContentCronometro.ResumeLayout(false);
            this.panelCronometro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVCajasAuditadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbContMatHM;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.TableLayoutPanel tbContentNumPrendas;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label totalTagValueLabel;
        private System.Windows.Forms.TableLayoutPanel tbFormHM;
        private System.Windows.Forms.TableLayoutPanel tbContCronoEstados;
        private System.Windows.Forms.TableLayoutPanel tbContentEstados;
        private System.Windows.Forms.Button ReportaIncidente;
        private System.Windows.Forms.GroupBox autonomous_CB;
        private System.Windows.Forms.TableLayoutPanel tbContentCronometro;
        private System.Windows.Forms.Label SeConEnSegundos;
        private System.Windows.Forms.Panel panelCronometro;
        private System.Windows.Forms.Label m0Cronometro;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        private System.Windows.Forms.Timer timerCronome_tro;
        private System.Windows.Forms.DataGridView dGVCajasAuditadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_op;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_hm;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_prendas;
    }
}