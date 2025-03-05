using System.Drawing;
using System.Windows.Forms;

namespace RFIDPrendas
{
    partial class FormValidarSalida
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormValidarSalida));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tablaMsnError = new System.Windows.Forms.TableLayoutPanel();
            this.iconoMensaje = new System.Windows.Forms.PictureBox();
            this.MensajeError = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.tbContentCronometro = new System.Windows.Forms.TableLayoutPanel();
            this.SeConEnSegundos = new System.Windows.Forms.Label();
            this.panelCronometro = new System.Windows.Forms.Panel();
            this.m0Cronometro = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.timerCronome_tro = new System.Windows.Forms.Timer(this.components);
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.transmitPowerGB = new System.Windows.Forms.GroupBox();
            this.gpiNumberLabel = new System.Windows.Forms.Label();
            this.gpiStateGB = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gpiLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbcomp = new System.Windows.Forms.TableLayoutPanel();
            this.tbDetD2 = new System.Windows.Forms.TableLayoutPanel();
            this.inventoryList = new System.Windows.Forms.ListView();
            this.id_rfid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.op = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hoja_marcacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.corte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subcorte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.talla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.color = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label14 = new System.Windows.Forms.Label();
            this.tbFooter = new System.Windows.Forms.TableLayoutPanel();
            this.tbFooterInfo = new System.Windows.Forms.TableLayoutPanel();
            this.tbContentEstados = new System.Windows.Forms.TableLayoutPanel();
            this.ReportaIncidente = new System.Windows.Forms.Button();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.tbContador = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.detalleRta = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_NoCoinciden = new System.Windows.Forms.DataGridView();
            this.rfidFaltaMatricula = new System.Windows.Forms.Label();
            this.rfidFaltaLectura = new System.Windows.Forms.Label();
            this.dgv_faltaLectura = new System.Windows.Forms.DataGridView();
            this.dgv_etiquetas = new System.Windows.Forms.DataGridView();
            this.rfidMatriculada = new System.Windows.Forms.Label();
            this.dgv_MatriculaFaltante = new System.Windows.Forms.DataGridView();
            this.rfidNoCoincideMatricula = new System.Windows.Forms.Label();
            this.tablaMsnError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoMensaje)).BeginInit();
            this.tbContentCronometro.SuspendLayout();
            this.panelCronometro.SuspendLayout();
            this.transmitPowerGB.SuspendLayout();
            this.gpiStateGB.SuspendLayout();
            this.tbcomp.SuspendLayout();
            this.tbDetD2.SuspendLayout();
            this.tbFooter.SuspendLayout();
            this.tbFooterInfo.SuspendLayout();
            this.tbContentEstados.SuspendLayout();
            this.tbContador.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.detalleRta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NoCoinciden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faltaLectura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_etiquetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MatriculaFaltante)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // tablaMsnError
            // 
            this.tablaMsnError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaMsnError.BackColor = System.Drawing.Color.LightGreen;
            this.tablaMsnError.ColumnCount = 2;
            this.tablaMsnError.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.24627F));
            this.tablaMsnError.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.75373F));
            this.tablaMsnError.Controls.Add(this.iconoMensaje, 0, 0);
            this.tablaMsnError.Controls.Add(this.MensajeError, 1, 0);
            this.tablaMsnError.Location = new System.Drawing.Point(3, 3);
            this.tablaMsnError.Name = "tablaMsnError";
            this.tablaMsnError.RowCount = 1;
            this.tablaMsnError.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablaMsnError.Size = new System.Drawing.Size(536, 68);
            this.tablaMsnError.TabIndex = 62;
            // 
            // iconoMensaje
            // 
            this.iconoMensaje.Image = global::RFIDPrendas.Properties.Resources.icon_inicial;
            this.iconoMensaje.Location = new System.Drawing.Point(3, 3);
            this.iconoMensaje.Name = "iconoMensaje";
            this.iconoMensaje.Size = new System.Drawing.Size(60, 60);
            this.iconoMensaje.TabIndex = 0;
            this.iconoMensaje.TabStop = false;
            // 
            // MensajeError
            // 
            this.MensajeError.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MensajeError.AutoSize = true;
            this.MensajeError.Location = new System.Drawing.Point(73, 27);
            this.MensajeError.Name = "MensajeError";
            this.MensajeError.Size = new System.Drawing.Size(25, 13);
            this.MensajeError.TabIndex = 1;
            this.MensajeError.Text = "___";
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
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(3, 3);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(467, 366);
            this.readButton.TabIndex = 0;
            this.readButton.Tag = "Start Reading";
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // tbContentCronometro
            // 
            this.tbContentCronometro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbContentCronometro.BackColor = System.Drawing.Color.White;
            this.tbContentCronometro.ColumnCount = 1;
            this.tbContentCronometro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentCronometro.Controls.Add(this.SeConEnSegundos, 0, 0);
            this.tbContentCronometro.Controls.Add(this.panelCronometro, 0, 1);
            this.tbContentCronometro.Location = new System.Drawing.Point(51, 135);
            this.tbContentCronometro.Margin = new System.Windows.Forms.Padding(0);
            this.tbContentCronometro.Name = "tbContentCronometro";
            this.tbContentCronometro.RowCount = 3;
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tbContentCronometro.Size = new System.Drawing.Size(235, 101);
            this.tbContentCronometro.TabIndex = 60;
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
            this.SeConEnSegundos.Size = new System.Drawing.Size(235, 30);
            this.SeConEnSegundos.TabIndex = 0;
            this.SeConEnSegundos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCronometro
            // 
            this.panelCronometro.BackColor = System.Drawing.Color.DarkRed;
            this.panelCronometro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCronometro.Controls.Add(this.m0Cronometro);
            this.panelCronometro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCronometro.Location = new System.Drawing.Point(0, 30);
            this.panelCronometro.Margin = new System.Windows.Forms.Padding(0);
            this.panelCronometro.Name = "panelCronometro";
            this.panelCronometro.Size = new System.Drawing.Size(235, 65);
            this.panelCronometro.TabIndex = 1;
            // 
            // m0Cronometro
            // 
            this.m0Cronometro.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.m0Cronometro.ForeColor = System.Drawing.Color.Transparent;
            this.m0Cronometro.Location = new System.Drawing.Point(0, 0);
            this.m0Cronometro.Name = "m0Cronometro";
            this.m0Cronometro.Size = new System.Drawing.Size(233, 74);
            this.m0Cronometro.TabIndex = 0;
            this.m0Cronometro.Text = "00:00:00";
            this.m0Cronometro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(244, 38);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 31);
            this.label13.TabIndex = 55;
            this.label13.Text = "Pds";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.AutoSize = true;
            this.totalTagValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagValueLabel.ForeColor = System.Drawing.Color.Red;
            this.totalTagValueLabel.Location = new System.Drawing.Point(0, 0);
            this.totalTagValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(241, 108);
            this.totalTagValueLabel.TabIndex = 54;
            this.totalTagValueLabel.Text = "200";
            this.totalTagValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.totalTagValueLabel.Click += new System.EventHandler(this.TotalTagValueLabel_Click);
            // 
            // timerCronome_tro
            // 
            this.timerCronome_tro.Interval = 1000;
            this.timerCronome_tro.Tick += new System.EventHandler(this.timerCronome_tro_Tick);
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            this.accessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.accessBackgroundWorker_DoWork);
            this.accessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.accessBackgroundWorker_ProgressChanged);
            this.accessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.accessBackgroundWorker_RunWorkerCompleted);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(114, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "1620";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "1620";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 203;
            this.label12.Text = "2920";
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
            this.transmitPowerGB.TabIndex = 202;
            this.transmitPowerGB.TabStop = false;
            this.transmitPowerGB.Text = "Transmit Power (dbm)";
            // 
            // gpiNumberLabel
            // 
            this.gpiNumberLabel.AutoSize = true;
            this.gpiNumberLabel.Location = new System.Drawing.Point(77, 38);
            this.gpiNumberLabel.Name = "gpiNumberLabel";
            this.gpiNumberLabel.Size = new System.Drawing.Size(259, 13);
            this.gpiNumberLabel.TabIndex = 201;
            this.gpiNumberLabel.Text = " 1          2          3         4          5          6         7         8";
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
            this.gpiStateGB.TabIndex = 200;
            this.gpiStateGB.TabStop = false;
            this.gpiStateGB.Text = "GPI State";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(321, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 20;
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
            // gpiLabel
            // 
            this.gpiLabel.AutoSize = true;
            this.gpiLabel.Location = new System.Drawing.Point(6, 27);
            this.gpiLabel.Name = "gpiLabel";
            this.gpiLabel.Size = new System.Drawing.Size(68, 13);
            this.gpiLabel.TabIndex = 50;
            this.gpiLabel.Text = "Red For Low";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // tbcomp
            // 
            this.tbcomp.ColumnCount = 2;
            this.tbcomp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tbcomp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbcomp.Controls.Add(this.tbDetD2, 0, 0);
            this.tbcomp.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tbcomp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcomp.Location = new System.Drawing.Point(0, 0);
            this.tbcomp.Margin = new System.Windows.Forms.Padding(0);
            this.tbcomp.Name = "tbcomp";
            this.tbcomp.RowCount = 1;
            this.tbcomp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbcomp.Size = new System.Drawing.Size(1370, 749);
            this.tbcomp.TabIndex = 204;
            // 
            // tbDetD2
            // 
            this.tbDetD2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDetD2.ColumnCount = 1;
            this.tbDetD2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbDetD2.Controls.Add(this.inventoryList, 0, 1);
            this.tbDetD2.Controls.Add(this.label14, 0, 0);
            this.tbDetD2.Controls.Add(this.tbFooter, 0, 2);
            this.tbDetD2.Location = new System.Drawing.Point(3, 3);
            this.tbDetD2.Name = "tbDetD2";
            this.tbDetD2.RowCount = 3;
            this.tbDetD2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tbDetD2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbDetD2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbDetD2.Size = new System.Drawing.Size(816, 743);
            this.tbDetD2.TabIndex = 0;
            // 
            // inventoryList
            // 
            this.inventoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id_rfid,
            this.op,
            this.hoja_marcacion,
            this.corte,
            this.subcorte,
            this.talla,
            this.color});
            this.inventoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.inventoryList.FullRowSelect = true;
            this.inventoryList.GridLines = true;
            this.inventoryList.HideSelection = false;
            this.inventoryList.Location = new System.Drawing.Point(3, 75);
            this.inventoryList.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.inventoryList.MultiSelect = false;
            this.inventoryList.Name = "inventoryList";
            this.inventoryList.Size = new System.Drawing.Size(810, 293);
            this.inventoryList.TabIndex = 32;
            this.inventoryList.UseCompatibleStateImageBehavior = false;
            this.inventoryList.View = System.Windows.Forms.View.Details;
            // 
            // id_rfid
            // 
            this.id_rfid.Text = "RFID";
            this.id_rfid.Width = 200;
            // 
            // op
            // 
            this.op.Text = "OP";
            this.op.Width = 130;
            // 
            // hoja_marcacion
            // 
            this.hoja_marcacion.Text = "HM";
            this.hoja_marcacion.Width = 130;
            // 
            // corte
            // 
            this.corte.Text = "Corte";
            this.corte.Width = 100;
            // 
            // subcorte
            // 
            this.subcorte.Text = "Sub Corte";
            // 
            // talla
            // 
            this.talla.Text = "Talla";
            // 
            // color
            // 
            this.color.Text = "Color";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 3);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(810, 71);
            this.label14.TabIndex = 30;
            this.label14.Text = "Lista de Etiquetas RFID Leídas";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbFooter
            // 
            this.tbFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFooter.ColumnCount = 2;
            this.tbFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tbFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tbFooter.Controls.Add(this.readButton, 0, 0);
            this.tbFooter.Controls.Add(this.tbFooterInfo, 1, 0);
            this.tbFooter.Location = new System.Drawing.Point(0, 371);
            this.tbFooter.Margin = new System.Windows.Forms.Padding(0);
            this.tbFooter.Name = "tbFooter";
            this.tbFooter.RowCount = 1;
            this.tbFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbFooter.Size = new System.Drawing.Size(816, 372);
            this.tbFooter.TabIndex = 33;
            // 
            // tbFooterInfo
            // 
            this.tbFooterInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbFooterInfo.ColumnCount = 1;
            this.tbFooterInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbFooterInfo.Controls.Add(this.tbContentEstados, 0, 2);
            this.tbFooterInfo.Controls.Add(this.tbContador, 0, 0);
            this.tbFooterInfo.Controls.Add(this.tbContentCronometro, 0, 1);
            this.tbFooterInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFooterInfo.Location = new System.Drawing.Point(476, 3);
            this.tbFooterInfo.Name = "tbFooterInfo";
            this.tbFooterInfo.RowCount = 3;
            this.tbFooterInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbFooterInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbFooterInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbFooterInfo.Size = new System.Drawing.Size(337, 366);
            this.tbFooterInfo.TabIndex = 1;
            // 
            // tbContentEstados
            // 
            this.tbContentEstados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContentEstados.BackColor = System.Drawing.Color.White;
            this.tbContentEstados.ColumnCount = 1;
            this.tbContentEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentEstados.Controls.Add(this.ReportaIncidente, 0, 0);
            this.tbContentEstados.Controls.Add(this.autonomous_CB, 0, 1);
            this.tbContentEstados.Location = new System.Drawing.Point(1, 263);
            this.tbContentEstados.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tbContentEstados.Name = "tbContentEstados";
            this.tbContentEstados.RowCount = 3;
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tbContentEstados.Size = new System.Drawing.Size(332, 102);
            this.tbContentEstados.TabIndex = 59;
            // 
            // ReportaIncidente
            // 
            this.ReportaIncidente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReportaIncidente.AutoSize = true;
            this.ReportaIncidente.BackColor = System.Drawing.Color.Red;
            this.ReportaIncidente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportaIncidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportaIncidente.ForeColor = System.Drawing.Color.White;
            this.ReportaIncidente.Location = new System.Drawing.Point(96, 1);
            this.ReportaIncidente.Margin = new System.Windows.Forms.Padding(0);
            this.ReportaIncidente.Name = "ReportaIncidente";
            this.ReportaIncidente.Size = new System.Drawing.Size(140, 27);
            this.ReportaIncidente.TabIndex = 50;
            this.ReportaIncidente.Text = "⚠️ INCIDENTE";
            this.ReportaIncidente.UseVisualStyleBackColor = false;
            this.ReportaIncidente.Visible = false;
            // 
            // autonomous_CB
            // 
            this.autonomous_CB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.autonomous_CB.BackColor = System.Drawing.Color.White;
            this.autonomous_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autonomous_CB.Location = new System.Drawing.Point(53, 30);
            this.autonomous_CB.Margin = new System.Windows.Forms.Padding(0);
            this.autonomous_CB.Name = "autonomous_CB";
            this.autonomous_CB.Padding = new System.Windows.Forms.Padding(0);
            this.autonomous_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autonomous_CB.Size = new System.Drawing.Size(225, 66);
            this.autonomous_CB.TabIndex = 42;
            this.autonomous_CB.TabStop = false;
            this.autonomous_CB.Text = "Estado de las Antenas";
            // 
            // tbContador
            // 
            this.tbContador.ColumnCount = 2;
            this.tbContador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.74747F));
            this.tbContador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.25253F));
            this.tbContador.Controls.Add(this.label13, 1, 0);
            this.tbContador.Controls.Add(this.totalTagValueLabel, 0, 0);
            this.tbContador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContador.Location = new System.Drawing.Point(1, 1);
            this.tbContador.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tbContador.Name = "tbContador";
            this.tbContador.RowCount = 1;
            this.tbContador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContador.Size = new System.Drawing.Size(332, 108);
            this.tbContador.TabIndex = 61;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.detalleRta, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tablaMsnError, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(825, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(542, 743);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // detalleRta
            // 
            this.detalleRta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detalleRta.BackColor = System.Drawing.Color.Transparent;
            this.detalleRta.ColumnCount = 1;
            this.detalleRta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detalleRta.Controls.Add(this.dgv_NoCoinciden, 0, 10);
            this.detalleRta.Controls.Add(this.rfidFaltaMatricula, 0, 3);
            this.detalleRta.Controls.Add(this.rfidFaltaLectura, 0, 6);
            this.detalleRta.Controls.Add(this.dgv_faltaLectura, 0, 7);
            this.detalleRta.Controls.Add(this.dgv_etiquetas, 0, 1);
            this.detalleRta.Controls.Add(this.rfidMatriculada, 0, 0);
            this.detalleRta.Controls.Add(this.dgv_MatriculaFaltante, 0, 4);
            this.detalleRta.Controls.Add(this.rfidNoCoincideMatricula, 0, 9);
            this.detalleRta.Location = new System.Drawing.Point(0, 74);
            this.detalleRta.Margin = new System.Windows.Forms.Padding(0);
            this.detalleRta.Name = "detalleRta";
            this.detalleRta.RowCount = 11;
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.detalleRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.detalleRta.Size = new System.Drawing.Size(542, 669);
            this.detalleRta.TabIndex = 64;
            // 
            // dgv_NoCoinciden
            // 
            this.dgv_NoCoinciden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_NoCoinciden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_NoCoinciden.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dgv_NoCoinciden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NoCoinciden.Location = new System.Drawing.Point(3, 520);
            this.dgv_NoCoinciden.Name = "dgv_NoCoinciden";
            this.dgv_NoCoinciden.Size = new System.Drawing.Size(536, 146);
            this.dgv_NoCoinciden.TabIndex = 41;
            // 
            // rfidFaltaMatricula
            // 
            this.rfidFaltaMatricula.AutoSize = true;
            this.rfidFaltaMatricula.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.rfidFaltaMatricula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rfidFaltaMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rfidFaltaMatricula.ForeColor = System.Drawing.Color.White;
            this.rfidFaltaMatricula.Location = new System.Drawing.Point(6, 119);
            this.rfidFaltaMatricula.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.rfidFaltaMatricula.Name = "rfidFaltaMatricula";
            this.rfidFaltaMatricula.Size = new System.Drawing.Size(533, 26);
            this.rfidFaltaMatricula.TabIndex = 35;
            this.rfidFaltaMatricula.Text = "RFID Matricula faltante";
            this.rfidFaltaMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rfidFaltaLectura
            // 
            this.rfidFaltaLectura.AutoSize = true;
            this.rfidFaltaLectura.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.rfidFaltaLectura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rfidFaltaLectura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rfidFaltaLectura.ForeColor = System.Drawing.Color.White;
            this.rfidFaltaLectura.Location = new System.Drawing.Point(6, 305);
            this.rfidFaltaLectura.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.rfidFaltaLectura.Name = "rfidFaltaLectura";
            this.rfidFaltaLectura.Size = new System.Drawing.Size(533, 26);
            this.rfidFaltaLectura.TabIndex = 36;
            this.rfidFaltaLectura.Text = "RFID Lectura sobrante";
            this.rfidFaltaLectura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_faltaLectura
            // 
            this.dgv_faltaLectura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_faltaLectura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_faltaLectura.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dgv_faltaLectura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_faltaLectura.Location = new System.Drawing.Point(3, 334);
            this.dgv_faltaLectura.Name = "dgv_faltaLectura";
            this.dgv_faltaLectura.Size = new System.Drawing.Size(536, 141);
            this.dgv_faltaLectura.TabIndex = 34;
            // 
            // dgv_etiquetas
            // 
            this.dgv_etiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_etiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_etiquetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_etiquetas.BackgroundColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_etiquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_etiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_etiquetas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_etiquetas.GridColor = System.Drawing.Color.Silver;
            this.dgv_etiquetas.Location = new System.Drawing.Point(3, 29);
            this.dgv_etiquetas.Name = "dgv_etiquetas";
            this.dgv_etiquetas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_etiquetas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_etiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_etiquetas.Size = new System.Drawing.Size(536, 74);
            this.dgv_etiquetas.TabIndex = 33;
            // 
            // rfidMatriculada
            // 
            this.rfidMatriculada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rfidMatriculada.AutoSize = true;
            this.rfidMatriculada.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.rfidMatriculada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rfidMatriculada.ForeColor = System.Drawing.Color.White;
            this.rfidMatriculada.Location = new System.Drawing.Point(6, 0);
            this.rfidMatriculada.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.rfidMatriculada.Name = "rfidMatriculada";
            this.rfidMatriculada.Size = new System.Drawing.Size(533, 26);
            this.rfidMatriculada.TabIndex = 37;
            this.rfidMatriculada.Text = "Caja Matriculada";
            this.rfidMatriculada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_MatriculaFaltante
            // 
            this.dgv_MatriculaFaltante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_MatriculaFaltante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_MatriculaFaltante.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dgv_MatriculaFaltante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MatriculaFaltante.Location = new System.Drawing.Point(3, 148);
            this.dgv_MatriculaFaltante.Name = "dgv_MatriculaFaltante";
            this.dgv_MatriculaFaltante.Size = new System.Drawing.Size(536, 141);
            this.dgv_MatriculaFaltante.TabIndex = 38;
            // 
            // rfidNoCoincideMatricula
            // 
            this.rfidNoCoincideMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rfidNoCoincideMatricula.AutoSize = true;
            this.rfidNoCoincideMatricula.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.rfidNoCoincideMatricula.ForeColor = System.Drawing.Color.White;
            this.rfidNoCoincideMatricula.Location = new System.Drawing.Point(6, 491);
            this.rfidNoCoincideMatricula.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.rfidNoCoincideMatricula.Name = "rfidNoCoincideMatricula";
            this.rfidNoCoincideMatricula.Size = new System.Drawing.Size(533, 26);
            this.rfidNoCoincideMatricula.TabIndex = 40;
            this.rfidNoCoincideMatricula.Text = "Prendas no Coinciden";
            this.rfidNoCoincideMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormValidarSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tbcomp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormValidarSalida";
            this.ShowIcon = false;
            this.Text = "Registro de Caja";
            this.Activated += new System.EventHandler(this.FormCaja_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormValidarSalida_FormClosing);
            this.Load += new System.EventHandler(this.FormValidarSalida_Load);
            this.SizeChanged += new System.EventHandler(this.FormValidarSalida_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormValidarSalida_KeyDown);
            this.Resize += new System.EventHandler(this.FormValidarSalida_Resize);
            this.tablaMsnError.ResumeLayout(false);
            this.tablaMsnError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoMensaje)).EndInit();
            this.tbContentCronometro.ResumeLayout(false);
            this.panelCronometro.ResumeLayout(false);
            this.transmitPowerGB.ResumeLayout(false);
            this.transmitPowerGB.PerformLayout();
            this.gpiStateGB.ResumeLayout(false);
            this.gpiStateGB.PerformLayout();
            this.tbcomp.ResumeLayout(false);
            this.tbDetD2.ResumeLayout(false);
            this.tbDetD2.PerformLayout();
            this.tbFooter.ResumeLayout(false);
            this.tbFooterInfo.ResumeLayout(false);
            this.tbContentEstados.ResumeLayout(false);
            this.tbContentEstados.PerformLayout();
            this.tbContador.ResumeLayout(false);
            this.tbContador.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.detalleRta.ResumeLayout(false);
            this.detalleRta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NoCoinciden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faltaLectura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_etiquetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MatriculaFaltante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button readButton;
        private Timer timerCronome_tro;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        private HScrollBar hScrollBar1;
        private Label label11;
        private Label label10;
        private Label label12;
        private GroupBox transmitPowerGB;
        private Label gpiNumberLabel;
        private GroupBox gpiStateGB;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label gpiLabel;
        private Timer timer1;
        private TableLayoutPanel tablaMsnError;
        private PictureBox iconoMensaje;
        private Label MensajeError;
        private TableLayoutPanel tbContentCronometro;
        private Label SeConEnSegundos;
        private Panel panelCronometro;
        private Label m0Cronometro;
        private Label totalTagValueLabel;
        private Label label13;
        private TableLayoutPanel tbcomp;
        private TableLayoutPanel tbDetD2;
        internal ListView inventoryList;
        private ColumnHeader id_rfid;
        private ColumnHeader op;
        private ColumnHeader hoja_marcacion;
        private ColumnHeader corte;
        private ColumnHeader subcorte;
        private ColumnHeader talla;
        private ColumnHeader color;
        private Label label14;
        private TableLayoutPanel tbFooter;
        private TableLayoutPanel tbFooterInfo;
        private TableLayoutPanel tbContador;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tbContentEstados;
        private Button ReportaIncidente;
        private GroupBox autonomous_CB;
        private TableLayoutPanel detalleRta;
        private DataGridView dgv_NoCoinciden;
        private Label rfidFaltaMatricula;
        private Label rfidFaltaLectura;
        private DataGridView dgv_faltaLectura;
        private DataGridView dgv_etiquetas;
        private Label rfidMatriculada;
        private DataGridView dgv_MatriculaFaltante;
        private Label rfidNoCoincideMatricula;
    }
}