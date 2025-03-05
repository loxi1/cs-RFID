
namespace RFIDPrendas
{
    partial class FormLogin
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucTextBoxPassword = new RFIDPrendas.UCTextBox();
            this.ucTextBoxUsuario = new RFIDPrendas.UCTextBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.ForeColor = System.Drawing.Color.White;
            this.buttonOk.Location = new System.Drawing.Point(150, 137);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(106, 37);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Aceptar";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            this.buttonOk.Enter += new System.EventHandler(this.buttonOk_Enter);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(264, 137);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(106, 37);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña";
            // 
            // ucTextBoxPassword
            // 
            this.ucTextBoxPassword.BackColor = System.Drawing.SystemColors.Window;
            this.ucTextBoxPassword.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ucTextBoxPassword.BorderFocusColor = System.Drawing.Color.YellowGreen;
            this.ucTextBoxPassword.BorderSize = 2;
            this.ucTextBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTextBoxPassword.ForeColor = System.Drawing.Color.DimGray;
            this.ucTextBoxPassword.Location = new System.Drawing.Point(120, 81);
            this.ucTextBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.ucTextBoxPassword.Multiline = false;
            this.ucTextBoxPassword.Name = "ucTextBoxPassword";
            this.ucTextBoxPassword.Padding = new System.Windows.Forms.Padding(7);
            this.ucTextBoxPassword.PasswordChar = true;
            this.ucTextBoxPassword.PlaceHolderText = null;
            this.ucTextBoxPassword.Size = new System.Drawing.Size(250, 31);
            this.ucTextBoxPassword.TabIndex = 1;
            this.ucTextBoxPassword.UnderlinedStyle = false;
            this.ucTextBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // ucTextBoxUsuario
            // 
            this.ucTextBoxUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.ucTextBoxUsuario.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ucTextBoxUsuario.BorderFocusColor = System.Drawing.Color.YellowGreen;
            this.ucTextBoxUsuario.BorderSize = 2;
            this.ucTextBoxUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTextBoxUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.ucTextBoxUsuario.Location = new System.Drawing.Point(120, 33);
            this.ucTextBoxUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.ucTextBoxUsuario.Multiline = false;
            this.ucTextBoxUsuario.Name = "ucTextBoxUsuario";
            this.ucTextBoxUsuario.Padding = new System.Windows.Forms.Padding(7);
            this.ucTextBoxUsuario.PasswordChar = false;
            this.ucTextBoxUsuario.PlaceHolderText = null;
            this.ucTextBoxUsuario.Size = new System.Drawing.Size(250, 31);
            this.ucTextBoxUsuario.TabIndex = 0;
            this.ucTextBoxUsuario.UnderlinedStyle = false;
            this.ucTextBoxUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(396, 200);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.ucTextBoxPassword);
            this.Controls.Add(this.ucTextBoxUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso al Sistema";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCTextBox ucTextBoxUsuario;
        private UCTextBox ucTextBoxPassword;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}