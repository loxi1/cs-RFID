namespace RFIDPrendas
{
    partial class FormAlerta
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
            this.components = new System.ComponentModel.Container();
            this.FranjaTop = new System.Windows.Forms.Panel();
            this.icon_ok = new System.Windows.Forms.PictureBox();
            this.icon_error = new System.Windows.Forms.PictureBox();
            this.icon_info = new System.Windows.Forms.PictureBox();
            this.MSNAlerta = new System.Windows.Forms.Label();
            this.tiempo = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.icon_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_info)).BeginInit();
            this.SuspendLayout();
            // 
            // FranjaTop
            // 
            this.FranjaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.FranjaTop.Location = new System.Drawing.Point(0, 0);
            this.FranjaTop.Name = "FranjaTop";
            this.FranjaTop.Size = new System.Drawing.Size(350, 10);
            this.FranjaTop.TabIndex = 0;
            // 
            // icon_ok
            // 
            this.icon_ok.BackColor = System.Drawing.Color.Transparent;
            this.icon_ok.Location = new System.Drawing.Point(10, 15);
            this.icon_ok.Name = "icon_ok";
            this.icon_ok.Size = new System.Drawing.Size(60, 60);
            this.icon_ok.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_ok.TabIndex = 1;
            this.icon_ok.TabStop = false;
            // 
            // icon_error
            // 
            this.icon_error.BackColor = System.Drawing.Color.Transparent;
            this.icon_error.Location = new System.Drawing.Point(10, 15);
            this.icon_error.Name = "icon_error";
            this.icon_error.Size = new System.Drawing.Size(60, 60);
            this.icon_error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_error.TabIndex = 2;
            this.icon_error.TabStop = false;
            // 
            // icon_info
            // 
            this.icon_info.BackColor = System.Drawing.Color.Transparent;
            this.icon_info.Image = global::RFIDPrendas.Properties.Resources.icon_admiracion;
            this.icon_info.Location = new System.Drawing.Point(10, 15);
            this.icon_info.Name = "icon_info";
            this.icon_info.Size = new System.Drawing.Size(60, 60);
            this.icon_info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_info.TabIndex = 3;
            this.icon_info.TabStop = false;
            // 
            // MSNAlerta
            // 
            this.MSNAlerta.AutoSize = true;
            this.MSNAlerta.BackColor = System.Drawing.Color.Transparent;
            this.MSNAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.MSNAlerta.ForeColor = System.Drawing.Color.White;
            this.MSNAlerta.Location = new System.Drawing.Point(80, 20);
            this.MSNAlerta.MaximumSize = new System.Drawing.Size(260, 0);
            this.MSNAlerta.Name = "MSNAlerta";
            this.MSNAlerta.Size = new System.Drawing.Size(0, 24);
            this.MSNAlerta.TabIndex = 0;
            this.MSNAlerta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tiempo
            // 
            this.tiempo.Interval = 1000;
            this.tiempo.Tick += new System.EventHandler(this.tiempo_Tick);
            // 
            // FormAlerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(350, 90);
            this.Controls.Add(this.MSNAlerta);
            this.Controls.Add(this.icon_info);
            this.Controls.Add(this.icon_error);
            this.Controls.Add(this.icon_ok);
            this.Controls.Add(this.FranjaTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAlerta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAlerta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAlerta_FormClosing);
            this.Load += new System.EventHandler(this.FormAlerta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icon_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_info)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FranjaTop;
        private System.Windows.Forms.PictureBox icon_ok;
        private System.Windows.Forms.PictureBox icon_error;
        private System.Windows.Forms.PictureBox icon_info;
        private System.Windows.Forms.Label MSNAlerta;
        private System.Windows.Forms.Timer tiempo;
    }
}
