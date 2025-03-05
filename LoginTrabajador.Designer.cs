using System;
using System.Drawing;
using System.Windows.Forms;

namespace RFIDPrendas
{
    partial class LoginTrabajador
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnLogin;
        private Label lblTitulo;
        private LinkLabel linkNuevoUsuario;
        private PictureBox iconUsuario;
        private PictureBox iconPassword;
        private Panel panelUsuario;
        private Panel panelContraseña;
        private Panel panelFondo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginTrabajador));
            this.panelFondo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.iconUsuario = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.iconPassword = new System.Windows.Forms.PictureBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.panelContraseña = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkNuevoUsuario = new System.Windows.Forms.LinkLabel();
            this.panelFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFondo
            // 
            this.panelFondo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFondo.Controls.Add(this.lblTitulo);
            this.panelFondo.Controls.Add(this.iconUsuario);
            this.panelFondo.Controls.Add(this.txtUsuario);
            this.panelFondo.Controls.Add(this.panelUsuario);
            this.panelFondo.Controls.Add(this.iconPassword);
            this.panelFondo.Controls.Add(this.txtContraseña);
            this.panelFondo.Controls.Add(this.panelContraseña);
            this.panelFondo.Controls.Add(this.btnLogin);
            this.panelFondo.Controls.Add(this.linkNuevoUsuario);
            this.panelFondo.Location = new System.Drawing.Point(0, 0);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(320, 400);
            this.panelFondo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitulo.Location = new System.Drawing.Point(40, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(210, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Iniciar Sessión";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconUsuario
            // 
            this.iconUsuario.Image = ((System.Drawing.Image)(resources.GetObject("iconUsuario.Image")));
            this.iconUsuario.Location = new System.Drawing.Point(40, 90);
            this.iconUsuario.Name = "iconUsuario";
            this.iconUsuario.Size = new System.Drawing.Size(24, 24);
            this.iconUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconUsuario.TabIndex = 1;
            this.iconUsuario.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 14F);
            this.txtUsuario.ForeColor = System.Drawing.Color.Gray;
            this.txtUsuario.Location = new System.Drawing.Point(70, 90);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(180, 22);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Text = "Usuario";
            this.txtUsuario.Enter += new System.EventHandler(this.TxtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.TxtUsuario_Leave);
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelUsuario.Location = new System.Drawing.Point(70, 120);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(180, 2);
            this.panelUsuario.TabIndex = 3;
            // 
            // iconPassword
            // 
            this.iconPassword.Image = ((System.Drawing.Image)(resources.GetObject("iconPassword.Image")));
            this.iconPassword.Location = new System.Drawing.Point(40, 140);
            this.iconPassword.Name = "iconPassword";
            this.iconPassword.Size = new System.Drawing.Size(24, 24);
            this.iconPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPassword.TabIndex = 4;
            this.iconPassword.TabStop = false;
            // 
            // txtContraseña
            // 
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font = new System.Drawing.Font("Arial", 14F);
            this.txtContraseña.ForeColor = System.Drawing.Color.Gray;
            this.txtContraseña.Location = new System.Drawing.Point(70, 140);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(180, 22);
            this.txtContraseña.TabIndex = 5;
            this.txtContraseña.Text = "Contraseña";
            this.txtContraseña.Enter += new System.EventHandler(this.TxtContraseña_Enter);
            this.txtContraseña.Leave += new System.EventHandler(this.TxtContraseña_Leave);
            // 
            // panelContraseña
            // 
            this.panelContraseña.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelContraseña.Location = new System.Drawing.Point(70, 170);
            this.panelContraseña.Name = "panelContraseña";
            this.panelContraseña.Size = new System.Drawing.Size(180, 2);
            this.panelContraseña.TabIndex = 6;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(70, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 40);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "INGRESAR";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // linkNuevoUsuario
            // 
            this.linkNuevoUsuario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.linkNuevoUsuario.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.linkNuevoUsuario.Location = new System.Drawing.Point(90, 260);
            this.linkNuevoUsuario.Name = "linkNuevoUsuario";
            this.linkNuevoUsuario.Size = new System.Drawing.Size(160, 20);
            this.linkNuevoUsuario.TabIndex = 8;
            this.linkNuevoUsuario.TabStop = true;
            this.linkNuevoUsuario.Text = "Crear nuevo usuario";
            // 
            // LoginTrabajador
            // 
            this.ClientSize = new System.Drawing.Size(321, 402);
            this.Controls.Add(this.panelFondo);
            this.Name = "LoginTrabajador";
            this.panelFondo.ResumeLayout(false);
            this.panelFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
