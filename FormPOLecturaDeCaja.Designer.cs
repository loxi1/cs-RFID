using System.Windows.Forms;
namespace RFIDPrendas
{
    partial class FormPOLecturaDeCaja
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
            this.gpiLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gpiStateGB = new System.Windows.Forms.GroupBox();
            this.gpiNumberLabel = new System.Windows.Forms.Label();
            this.transmitPowerGB = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timerCronome_tro = new System.Windows.Forms.Timer(this.components);
            this.readButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.ReportaIncidente = new System.Windows.Forms.Button();
            this.textPO = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.SeConEnSegundos = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m0Cronometro = new System.Windows.Forms.Label();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.gpiStateGB.SuspendLayout();
            this.transmitPowerGB.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpiLabel
            // 
            this.gpiLabel.AutoSize = true;
            this.gpiLabel.Location = new System.Drawing.Point(6, 27);
            this.gpiLabel.Name = "gpiLabel";
            this.gpiLabel.Size = new System.Drawing.Size(68, 13);
            this.gpiLabel.TabIndex = 50;
            this.gpiLabel.Text = "Red For Low";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.GreenYellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(80, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(114, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.GreenYellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(150, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(185, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(321, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.GreenYellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(288, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "  ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(254, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "  ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.GreenYellow;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(220, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "  ";
            // 
            // gpiStateGB
            // 
            this.gpiStateGB.Controls.Add(this.gpiNumberLabel);
            this.gpiStateGB.Controls.Add(this.label6);
            this.gpiStateGB.Controls.Add(this.label7);
            this.gpiStateGB.Controls.Add(this.label8);
            this.gpiStateGB.Controls.Add(this.label9);
            this.gpiStateGB.Controls.Add(this.label5);
            this.gpiStateGB.Controls.Add(this.label4);
            this.gpiStateGB.Controls.Add(this.label3);
            this.gpiStateGB.Controls.Add(this.label2);
            this.gpiStateGB.Controls.Add(this.gpiLabel);
            this.gpiStateGB.Location = new System.Drawing.Point(12, 331);
            this.gpiStateGB.Name = "gpiStateGB";
            this.gpiStateGB.Size = new System.Drawing.Size(347, 54);
            this.gpiStateGB.TabIndex = 0;
            this.gpiStateGB.TabStop = false;
            this.gpiStateGB.Text = "GPI State";
            // 
            // gpiNumberLabel
            // 
            this.gpiNumberLabel.AutoSize = true;
            this.gpiNumberLabel.Location = new System.Drawing.Point(77, 38);
            this.gpiNumberLabel.Name = "gpiNumberLabel";
            this.gpiNumberLabel.Size = new System.Drawing.Size(121, 13);
            this.gpiNumberLabel.TabIndex = 0;
            this.gpiNumberLabel.Text = " 1          2          3         4";
            // 
            // transmitPowerGB
            // 
            this.transmitPowerGB.Controls.Add(this.label12);
            this.transmitPowerGB.Controls.Add(this.label10);
            this.transmitPowerGB.Controls.Add(this.label11);
            this.transmitPowerGB.Controls.Add(this.hScrollBar1);
            this.transmitPowerGB.Location = new System.Drawing.Point(11, 331);
            this.transmitPowerGB.Name = "transmitPowerGB";
            this.transmitPowerGB.Size = new System.Drawing.Size(347, 53);
            this.transmitPowerGB.TabIndex = 0;
            this.transmitPowerGB.TabStop = false;
            this.transmitPowerGB.Text = "Transmit Power (dbm)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "2920";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "1620";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(114, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "1620";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(13, 16);
            this.hScrollBar1.Maximum = 2920;
            this.hScrollBar1.Minimum = 1620;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(314, 19);
            this.hScrollBar1.TabIndex = 3;
            this.hScrollBar1.Value = 1620;
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            this.accessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.accessBackgroundWorker_DoWork);
            this.accessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.accessBackgroundWorker_ProgressChanged);
            this.accessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.accessBackgroundWorker_RunWorkerCompleted);
            // 
            // timerCronome_tro
            // 
            this.timerCronome_tro.Interval = 1000;
            this.timerCronome_tro.Tick += new System.EventHandler(this.timerCronome_tro_Tick);
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
            this.readButton.Location = new System.Drawing.Point(0, 312);
            this.readButton.Margin = new System.Windows.Forms.Padding(0);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(641, 248);
            this.readButton.TabIndex = 1;
            this.readButton.Tag = "Start Reading";
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.18705F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.81295F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.readButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.71429F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1390, 560);
            this.tableLayoutPanel1.TabIndex = 27;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(641, 312);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.06461F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.9354F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.autonomous_CB, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(641, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.47653F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.52347F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(749, 560);
            this.tableLayoutPanel2.TabIndex = 40;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.69732F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.30268F));
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ReportaIncidente, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textPO, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(479, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(270, 473);
            this.tableLayoutPanel3.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(3, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 31);
            this.label13.TabIndex = 48;
            this.label13.Text = "Pds";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReportaIncidente
            // 
            this.ReportaIncidente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportaIncidente.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ReportaIncidente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportaIncidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportaIncidente.ForeColor = System.Drawing.Color.White;
            this.ReportaIncidente.Location = new System.Drawing.Point(3, 443);
            this.ReportaIncidente.Name = "ReportaIncidente";
            this.ReportaIncidente.Size = new System.Drawing.Size(98, 27);
            this.ReportaIncidente.TabIndex = 49;
            this.ReportaIncidente.Text = "INCIDENTE";
            this.ReportaIncidente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ReportaIncidente.UseVisualStyleBackColor = false;
            this.ReportaIncidente.Visible = false;
            this.ReportaIncidente.Click += new System.EventHandler(this.ReportaIncidente_Click);
            // 
            // textPO
            // 
            this.textPO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPO.Location = new System.Drawing.Point(107, 443);
            this.textPO.Name = "textPO";
            this.textPO.Size = new System.Drawing.Size(160, 20);
            this.textPO.TabIndex = 50;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.totalTagValueLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.SeConEnSegundos, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.14561F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.85439F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(473, 467);
            this.tableLayoutPanel4.TabIndex = 50;
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalTagValueLabel.AutoSize = true;
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagValueLabel.ForeColor = System.Drawing.Color.Red;
            this.totalTagValueLabel.Location = new System.Drawing.Point(0, 0);
            this.totalTagValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(473, 448);
            this.totalTagValueLabel.TabIndex = 47;
            this.totalTagValueLabel.Text = "0";
            this.totalTagValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SeConEnSegundos
            // 
            this.SeConEnSegundos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SeConEnSegundos.AutoSize = true;
            this.SeConEnSegundos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeConEnSegundos.Location = new System.Drawing.Point(287, 450);
            this.SeConEnSegundos.Name = "SeConEnSegundos";
            this.SeConEnSegundos.Size = new System.Drawing.Size(183, 17);
            this.SeConEnSegundos.TabIndex = 49;
            this.SeConEnSegundos.Text = "¡Se contó en tan solo 5 seg!";
            this.SeConEnSegundos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.m0Cronometro);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(624, 495);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(125, 65);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiempo";
            // 
            // m0Cronometro
            // 
            this.m0Cronometro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m0Cronometro.AutoSize = true;
            this.m0Cronometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m0Cronometro.Location = new System.Drawing.Point(17, 26);
            this.m0Cronometro.Margin = new System.Windows.Forms.Padding(0);
            this.m0Cronometro.Name = "m0Cronometro";
            this.m0Cronometro.Size = new System.Drawing.Size(92, 17);
            this.m0Cronometro.TabIndex = 37;
            this.m0Cronometro.Text = "00 : 00 : 00";
            this.m0Cronometro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // autonomous_CB
            // 
            this.autonomous_CB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autonomous_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autonomous_CB.Location = new System.Drawing.Point(10, 495);
            this.autonomous_CB.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.autonomous_CB.Name = "autonomous_CB";
            this.autonomous_CB.Padding = new System.Windows.Forms.Padding(0);
            this.autonomous_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autonomous_CB.Size = new System.Drawing.Size(265, 65);
            this.autonomous_CB.TabIndex = 41;
            this.autonomous_CB.TabStop = false;
            this.autonomous_CB.Text = "Estado de las Antenas";
            // 
            // FormPOLecturaDeCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1408, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormPOLecturaDeCaja";
            this.Text = "Lectura de Caja";
            this.Activated += new System.EventHandler(this.FormPOLecturaDeCaja_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPOLecturaDeCaja_FormClosing);
            this.Load += new System.EventHandler(this.FormPOLecturaDeCaja_Load);
            this.Shown += new System.EventHandler(this.FormPOLecturaDeCaja_Shown);
            this.Resize += new System.EventHandler(this.FormPOLecturaDeCaja_Resize);
            this.gpiStateGB.ResumeLayout(false);
            this.gpiStateGB.PerformLayout();
            this.transmitPowerGB.ResumeLayout(false);
            this.transmitPowerGB.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label gpiLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gpiStateGB;
        private System.Windows.Forms.Label gpiNumberLabel;
        private System.Windows.Forms.GroupBox transmitPowerGB;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        private Timer timerCronome_tro;
        private Button readButton;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox autonomous_CB;
        private GroupBox groupBox1;
        private Label m0Cronometro;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label13;
        private Label SeConEnSegundos;
        private Button ReportaIncidente;
        private TableLayoutPanel tableLayoutPanel4;
        private Label totalTagValueLabel;
        private TextBox textPO;
    }
}