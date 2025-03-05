using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDPrendas
{
    public partial class FormMessageBox : Form
    {
        private bool isError = false;
        public FormMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            this.Text = title;
            this.Size = new Size(800, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Padding = new Padding(20);
            //this.BackColor = Color.DarkSeaGreen; // Fondo dependiendo del tipo de mensaje


            // Configurar el PictureBox para el icono
            PictureBox iconBox = new PictureBox()
            {
                Location = new Point(40, 40),
                Size = new Size(64, 64), // Tamaño del icono
                BackColor = Color.Transparent,
                Image = null, // Inicialmente sin imagen
                SizeMode = PictureBoxSizeMode.StretchImage // Asegura que la imagen se estire para llenar el PictureBox
            };

            // Añadir el ícono adecuado
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    iconBox.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Warning:
                    iconBox.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageBoxIcon.Error:
                    isError = true;
                    iconBox.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MessageBoxIcon.Question:
                    iconBox.Image = SystemIcons.Question.ToBitmap();
                    break;
            }

            this.Controls.Add(iconBox);

            if (isError)
            {
                this.BackColor = Color.Red; // Fondo rojo para mensajes de error
            }
            else
            {
                this.BackColor = Color.DarkSeaGreen; // Fondo verde oscuro para otros mensajes
            }


            Label messageLabel = new Label()
            {
                Text = message,
                Font = new Font("Arial", 24, FontStyle.Regular), // Tamaño de letra más grande
                ForeColor = isError ? Color.White : Color.Black, // Color del texto
                AutoSize = true,
                Location = new Point(120, 40), // Ajuste de la posición del texto
                MaximumSize = new Size(600, 0) // Ancho máximo ajustado
            };
            this.Controls.Add(messageLabel);

            // Configurar el panel para los botones
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(20), // Espaciado más amplio
                Dock = DockStyle.Bottom,
                AutoSize = true,
                BackColor = this.BackColor
                //Height = 100, // Altura mayor para los botones
                
            };
            this.Controls.Add(buttonPanel);

            // Añadir botones según la configuración
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    AddButton(buttonPanel, "Aceptar", DialogResult.OK);
                    break;

                case MessageBoxButtons.OKCancel:
                    AddButton(buttonPanel, "Cancelar", DialogResult.Cancel);
                    AddButton(buttonPanel, "Aceptar", DialogResult.OK);
                    break;

                case MessageBoxButtons.YesNo:
                    AddButton(buttonPanel, "No", DialogResult.No);
                    AddButton(buttonPanel, "Si", DialogResult.Yes);
                    break;

                case MessageBoxButtons.YesNoCancel:
                    AddButton(buttonPanel, "Cancelar", DialogResult.Cancel);
                    AddButton(buttonPanel, "No", DialogResult.No);
                    AddButton(buttonPanel, "Si", DialogResult.Yes);
                    break;

                case MessageBoxButtons.RetryCancel:
                    AddButton(buttonPanel, "Cancelar", DialogResult.Cancel);
                    AddButton(buttonPanel, "Reintentar", DialogResult.Retry);
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    AddButton(buttonPanel, "Ignorar", DialogResult.Ignore);
                    AddButton(buttonPanel, "Reintentar", DialogResult.Retry);
                    AddButton(buttonPanel, "Abortar", DialogResult.Abort);
                    break;
            }
        }

        private void AddButton(FlowLayoutPanel panel, string text, DialogResult dialogResult)
        {
            Button button = new Button()
            {
                Text = text,
                DialogResult = dialogResult,
                AutoSize = true,
                Font = new Font("Arial", 18, FontStyle.Bold), // Tamaño de letra del botón más grande
                Padding = new Padding(20), // Espaciado del botón más amplio
                Margin = new Padding(10,10,10,10) // Margen entre los botones
            };
            button.Click += (sender, e) => { this.DialogResult = dialogResult; this.Close(); };
            panel.Controls.Add(button);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            using (FormMessageBox msgBox = new FormMessageBox(message, title, buttons, icon))
            {
                return msgBox.ShowDialog();
            }
        }        
    }
}
