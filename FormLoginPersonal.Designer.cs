namespace RFIDPrendas
{
    partial class FormLoginPersonal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoginPersonal));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.iconPassword = new System.Windows.Forms.PictureBox();
            this.iconUsuario = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucPassword = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelClave = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ucTextBox = new System.Windows.Forms.TextBox();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUsuario)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tableLayoutPanel1.Controls.Add(this.iconPassword, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.iconUsuario, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelUsuario, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelClave, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 101);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // iconPassword
            // 
            this.iconPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPassword.Image = global::RFIDPrendas.Properties.Resources.password;
            this.iconPassword.Location = new System.Drawing.Point(0, 50);
            this.iconPassword.Margin = new System.Windows.Forms.Padding(0);
            this.iconPassword.Name = "iconPassword";
            this.iconPassword.Size = new System.Drawing.Size(58, 50);
            this.iconPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPassword.TabIndex = 5;
            this.iconPassword.TabStop = false;
            // 
            // iconUsuario
            // 
            this.iconUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconUsuario.Image = global::RFIDPrendas.Properties.Resources.face_recognition;
            this.iconUsuario.Location = new System.Drawing.Point(0, 0);
            this.iconUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.iconUsuario.Name = "iconUsuario";
            this.iconUsuario.Size = new System.Drawing.Size(58, 50);
            this.iconUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconUsuario.TabIndex = 4;
            this.iconUsuario.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.ucPassword, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(196, 53);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(251, 44);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 1);
            this.panel1.TabIndex = 4;
            // 
            // ucPassword
            // 
            this.ucPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ucPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ucPassword.ForeColor = System.Drawing.Color.Gray;
            this.ucPassword.Location = new System.Drawing.Point(3, 3);
            this.ucPassword.Name = "ucPassword";
            this.ucPassword.PasswordChar = '*';
            this.ucPassword.Size = new System.Drawing.Size(245, 31);
            this.ucPassword.TabIndex = 3;
            this.ucPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UcPassword_KeyPress);
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.labelUsuario.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelUsuario.Location = new System.Drawing.Point(72, 9);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(118, 32);
            this.labelUsuario.TabIndex = 0;
            this.labelUsuario.Text = "Usuario";
            this.labelUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelClave
            // 
            this.labelClave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelClave.AutoSize = true;
            this.labelClave.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.labelClave.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelClave.Location = new System.Drawing.Point(102, 59);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(88, 32);
            this.labelClave.TabIndex = 2;
            this.labelClave.Text = "Clave";
            this.labelClave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ucTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelUsuario, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(196, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(251, 44);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ucTextBox
            // 
            this.ucTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ucTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ucTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ucTextBox.Location = new System.Drawing.Point(3, 3);
            this.ucTextBox.Name = "ucTextBox";
            this.ucTextBox.Size = new System.Drawing.Size(245, 31);
            this.ucTextBox.TabIndex = 2;
            this.ucTextBox.Text = "Ingrese su usuario...";
            this.ucTextBox.Enter += new System.EventHandler(this.UcTextBox_Enter);
            this.ucTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UcTextBox_KeyPress);
            this.ucTextBox.Leave += new System.EventHandler(this.UcTextBox_Leave);
            // 
            // panelUsuario
            // 
            this.panelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUsuario.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelUsuario.Location = new System.Drawing.Point(3, 42);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(245, 1);
            this.panelUsuario.TabIndex = 4;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(161, 3);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(140, 40);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.ButtonCancelar_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonOk.ForeColor = System.Drawing.Color.White;
            this.buttonOk.Location = new System.Drawing.Point(307, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(140, 40);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Iniciar Sesión";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelBotones.Controls.Add(this.buttonOk);
            this.panelBotones.Controls.Add(this.buttonCancelar);
            this.panelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBotones.Location = new System.Drawing.Point(27, 229);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(450, 50);
            this.panelBotones.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitulo.Location = new System.Drawing.Point(129, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(255, 40);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Iniciar Sessión";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupBox1.Location = new System.Drawing.Point(15, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(476, 286);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // FormLoginPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(507, 313);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLoginPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUsuario)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private System.Windows.Forms.TextBox ucPassword;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox ucTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.PictureBox iconUsuario;
        private System.Windows.Forms.PictureBox iconPassword;
        private System.Windows.Forms.Label lblTitulo;
        internal System.Windows.Forms.GroupBox GroupBox1;
    }
}
