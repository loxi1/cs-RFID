
namespace RFIDPrendas
{
    partial class FormIncidente
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
            this.TextIncidente = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.RegistrarIncidenc = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.45509F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.54491F));
            this.tableLayoutPanel1.Controls.Add(this.TextIncidente, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnGuardar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.RegistrarIncidenc, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.18518F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.81481F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(404, 162);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TextIncidente
            // 
            this.TextIncidente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextIncidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextIncidente.Location = new System.Drawing.Point(3, 59);
            this.TextIncidente.Multiline = true;
            this.TextIncidente.Name = "TextIncidente";
            this.TextIncidente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextIncidente.Size = new System.Drawing.Size(286, 100);
            this.TextIncidente.TabIndex = 0;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(295, 59);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(106, 100);
            this.BtnGuardar.TabIndex = 1;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // RegistrarIncidenc
            // 
            this.RegistrarIncidenc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RegistrarIncidenc.AutoSize = true;
            this.RegistrarIncidenc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrarIncidenc.Location = new System.Drawing.Point(3, 0);
            this.RegistrarIncidenc.Name = "RegistrarIncidenc";
            this.RegistrarIncidenc.Size = new System.Drawing.Size(275, 56);
            this.RegistrarIncidenc.TabIndex = 2;
            this.RegistrarIncidenc.Text = "Registrar Incidencia";
            this.RegistrarIncidenc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormIncidente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 162);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIncidente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Incidentes";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TextIncidente;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label RegistrarIncidenc;
    }
}