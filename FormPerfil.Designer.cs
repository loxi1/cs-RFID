namespace RFIDPrendas
{
    partial class FormPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPerfil));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.lblDatos = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContainer.Controls.Add(this.pictureBoxIcon);
            this.panelContainer.Controls.Add(this.labelTitulo);
            this.panelContainer.Controls.Add(this.labelCodigo);
            this.panelContainer.Controls.Add(this.lblCodigo);
            this.panelContainer.Controls.Add(this.labelNombre);
            this.panelContainer.Controls.Add(this.lblDatos);
            this.panelContainer.Controls.Add(this.btnCerrar);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(420, 280);
            this.panelContainer.TabIndex = 0;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
            this.pictureBoxIcon.Location = new System.Drawing.Point(20, 20);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(100, 30);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(209, 29);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Perfil de Usuario";
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelCodigo.Location = new System.Drawing.Point(50, 110);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(70, 20);
            this.labelCodigo.TabIndex = 2;
            this.labelCodigo.Text = "Código:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCodigo.Location = new System.Drawing.Point(150, 110);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(36, 20);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "___";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelNombre.Location = new System.Drawing.Point(50, 150);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(76, 20);
            this.labelNombre.TabIndex = 4;
            this.labelNombre.Text = "Nombre:";
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDatos.Location = new System.Drawing.Point(150, 150);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(36, 20);
            this.lblDatos.TabIndex = 5;
            this.lblDatos.Text = "___";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.IndianRed;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(140, 210);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 40);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FormPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 280);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Perfil de Usuario";
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.Button btnCerrar;
    }
}
