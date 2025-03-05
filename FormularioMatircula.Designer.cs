namespace RFIDPrendas
{
    partial class FormularioMatircula
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelCronometro = new System.Windows.Forms.Panel();
            this.labelTiempo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelCronometro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelCronometro, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.Black;
            this.labelTitulo.Location = new System.Drawing.Point(3, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(294, 39);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "TAN SOLO X SEG";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCronometro
            // 
            this.panelCronometro.BackColor = System.Drawing.Color.LightCoral;
            this.panelCronometro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCronometro.Controls.Add(this.labelTiempo);
            this.panelCronometro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCronometro.Location = new System.Drawing.Point(0, 39);
            this.panelCronometro.Margin = new System.Windows.Forms.Padding(0);
            this.panelCronometro.Name = "panelCronometro";
            this.panelCronometro.Size = new System.Drawing.Size(300, 91);
            this.panelCronometro.TabIndex = 1;
            // 
            // labelTiempo
            // 
            this.labelTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTiempo.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.labelTiempo.ForeColor = System.Drawing.Color.Black;
            this.labelTiempo.Location = new System.Drawing.Point(0, 0);
            this.labelTiempo.Name = "labelTiempo";
            this.labelTiempo.Size = new System.Drawing.Size(298, 89);
            this.labelTiempo.TabIndex = 0;
            this.labelTiempo.Text = "00:00";
            this.labelTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormularioMatircula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioMatircula";
            this.Text = "Cronometro";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelCronometro.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panelCronometro;
        private System.Windows.Forms.Label labelTiempo;
    }

    #endregion   
}