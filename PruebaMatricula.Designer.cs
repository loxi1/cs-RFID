using System;
using System.Windows.Forms;

namespace RFIDPrendas
{
    public partial class PruebaMatricula : Form
    {
        public PruebaMatricula()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ReportaIncidente = new System.Windows.Forms.Button();
            this.autonomous_CB = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutMatricula = new System.Windows.Forms.TableLayoutPanel();
            this.labelOp = new System.Windows.Forms.Label();
            this.textOp = new System.Windows.Forms.TextBox();
            this.labelHM = new System.Windows.Forms.Label();
            this.textHM = new System.Windows.Forms.TextBox();
            this.btnSaveMatricula = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.totalTagValueLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnIncidente = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelCronometro = new System.Windows.Forms.Panel();
            this.labelTiempo = new System.Windows.Forms.Label();
            this.groupBoxTiempo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutMatricula.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panelCronometro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.readButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 681);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(783, 547);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(414, 131);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.ReportaIncidente, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.autonomous_CB, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(408, 125);
            this.tableLayoutPanel5.TabIndex = 1;
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
            this.ReportaIncidente.Size = new System.Drawing.Size(198, 31);
            this.ReportaIncidente.TabIndex = 50;
            this.ReportaIncidente.Text = "INCIDENTE";
            this.ReportaIncidente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ReportaIncidente.UseVisualStyleBackColor = false;
            this.ReportaIncidente.Visible = false;
            // 
            // autonomous_CB
            // 
            this.autonomous_CB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autonomous_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autonomous_CB.Location = new System.Drawing.Point(10, 60);
            this.autonomous_CB.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.autonomous_CB.Name = "autonomous_CB";
            this.autonomous_CB.Padding = new System.Windows.Forms.Padding(0);
            this.autonomous_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autonomous_CB.Size = new System.Drawing.Size(194, 65);
            this.autonomous_CB.TabIndex = 42;
            this.autonomous_CB.TabStop = false;
            this.autonomous_CB.Text = "Estado de las Antenas";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(207, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "!CONTO EN TAN SOLO X SEG¡";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(204, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 88);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 86);
            this.label2.TabIndex = 0;
            this.label2.Text = "00:00:00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // readButton
            // 
            this.readButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.readButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.readButton.ForeColor = System.Drawing.Color.White;
            this.readButton.Location = new System.Drawing.Point(3, 547);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(774, 131);
            this.readButton.TabIndex = 1;
            this.readButton.Text = "Iniciar";
            this.readButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(774, 538);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutMatricula, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(783, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(414, 538);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutMatricula
            // 
            this.tableLayoutMatricula.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutMatricula.ColumnCount = 2;
            this.tableLayoutMatricula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutMatricula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutMatricula.Controls.Add(this.labelOp, 0, 0);
            this.tableLayoutMatricula.Controls.Add(this.textOp, 1, 0);
            this.tableLayoutMatricula.Controls.Add(this.labelHM, 0, 1);
            this.tableLayoutMatricula.Controls.Add(this.textHM, 1, 1);
            this.tableLayoutMatricula.Controls.Add(this.btnSaveMatricula, 0, 2);
            this.tableLayoutMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMatricula.Location = new System.Drawing.Point(10, 413);
            this.tableLayoutMatricula.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutMatricula.Name = "tableLayoutMatricula";
            this.tableLayoutMatricula.RowCount = 3;
            this.tableLayoutMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutMatricula.Size = new System.Drawing.Size(394, 115);
            this.tableLayoutMatricula.TabIndex = 0;
            // 
            // labelOp
            // 
            this.labelOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOp.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelOp.Location = new System.Drawing.Point(3, 0);
            this.labelOp.Name = "labelOp";
            this.labelOp.Size = new System.Drawing.Size(151, 34);
            this.labelOp.TabIndex = 0;
            this.labelOp.Text = "OP:";
            this.labelOp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textOp
            // 
            this.textOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOp.Font = new System.Drawing.Font("Arial", 10F);
            this.textOp.Location = new System.Drawing.Point(162, 5);
            this.textOp.Margin = new System.Windows.Forms.Padding(5);
            this.textOp.Name = "textOp";
            this.textOp.Size = new System.Drawing.Size(227, 23);
            this.textOp.TabIndex = 1;
            // 
            // labelHM
            // 
            this.labelHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelHM.Location = new System.Drawing.Point(3, 34);
            this.labelHM.Name = "labelHM";
            this.labelHM.Size = new System.Drawing.Size(151, 34);
            this.labelHM.TabIndex = 2;
            this.labelHM.Text = "HM:";
            this.labelHM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textHM
            // 
            this.textHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textHM.Font = new System.Drawing.Font("Arial", 10F);
            this.textHM.Location = new System.Drawing.Point(162, 39);
            this.textHM.Margin = new System.Windows.Forms.Padding(5);
            this.textHM.Name = "textHM";
            this.textHM.Size = new System.Drawing.Size(227, 23);
            this.textHM.TabIndex = 3;
            // 
            // btnSaveMatricula
            // 
            this.btnSaveMatricula.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tableLayoutMatricula.SetColumnSpan(this.btnSaveMatricula, 2);
            this.btnSaveMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMatricula.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveMatricula.ForeColor = System.Drawing.Color.White;
            this.btnSaveMatricula.Location = new System.Drawing.Point(3, 71);
            this.btnSaveMatricula.Name = "btnSaveMatricula";
            this.btnSaveMatricula.Size = new System.Drawing.Size(388, 41);
            this.btnSaveMatricula.TabIndex = 4;
            this.btnSaveMatricula.Text = "Asignar";
            this.btnSaveMatricula.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.totalTagValueLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label13, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(408, 397);
            this.tableLayoutPanel6.TabIndex = 1;
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
            this.totalTagValueLabel.Size = new System.Drawing.Size(204, 397);
            this.totalTagValueLabel.TabIndex = 50;
            this.totalTagValueLabel.Text = "150";
            this.totalTagValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(207, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 31);
            this.label13.TabIndex = 49;
            this.label13.Text = "Pds";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIncidente
            // 
            this.btnIncidente.Location = new System.Drawing.Point(0, 0);
            this.btnIncidente.Name = "btnIncidente";
            this.btnIncidente.Size = new System.Drawing.Size(75, 23);
            this.btnIncidente.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Location = new System.Drawing.Point(0, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(100, 23);
            this.labelTitulo.TabIndex = 0;
            // 
            // panelCronometro
            // 
            this.panelCronometro.BackColor = System.Drawing.Color.LightCoral;
            this.panelCronometro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCronometro.Controls.Add(this.labelTiempo);
            this.panelCronometro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCronometro.Location = new System.Drawing.Point(0, 0);
            this.panelCronometro.Name = "panelCronometro";
            this.panelCronometro.Size = new System.Drawing.Size(200, 100);
            this.panelCronometro.TabIndex = 0;
            // 
            // labelTiempo
            // 
            this.labelTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTiempo.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.labelTiempo.ForeColor = System.Drawing.Color.Black;
            this.labelTiempo.Location = new System.Drawing.Point(0, 0);
            this.labelTiempo.Name = "labelTiempo";
            this.labelTiempo.Size = new System.Drawing.Size(200, 100);
            this.labelTiempo.TabIndex = 0;
            this.labelTiempo.Text = "00:00:00";
            this.labelTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxTiempo
            // 
            this.groupBoxTiempo.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTiempo.Name = "groupBoxTiempo";
            this.groupBoxTiempo.Size = new System.Drawing.Size(200, 100);
            this.groupBoxTiempo.TabIndex = 0;
            this.groupBoxTiempo.TabStop = false;
            // 
            // PruebaMatricula
            // 
            this.ClientSize = new System.Drawing.Size(1200, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PruebaMatricula";
            this.Text = "Prueba Matricula";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutMatricula.ResumeLayout(false);
            this.tableLayoutMatricula.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.panelCronometro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutMatricula;
        private Button readButton;
        private Button btnIncidente;
        private Button btnSaveMatricula;
        private Label labelTitulo;
        private Label labelTiempo;
        private Label labelOp;
        private Label labelHM;
        private Panel panelCronometro;
        private TextBox textOp;
        private TextBox textHM;
        private PictureBox pictureBox1;
        private GroupBox groupBoxTiempo;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private GroupBox autonomous_CB;
        private Button ReportaIncidente;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label13;
        private Label totalTagValueLabel;
    }
}
