
namespace RFIDPrendas
{
    partial class FormTrabajador
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
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClave = new System.Windows.Forms.Label();
            this.ucTextBox = new System.Windows.Forms.TextBox();
            this.ucPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(262, 135);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(148, 47);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Tag = "Clear";
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOk.ForeColor = System.Drawing.Color.White;
            this.ButtonOk.Location = new System.Drawing.Point(115, 135);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(131, 47);
            this.ButtonOk.TabIndex = 2;
            this.ButtonOk.Tag = "Retrieve";
            this.ButtonOk.Text = "Aceptar";
            this.ButtonOk.UseVisualStyleBackColor = false;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 31);
            this.label1.TabIndex = 18;
            this.label1.Text = "Código Trabajador :";
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.Location = new System.Drawing.Point(118, 67);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(159, 31);
            this.labelClave.TabIndex = 20;
            this.labelClave.Text = "Password :";
            // 
            // ucTextBox
            // 
            this.ucTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ucTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.ucTextBox.Location = new System.Drawing.Point(287, 13);
            this.ucTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucTextBox.Name = "ucTextBox";
            this.ucTextBox.Size = new System.Drawing.Size(180, 38);
            this.ucTextBox.TabIndex = 19;
            this.ucTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucTextBox_KeyDown);
            // 
            // ucPassword
            // 
            this.ucPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPassword.ForeColor = System.Drawing.Color.DimGray;
            this.ucPassword.Location = new System.Drawing.Point(287, 60);
            this.ucPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucPassword.Name = "ucPassword";
            this.ucPassword.PasswordChar = '*';
            this.ucPassword.Size = new System.Drawing.Size(180, 38);
            this.ucPassword.TabIndex = 21;
            // 
            // FormTrabajador
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(484, 212);
            this.Controls.Add(this.ucPassword);
            this.Controls.Add(this.ucTextBox);
            this.Controls.Add(this.labelClave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.ButtonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingreso Trabajador";
            this.Shown += new System.EventHandler(this.FormTrabajador_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.TextBox ucTextBox;
        private System.Windows.Forms.TextBox ucPassword;
    }
}