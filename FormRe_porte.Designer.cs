
using System;

namespace RFIDPrendas
{
    partial class FormRe_porte
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewReporte = new System.Windows.Forms.DataGridView();
            this.labelTituloReporte = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Op_Buscar = new System.Windows.Forms.TextBox();
            this.Marca_Buscar = new System.Windows.Forms.TextBox();
            this.NroCaja_Buscar = new System.Windows.Forms.TextBox();
            this.NroCaja_ = new System.Windows.Forms.Label();
            this.Marcacion_ = new System.Windows.Forms.Label();
            this.OP_ = new System.Windows.Forms.Label();
            this.labelBuscarReporte = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.BTNLimpiar = new System.Windows.Forms.Button();
            this.BTNBuscar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewReporte, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelTituloReporte, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(323, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.432433F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.56757F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(474, 444);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridViewReporte
            // 
            this.dataGridViewReporte.AllowUserToOrderColumns = true;
            this.dataGridViewReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReporte.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dataGridViewReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReporte.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewReporte.Location = new System.Drawing.Point(3, 36);
            this.dataGridViewReporte.Name = "dataGridViewReporte";
            this.dataGridViewReporte.Size = new System.Drawing.Size(468, 405);
            this.dataGridViewReporte.TabIndex = 9;
            // 
            // labelTituloReporte
            // 
            this.labelTituloReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTituloReporte.AutoSize = true;
            this.labelTituloReporte.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.labelTituloReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloReporte.ForeColor = System.Drawing.Color.White;
            this.labelTituloReporte.Location = new System.Drawing.Point(3, 0);
            this.labelTituloReporte.Name = "labelTituloReporte";
            this.labelTituloReporte.Size = new System.Drawing.Size(468, 33);
            this.labelTituloReporte.TabIndex = 8;
            this.labelTituloReporte.Text = "Reporte";
            this.labelTituloReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.01887F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(314, 436);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.Op_Buscar, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.Marca_Buscar, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.NroCaja_Buscar, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.NroCaja_, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.Marcacion_, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.OP_, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelBuscarReporte, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.52831F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.4717F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(308, 224);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // Op_Buscar
            // 
            this.Op_Buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Op_Buscar.Location = new System.Drawing.Point(3, 163);
            this.Op_Buscar.Name = "Op_Buscar";
            this.Op_Buscar.Size = new System.Drawing.Size(117, 20);
            this.Op_Buscar.TabIndex = 10;
            this.Op_Buscar.Text = "1000037578";
            // 
            // Marca_Buscar
            // 
            this.Marca_Buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Marca_Buscar.Location = new System.Drawing.Point(126, 163);
            this.Marca_Buscar.Name = "Marca_Buscar";
            this.Marca_Buscar.Size = new System.Drawing.Size(101, 20);
            this.Marca_Buscar.TabIndex = 8;
            // 
            // NroCaja_Buscar
            // 
            this.NroCaja_Buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.NroCaja_Buscar.Location = new System.Drawing.Point(233, 163);
            this.NroCaja_Buscar.Name = "NroCaja_Buscar";
            this.NroCaja_Buscar.Size = new System.Drawing.Size(72, 20);
            this.NroCaja_Buscar.TabIndex = 9;
            // 
            // NroCaja_
            // 
            this.NroCaja_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NroCaja_.AutoSize = true;
            this.NroCaja_.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NroCaja_.Location = new System.Drawing.Point(233, 143);
            this.NroCaja_.Name = "NroCaja_";
            this.NroCaja_.Size = new System.Drawing.Size(54, 17);
            this.NroCaja_.TabIndex = 6;
            this.NroCaja_.Text = "# Caja";
            // 
            // Marcacion_
            // 
            this.Marcacion_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Marcacion_.AutoSize = true;
            this.Marcacion_.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Marcacion_.Location = new System.Drawing.Point(126, 143);
            this.Marcacion_.Name = "Marcacion_";
            this.Marcacion_.Size = new System.Drawing.Size(82, 17);
            this.Marcacion_.TabIndex = 5;
            this.Marcacion_.Text = "Marcación";
            this.Marcacion_.Click += new System.EventHandler(this.Marcacion__Click);
            // 
            // OP_
            // 
            this.OP_.AutoSize = true;
            this.OP_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OP_.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OP_.Location = new System.Drawing.Point(3, 143);
            this.OP_.Name = "OP_";
            this.OP_.Size = new System.Drawing.Size(117, 17);
            this.OP_.TabIndex = 11;
            this.OP_.Text = "OP";
            // 
            // labelBuscarReporte
            // 
            this.labelBuscarReporte.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.labelBuscarReporte, 3);
            this.labelBuscarReporte.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelBuscarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuscarReporte.Location = new System.Drawing.Point(3, 88);
            this.labelBuscarReporte.Name = "labelBuscarReporte";
            this.labelBuscarReporte.Size = new System.Drawing.Size(302, 31);
            this.labelBuscarReporte.TabIndex = 12;
            this.labelBuscarReporte.Text = "Buscar";
            this.labelBuscarReporte.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.BTNLimpiar, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.BTNBuscar, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 233);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(308, 180);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNLimpiar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BTNLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNLimpiar.ForeColor = System.Drawing.Color.White;
            this.BTNLimpiar.Location = new System.Drawing.Point(157, 3);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(148, 92);
            this.BTNLimpiar.TabIndex = 12;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = false;
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNBuscar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BTNBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNBuscar.ForeColor = System.Drawing.Color.White;
            this.BTNBuscar.Location = new System.Drawing.Point(3, 3);
            this.BTNBuscar.Name = "BTNBuscar";
            this.BTNBuscar.Size = new System.Drawing.Size(148, 92);
            this.BTNBuscar.TabIndex = 9;
            this.BTNBuscar.Text = "Buscar";
            this.BTNBuscar.UseVisualStyleBackColor = false;
            this.BTNBuscar.Click += new System.EventHandler(this.BTNBuscar_Click);
            // 
            // FormRe_porte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRe_porte";
            this.Text = "Reporte de Incidencia";
            this.Resize += new System.EventHandler(this.FormRe_porte_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelTituloReporte;
        private System.Windows.Forms.DataGridView dataGridViewReporte;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label Marcacion_;
        private System.Windows.Forms.Label NroCaja_;
        private System.Windows.Forms.TextBox Marca_Buscar;
        private System.Windows.Forms.TextBox NroCaja_Buscar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button BTNBuscar;
        private System.Windows.Forms.Button BTNLimpiar;
        private System.Windows.Forms.TextBox Op_Buscar;
        private System.Windows.Forms.Label OP_;
        private System.Windows.Forms.Label labelBuscarReporte;
    }
}