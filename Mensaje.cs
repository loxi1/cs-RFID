using System;
using System.Drawing;
using System.Windows.Forms;

namespace RFIDPrendas
{
    class Mensaje
    {
        // Método para cambiar el texto y estilo del label
        public void SetMessage(Label mnsj, string messageType, string msn)
        {
            mnsj.Text = msn;
            mnsj.Visible = true;
            switch (messageType.ToLower())
            {
                case "ok":
                    mnsj.ForeColor = Color.Green;
                    SetBackgroundImage(mnsj, Properties.Resources.icon_ok);
                    break;
                case "admiracion":
                    mnsj.ForeColor = Color.Orange;
                    SetBackgroundImage(mnsj, Properties.Resources.icon_admiracion);
                    break;
                case "cancelar":
                    mnsj.ForeColor = Color.Red;
                    SetBackgroundImage(mnsj, Properties.Resources.icon_error);
                    break;
                default:
                    mnsj.Visible = false;
                    mnsj.ForeColor = Color.Black;
                    break;
            }
        }

        private void SetBackgroundImage(Label mnsj, Image image)
        {
            try
            {
                int dimension = mnsj.Height;
                // Crear una nueva imagen redimensionada
                Image resizedImage = new Bitmap(image, new Size(dimension, dimension));

                // Establecer la nueva imagen redimensionada como fondo
                mnsj.BackgroundImage = resizedImage;
                mnsj.BackgroundImageLayout = ImageLayout.None;
                // Alinea la imagen a la derecha
                mnsj.TextAlign = ContentAlignment.MiddleLeft; // Alinea el texto a la izquierda
                mnsj.Padding = new System.Windows.Forms.Padding(dimension + 10, 0, dimension + 10, 0);  // Alineación con espacio a la derecha

                mnsj.AutoSize = true;
                //mnsj.BackgroundImageLayout = ImageLayout.Stretch;  // Para estirar la imagen en el Label
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }
        }
    }
}
