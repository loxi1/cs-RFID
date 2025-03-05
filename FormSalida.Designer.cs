namespace RFIDPrendas
{
    partial class FormSalida
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerCronome_tro = new System.Windows.Forms.Timer(this.components);
            this.m0Cronometro = new System.Windows.Forms.Label();
            this.tablaContenedor = new System.Windows.Forms.TableLayoutPanel();
            this.inventoryList = new System.Windows.Forms.ListView();
            this.id_rfid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.op = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hoja_marcacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.corte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subcorte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.talla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.color = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label14 = new System.Windows.Forms.Label();
            this.detalleRta = new System.Windows.Forms.TableLayoutPanel();
            this.rfidFaltaMatricula = new System.Windows.Forms.Label();
            this.rfidFaltaLectura = new System.Windows.Forms.Label();
            this.dgv_faltaLectura = new System.Windows.Forms.DataGridView();
            this.dgv_etiquetas = new System.Windows.Forms.DataGridView();
            this.rfidMatriculada = new System.Windows.Forms.Label();
            this.dgv_MatriculaFaltante = new System.Windows.Forms.DataGridView();
            this.rfidNoCoincideMatricula = new System.Windows.Forms.Label();
            this.dgv_NoCoinciden = new System.Windows.Forms.DataGridView();
            this.tablaMsnError = new System.Windows.Forms.TableLayoutPanel();
            this.iconoMensaje = new System.Windows.Forms.PictureBox();
            this.MensajeError = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tablaTablaCompartativa = new System.Windows.Forms.TableLayoutPanel();
            this.tablaDetalle = new System.Windows.Forms.TableLayoutPanel();
            this.readButton = new System.Windows.Forms.Button();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.SeConEnSegundos = new System.Windows.Forms.Label();
            this.textoPrenda = new System.Windows.Forms.Label();
            this.grupoCronometro = new System.Windows.Forms.GroupBox();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.tablaContenedor.SuspendLayout();
            this.detalleRta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faltaLectura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_etiquetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MatriculaFaltante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NoCoinciden)).BeginInit();
            this.tablaMsnError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoMensaje)).BeginInit();
            this.tablaTablaCompartativa.SuspendLayout();
            this.tablaDetalle.SuspendLayout();
            this.grupoCronometro.SuspendLayout();
            this.SuspendLayout();
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // timerCronome_tro
            // 
            this.timerCronome_tro.Interval = 1000;
            // 
            // m0Cronometro
            // 
            this.m0Cronometro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m0Cronometro.AutoSize = true;
            this.m0Cronometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m0Cronometro.Location = new System.Drawing.Point(10, 26);
            this.m0Cronometro.Margin = new System.Windows.Forms.Padding(0);
            this.m0Cronometro.Name = "m0Cronometro";
            this.m0Cronometro.Size = new System.Drawing.Size(92, 17);
            this.m0Cronometro.TabIndex = 37;
            this.m0Cronometro.Text = "00 : 00 : 00";
            this.m0Cronometro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tablaContenedor
            // 
            this.tablaContenedor.BackColor = System.Drawing.Color.LightYellow;
            this.tablaContenedor.ColumnCount = 2;
            this.tablaContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tablaContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tablaContenedor.Controls.Add(this.inventoryList, 0, 1);
            this.tablaContenedor.Controls.Add(this.label14, 0, 0);
            this.tablaContenedor.Controls.Add(this.detalleRta, 1, 1);
            this.tablaContenedor.Controls.Add(this.tablaMsnError, 1, 0);
            this.tablaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaContenedor.Location = new System.Drawing.Point(3, 3);
            this.tablaContenedor.Name = "tablaContenedor";
            this.tablaContenedor.RowCount = 3;
            this.tablaContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89F));
            this.tablaContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tablaContenedor.Size = new System.Drawing.Size(1402, 461);
            this.tablaContenedor.TabIndex = 204;
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
            this.inventoryList.Dock = System.Windows.Forms.DockStyle.Top;
            this.inventoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.inventoryList.FullRowSelect = true;
            this.inventoryList.GridLines = true;
            this.inventoryList.HideSelection = false;
            this.inventoryList.Location = new System.Drawing.Point(3, 47);
            this.inventoryList.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.inventoryList.MultiSelect = false;
            this.inventoryList.Name = "inventoryList";
            this.inventoryList.Size = new System.Drawing.Size(905, 406);
            this.inventoryList.TabIndex = 31;
            this.inventoryList.UseCompatibleStateImageBehavior = false;
            this.inventoryList.View = System.Windows.Forms.View.Details;
            // 
            // id_rfid
            // 
            this.id_rfid.Text = "RFID";
            this.id_rfid.Width = 300;
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
            this.subcorte.Text = "SubCorte";
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
            this.label14.Size = new System.Drawing.Size(905, 43);
            this.label14.TabIndex = 29;
            this.label14.Text = "Lista de Etiquetas RFID Leídas";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // detalleRta
            // 
            this.detalleRta.ColumnCount = 1;
            this.detalleRta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detalleRta.Controls.Add(this.rfidFaltaMatricula, 0, 3);
            this.detalleRta.Controls.Add(this.rfidFaltaLectura, 0, 6);
            this.detalleRta.Controls.Add(this.dgv_faltaLectura, 0, 7);
            this.detalleRta.Controls.Add(this.dgv_etiquetas, 0, 1);
            this.detalleRta.Controls.Add(this.rfidMatriculada, 0, 0);
            this.detalleRta.Controls.Add(this.dgv_MatriculaFaltante, 0, 4);
            this.detalleRta.Controls.Add(this.rfidNoCoincideMatricula, 0, 9);
            this.detalleRta.Controls.Add(this.dgv_NoCoinciden, 0, 10);
            this.detalleRta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detalleRta.Location = new System.Drawing.Point(911, 46);
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
            this.detalleRta.Size = new System.Drawing.Size(491, 410);
            this.detalleRta.TabIndex = 60;
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
            this.rfidFaltaMatricula.Size = new System.Drawing.Size(485, 16);
            this.rfidFaltaMatricula.TabIndex = 35;
            this.rfidFaltaMatricula.Text = "Prendas faltante ";
            this.rfidFaltaMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rfidFaltaLectura
            // 
            this.rfidFaltaLectura.AutoSize = true;
            this.rfidFaltaLectura.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.rfidFaltaLectura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rfidFaltaLectura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rfidFaltaLectura.ForeColor = System.Drawing.Color.White;
            this.rfidFaltaLectura.Location = new System.Drawing.Point(3, 187);
            this.rfidFaltaLectura.Name = "rfidFaltaLectura";
            this.rfidFaltaLectura.Size = new System.Drawing.Size(485, 16);
            this.rfidFaltaLectura.TabIndex = 36;
            this.rfidFaltaLectura.Text = "Prendas sobrante";
            this.rfidFaltaLectura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_faltaLectura
            // 
            this.dgv_faltaLectura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_faltaLectura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_faltaLectura.BackgroundColor = System.Drawing.Color.LightGreen;
            this.dgv_faltaLectura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_faltaLectura.Location = new System.Drawing.Point(3, 206);
            this.dgv_faltaLectura.Name = "dgv_faltaLectura";
            this.dgv_faltaLectura.Size = new System.Drawing.Size(485, 84);
            this.dgv_faltaLectura.TabIndex = 34;
            // 
            // dgv_etiquetas
            // 
            this.dgv_etiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_etiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_etiquetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_etiquetas.BackgroundColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_etiquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_etiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_etiquetas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_etiquetas.GridColor = System.Drawing.Color.Silver;
            this.dgv_etiquetas.Location = new System.Drawing.Point(3, 19);
            this.dgv_etiquetas.Name = "dgv_etiquetas";
            this.dgv_etiquetas.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_etiquetas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_etiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_etiquetas.Size = new System.Drawing.Size(485, 43);
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
            this.rfidMatriculada.Location = new System.Drawing.Point(3, 0);
            this.rfidMatriculada.Name = "rfidMatriculada";
            this.rfidMatriculada.Size = new System.Drawing.Size(485, 16);
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
            this.dgv_MatriculaFaltante.BackgroundColor = System.Drawing.Color.LightGreen;
            this.dgv_MatriculaFaltante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MatriculaFaltante.Location = new System.Drawing.Point(3, 92);
            this.dgv_MatriculaFaltante.Name = "dgv_MatriculaFaltante";
            this.dgv_MatriculaFaltante.Size = new System.Drawing.Size(485, 84);
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
            this.rfidNoCoincideMatricula.Location = new System.Drawing.Point(3, 301);
            this.rfidNoCoincideMatricula.Name = "rfidNoCoincideMatricula";
            this.rfidNoCoincideMatricula.Size = new System.Drawing.Size(485, 16);
            this.rfidNoCoincideMatricula.TabIndex = 39;
            this.rfidNoCoincideMatricula.Text = "Prendas no Coinciden";
            this.rfidNoCoincideMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_NoCoinciden
            // 
            this.dgv_NoCoinciden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_NoCoinciden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_NoCoinciden.BackgroundColor = System.Drawing.Color.LightGreen;
            this.dgv_NoCoinciden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NoCoinciden.Location = new System.Drawing.Point(3, 320);
            this.dgv_NoCoinciden.Name = "dgv_NoCoinciden";
            this.dgv_NoCoinciden.Size = new System.Drawing.Size(485, 87);
            this.dgv_NoCoinciden.TabIndex = 40;
            // 
            // tablaMsnError
            // 
            this.tablaMsnError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaMsnError.BackColor = System.Drawing.Color.Transparent;
            this.tablaMsnError.ColumnCount = 2;
            this.tablaMsnError.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaMsnError.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tablaMsnError.Controls.Add(this.iconoMensaje, 0, 0);
            this.tablaMsnError.Controls.Add(this.MensajeError, 1, 0);
            this.tablaMsnError.Location = new System.Drawing.Point(911, 0);
            this.tablaMsnError.Margin = new System.Windows.Forms.Padding(0);
            this.tablaMsnError.Name = "tablaMsnError";
            this.tablaMsnError.RowCount = 1;
            this.tablaMsnError.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablaMsnError.Size = new System.Drawing.Size(491, 46);
            this.tablaMsnError.TabIndex = 61;
            // 
            // iconoMensaje
            // 
            this.iconoMensaje.Image = global::RFIDPrendas.Properties.Resources.icon_inicial;
            this.iconoMensaje.Location = new System.Drawing.Point(3, 3);
            this.iconoMensaje.Name = "iconoMensaje";
            this.iconoMensaje.Size = new System.Drawing.Size(43, 40);
            this.iconoMensaje.TabIndex = 0;
            this.iconoMensaje.TabStop = false;
            // 
            // MensajeError
            // 
            this.MensajeError.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MensajeError.AutoSize = true;
            this.MensajeError.Location = new System.Drawing.Point(52, 16);
            this.MensajeError.Name = "MensajeError";
            this.MensajeError.Size = new System.Drawing.Size(0, 13);
            this.MensajeError.TabIndex = 1;
            this.MensajeError.Click += new System.EventHandler(this.Label1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // tablaTablaCompartativa
            // 
            this.tablaTablaCompartativa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaTablaCompartativa.ColumnCount = 1;
            this.tablaTablaCompartativa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablaTablaCompartativa.Controls.Add(this.tablaContenedor, 0, 0);
            this.tablaTablaCompartativa.Controls.Add(this.tablaDetalle, 0, 1);
            this.tablaTablaCompartativa.Location = new System.Drawing.Point(0, 0);
            this.tablaTablaCompartativa.Margin = new System.Windows.Forms.Padding(0);
            this.tablaTablaCompartativa.Name = "tablaTablaCompartativa";
            this.tablaTablaCompartativa.RowCount = 2;
            this.tablaTablaCompartativa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tablaTablaCompartativa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablaTablaCompartativa.Size = new System.Drawing.Size(1408, 584);
            this.tablaTablaCompartativa.TabIndex = 205;
            // 
            // tablaDetalle
            // 
            this.tablaDetalle.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tablaDetalle.ColumnCount = 6;
            this.tablaDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tablaDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablaDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablaDetalle.Controls.Add(this.readButton, 0, 0);
            this.tablaDetalle.Controls.Add(this.totalTagValueLabel, 2, 0);
            this.tablaDetalle.Controls.Add(this.SeConEnSegundos, 4, 0);
            this.tablaDetalle.Controls.Add(this.textoPrenda, 3, 0);
            this.tablaDetalle.Controls.Add(this.grupoCronometro, 5, 0);
            this.tablaDetalle.Controls.Add(this.autonomous_CB, 1, 0);
            this.tablaDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaDetalle.Location = new System.Drawing.Point(3, 470);
            this.tablaDetalle.Name = "tablaDetalle";
            this.tablaDetalle.RowCount = 1;
            this.tablaDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablaDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tablaDetalle.Size = new System.Drawing.Size(1402, 111);
            this.tablaDetalle.TabIndex = 120;
            // 
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.readButton.FlatAppearance.BorderSize = 0;
            this.readButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(4, 4);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(552, 103);
            this.readButton.TabIndex = 0;
            this.readButton.Tag = "Start Reading";
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.totalTagValueLabel.AutoSize = true;
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagValueLabel.ForeColor = System.Drawing.Color.Red;
            this.totalTagValueLabel.Location = new System.Drawing.Point(976, 40);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(0, 31);
            this.totalTagValueLabel.TabIndex = 53;
            this.totalTagValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SeConEnSegundos
            // 
            this.SeConEnSegundos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SeConEnSegundos.AutoSize = true;
            this.SeConEnSegundos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeConEnSegundos.Location = new System.Drawing.Point(1145, 76);
            this.SeConEnSegundos.Name = "SeConEnSegundos";
            this.SeConEnSegundos.Size = new System.Drawing.Size(111, 34);
            this.SeConEnSegundos.TabIndex = 60;
            this.SeConEnSegundos.Text = "¡Se contó en tan solo 5 seg!";
            this.SeConEnSegundos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SeConEnSegundos.Visible = false;
            // 
            // textoPrenda
            // 
            this.textoPrenda.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textoPrenda.AutoSize = true;
            this.textoPrenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoPrenda.ForeColor = System.Drawing.Color.Red;
            this.textoPrenda.Location = new System.Drawing.Point(983, 40);
            this.textoPrenda.Name = "textoPrenda";
            this.textoPrenda.Size = new System.Drawing.Size(61, 31);
            this.textoPrenda.TabIndex = 54;
            this.textoPrenda.Text = "Pds";
            this.textoPrenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grupoCronometro
            // 
            this.grupoCronometro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grupoCronometro.Controls.Add(this.m0Cronometro);
            this.grupoCronometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupoCronometro.Location = new System.Drawing.Point(1276, 30);
            this.grupoCronometro.Margin = new System.Windows.Forms.Padding(0);
            this.grupoCronometro.Name = "grupoCronometro";
            this.grupoCronometro.Padding = new System.Windows.Forms.Padding(0);
            this.grupoCronometro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grupoCronometro.Size = new System.Drawing.Size(109, 50);
            this.grupoCronometro.TabIndex = 58;
            this.grupoCronometro.TabStop = false;
            this.grupoCronometro.Text = "Tiempo";
            // 
            // autonomous_CB
            // 
            this.autonomous_CB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.autonomous_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autonomous_CB.Location = new System.Drawing.Point(575, 26);
            this.autonomous_CB.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.autonomous_CB.Name = "autonomous_CB";
            this.autonomous_CB.Padding = new System.Windows.Forms.Padding(0);
            this.autonomous_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autonomous_CB.Size = new System.Drawing.Size(259, 59);
            this.autonomous_CB.TabIndex = 57;
            this.autonomous_CB.TabStop = false;
            this.autonomous_CB.Text = "Estado de las Antenas";
            // 
            // FormSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 584);
            this.Controls.Add(this.tablaTablaCompartativa);
            this.Name = "FormSalida";
            this.Text = "Validar salida";
            this.Load += new System.EventHandler(this.FormSalida_Load);
            this.Resize += new System.EventHandler(this.FormSalida_Resize);
            this.tablaContenedor.ResumeLayout(false);
            this.tablaContenedor.PerformLayout();
            this.detalleRta.ResumeLayout(false);
            this.detalleRta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faltaLectura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_etiquetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MatriculaFaltante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NoCoinciden)).EndInit();
            this.tablaMsnError.ResumeLayout(false);
            this.tablaMsnError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoMensaje)).EndInit();
            this.tablaTablaCompartativa.ResumeLayout(false);
            this.tablaDetalle.ResumeLayout(false);
            this.tablaDetalle.PerformLayout();
            this.grupoCronometro.ResumeLayout(false);
            this.grupoCronometro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerCronome_tro;
        private System.Windows.Forms.Label m0Cronometro;
        private System.Windows.Forms.TableLayoutPanel tablaContenedor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel detalleRta;
        private System.Windows.Forms.Label rfidFaltaMatricula;
        private System.Windows.Forms.Label rfidFaltaLectura;
        private System.Windows.Forms.DataGridView dgv_faltaLectura;
        private System.Windows.Forms.DataGridView dgv_etiquetas;
        private System.Windows.Forms.Label rfidMatriculada;
        private System.Windows.Forms.DataGridView dgv_MatriculaFaltante;
        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tablaTablaCompartativa;
        private System.Windows.Forms.TableLayoutPanel tablaDetalle;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Label totalTagValueLabel;
        private System.Windows.Forms.Label SeConEnSegundos;
        private System.Windows.Forms.Label textoPrenda;
        private System.Windows.Forms.GroupBox grupoCronometro;
        private System.Windows.Forms.GroupBox autonomous_CB;
        private System.Windows.Forms.TableLayoutPanel tablaMsnError;
        private System.Windows.Forms.PictureBox iconoMensaje;
        private System.Windows.Forms.Label MensajeError;
        internal System.Windows.Forms.ListView inventoryList;
        private System.Windows.Forms.ColumnHeader id_rfid;
        private System.Windows.Forms.ColumnHeader op;
        private System.Windows.Forms.ColumnHeader hoja_marcacion;
        private System.Windows.Forms.ColumnHeader corte;
        private System.Windows.Forms.ColumnHeader subcorte;
        private System.Windows.Forms.ColumnHeader talla;
        private System.Windows.Forms.ColumnHeader color;
        private System.Windows.Forms.Label rfidNoCoincideMatricula;
        private System.Windows.Forms.DataGridView dgv_NoCoinciden;
    }
}