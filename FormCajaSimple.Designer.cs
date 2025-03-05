using System.Drawing;
using System.Windows.Forms;

namespace RFIDPrendas
{
    partial class FormCajaSimple
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.labelmsj = new System.Windows.Forms.Label();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.label_tiempo = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpiStateGB.SuspendLayout();
            this.transmitPowerGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cajas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.inventoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inventoryList.FullRowSelect = true;
            this.inventoryList.GridLines = true;
            this.inventoryList.HideSelection = false;
            this.inventoryList.Location = new System.Drawing.Point(620, 221);
            this.inventoryList.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.inventoryList.MultiSelect = false;
            this.inventoryList.Name = "inventoryList";
            this.inventoryList.Size = new System.Drawing.Size(20, 336);
            this.inventoryList.TabIndex = 10;
            this.inventoryList.UseCompatibleStateImageBehavior = false;
            this.inventoryList.View = System.Windows.Forms.View.Details;
            this.inventoryList.Visible = false;
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
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(3, 223);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(611, 334);
            this.readButton.TabIndex = 20;
            this.readButton.Tag = "Start Reading";
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
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
            this.dgv_cajas.AllowUserToDeleteRows = false;
            this.dgv_cajas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_cajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_cajas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_cajas.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_cajas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_cajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_cajas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_cajas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_cajas.GridColor = System.Drawing.Color.Silver;
            this.dgv_cajas.Location = new System.Drawing.Point(646, 223);
            this.dgv_cajas.Name = "dgv_cajas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_cajas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_cajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cajas.Size = new System.Drawing.Size(30, 334);
            this.dgv_cajas.TabIndex = 4;
            this.dgv_cajas.Visible = false;
            this.dgv_cajas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_etiquetas_CellDoubleClick);
            this.dgv_cajas.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_cajas_DefaultValuesNeeded);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.665402F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.942446F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.66187F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.546762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.1295F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.54676F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.readButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelmsj, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inventoryList, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgv_cajas, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.totalTagValueLabel, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_tiempo, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTime, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.71429F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.17857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.392858F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.53571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1390, 560);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // labelmsj
            // 
            this.labelmsj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelmsj.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.SetColumnSpan(this.labelmsj, 5);
            this.labelmsj.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmsj.ForeColor = System.Drawing.Color.Red;
            this.labelmsj.Location = new System.Drawing.Point(10, 6);
            this.labelmsj.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.labelmsj.Name = "labelmsj";
            this.tableLayoutPanel1.SetRowSpan(this.labelmsj, 2);
            this.labelmsj.Size = new System.Drawing.Size(749, 161);
            this.labelmsj.TabIndex = 27;
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalTagValueLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.totalTagValueLabel, 2);
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 200F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagValueLabel.ForeColor = System.Drawing.Color.Red;
            this.totalTagValueLabel.Location = new System.Drawing.Point(772, 220);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(615, 340);
            this.totalTagValueLabel.TabIndex = 29;
            this.totalTagValueLabel.Text = "10";
            this.totalTagValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_tiempo
            // 
            this.label_tiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_tiempo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label_tiempo, 2);
            this.label_tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tiempo.Location = new System.Drawing.Point(772, 60);
            this.label_tiempo.Name = "label_tiempo";
            this.label_tiempo.Size = new System.Drawing.Size(615, 113);
            this.label_tiempo.TabIndex = 30;
            this.label_tiempo.Tag = "3";
            this.label_tiempo.Text = "Tiempo 00:00:00";
            this.label_tiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.Location = new System.Drawing.Point(916, 19);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(100, 38);
            this.textBoxTime.TabIndex = 31;
            this.textBoxTime.Tag = "10";
            this.textBoxTime.Text = "2";
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1022, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 32;
            this.label1.Tag = "10";
            this.label1.Text = "segundos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormCajaSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1408, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCajaSimple";
            this.ShowIcon = false;
            this.Text = "Cajas";
            this.Activated += new System.EventHandler(this.FormCajaCantidad_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCajaCantidad_FormClosing);
            this.Load += new System.EventHandler(this.FormCajaCantidad_Load);
            this.Resize += new System.EventHandler(this.FormCajaCantidad_Resize);
            this.gpiStateGB.ResumeLayout(false);
            this.gpiStateGB.PerformLayout();
            this.transmitPowerGB.ResumeLayout(false);
            this.transmitPowerGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cajas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelmsj;
        private Label totalTagValueLabel;
        private Label label_tiempo;
        private TextBox textBoxTime;
        private Label label1;
    }
}

