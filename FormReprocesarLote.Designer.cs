namespace RFIDPrendas
{
    partial class FormReprocesarLote
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
            this.tbFormHM = new System.Windows.Forms.TableLayoutPanel();
            this.tbContentMatricula = new System.Windows.Forms.TableLayoutPanel();
            this.labelOp = new System.Windows.Forms.Label();
            this.textOp = new System.Windows.Forms.TextBox();
            this.labelHM = new System.Windows.Forms.Label();
            this.textHM = new System.Windows.Forms.TextBox();
            this.btnSaveMatricula = new System.Windows.Forms.Button();
            this.dGVReprocesarCaja = new System.Windows.Forms.DataGridView();
            this._nro_op_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._nro_HM_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timerCronome_tro = new System.Windows.Forms.Timer(this.components);
            this.tbContMatHM.SuspendLayout();
            this.tbFormHM.SuspendLayout();
            this.tbContentMatricula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVReprocesarCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // tbContMatHM
            // 
            this.tbContMatHM.ColumnCount = 1;
            this.tbContMatHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContMatHM.Controls.Add(this.tbFormHM, 0, 0);
            this.tbContMatHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContMatHM.Location = new System.Drawing.Point(0, 0);
            this.tbContMatHM.Name = "tbContMatHM";
            this.tbContMatHM.RowCount = 1;
            this.tbContMatHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContMatHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbContMatHM.Size = new System.Drawing.Size(1370, 584);
            this.tbContMatHM.TabIndex = 2;
            // 
            // tbFormHM
            // 
            this.tbFormHM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFormHM.BackgroundImage = global::RFIDPrendas.Properties.Resources.salida_embalaje_2;
            this.tbFormHM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbFormHM.ColumnCount = 2;
            this.tbFormHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbFormHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbFormHM.Controls.Add(this.tbContentMatricula, 0, 0);
            this.tbFormHM.Controls.Add(this.dGVReprocesarCaja, 1, 0);
            this.tbFormHM.Location = new System.Drawing.Point(0, 0);
            this.tbFormHM.Margin = new System.Windows.Forms.Padding(0);
            this.tbFormHM.Name = "tbFormHM";
            this.tbFormHM.RowCount = 1;
            this.tbFormHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbFormHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbFormHM.Size = new System.Drawing.Size(1370, 584);
            this.tbFormHM.TabIndex = 4;
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
            this.tbContentMatricula.Size = new System.Drawing.Size(675, 574);
            this.tbContentMatricula.TabIndex = 1;
            // 
            // labelOp
            // 
            this.labelOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOp.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelOp.Location = new System.Drawing.Point(13, 10);
            this.labelOp.Name = "labelOp";
            this.labelOp.Size = new System.Drawing.Size(256, 166);
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
            this.labelHM.Location = new System.Drawing.Point(13, 176);
            this.labelHM.Name = "labelHM";
            this.labelHM.Size = new System.Drawing.Size(256, 166);
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
            this.textHM.Location = new System.Drawing.Point(277, 181);
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
            this.btnSaveMatricula.Location = new System.Drawing.Point(13, 345);
            this.btnSaveMatricula.Name = "btnSaveMatricula";
            this.btnSaveMatricula.Size = new System.Drawing.Size(649, 216);
            this.btnSaveMatricula.TabIndex = 4;
            this.btnSaveMatricula.Text = "Des-Matricular";
            this.btnSaveMatricula.UseVisualStyleBackColor = false;
            this.btnSaveMatricula.Click += new System.EventHandler(this.BtnSaveMatricula_Click);
            // 
            // dGVReprocesarCaja
            // 
            this.dGVReprocesarCaja.AllowUserToAddRows = false;
            this.dGVReprocesarCaja.AllowUserToDeleteRows = false;
            this.dGVReprocesarCaja.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dGVReprocesarCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVReprocesarCaja.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dGVReprocesarCaja.BackgroundColor = System.Drawing.Color.White;
            this.dGVReprocesarCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVReprocesarCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._nro_op_,
            this._nro_HM_,
            this._fecha});
            this.dGVReprocesarCaja.Location = new System.Drawing.Point(827, 3);
            this.dGVReprocesarCaja.Name = "dGVReprocesarCaja";
            this.dGVReprocesarCaja.Size = new System.Drawing.Size(400, 150);
            this.dGVReprocesarCaja.TabIndex = 2;
            // 
            // _nro_op_
            // 
            this._nro_op_.HeaderText = "OP";
            this._nro_op_.Name = "_nro_op_";
            // 
            // _nro_HM_
            // 
            this._nro_HM_.HeaderText = "HM";
            this._nro_HM_.Name = "_nro_HM_";
            // 
            // _fecha
            // 
            this._fecha.HeaderText = "Fecha";
            this._fecha.Name = "_fecha";
            // 
            // accessBackgroundWorker
            // 
            this.accessBackgroundWorker.WorkerReportsProgress = true;
            // 
            // timerCronome_tro
            // 
            this.timerCronome_tro.Interval = 1000;
            // 
            // FormReprocesarLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 584);
            this.Controls.Add(this.tbContMatHM);
            this.Name = "FormReprocesarLote";
            this.Text = "FormReprocesarLote";
            this.Load += new System.EventHandler(this.FormReprocesarLote_Load);
            this.Resize += new System.EventHandler(this.FormReprocesarLote_Resize);
            this.tbContMatHM.ResumeLayout(false);
            this.tbFormHM.ResumeLayout(false);
            this.tbContentMatricula.ResumeLayout(false);
            this.tbContentMatricula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVReprocesarCaja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbContMatHM;
        private System.Windows.Forms.TableLayoutPanel tbFormHM;
        private System.Windows.Forms.TableLayoutPanel tbContentMatricula;
        private System.Windows.Forms.Label labelOp;
        private System.Windows.Forms.TextBox textOp;
        private System.Windows.Forms.Label labelHM;
        private System.Windows.Forms.TextBox textHM;
        private System.Windows.Forms.Button btnSaveMatricula;
        internal System.ComponentModel.BackgroundWorker accessBackgroundWorker;
        private System.Windows.Forms.Timer timerCronome_tro;
        private System.Windows.Forms.DataGridView dGVReprocesarCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nro_op_;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nro_HM_;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fecha;
    }
}