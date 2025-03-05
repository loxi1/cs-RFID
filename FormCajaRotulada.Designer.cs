using System.Drawing;
using System.Windows.Forms;

namespace RFIDPrendas
{
    partial class FormCajaRotulada
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
            this.inventoryList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpiLabel = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.dataButton = new System.Windows.Forms.Button();
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
            this.dgv_cajas = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uctb_qr_o_br = new RFIDPrendas.UCTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkOp = new System.Windows.Forms.CheckBox();
            this.uctb_op = new RFIDPrendas.UCTextBox();
            this.labelmsj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.uctb_hm = new RFIDPrendas.UCTextBox();
            this.uctb_caja = new RFIDPrendas.UCTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m0Cronometro = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SeConEnSegundos = new System.Windows.Forms.Label();
            this.ReportaIncidente = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.timerCronome_tro = new System.Windows.Forms.Timer(this.components);
            this.gpiStateGB.SuspendLayout();
            this.transmitPowerGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cajas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // inventoryList
            // 
            this.inventoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader2,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader4});
            this.tableLayoutPanel1.SetColumnSpan(this.inventoryList, 8);
            this.inventoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inventoryList.FullRowSelect = true;
            this.inventoryList.GridLines = true;
            this.inventoryList.HideSelection = false;
            this.inventoryList.Location = new System.Drawing.Point(3, 482);
            this.inventoryList.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.inventoryList.MultiSelect = false;
            this.inventoryList.Name = "inventoryList";
            this.inventoryList.Size = new System.Drawing.Size(1384, 51);
            this.inventoryList.TabIndex = 10;
            this.inventoryList.UseCompatibleStateImageBehavior = false;
            this.inventoryList.View = System.Windows.Forms.View.Details;
            this.inventoryList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.inventoryList_ColumnClick);
            this.inventoryList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.inventoryList_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Etiqueta RFID";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Antena";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "OP";
            this.columnHeader12.Width = 200;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Corte";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Talla";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Color";
            this.columnHeader15.Width = 200;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Talla ID";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cantidad leídas";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Evento";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Fase";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "PC Bits";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 55;
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
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.readButton, 2);
            this.readButton.Enabled = false;
            this.readButton.FlatAppearance.BorderSize = 0;
            this.readButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(3, 539);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(286, 18);
            this.readButton.TabIndex = 20;
            this.readButton.Tag = "Start Reading";
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // dataButton
            // 
            this.dataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.dataButton.FlatAppearance.BorderSize = 0;
            this.dataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataButton.ForeColor = System.Drawing.Color.White;
            this.dataButton.Location = new System.Drawing.Point(615, 3);
            this.dataButton.Name = "dataButton";
            this.dataButton.Size = new System.Drawing.Size(265, 28);
            this.dataButton.TabIndex = 3;
            this.dataButton.Tag = "Retrieve";
            this.dataButton.Text = "Consultar";
            this.dataButton.UseVisualStyleBackColor = false;
            this.dataButton.Click += new System.EventHandler(this.dataButton_Click);
            this.dataButton.Enter += new System.EventHandler(this.dataButton_Enter);
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
            this.gpiNumberLabel.Size = new System.Drawing.Size(259, 13);
            this.gpiNumberLabel.TabIndex = 0;
            this.gpiNumberLabel.Text = " 1          2          3         4          5          6         7         8";
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
            // dgv_cajas
            // 
            this.dgv_cajas.AllowUserToAddRows = false;
            this.dgv_cajas.AllowUserToDeleteRows = false;
            this.dgv_cajas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_cajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_cajas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_cajas.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgv_cajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgv_cajas, 8);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_cajas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_cajas.GridColor = System.Drawing.Color.Silver;
            this.dgv_cajas.Location = new System.Drawing.Point(3, 239);
            this.dgv_cajas.Name = "dgv_cajas";
            this.dgv_cajas.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_cajas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_cajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cajas.Size = new System.Drawing.Size(1384, 21);
            this.dgv_cajas.TabIndex = 4;
            this.dgv_cajas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_etiquetas_CellDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.410072F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.59712F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.920863F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.539568F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.561152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4964F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.76259F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.568345F));
            this.tableLayoutPanel1.Controls.Add(this.uctb_qr_o_br, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgv_cajas, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.readButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkOp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inventoryList, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.uctb_op, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelmsj, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uctb_hm, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.uctb_caja, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.441223F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.642857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.39286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.178571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.89286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.35714F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1390, 560);
            this.tableLayoutPanel1.TabIndex = 27;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint);
            // 
            // uctb_qr_o_br
            // 
            this.uctb_qr_o_br.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctb_qr_o_br.AutoSize = true;
            this.uctb_qr_o_br.BackColor = System.Drawing.SystemColors.Window;
            this.uctb_qr_o_br.BorderColor = System.Drawing.Color.YellowGreen;
            this.uctb_qr_o_br.BorderFocusColor = System.Drawing.Color.MediumSeaGreen;
            this.uctb_qr_o_br.BorderSize = 2;
            this.uctb_qr_o_br.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctb_qr_o_br.ForeColor = System.Drawing.Color.DimGray;
            this.uctb_qr_o_br.Location = new System.Drawing.Point(296, 6);
            this.uctb_qr_o_br.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uctb_qr_o_br.Multiline = false;
            this.uctb_qr_o_br.Name = "uctb_qr_o_br";
            this.uctb_qr_o_br.Padding = new System.Windows.Forms.Padding(7);
            this.uctb_qr_o_br.PasswordChar = false;
            this.uctb_qr_o_br.PlaceHolderText = "QR";
            this.uctb_qr_o_br.Size = new System.Drawing.Size(116, 31);
            this.uctb_qr_o_br.TabIndex = 1;
            this.uctb_qr_o_br.UnderlinedStyle = false;
            this.uctb_qr_o_br.Visible = false;
            this.uctb_qr_o_br.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Uctb_qr_or_br_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.label15, 8);
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 462);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(1384, 19);
            this.label15.TabIndex = 31;
            this.label15.Text = "Lista de Etiquetas RFID Leídas";
            // 
            // checkOp
            // 
            this.checkOp.AutoSize = true;
            this.checkOp.Checked = true;
            this.checkOp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOp.Location = new System.Drawing.Point(3, 3);
            this.checkOp.Name = "checkOp";
            this.checkOp.Size = new System.Drawing.Size(97, 28);
            this.checkOp.TabIndex = 54;
            this.checkOp.Text = "Sin OP";
            this.checkOp.UseVisualStyleBackColor = true;
            this.checkOp.CheckedChanged += new System.EventHandler(this.CheckOp_CheckedChanged);
            // 
            // uctb_op
            // 
            this.uctb_op.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctb_op.AutoSize = true;
            this.uctb_op.BackColor = System.Drawing.SystemColors.Window;
            this.uctb_op.BorderColor = System.Drawing.Color.YellowGreen;
            this.uctb_op.BorderFocusColor = System.Drawing.Color.MediumSeaGreen;
            this.uctb_op.BorderSize = 2;
            this.uctb_op.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctb_op.ForeColor = System.Drawing.Color.DimGray;
            this.uctb_op.Location = new System.Drawing.Point(107, 6);
            this.uctb_op.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uctb_op.Multiline = false;
            this.uctb_op.Name = "uctb_op";
            this.uctb_op.Padding = new System.Windows.Forms.Padding(7);
            this.uctb_op.PasswordChar = false;
            this.uctb_op.PlaceHolderText = "Nro OP";
            this.uctb_op.Size = new System.Drawing.Size(181, 31);
            this.uctb_op.TabIndex = 1;
            this.uctb_op.UnderlinedStyle = false;
            this.uctb_op.Visible = false;
            this.uctb_op.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.uctb_op.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Uctb_op_KeyPress);
            this.uctb_op.Leave += new System.EventHandler(this.uctb_op_Leave);
            // 
            // labelmsj
            // 
            this.labelmsj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelmsj.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.labelmsj, 3);
            this.labelmsj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmsj.ForeColor = System.Drawing.Color.Red;
            this.labelmsj.Location = new System.Drawing.Point(10, 40);
            this.labelmsj.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.labelmsj.Name = "labelmsj";
            this.labelmsj.Size = new System.Drawing.Size(396, 12);
            this.labelmsj.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.label14, 8);
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 217);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1384, 19);
            this.label14.TabIndex = 28;
            this.label14.Text = "Cajas Registradas";
            // 
            // uctb_hm
            // 
            this.uctb_hm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctb_hm.AutoSize = true;
            this.uctb_hm.BackColor = System.Drawing.SystemColors.Window;
            this.uctb_hm.BorderColor = System.Drawing.Color.YellowGreen;
            this.uctb_hm.BorderFocusColor = System.Drawing.Color.MediumSeaGreen;
            this.uctb_hm.BorderSize = 2;
            this.uctb_hm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctb_hm.ForeColor = System.Drawing.Color.DimGray;
            this.uctb_hm.Location = new System.Drawing.Point(420, 6);
            this.uctb_hm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uctb_hm.Multiline = false;
            this.uctb_hm.Name = "uctb_hm";
            this.uctb_hm.Padding = new System.Windows.Forms.Padding(7);
            this.uctb_hm.PasswordChar = false;
            this.uctb_hm.PlaceHolderText = "Hoja Marc.";
            this.uctb_hm.Size = new System.Drawing.Size(69, 31);
            this.uctb_hm.TabIndex = 2;
            this.uctb_hm.UnderlinedStyle = false;
            this.uctb_hm.Visible = false;
            this.uctb_hm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.uctb_hm.Leave += new System.EventHandler(this.uctb_hm_Leave);
            // 
            // uctb_caja
            // 
            this.uctb_caja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctb_caja.AutoSize = true;
            this.uctb_caja.BackColor = System.Drawing.SystemColors.Window;
            this.uctb_caja.BorderColor = System.Drawing.Color.YellowGreen;
            this.uctb_caja.BorderFocusColor = System.Drawing.Color.MediumSeaGreen;
            this.uctb_caja.BorderSize = 2;
            this.uctb_caja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctb_caja.ForeColor = System.Drawing.Color.DimGray;
            this.uctb_caja.Location = new System.Drawing.Point(497, 6);
            this.uctb_caja.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uctb_caja.Multiline = false;
            this.uctb_caja.Name = "uctb_caja";
            this.uctb_caja.Padding = new System.Windows.Forms.Padding(7);
            this.uctb_caja.PasswordChar = false;
            this.uctb_caja.PlaceHolderText = "Nro Caja";
            this.uctb_caja.Size = new System.Drawing.Size(111, 31);
            this.uctb_caja.TabIndex = 32;
            this.uctb_caja.UnderlinedStyle = false;
            this.uctb_caja.Visible = false;
            this.uctb_caja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.uctb_caja.Leave += new System.EventHandler(this.uctb_caja_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.m0Cronometro);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1265, 536);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(125, 24);
            this.groupBox1.TabIndex = 49;
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.85793F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.14208F));
            this.tableLayoutPanel2.Controls.Add(this.SeConEnSegundos, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ReportaIncidente, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(886, 539);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(366, 18);
            this.tableLayoutPanel2.TabIndex = 51;
            // 
            // SeConEnSegundos
            // 
            this.SeConEnSegundos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SeConEnSegundos.AutoSize = true;
            this.SeConEnSegundos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeConEnSegundos.Location = new System.Drawing.Point(76, 1);
            this.SeConEnSegundos.Name = "SeConEnSegundos";
            this.SeConEnSegundos.Size = new System.Drawing.Size(183, 17);
            this.SeConEnSegundos.TabIndex = 51;
            this.SeConEnSegundos.Text = "¡Se contó en tan solo 5 seg!";
            this.SeConEnSegundos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SeConEnSegundos.Visible = false;
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
            this.ReportaIncidente.Location = new System.Drawing.Point(265, 3);
            this.ReportaIncidente.Name = "ReportaIncidente";
            this.ReportaIncidente.Size = new System.Drawing.Size(98, 12);
            this.ReportaIncidente.TabIndex = 50;
            this.ReportaIncidente.Text = "INCIDENTE";
            this.ReportaIncidente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ReportaIncidente.UseVisualStyleBackColor = false;
            this.ReportaIncidente.Visible = false;
            this.ReportaIncidente.Click += new System.EventHandler(this.ReportaIncidente_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 4);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.92925F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.07075F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel3.Controls.Add(this.label13, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.totalTagValueLabel, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.autonomous_CB, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(295, 539);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(585, 18);
            this.tableLayoutPanel3.TabIndex = 54;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(461, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 18);
            this.label13.TabIndex = 53;
            this.label13.Text = "Pds";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.totalTagValueLabel.AutoSize = true;
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagValueLabel.ForeColor = System.Drawing.Color.Red;
            this.totalTagValueLabel.Location = new System.Drawing.Point(426, 0);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(29, 18);
            this.totalTagValueLabel.TabIndex = 52;
            this.totalTagValueLabel.Text = "0";
            this.totalTagValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // autonomous_CB
            // 
            this.autonomous_CB.AutoSize = true;
            this.autonomous_CB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autonomous_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autonomous_CB.Location = new System.Drawing.Point(63, 0);
            this.autonomous_CB.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.autonomous_CB.Name = "autonomous_CB";
            this.autonomous_CB.Padding = new System.Windows.Forms.Padding(0);
            this.autonomous_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autonomous_CB.Size = new System.Drawing.Size(221, 18);
            this.autonomous_CB.TabIndex = 50;
            this.autonomous_CB.TabStop = false;
            this.autonomous_CB.Text = "Estado de las Antenas";
            // 
            // timerCronome_tro
            // 
            this.timerCronome_tro.Interval = 1000;
            this.timerCronome_tro.Tick += new System.EventHandler(this.timerCronome_tro_Tick);
            // 
            // FormCajaRotulada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1408, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCajaRotulada";
            this.ShowIcon = false;
            this.Text = "Registro de Cantidad de Prendas en Caja";
            this.Activated += new System.EventHandler(this.FormCajaRotulada_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCajaRotulada_FormClosing);
            this.Load += new System.EventHandler(this.FormCajaRotulada_Load);
            this.Resize += new System.EventHandler(this.FormCajaRotulada_Resize);
            this.gpiStateGB.ResumeLayout(false);
            this.gpiStateGB.PerformLayout();
            this.transmitPowerGB.ResumeLayout(false);
            this.transmitPowerGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cajas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        //private System.Windows.Forms.ColumnHeader columnHeader5;
        //private System.Windows.Forms.ColumnHeader columnHeader6;

        private System.Windows.Forms.Label gpiLabel;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button dataButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        //private System.Windows.Forms.ToolStripStatusLabel regEventLabel;
        internal System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox gpiStateGB;
        private System.Windows.Forms.Label gpiNumberLabel;
        private System.Windows.Forms.GroupBox transmitPowerGB;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        internal System.Windows.Forms.ListView inventoryList;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        //private System.Windows.Forms.ColumnHeader columnHeader11;

        private System.Windows.Forms.ColumnHeader columnHeader12; //op
        private System.Windows.Forms.ColumnHeader columnHeader13; // corte
        private System.Windows.Forms.ColumnHeader columnHeader14; // Subcorte
        private System.Windows.Forms.ColumnHeader columnHeader15; // Cod Talla
        private System.Windows.Forms.ColumnHeader columnHeader16; // Talla ID

        private System.Windows.Forms.DataGridView dgv_cajas;
        private UCTextBox uctb_op;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelmsj;
        private Label label14;
        private Label label15;
        private UCTextBox uctb_hm;
        private UCTextBox uctb_caja;
        private GroupBox groupBox1;
        private Label m0Cronometro;
        private TableLayoutPanel tableLayoutPanel2;
        private Button ReportaIncidente;
        private Label SeConEnSegundos;
        private Timer timerCronome_tro;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label13;
        private Label totalTagValueLabel;
        private GroupBox autonomous_CB;
        private CheckBox checkOp;
        private UCTextBox uctb_qr_o_br;
    }
}