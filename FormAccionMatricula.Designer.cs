namespace RFIDPrendas
{
    partial class FormAccionMatricula
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
            this.tbContConfirmacion = new System.Windows.Forms.TableLayoutPanel();
            this.TituloAviso = new System.Windows.Forms.Label();
            this.DescripcionAviso = new System.Windows.Forms.Label();
            this.FranjaAbajo = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVoverAContar = new System.Windows.Forms.Button();
            this.btnIncidente = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbContConfirmacion.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbContConfirmacion
            // 
            this.tbContConfirmacion.ColumnCount = 1;
            this.tbContConfirmacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContConfirmacion.Controls.Add(this.TituloAviso, 0, 1);
            this.tbContConfirmacion.Controls.Add(this.DescripcionAviso, 0, 2);
            this.tbContConfirmacion.Controls.Add(this.FranjaAbajo, 0, 4);
            this.tbContConfirmacion.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tbContConfirmacion.Controls.Add(this.pictureBox1, 0, 0);
            this.tbContConfirmacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContConfirmacion.Location = new System.Drawing.Point(0, 0);
            this.tbContConfirmacion.Name = "tbContConfirmacion";
            this.tbContConfirmacion.RowCount = 5;
            this.tbContConfirmacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tbContConfirmacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tbContConfirmacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tbContConfirmacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tbContConfirmacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tbContConfirmacion.Size = new System.Drawing.Size(454, 311);
            this.tbContConfirmacion.TabIndex = 4;
            // 
            // TituloAviso
            // 
            this.TituloAviso.AutoSize = true;
            this.TituloAviso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TituloAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TituloAviso.Location = new System.Drawing.Point(3, 150);
            this.TituloAviso.Name = "TituloAviso";
            this.TituloAviso.Size = new System.Drawing.Size(448, 50);
            this.TituloAviso.TabIndex = 1;
            this.TituloAviso.Text = "¿Está correcto el conteo?";
            this.TituloAviso.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DescripcionAviso
            // 
            this.DescripcionAviso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescripcionAviso.AutoSize = true;
            this.DescripcionAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescripcionAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DescripcionAviso.Location = new System.Drawing.Point(79, 216);
            this.DescripcionAviso.Name = "DescripcionAviso";
            this.DescripcionAviso.Size = new System.Drawing.Size(295, 22);
            this.DescripcionAviso.TabIndex = 2;
            this.DescripcionAviso.Text = "Elija una de las siguientes opciones";
            this.DescripcionAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FranjaAbajo
            // 
            this.FranjaAbajo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FranjaAbajo.ColumnCount = 1;
            this.FranjaAbajo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FranjaAbajo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FranjaAbajo.Location = new System.Drawing.Point(0, 306);
            this.FranjaAbajo.Margin = new System.Windows.Forms.Padding(0);
            this.FranjaAbajo.Name = "FranjaAbajo";
            this.FranjaAbajo.RowCount = 1;
            this.FranjaAbajo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FranjaAbajo.Size = new System.Drawing.Size(454, 5);
            this.FranjaAbajo.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.btnAceptar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnVoverAContar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnIncidente, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 255);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(454, 50);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(13, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnAceptar.Size = new System.Drawing.Size(87, 40);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Si, Ok";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // btnVoverAContar
            // 
            this.btnVoverAContar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVoverAContar.AutoSize = true;
            this.btnVoverAContar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoverAContar.Location = new System.Drawing.Point(119, 5);
            this.btnVoverAContar.Name = "btnVoverAContar";
            this.btnVoverAContar.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnVoverAContar.Size = new System.Drawing.Size(192, 40);
            this.btnVoverAContar.TabIndex = 1;
            this.btnVoverAContar.Text = "No, Volver a contar";
            this.btnVoverAContar.UseVisualStyleBackColor = true;
            this.btnVoverAContar.Click += new System.EventHandler(this.BtnVoverAContar_Click);
            // 
            // btnIncidente
            // 
            this.btnIncidente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIncidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncidente.Location = new System.Drawing.Point(324, 5);
            this.btnIncidente.Name = "btnIncidente";
            this.btnIncidente.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnIncidente.Size = new System.Drawing.Size(122, 40);
            this.btnIncidente.TabIndex = 2;
            this.btnIncidente.Text = "Incidente";
            this.btnIncidente.UseVisualStyleBackColor = true;
            this.btnIncidente.Click += new System.EventHandler(this.BtnIncidente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(177, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FormAccionMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 311);
            this.Controls.Add(this.tbContConfirmacion);
            this.Name = "FormAccionMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAccionMatricula";
            this.Load += new System.EventHandler(this.FormAccionMatricula_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAccionMatricula_KeyDown);
            this.tbContConfirmacion.ResumeLayout(false);
            this.tbContConfirmacion.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tbContConfirmacion;
        internal System.Windows.Forms.Label TituloAviso;
        internal System.Windows.Forms.Label DescripcionAviso;
        internal System.Windows.Forms.TableLayoutPanel FranjaAbajo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVoverAContar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIncidente;
    }
}