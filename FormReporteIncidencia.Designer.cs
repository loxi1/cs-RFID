
using System;

namespace RFIDPrendas
{
    partial class FormReporteIncidencia
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
            this.labelMsnReporte = new System.Windows.Forms.Label();
            this.labelBuscarReporte = new System.Windows.Forms.Label();
            this.FechaReporte = new System.Windows.Forms.DateTimePicker();
            this.BTNBuscar = new System.Windows.Forms.Button();
            this.BTNLimpiar = new System.Windows.Forms.Button();
            this.CodigoEmpleado = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.875F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(332, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.432433F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.56757F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(465, 444);
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
            this.dataGridViewReporte.Size = new System.Drawing.Size(459, 405);
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
            this.labelTituloReporte.Size = new System.Drawing.Size(459, 33);
            this.labelTituloReporte.TabIndex = 8;
            this.labelTituloReporte.Text = "Reporte";
            this.labelTituloReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.labelMsnReporte, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelBuscarReporte, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.FechaReporte, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.BTNBuscar, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.BTNLimpiar, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.CodigoEmpleado, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.16981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.83019F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(323, 444);
            this.tableLayoutPanel3.TabIndex = 1;
            this.tableLayoutPanel3.Resize += new System.EventHandler(this.tableLayoutPanel3_Resize);
            // 
            // labelMsnReporte
            // 
            this.labelMsnReporte.AutoSize = true;
            this.labelMsnReporte.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel3.SetColumnSpan(this.labelMsnReporte, 2);
            this.labelMsnReporte.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelMsnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.labelMsnReporte.ForeColor = System.Drawing.Color.Red;
            this.labelMsnReporte.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelMsnReporte.Location = new System.Drawing.Point(3, 424);
            this.labelMsnReporte.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelMsnReporte.Name = "labelMsnReporte";
            this.labelMsnReporte.Size = new System.Drawing.Size(317, 20);
            this.labelMsnReporte.TabIndex = 11;
            // 
            // labelBuscarReporte
            // 
            this.labelBuscarReporte.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.labelBuscarReporte, 2);
            this.labelBuscarReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBuscarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuscarReporte.Location = new System.Drawing.Point(3, 0);
            this.labelBuscarReporte.Name = "labelBuscarReporte";
            this.labelBuscarReporte.Size = new System.Drawing.Size(317, 25);
            this.labelBuscarReporte.TabIndex = 1;
            this.labelBuscarReporte.Text = "Buscar:";
            this.labelBuscarReporte.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FechaReporte
            // 
            this.FechaReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FechaReporte.CustomFormat = "dd-MM-yyyy";
            this.FechaReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaReporte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaReporte.Location = new System.Drawing.Point(166, 30);
            this.FechaReporte.Margin = new System.Windows.Forms.Padding(5);
            this.FechaReporte.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.FechaReporte.Name = "FechaReporte";
            this.FechaReporte.Size = new System.Drawing.Size(152, 23);
            this.FechaReporte.TabIndex = 6;
            this.FechaReporte.Value = new System.DateTime(2024, 9, 6, 0, 0, 0, 0);
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNBuscar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BTNBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNBuscar.ForeColor = System.Drawing.Color.White;
            this.BTNBuscar.Location = new System.Drawing.Point(3, 56);
            this.BTNBuscar.Name = "BTNBuscar";
            this.BTNBuscar.Size = new System.Drawing.Size(155, 130);
            this.BTNBuscar.TabIndex = 7;
            this.BTNBuscar.Text = "Buscar";
            this.BTNBuscar.UseVisualStyleBackColor = false;
            this.BTNBuscar.Click += new System.EventHandler(this.BTNBuscar_Click);
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNLimpiar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BTNLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNLimpiar.ForeColor = System.Drawing.Color.White;
            this.BTNLimpiar.Location = new System.Drawing.Point(164, 56);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(156, 130);
            this.BTNLimpiar.TabIndex = 10;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = false;
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // CodigoEmpleado
            // 
            this.CodigoEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CodigoEmpleado.Location = new System.Drawing.Point(5, 30);
            this.CodigoEmpleado.Margin = new System.Windows.Forms.Padding(5);
            this.CodigoEmpleado.Name = "CodigoEmpleado";
            this.CodigoEmpleado.Size = new System.Drawing.Size(151, 20);
            this.CodigoEmpleado.TabIndex = 12;
            this.CodigoEmpleado.Text = "030658";
            // 
            // FormReporteIncidencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormReporteIncidencia";
            this.Text = "Reporte de Incidencia";
            this.Load += new System.EventHandler(this.FormReporteIncidencia_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelTituloReporte;
        private System.Windows.Forms.DataGridView dataGridViewReporte;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelBuscarReporte;
        private System.Windows.Forms.DateTimePicker FechaReporte;
        private System.Windows.Forms.Button BTNBuscar;
        private System.Windows.Forms.Button BTNLimpiar;
        private System.Windows.Forms.Label labelMsnReporte;
        private System.Windows.Forms.TextBox CodigoEmpleado;
    }
}