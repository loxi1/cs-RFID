
namespace RFIDPrendas
{
    partial class FormConsultas
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
            this.label1CodigoTrabajador = new System.Windows.Forms.Label();
            this.label1Clave = new System.Windows.Forms.Label();
            this.label1Respuesta = new System.Windows.Forms.Label();
            this.button1Login = new System.Windows.Forms.Button();
            this.textBoxCodTrabajador = new System.Windows.Forms.TextBox();
            this.textBoxClave = new System.Windows.Forms.TextBox();
            this.rta_1 = new System.Windows.Forms.Label();
            this.rta_2 = new System.Windows.Forms.Label();
            this.rta_3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1CodigoTrabajador
            // 
            this.label1CodigoTrabajador.AutoSize = true;
            this.label1CodigoTrabajador.Location = new System.Drawing.Point(13, 22);
            this.label1CodigoTrabajador.Name = "label1CodigoTrabajador";
            this.label1CodigoTrabajador.Size = new System.Drawing.Size(115, 13);
            this.label1CodigoTrabajador.TabIndex = 4;
            this.label1CodigoTrabajador.Text = "Código de Trabajador :";
            // 
            // label1Clave
            // 
            this.label1Clave.AutoSize = true;
            this.label1Clave.Location = new System.Drawing.Point(16, 55);
            this.label1Clave.Name = "label1Clave";
            this.label1Clave.Size = new System.Drawing.Size(40, 13);
            this.label1Clave.TabIndex = 5;
            this.label1Clave.Text = "Clave :";
            // 
            // label1Respuesta
            // 
            this.label1Respuesta.AutoSize = true;
            this.label1Respuesta.Location = new System.Drawing.Point(19, 90);
            this.label1Respuesta.Name = "label1Respuesta";
            this.label1Respuesta.Size = new System.Drawing.Size(64, 13);
            this.label1Respuesta.TabIndex = 6;
            this.label1Respuesta.Text = "Respuesta :";
            // 
            // button1Login
            // 
            this.button1Login.Location = new System.Drawing.Point(182, 313);
            this.button1Login.Name = "button1Login";
            this.button1Login.Size = new System.Drawing.Size(75, 23);
            this.button1Login.TabIndex = 3;
            this.button1Login.Text = "Login";
            this.button1Login.UseVisualStyleBackColor = true;
            this.button1Login.Click += new System.EventHandler(this.button1Login_Click);
            // 
            // textBoxCodTrabajador
            // 
            this.textBoxCodTrabajador.Location = new System.Drawing.Point(135, 19);
            this.textBoxCodTrabajador.Name = "textBoxCodTrabajador";
            this.textBoxCodTrabajador.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodTrabajador.TabIndex = 0;
            // 
            // textBoxClave
            // 
            this.textBoxClave.Location = new System.Drawing.Point(135, 49);
            this.textBoxClave.Name = "textBoxClave";
            this.textBoxClave.Size = new System.Drawing.Size(100, 20);
            this.textBoxClave.TabIndex = 1;
            // 
            // rta_1
            // 
            this.rta_1.AutoSize = true;
            this.rta_1.Location = new System.Drawing.Point(135, 89);
            this.rta_1.Name = "rta_1";
            this.rta_1.Size = new System.Drawing.Size(34, 13);
            this.rta_1.TabIndex = 7;
            this.rta_1.Text = ".........";
            // 
            // rta_2
            // 
            this.rta_2.AutoSize = true;
            this.rta_2.Location = new System.Drawing.Point(135, 115);
            this.rta_2.Name = "rta_2";
            this.rta_2.Size = new System.Drawing.Size(34, 13);
            this.rta_2.TabIndex = 8;
            this.rta_2.Text = ".........";
            // 
            // rta_3
            // 
            this.rta_3.AutoSize = true;
            this.rta_3.Location = new System.Drawing.Point(135, 141);
            this.rta_3.Name = "rta_3";
            this.rta_3.Size = new System.Drawing.Size(34, 13);
            this.rta_3.TabIndex = 9;
            this.rta_3.Text = ".........";
            // 
            // FormConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 348);
            this.Controls.Add(this.rta_3);
            this.Controls.Add(this.rta_2);
            this.Controls.Add(this.rta_1);
            this.Controls.Add(this.textBoxClave);
            this.Controls.Add(this.textBoxCodTrabajador);
            this.Controls.Add(this.button1Login);
            this.Controls.Add(this.label1Respuesta);
            this.Controls.Add(this.label1Clave);
            this.Controls.Add(this.label1CodigoTrabajador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormConsultas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1CodigoTrabajador;
        private System.Windows.Forms.Label label1Clave;
        private System.Windows.Forms.Label label1Respuesta;
        private System.Windows.Forms.Button button1Login;
        private System.Windows.Forms.TextBox textBoxCodTrabajador;
        private System.Windows.Forms.TextBox textBoxClave;
        private System.Windows.Forms.Label rta_1;
        private System.Windows.Forms.Label rta_2;
        private System.Windows.Forms.Label rta_3;
    }
}