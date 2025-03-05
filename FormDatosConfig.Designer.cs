
namespace RFIDPrendas
{
    partial class FormDatosConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatosConfig));
            this.Segundos = new System.Windows.Forms.Label();
            this.Sensibilidad = new System.Windows.Forms.Label();
            this.VerCronometro = new System.Windows.Forms.Label();
            this.textBoxSegundos = new System.Windows.Forms.TextBox();
            this.textBoxSensibilidad = new System.Windows.Forms.TextBox();
            this.checkBox1VerCronometro = new System.Windows.Forms.CheckBox();
            this.button1GuardarConfiguracion = new System.Windows.Forms.Button();
            this.button1Configuracioninicial = new System.Windows.Forms.Button();
            this.label1Conexion = new System.Windows.Forms.Label();
            this.checkBox1Conexion = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ipReader = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Segundos
            // 
            this.Segundos.AutoSize = true;
            this.Segundos.Location = new System.Drawing.Point(13, 29);
            this.Segundos.Name = "Segundos";
            this.Segundos.Size = new System.Drawing.Size(81, 13);
            this.Segundos.TabIndex = 0;
            this.Segundos.Text = "Tiempo Maximo";
            // 
            // Sensibilidad
            // 
            this.Sensibilidad.AutoSize = true;
            this.Sensibilidad.Location = new System.Drawing.Point(13, 69);
            this.Sensibilidad.Name = "Sensibilidad";
            this.Sensibilidad.Size = new System.Drawing.Size(63, 13);
            this.Sensibilidad.TabIndex = 1;
            this.Sensibilidad.Text = "Sensibilidad";
            // 
            // VerCronometro
            // 
            this.VerCronometro.AutoSize = true;
            this.VerCronometro.Location = new System.Drawing.Point(13, 109);
            this.VerCronometro.Name = "VerCronometro";
            this.VerCronometro.Size = new System.Drawing.Size(80, 13);
            this.VerCronometro.TabIndex = 2;
            this.VerCronometro.Text = "Ver Cronometro";
            // 
            // textBoxSegundos
            // 
            this.textBoxSegundos.Location = new System.Drawing.Point(105, 21);
            this.textBoxSegundos.Name = "textBoxSegundos";
            this.textBoxSegundos.Size = new System.Drawing.Size(100, 20);
            this.textBoxSegundos.TabIndex = 3;
            // 
            // textBoxSensibilidad
            // 
            this.textBoxSensibilidad.Location = new System.Drawing.Point(105, 61);
            this.textBoxSensibilidad.Name = "textBoxSensibilidad";
            this.textBoxSensibilidad.Size = new System.Drawing.Size(100, 20);
            this.textBoxSensibilidad.TabIndex = 4;
            // 
            // checkBox1VerCronometro
            // 
            this.checkBox1VerCronometro.AutoSize = true;
            this.checkBox1VerCronometro.Location = new System.Drawing.Point(105, 109);
            this.checkBox1VerCronometro.Name = "checkBox1VerCronometro";
            this.checkBox1VerCronometro.Size = new System.Drawing.Size(15, 14);
            this.checkBox1VerCronometro.TabIndex = 5;
            this.checkBox1VerCronometro.UseVisualStyleBackColor = true;
            // 
            // button1GuardarConfiguracion
            // 
            this.button1GuardarConfiguracion.Location = new System.Drawing.Point(182, 307);
            this.button1GuardarConfiguracion.Name = "button1GuardarConfiguracion";
            this.button1GuardarConfiguracion.Size = new System.Drawing.Size(75, 23);
            this.button1GuardarConfiguracion.TabIndex = 9;
            this.button1GuardarConfiguracion.Text = "Guardar";
            this.button1GuardarConfiguracion.UseVisualStyleBackColor = true;
            this.button1GuardarConfiguracion.Click += new System.EventHandler(this.button1GuardarConfiguracion_Click);
            // 
            // button1Configuracioninicial
            // 
            this.button1Configuracioninicial.Location = new System.Drawing.Point(13, 307);
            this.button1Configuracioninicial.Name = "button1Configuracioninicial";
            this.button1Configuracioninicial.Size = new System.Drawing.Size(117, 23);
            this.button1Configuracioninicial.TabIndex = 7;
            this.button1Configuracioninicial.Text = "Configuración Inicial";
            this.button1Configuracioninicial.UseVisualStyleBackColor = true;
            this.button1Configuracioninicial.Click += new System.EventHandler(this.button1Configuracioninicial_Click);
            // 
            // label1Conexion
            // 
            this.label1Conexion.AutoSize = true;
            this.label1Conexion.Location = new System.Drawing.Point(16, 140);
            this.label1Conexion.Name = "label1Conexion";
            this.label1Conexion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1Conexion.Size = new System.Drawing.Size(81, 13);
            this.label1Conexion.TabIndex = 8;
            this.label1Conexion.Text = "Editar Conexión";
            // 
            // checkBox1Conexion
            // 
            this.checkBox1Conexion.AutoSize = true;
            this.checkBox1Conexion.Location = new System.Drawing.Point(105, 138);
            this.checkBox1Conexion.Name = "checkBox1Conexion";
            this.checkBox1Conexion.Size = new System.Drawing.Size(15, 14);
            this.checkBox1Conexion.TabIndex = 6;
            this.checkBox1Conexion.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP Reader";
            // 
            // ipReader
            // 
            this.ipReader.Location = new System.Drawing.Point(105, 168);
            this.ipReader.Name = "ipReader";
            this.ipReader.Size = new System.Drawing.Size(100, 20);
            this.ipReader.TabIndex = 11;
            this.ipReader.TextChanged += new System.EventHandler(this.IpReader_TextChanged);
            // 
            // FormDatosConfig
            // 
            this.AcceptButton = this.button1GuardarConfiguracion;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 348);
            this.Controls.Add(this.ipReader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1Conexion);
            this.Controls.Add(this.label1Conexion);
            this.Controls.Add(this.button1Configuracioninicial);
            this.Controls.Add(this.button1GuardarConfiguracion);
            this.Controls.Add(this.checkBox1VerCronometro);
            this.Controls.Add(this.textBoxSensibilidad);
            this.Controls.Add(this.textBoxSegundos);
            this.Controls.Add(this.VerCronometro);
            this.Controls.Add(this.Sensibilidad);
            this.Controls.Add(this.Segundos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDatosConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos Configurables";
            this.Load += new System.EventHandler(this.FormDatosConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Segundos;
        private System.Windows.Forms.Label Sensibilidad;
        private System.Windows.Forms.Label VerCronometro;
        private System.Windows.Forms.TextBox textBoxSegundos;
        private System.Windows.Forms.TextBox textBoxSensibilidad;
        private System.Windows.Forms.CheckBox checkBox1VerCronometro;
        private System.Windows.Forms.Button button1GuardarConfiguracion;
        private System.Windows.Forms.Button button1Configuracioninicial;
        private System.Windows.Forms.Label label1Conexion;
        private System.Windows.Forms.CheckBox checkBox1Conexion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipReader;
    }
}