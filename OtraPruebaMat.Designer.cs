using System.Drawing;
using System.Windows.Forms;

namespace RFIDPrendas
{
    partial class OtraPruebaMat
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
            this.tbContMatHM = new System.Windows.Forms.TableLayoutPanel();
            this.readButton = new System.Windows.Forms.Button();
            this.tbContentNumPrendas = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.tbFormHM = new System.Windows.Forms.TableLayoutPanel();
            this.tbContentMatricula = new System.Windows.Forms.TableLayoutPanel();
            this.labelOp = new System.Windows.Forms.Label();
            this.textOp = new System.Windows.Forms.TextBox();
            this.labelHM = new System.Windows.Forms.Label();
            this.textHM = new System.Windows.Forms.TextBox();
            this.btnSaveMatricula = new System.Windows.Forms.Button();
            this.tbContCronoEstados = new System.Windows.Forms.TableLayoutPanel();
            this.tbContentEstados = new System.Windows.Forms.TableLayoutPanel();
            this.ReportaIncidente = new System.Windows.Forms.Button();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.tbContentCronometro = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelCronometro = new System.Windows.Forms.Panel();
            this.labelTiempo = new System.Windows.Forms.Label();
            this.tbContMatHM.SuspendLayout();
            this.tbContentNumPrendas.SuspendLayout();
            this.tbFormHM.SuspendLayout();
            this.tbContentMatricula.SuspendLayout();
            this.tbContCronoEstados.SuspendLayout();
            this.tbContentEstados.SuspendLayout();
            this.tbContentCronometro.SuspendLayout();
            this.panelCronometro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbContMatHM
            // 
            this.tbContMatHM.ColumnCount = 2;
            this.tbContMatHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tbContMatHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tbContMatHM.Controls.Add(this.readButton, 0, 1);
            this.tbContMatHM.Controls.Add(this.tbContentNumPrendas, 0, 0);
            this.tbContMatHM.Controls.Add(this.tbFormHM, 1, 0);
            this.tbContMatHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContMatHM.Location = new System.Drawing.Point(0, 0);
            this.tbContMatHM.Name = "tbContMatHM";
            this.tbContMatHM.RowCount = 2;
            this.tbContMatHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tbContMatHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tbContMatHM.Size = new System.Drawing.Size(1220, 753);
            this.tbContMatHM.TabIndex = 0;
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
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(0, 414);
            this.readButton.Margin = new System.Windows.Forms.Padding(0);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(549, 339);
            this.readButton.TabIndex = 2;
            this.readButton.Tag = "Start Reading";
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            // 
            // tbContentNumPrendas
            // 
            this.tbContentNumPrendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContentNumPrendas.ColumnCount = 2;
            this.tbContentNumPrendas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tbContentNumPrendas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tbContentNumPrendas.Controls.Add(this.label13, 0, 0);
            this.tbContentNumPrendas.Controls.Add(this.totalTagValueLabel, 0, 0);
            this.tbContentNumPrendas.Location = new System.Drawing.Point(3, 3);
            this.tbContentNumPrendas.Name = "tbContentNumPrendas";
            this.tbContentNumPrendas.RowCount = 1;
            this.tbContentNumPrendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentNumPrendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 408F));
            this.tbContentNumPrendas.Size = new System.Drawing.Size(543, 408);
            this.tbContentNumPrendas.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(350, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 31);
            this.label13.TabIndex = 49;
            this.label13.Text = "Pds";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTagValueLabel
            // 
            this.totalTagValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalTagValueLabel.AutoSize = true;
            this.totalTagValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagValueLabel.ForeColor = System.Drawing.Color.Red;
            this.totalTagValueLabel.Location = new System.Drawing.Point(0, 0);
            this.totalTagValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.totalTagValueLabel.Name = "totalTagValueLabel";
            this.totalTagValueLabel.Size = new System.Drawing.Size(347, 408);
            this.totalTagValueLabel.TabIndex = 48;
            this.totalTagValueLabel.Text = "0";
            this.totalTagValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFormHM
            // 
            this.tbFormHM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFormHM.BackgroundImage = global::RFIDPrendas.Properties.Resources.salida_embalaje_2;
            this.tbFormHM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbFormHM.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbFormHM.ColumnCount = 1;
            this.tbFormHM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbFormHM.Controls.Add(this.tbContentMatricula, 0, 0);
            this.tbFormHM.Controls.Add(this.tbContCronoEstados, 0, 1);
            this.tbFormHM.Location = new System.Drawing.Point(549, 0);
            this.tbFormHM.Margin = new System.Windows.Forms.Padding(0);
            this.tbFormHM.Name = "tbFormHM";
            this.tbFormHM.RowCount = 2;
            this.tbContMatHM.SetRowSpan(this.tbFormHM, 2);
            this.tbFormHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbFormHM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbFormHM.Size = new System.Drawing.Size(671, 753);
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
            this.tbContentMatricula.Location = new System.Drawing.Point(6, 6);
            this.tbContentMatricula.Margin = new System.Windows.Forms.Padding(5);
            this.tbContentMatricula.Name = "tbContentMatricula";
            this.tbContentMatricula.Padding = new System.Windows.Forms.Padding(10);
            this.tbContentMatricula.RowCount = 3;
            this.tbContentMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbContentMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbContentMatricula.Size = new System.Drawing.Size(659, 590);
            this.tbContentMatricula.TabIndex = 1;
            // 
            // labelOp
            // 
            this.labelOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOp.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelOp.Location = new System.Drawing.Point(13, 10);
            this.labelOp.Name = "labelOp";
            this.labelOp.Size = new System.Drawing.Size(249, 171);
            this.labelOp.TabIndex = 0;
            this.labelOp.Text = "OP:";
            this.labelOp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textOp
            // 
            this.textOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOp.Font = new System.Drawing.Font("Arial", 10F);
            this.textOp.Location = new System.Drawing.Point(270, 15);
            this.textOp.Margin = new System.Windows.Forms.Padding(5);
            this.textOp.Name = "textOp";
            this.textOp.Size = new System.Drawing.Size(374, 23);
            this.textOp.TabIndex = 1;
            // 
            // labelHM
            // 
            this.labelHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelHM.Location = new System.Drawing.Point(13, 181);
            this.labelHM.Name = "labelHM";
            this.labelHM.Size = new System.Drawing.Size(249, 171);
            this.labelHM.TabIndex = 2;
            this.labelHM.Text = "HM:";
            this.labelHM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textHM
            // 
            this.textHM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textHM.Font = new System.Drawing.Font("Arial", 10F);
            this.textHM.Location = new System.Drawing.Point(270, 186);
            this.textHM.Margin = new System.Windows.Forms.Padding(5);
            this.textHM.Name = "textHM";
            this.textHM.Size = new System.Drawing.Size(374, 23);
            this.textHM.TabIndex = 3;
            // 
            // btnSaveMatricula
            // 
            this.btnSaveMatricula.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tbContentMatricula.SetColumnSpan(this.btnSaveMatricula, 2);
            this.btnSaveMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveMatricula.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnSaveMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMatricula.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnSaveMatricula.ForeColor = System.Drawing.Color.White;
            this.btnSaveMatricula.Location = new System.Drawing.Point(13, 355);
            this.btnSaveMatricula.Name = "btnSaveMatricula";
            this.btnSaveMatricula.Size = new System.Drawing.Size(633, 222);
            this.btnSaveMatricula.TabIndex = 4;
            this.btnSaveMatricula.Text = "Asignar";
            this.btnSaveMatricula.UseVisualStyleBackColor = false;
            // 
            // tbContCronoEstados
            // 
            this.tbContCronoEstados.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbContCronoEstados.ColumnCount = 2;
            this.tbContCronoEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbContCronoEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbContCronoEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbContCronoEstados.Controls.Add(this.tbContentEstados, 1, 0);
            this.tbContCronoEstados.Controls.Add(this.tbContentCronometro, 0, 0);
            this.tbContCronoEstados.Location = new System.Drawing.Point(4, 605);
            this.tbContCronoEstados.Name = "tbContCronoEstados";
            this.tbContCronoEstados.RowCount = 1;
            this.tbContCronoEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContCronoEstados.Size = new System.Drawing.Size(606, 143);
            this.tbContCronoEstados.TabIndex = 0;
            // 
            // tbContentEstados
            // 
            this.tbContentEstados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContentEstados.ColumnCount = 1;
            this.tbContentEstados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentEstados.Controls.Add(this.ReportaIncidente, 0, 0);
            this.tbContentEstados.Controls.Add(this.autonomous_CB, 0, 1);
            this.tbContentEstados.Location = new System.Drawing.Point(306, 4);
            this.tbContentEstados.Name = "tbContentEstados";
            this.tbContentEstados.RowCount = 3;
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbContentEstados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tbContentEstados.Size = new System.Drawing.Size(296, 135);
            this.tbContentEstados.TabIndex = 3;
            // 
            // ReportaIncidente
            // 
            this.ReportaIncidente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportaIncidente.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ReportaIncidente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportaIncidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportaIncidente.ForeColor = System.Drawing.Color.White;
            this.ReportaIncidente.Location = new System.Drawing.Point(3, 3);
            this.ReportaIncidente.Name = "ReportaIncidente";
            this.ReportaIncidente.Size = new System.Drawing.Size(290, 27);
            this.ReportaIncidente.TabIndex = 50;
            this.ReportaIncidente.Text = "⚠️ INCIDENTE";
            this.ReportaIncidente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ReportaIncidente.UseVisualStyleBackColor = false;
            // 
            // autonomous_CB
            // 
            this.autonomous_CB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autonomous_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autonomous_CB.Location = new System.Drawing.Point(10, 55);
            this.autonomous_CB.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.autonomous_CB.Name = "autonomous_CB";
            this.autonomous_CB.Padding = new System.Windows.Forms.Padding(0);
            this.autonomous_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autonomous_CB.Size = new System.Drawing.Size(102, 65);
            this.autonomous_CB.TabIndex = 42;
            this.autonomous_CB.TabStop = false;
            this.autonomous_CB.Text = "Estado de las Antenas";
            // 
            // tbContentCronometro
            // 
            this.tbContentCronometro.ColumnCount = 1;
            this.tbContentCronometro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbContentCronometro.Controls.Add(this.labelTitulo, 0, 0);
            this.tbContentCronometro.Controls.Add(this.panelCronometro, 0, 1);
            this.tbContentCronometro.Location = new System.Drawing.Point(4, 4);
            this.tbContentCronometro.Name = "tbContentCronometro";
            this.tbContentCronometro.RowCount = 3;
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbContentCronometro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tbContentCronometro.Size = new System.Drawing.Size(288, 135);
            this.tbContentCronometro.TabIndex = 2;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.Black;
            this.labelTitulo.Location = new System.Drawing.Point(3, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(282, 33);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "¡Se contó en tan solo 5 seg!";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCronometro
            // 
            this.panelCronometro.BackColor = System.Drawing.Color.DarkRed;
            this.panelCronometro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCronometro.Controls.Add(this.labelTiempo);
            this.panelCronometro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCronometro.Location = new System.Drawing.Point(0, 33);
            this.panelCronometro.Margin = new System.Windows.Forms.Padding(0);
            this.panelCronometro.Name = "panelCronometro";
            this.panelCronometro.Size = new System.Drawing.Size(288, 87);
            this.panelCronometro.TabIndex = 1;
            // 
            // labelTiempo
            // 
            this.labelTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTiempo.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.labelTiempo.ForeColor = System.Drawing.Color.Black;
            this.labelTiempo.Location = new System.Drawing.Point(0, 0);
            this.labelTiempo.Name = "labelTiempo";
            this.labelTiempo.Size = new System.Drawing.Size(286, 85);
            this.labelTiempo.TabIndex = 0;
            this.labelTiempo.Text = "00:00:00";
            this.labelTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OtraPruebaMat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1220, 753);
            this.Controls.Add(this.tbContMatHM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "OtraPruebaMat";
            this.ShowIcon = false;
            this.Text = "OtraPruebaMat";
            this.Load += new System.EventHandler(this.OtraPruebaMat_Load);
            this.Resize += new System.EventHandler(this.OtraPruebaMat_Resize);
            this.tbContMatHM.ResumeLayout(false);
            this.tbContentNumPrendas.ResumeLayout(false);
            this.tbContentNumPrendas.PerformLayout();
            this.tbFormHM.ResumeLayout(false);
            this.tbContentMatricula.ResumeLayout(false);
            this.tbContentMatricula.PerformLayout();
            this.tbContCronoEstados.ResumeLayout(false);
            this.tbContentEstados.ResumeLayout(false);
            this.tbContentCronometro.ResumeLayout(false);
            this.panelCronometro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tbContMatHM;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.TableLayoutPanel tbContentNumPrendas;
        private System.Windows.Forms.Label totalTagValueLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TableLayoutPanel tbFormHM;
        private System.Windows.Forms.TableLayoutPanel tbContCronoEstados;
        private System.Windows.Forms.TableLayoutPanel tbContentCronometro;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panelCronometro;
        private System.Windows.Forms.Label labelTiempo;
        private System.Windows.Forms.TableLayoutPanel tbContentEstados;
        private System.Windows.Forms.GroupBox autonomous_CB;
        private System.Windows.Forms.Button ReportaIncidente;
        private Label labelOp;
        private TextBox textOp;
        private Label labelHM;
        private TextBox textHM;
        private Button btnSaveMatricula;
        private TableLayoutPanel tbContentMatricula;
    }
}