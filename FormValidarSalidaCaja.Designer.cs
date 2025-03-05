namespace RFIDPrendas
{
    partial class FormValidarSalidaCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbContentCaja = new System.Windows.Forms.TableLayoutPanel();
            this.tbContCronoEstados = new System.Windows.Forms.TableLayoutPanel();
            this.tbContentEstados = new System.Windows.Forms.TableLayoutPanel();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.tbContentCronometro = new System.Windows.Forms.TableLayoutPanel();
            this.SeConEnSegundos = new System.Windows.Forms.Label();
            this.panelCronometro = new System.Windows.Forms.Panel();
            this.m0Cronometro = new System.Windows.Forms.Label();
            this.tablaMsnError = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.inventoryList = new System.Windows.Forms.ListView();
            this.id_rfid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.op = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hoja_marcacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.corte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sucorte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.talla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.color = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbConRta = new System.Windows.Forms.TableLayoutPanel();
            this.detalleRta = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_NoCoinciden = new System.Windows.Forms.DataGridView();
            this.rfidNoCoincideMatricula = new System.Windows.Forms.Label();
            this.dgv_faltaLectura = new System.Windows.Forms.DataGridView();
            this.rfidFaltaLectura = new System.Windows.Forms.Label();
            this.dgv_MatriculaFaltante = new System.Windows.Forms.DataGridView();
            this.rfidFaltaMatricula = new System.Windows.Forms.Label();
            this.dgv_etiquetas = new System.Windows.Forms.DataGridView();
            this.rfidMatriculada = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MensajeError = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timerCronome_tro = new System.Windows.Forms.Timer(this.components);
            this.tbContentCaja.SuspendLayout();
            this.tbContCronoEstados.SuspendLayout();
            this.tbContentEstados.SuspendLayout();
            this.tbContentCronometro.SuspendLayout();
            this.panelCronometro.SuspendLayout();
            this.tablaMsnError.SuspendLayout();
            this.tbConRta.SuspendLayout();
            this.detalleRta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NoCoinciden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faltaLectura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MatriculaFaltante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_etiquetas)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbContentCaja
            // 
            this.tbContentCaja.ColumnCount = 2;
            this.tbContentCaja.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tbContentCaja.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbContentCaja.Controls.Add(this.tbContCronoEstados, 0, 1);
            this.tbContentCaja.Controls.Add(this.tablaMsnError, 0, 0);
            this.tbContentCaja.Controls.Add(this.tbConRta, 1, 0);
            this.tbContentCaja.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tbContentCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContentCaja.Location = new System.Drawing.Point(0, 0);
            this.tbContentCaja.Margin = new System.Windows.Forms.Padding(0);
            this.tbContentCaja.Name = "tbContentCaja";
            this.tbContentCaja.RowCount = 2;
            this.tbContentCaja.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbContentCaja.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbContentCaja.Size = new System.Drawing.Size(1370, 584);
            this.tbContentCaja.TabIndex = 0;
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
            this.tbContCronoEstados.Location = new System.Drawing.Point(822, 467);
            this.tbContCronoEstados.Margin = new System.Windows.Forms.Padding(0);
            this.tbContCronoEstados.Name = "tbContCronoEstados";
            this.tbContCronoEstados.RowCount = 1;
            this.tbContCronoEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContCronoEstados.Size = new System.Drawing.Size(548, 117);
            this.tbContCronoEstados.TabIndex = 4;
            // 
            // tbContentEstados
            // 
            this.tbContentEstados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContentEstados.BackColor = System.Drawing.Color.White;
            this.tbContentEstados.ColumnCount = 1;
            this.tbContentEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentEstados.Controls.Add(this.autonomous_CB, 0, 1);
            this.tbContentEstados.Location = new System.Drawing.Point(273, 0);
            this.tbContentEstados.Margin = new System.Windows.Forms.Padding(0);
            this.tbContentEstados.Name = "tbContentEstados";
            this.tbContentEstados.RowCount = 3;
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tbContentEstados.Size = new System.Drawing.Size(275, 117);
            this.tbContentEstados.TabIndex = 3;
            // 
            // autonomous_CB
            // 
            this.autonomous_CB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.autonomous_CB.BackColor = System.Drawing.Color.White;
            this.autonomous_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autonomous_CB.Location = new System.Drawing.Point(17, 35);
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
            // tablaMsnError
            // 
            this.tablaMsnError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaMsnError.ColumnCount = 1;
            this.tablaMsnError.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablaMsnError.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablaMsnError.Controls.Add(this.label14, 0, 0);
            this.tablaMsnError.Controls.Add(this.inventoryList, 0, 1);
            this.tablaMsnError.Location = new System.Drawing.Point(3, 3);
            this.tablaMsnError.Name = "tablaMsnError";
            this.tablaMsnError.RowCount = 2;
            this.tablaMsnError.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaMsnError.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tablaMsnError.Size = new System.Drawing.Size(816, 461);
            this.tablaMsnError.TabIndex = 1;
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
            this.label14.Size = new System.Drawing.Size(810, 43);
            this.label14.TabIndex = 30;
            this.label14.Text = "Lista de Etiquetas RFID Leídas";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inventoryList
            // 
            this.inventoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id_rfid,
            this.op,
            this.hoja_marcacion,
            this.corte,
            this.sucorte,
            this.talla,
            this.color});
            this.inventoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.inventoryList.FullRowSelect = true;
            this.inventoryList.GridLines = true;
            this.inventoryList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.inventoryList.HideSelection = false;
            this.inventoryList.Location = new System.Drawing.Point(3, 49);
            this.inventoryList.MultiSelect = false;
            this.inventoryList.Name = "inventoryList";
            this.inventoryList.Size = new System.Drawing.Size(810, 409);
            this.inventoryList.TabIndex = 31;
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
            this.op.Width = 200;
            // 
            // hoja_marcacion
            // 
            this.hoja_marcacion.Text = "HM";
            this.hoja_marcacion.Width = 100;
            // 
            // corte
            // 
            this.corte.Text = "Corte";
            this.corte.Width = 80;
            // 
            // sucorte
            // 
            this.sucorte.Text = "Sub Corte";
            this.sucorte.Width = 150;
            // 
            // talla
            // 
            this.talla.Text = "Talla";
            this.talla.Width = 80;
            // 
            // color
            // 
            this.color.Text = "Color";
            this.color.Width = 80;
            // 
            // tbConRta
            // 
            this.tbConRta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConRta.ColumnCount = 1;
            this.tbConRta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbConRta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbConRta.Controls.Add(this.detalleRta, 0, 1);
            this.tbConRta.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tbConRta.Location = new System.Drawing.Point(825, 3);
            this.tbConRta.Name = "tbConRta";
            this.tbConRta.RowCount = 2;
            this.tbConRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tbConRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tbConRta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbConRta.Size = new System.Drawing.Size(542, 461);
            this.tbConRta.TabIndex = 2;
            // 
            // detalleRta
            // 
            this.detalleRta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detalleRta.ColumnCount = 1;
            this.detalleRta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detalleRta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.detalleRta.Controls.Add(this.dgv_NoCoinciden, 0, 10);
            this.detalleRta.Controls.Add(this.rfidNoCoincideMatricula, 0, 9);
            this.detalleRta.Controls.Add(this.dgv_faltaLectura, 0, 7);
            this.detalleRta.Controls.Add(this.rfidFaltaLectura, 0, 6);
            this.detalleRta.Controls.Add(this.dgv_MatriculaFaltante, 0, 4);
            this.detalleRta.Controls.Add(this.rfidFaltaMatricula, 0, 3);
            this.detalleRta.Controls.Add(this.dgv_etiquetas, 0, 1);
            this.detalleRta.Controls.Add(this.rfidMatriculada, 0, 0);
            this.detalleRta.Location = new System.Drawing.Point(3, 49);
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
            this.detalleRta.Size = new System.Drawing.Size(536, 409);
            this.detalleRta.TabIndex = 1;
            // 
            // dgv_NoCoinciden
            // 
            this.dgv_NoCoinciden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_NoCoinciden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_NoCoinciden.BackgroundColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_NoCoinciden.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgv_NoCoinciden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NoCoinciden.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgv_NoCoinciden.Location = new System.Drawing.Point(3, 318);
            this.dgv_NoCoinciden.Name = "dgv_NoCoinciden";
            this.dgv_NoCoinciden.Size = new System.Drawing.Size(530, 88);
            this.dgv_NoCoinciden.TabIndex = 45;
            // 
            // rfidNoCoincideMatricula
            // 
            this.rfidNoCoincideMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rfidNoCoincideMatricula.AutoSize = true;
            this.rfidNoCoincideMatricula.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.rfidNoCoincideMatricula.ForeColor = System.Drawing.Color.White;
            this.rfidNoCoincideMatricula.Location = new System.Drawing.Point(3, 299);
            this.rfidNoCoincideMatricula.Name = "rfidNoCoincideMatricula";
            this.rfidNoCoincideMatricula.Size = new System.Drawing.Size(530, 16);
            this.rfidNoCoincideMatricula.TabIndex = 44;
            this.rfidNoCoincideMatricula.Text = "Prendas no Coinciden";
            this.rfidNoCoincideMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_faltaLectura
            // 
            this.dgv_faltaLectura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_faltaLectura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_faltaLectura.BackgroundColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_faltaLectura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgv_faltaLectura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_faltaLectura.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgv_faltaLectura.Location = new System.Drawing.Point(3, 205);
            this.dgv_faltaLectura.Name = "dgv_faltaLectura";
            this.dgv_faltaLectura.Size = new System.Drawing.Size(530, 83);
            this.dgv_faltaLectura.TabIndex = 43;
            // 
            // rfidFaltaLectura
            // 
            this.rfidFaltaLectura.AutoSize = true;
            this.rfidFaltaLectura.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.rfidFaltaLectura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rfidFaltaLectura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rfidFaltaLectura.ForeColor = System.Drawing.Color.White;
            this.rfidFaltaLectura.Location = new System.Drawing.Point(3, 186);
            this.rfidFaltaLectura.Name = "rfidFaltaLectura";
            this.rfidFaltaLectura.Size = new System.Drawing.Size(530, 16);
            this.rfidFaltaLectura.TabIndex = 42;
            this.rfidFaltaLectura.Text = "RFID Lectura sobrante";
            this.rfidFaltaLectura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_MatriculaFaltante
            // 
            this.dgv_MatriculaFaltante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_MatriculaFaltante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_MatriculaFaltante.BackgroundColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MatriculaFaltante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgv_MatriculaFaltante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_MatriculaFaltante.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgv_MatriculaFaltante.Location = new System.Drawing.Point(3, 92);
            this.dgv_MatriculaFaltante.Name = "dgv_MatriculaFaltante";
            this.dgv_MatriculaFaltante.Size = new System.Drawing.Size(530, 83);
            this.dgv_MatriculaFaltante.TabIndex = 41;
            // 
            // rfidFaltaMatricula
            // 
            this.rfidFaltaMatricula.AutoSize = true;
            this.rfidFaltaMatricula.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.rfidFaltaMatricula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rfidFaltaMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rfidFaltaMatricula.ForeColor = System.Drawing.Color.White;
            this.rfidFaltaMatricula.Location = new System.Drawing.Point(3, 73);
            this.rfidFaltaMatricula.Name = "rfidFaltaMatricula";
            this.rfidFaltaMatricula.Size = new System.Drawing.Size(530, 16);
            this.rfidFaltaMatricula.TabIndex = 40;
            this.rfidFaltaMatricula.Text = "RFID Matricula faltante";
            this.rfidFaltaMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_etiquetas
            // 
            this.dgv_etiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_etiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_etiquetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_etiquetas.BackgroundColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_etiquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgv_etiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_etiquetas.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgv_etiquetas.GridColor = System.Drawing.Color.Silver;
            this.dgv_etiquetas.Location = new System.Drawing.Point(3, 19);
            this.dgv_etiquetas.Name = "dgv_etiquetas";
            this.dgv_etiquetas.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_etiquetas.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgv_etiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_etiquetas.Size = new System.Drawing.Size(530, 43);
            this.dgv_etiquetas.TabIndex = 39;
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
            this.rfidMatriculada.Location = new System.Drawing.Point(3, 0);
            this.rfidMatriculada.Name = "rfidMatriculada";
            this.rfidMatriculada.Size = new System.Drawing.Size(530, 16);
            this.rfidMatriculada.TabIndex = 38;
            this.rfidMatriculada.Text = "Caja Matriculada";
            this.rfidMatriculada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.Controls.Add(this.MensajeError, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(536, 40);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // MensajeError
            // 
            this.MensajeError.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MensajeError.AutoSize = true;
            this.MensajeError.Location = new System.Drawing.Point(56, 13);
            this.MensajeError.Name = "MensajeError";
            this.MensajeError.Size = new System.Drawing.Size(22, 13);
            this.MensajeError.TabIndex = 2;
            this.MensajeError.Text = "xxx";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RFIDPrendas.Properties.Resources.icon_inicial;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 34);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.totalTagValueLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.readButton, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 470);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 111);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(615, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 31);
            this.label13.TabIndex = 54;
            this.label13.Text = "Pds";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.totalTagValueLabel.AutoSize = true;
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagValueLabel.ForeColor = System.Drawing.Color.Red;
            this.totalTagValueLabel.Location = new System.Drawing.Point(580, 40);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(29, 31);
            this.totalTagValueLabel.TabIndex = 53;
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
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(3, 3);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(402, 105);
            this.readButton.TabIndex = 1;
            this.readButton.Tag = "Start Reading";
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            this.accessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AccessBackgroundWorker_DoWork);
            this.accessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AccessBackgroundWorker_ProgressChanged);
            this.accessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AccessBackgroundWorker_RunWorkerCompleted);
            // 
            // timerCronome_tro
            // 
            this.timerCronome_tro.Interval = 1000;
            this.timerCronome_tro.Tick += new System.EventHandler(this.TimerCronome_tro_Tick);
            // 
            // FormValidarSalidaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 584);
            this.Controls.Add(this.tbContentCaja);
            this.KeyPreview = true;
            this.Name = "FormValidarSalidaCaja";
            this.Text = "FormValidarSalidaCaja";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormValidarSalidaCaja_KeyDown);
            this.tbContentCaja.ResumeLayout(false);
            this.tbContCronoEstados.ResumeLayout(false);
            this.tbContentEstados.ResumeLayout(false);
            this.tbContentCronometro.ResumeLayout(false);
            this.panelCronometro.ResumeLayout(false);
            this.tablaMsnError.ResumeLayout(false);
            this.tablaMsnError.PerformLayout();
            this.tbConRta.ResumeLayout(false);
            this.detalleRta.ResumeLayout(false);
            this.detalleRta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NoCoinciden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faltaLectura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MatriculaFaltante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_etiquetas)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbContentCaja;
        private System.Windows.Forms.TableLayoutPanel tablaMsnError;
        private System.Windows.Forms.TableLayoutPanel tbConRta;
        private System.Windows.Forms.TableLayoutPanel detalleRta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label rfidMatriculada;
        private System.Windows.Forms.DataGridView dgv_etiquetas;
        private System.Windows.Forms.Label rfidFaltaMatricula;
        private System.Windows.Forms.DataGridView dgv_MatriculaFaltante;
        private System.Windows.Forms.Label rfidFaltaLectura;
        private System.Windows.Forms.DataGridView dgv_faltaLectura;
        private System.Windows.Forms.Label rfidNoCoincideMatricula;
        private System.Windows.Forms.DataGridView dgv_NoCoinciden;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label MensajeError;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        private System.Windows.Forms.Timer timerCronome_tro;
        private System.Windows.Forms.ColumnHeader id_rfid;
        private System.Windows.Forms.ColumnHeader op;
        private System.Windows.Forms.ColumnHeader hoja_marcacion;
        private System.Windows.Forms.ColumnHeader corte;
        private System.Windows.Forms.ColumnHeader sucorte;
        private System.Windows.Forms.ColumnHeader talla;
        private System.Windows.Forms.ColumnHeader color;
        internal System.Windows.Forms.ListView inventoryList;
        private System.Windows.Forms.TableLayoutPanel tbContCronoEstados;
        private System.Windows.Forms.TableLayoutPanel tbContentEstados;
        private System.Windows.Forms.GroupBox autonomous_CB;
        private System.Windows.Forms.TableLayoutPanel tbContentCronometro;
        private System.Windows.Forms.Label SeConEnSegundos;
        private System.Windows.Forms.Panel panelCronometro;
        private System.Windows.Forms.Label m0Cronometro;
        private System.Windows.Forms.Label totalTagValueLabel;
        private System.Windows.Forms.Label label13;
    }
}