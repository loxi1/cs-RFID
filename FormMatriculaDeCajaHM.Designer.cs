using System.Drawing;

namespace RFIDPrendas
{
    partial class FormMatriculaDeCajaHM
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
            this.timerCronome_tro = new System.Windows.Forms.Timer(this.components);
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.m0Cronometro = new System.Windows.Forms.Label();
            this.SeConEnSegundos = new System.Windows.Forms.Label();
            this.tbContentCronometro = new System.Windows.Forms.TableLayoutPanel();
            this.panelCronometro = new System.Windows.Forms.Panel();
            this.ReportaIncidente = new System.Windows.Forms.Button();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.tbContentEstados = new System.Windows.Forms.TableLayoutPanel();
            this.tbContCronoEstados = new System.Windows.Forms.TableLayoutPanel();
            this.labelOp = new System.Windows.Forms.Label();
            this.textOp = new System.Windows.Forms.TextBox();
            this.labelHM = new System.Windows.Forms.Label();
            this.textHM = new System.Windows.Forms.TextBox();
            this.btnSaveMatricula = new System.Windows.Forms.Button();
            this.tbContentMatricula = new System.Windows.Forms.TableLayoutPanel();
            this.tbFormHM = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.tbContentNumPrendas = new System.Windows.Forms.TableLayoutPanel();
            this.tbContMatHM = new System.Windows.Forms.TableLayoutPanel();
            this.tbContentCronometro.SuspendLayout();
            this.panelCronometro.SuspendLayout();
            this.tbContentEstados.SuspendLayout();
            this.tbContCronoEstados.SuspendLayout();
            this.tbContentMatricula.SuspendLayout();
            this.tbFormHM.SuspendLayout();
            this.tbContentNumPrendas.SuspendLayout();
            this.tbContMatHM.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerCronome_tro
            // 
            this.timerCronome_tro.Interval = 1000;
            this.timerCronome_tro.Tick += new System.EventHandler(this.TimerCronome_tro_Tick);
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            this.accessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AccessBackgroundWorker_DoWork);
            this.accessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AccessBackgroundWorker_ProgressChanged);
            this.accessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AccessBackgroundWorker_RunWorkerCompleted);
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
            this.ReportaIncidente.Click += new System.EventHandler(this.ReportaIncidente_Click);
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
            // labelOp
            // 
            this.labelOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOp.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelOp.Location = new System.Drawing.Point(13, 10);
            this.labelOp.Name = "labelOp";
            this.labelOp.Size = new System.Drawing.Size(256, 131);
            this.labelOp.TabIndex = 0;
            this.labelOp.Text = "OP:";
            this.labelOp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textOp
            // 
            this.textOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOp.Font = new System.Drawing.Font("Arial", 10F);
            this.textOp.Location = new System.Drawing.Point(277, 15);
            this.textOp.Margin = new System.Windows.Forms.Padding(5);
            this.textOp.Name = "textOp";
            this.textOp.Size = new System.Drawing.Size(383, 23);
            this.textOp.TabIndex = 1;
            this.textOp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextOp_KeyDown);
            // 
            // labelHM
            // 
            this.labelHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelHM.Location = new System.Drawing.Point(13, 141);
            this.labelHM.Name = "labelHM";
            this.labelHM.Size = new System.Drawing.Size(256, 131);
            this.labelHM.TabIndex = 2;
            this.labelHM.Text = "HM:";
            this.labelHM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textHM
            // 
            this.textHM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textHM.Enabled = false;
            this.textHM.Font = new System.Drawing.Font("Arial", 10F);
            this.textHM.Location = new System.Drawing.Point(277, 146);
            this.textHM.Margin = new System.Windows.Forms.Padding(5);
            this.textHM.Name = "textHM";
            this.textHM.Size = new System.Drawing.Size(383, 23);
            this.textHM.TabIndex = 3;
            this.textHM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextHM_KeyDown);
            // 
            // btnSaveMatricula
            // 
            this.btnSaveMatricula.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tbContentMatricula.SetColumnSpan(this.btnSaveMatricula, 2);
            this.btnSaveMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveMatricula.Enabled = false;
            this.btnSaveMatricula.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnSaveMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMatricula.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnSaveMatricula.ForeColor = System.Drawing.Color.White;
            this.btnSaveMatricula.Location = new System.Drawing.Point(13, 275);
            this.btnSaveMatricula.Name = "btnSaveMatricula";
            this.btnSaveMatricula.Size = new System.Drawing.Size(649, 169);
            this.btnSaveMatricula.TabIndex = 4;
            this.btnSaveMatricula.Text = "Matricular";
            this.btnSaveMatricula.UseVisualStyleBackColor = false;
            this.btnSaveMatricula.Click += new System.EventHandler(this.BtnSaveMatricula_Click);
            // 
            // tbContentMatricula
            // 
            this.tbContentMatricula.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbContentMatricula.ColumnCount = 2;
            this.tbContentMatricula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbContentMatricula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tbContentMatricula.Controls.Add(this.labelOp, 0, 0);
            this.tbContentMatricula.Controls.Add(this.textOp, 1, 0);
            this.tbContentMatricula.Controls.Add(this.labelHM, 0, 1);
            this.tbContentMatricula.Controls.Add(this.textHM, 1, 1);
            this.tbContentMatricula.Controls.Add(this.btnSaveMatricula, 0, 2);
            this.tbContentMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContentMatricula.Location = new System.Drawing.Point(5, 5);
            this.tbContentMatricula.Margin = new System.Windows.Forms.Padding(5);
            this.tbContentMatricula.Name = "tbContentMatricula";
            this.tbContentMatricula.Padding = new System.Windows.Forms.Padding(10);
            this.tbContentMatricula.RowCount = 3;
            this.tbContentMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbContentMatricula.Size = new System.Drawing.Size(675, 457);
            this.tbContentMatricula.TabIndex = 1;
            // 
            // tbFormHM
            // 
            this.tbFormHM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFormHM.BackgroundImage = global::RFIDPrendas.Properties.Resources.salida_embalaje_2;
            this.tbFormHM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbFormHM.ColumnCount = 1;
            this.tbFormHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbFormHM.Controls.Add(this.tbContentMatricula, 0, 0);
            this.tbFormHM.Controls.Add(this.tbContCronoEstados, 0, 1);
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
            this.tbContMatHM.TabIndex = 1;
            // 
            // FormMatriculaDeCajaHM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 584);
            this.Controls.Add(this.tbContMatHM);
            this.KeyPreview = true;
            this.Name = "FormMatriculaDeCajaHM";
            this.Text = "FormMatriculaDeCajaHM";
            this.Load += new System.EventHandler(this.FormMatriculaDeCajaHM_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMatriculaDeCajaHM_KeyDown);
            this.Resize += new System.EventHandler(this.FormMatriculaDeCajaHM_Resize);
            this.tbContentCronometro.ResumeLayout(false);
            this.panelCronometro.ResumeLayout(false);
            this.tbContentEstados.ResumeLayout(false);
            this.tbContentEstados.PerformLayout();
            this.tbContCronoEstados.ResumeLayout(false);
            this.tbContentMatricula.ResumeLayout(false);
            this.tbContentMatricula.PerformLayout();
            this.tbFormHM.ResumeLayout(false);
            this.tbContentNumPrendas.ResumeLayout(false);
            this.tbContentNumPrendas.PerformLayout();
            this.tbContMatHM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerCronome_tro;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        private System.Windows.Forms.Label m0Cronometro;
        private System.Windows.Forms.Label SeConEnSegundos;
        private System.Windows.Forms.TableLayoutPanel tbContentCronometro;
        private System.Windows.Forms.Panel panelCronometro;
        private System.Windows.Forms.Button ReportaIncidente;
        private System.Windows.Forms.GroupBox autonomous_CB;
        private System.Windows.Forms.TableLayoutPanel tbContentEstados;
        private System.Windows.Forms.TableLayoutPanel tbContCronoEstados;
        private System.Windows.Forms.Label labelOp;
        private System.Windows.Forms.TextBox textOp;
        private System.Windows.Forms.Label labelHM;
        private System.Windows.Forms.TextBox textHM;
        private System.Windows.Forms.Button btnSaveMatricula;
        private System.Windows.Forms.TableLayoutPanel tbContentMatricula;
        private System.Windows.Forms.TableLayoutPanel tbFormHM;
        private System.Windows.Forms.TableLayoutPanel tbContMatHM;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.TableLayoutPanel tbContentNumPrendas;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label totalTagValueLabel;
    }
}