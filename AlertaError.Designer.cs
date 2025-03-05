namespace RFIDPrendas
{
    partial class AlertaError
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.icon_error = new System.Windows.Forms.PictureBox();
            this.TituloAviso = new System.Windows.Forms.Label();
            this.DescripcionAviso = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.FranjaAbajo = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_error)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.icon_error, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.TituloAviso, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.DescripcionAviso, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.BtnAceptar, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.FranjaAbajo, 0, 4);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 5;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(452, 263);
            this.TableLayoutPanel1.TabIndex = 2;
            // 
            // icon_error
            // 
            this.icon_error.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.icon_error.Image = global::RFIDPrendas.Properties.Resources.eliminar_90;
            this.icon_error.Location = new System.Drawing.Point(181, 18);
            this.icon_error.Margin = new System.Windows.Forms.Padding(0);
            this.icon_error.Name = "icon_error";
            this.icon_error.Size = new System.Drawing.Size(90, 90);
            this.icon_error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_error.TabIndex = 0;
            this.icon_error.TabStop = false;
            // 
            // TituloAviso
            // 
            this.TituloAviso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloAviso.AutoSize = true;
            this.TituloAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloAviso.Location = new System.Drawing.Point(179, 130);
            this.TituloAviso.Name = "TituloAviso";
            this.TituloAviso.Size = new System.Drawing.Size(93, 31);
            this.TituloAviso.TabIndex = 1;
            this.TituloAviso.Text = "Ups...";
            this.TituloAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescripcionAviso
            // 
            this.DescripcionAviso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescripcionAviso.AutoSize = true;
            this.DescripcionAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescripcionAviso.Location = new System.Drawing.Point(159, 176);
            this.DescripcionAviso.Name = "DescripcionAviso";
            this.DescripcionAviso.Size = new System.Drawing.Size(134, 22);
            this.DescripcionAviso.TabIndex = 2;
            this.DescripcionAviso.Text = "¡Algo Salio Mal!";
            this.DescripcionAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.ForeColor = System.Drawing.Color.White;
            this.BtnAceptar.Location = new System.Drawing.Point(170, 212);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(112, 41);
            this.BtnAceptar.TabIndex = 3;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // FranjaAbajo
            // 
            this.FranjaAbajo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FranjaAbajo.ColumnCount = 1;
            this.FranjaAbajo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FranjaAbajo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FranjaAbajo.Location = new System.Drawing.Point(0, 256);
            this.FranjaAbajo.Margin = new System.Windows.Forms.Padding(0);
            this.FranjaAbajo.Name = "FranjaAbajo";
            this.FranjaAbajo.RowCount = 1;
            this.FranjaAbajo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FranjaAbajo.Size = new System.Drawing.Size(452, 7);
            this.FranjaAbajo.TabIndex = 4;
            // 
            // AlertaError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 263);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlertaError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlertaError";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.PictureBox icon_error;
        internal System.Windows.Forms.Label TituloAviso;
        internal System.Windows.Forms.Label DescripcionAviso;
        internal System.Windows.Forms.Button BtnAceptar;
        internal System.Windows.Forms.TableLayoutPanel FranjaAbajo;
    }
}