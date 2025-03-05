using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svg;
using SharpVectors.Dom.Svg;
using SharpVectors.Renderers.Gdi;
using SvgDocument = Svg.SvgDocument;
using System.IO;

namespace RFIDPrendas
{
    public partial class FormAlerta : Form
    {
        private int conteo;
        private int conteoSegundos = 0;
        private PictureBox _icono;
        public FormAlerta(PictureBox pictureBox, string svgPath)
        {
            InitializeComponent();
            _icono = pictureBox;
            CargarIconoSVG(_icono, svgPath);
        }

        public FormAlerta(string PMensaje, int tipo)
        {
            InitializeComponent();
            MSNAlerta.Text = PMensaje;
            Color colorFondo;
            Color colorTexto = Color.White;
            Color colorBorde;

            // ✅ Ocultar los íconos por defecto y mostrar el correspondiente
            icon_error.Visible = false;
            icon_ok.Visible = false;
            icon_info.Visible = false;

            PictureBox selectedIcon = null; // Variable para el icono dinámico

            IniFile fileIniConfig = new IniFile();

            // Obtener la ruta de la carpeta "Ini"
            string iniDirectory = fileIniConfig.GetDirectory();

            // Nombre del archivo SVG dentro de "Ini"
            string svgFileName = "icono_checking_512.svg";

            switch (tipo)
            {
                case 1: // Éxito ✅
                    colorFondo = ColorTranslator.FromHtml("#2E7D32");
                    colorBorde = ColorTranslator.FromHtml("#1B5E20");
                    selectedIcon = icon_ok;
                    break;

                case 2: // Info ℹ️
                    svgFileName = "icono_exclamation_512.svg";
                    colorFondo = ColorTranslator.FromHtml("#1976D2");
                    colorBorde = ColorTranslator.FromHtml("#0D47A1");
                    selectedIcon = icon_info;
                    break;

                default: // Error ❌
                    svgFileName = "icono_error_512.svg";
                    colorFondo = ColorTranslator.FromHtml("#D32F2F");
                    colorBorde = ColorTranslator.FromHtml("#B71C1C");
                    selectedIcon = icon_error;
                    break;
            }

            // ✅ Mostrar solo el ícono seleccionado
            if (selectedIcon != null)
            {
                selectedIcon.Visible = true;

                // Construir la ruta del SVG y cargar el ícono
                string svgPath = Path.Combine(iniDirectory, svgFileName);
                CargarIconoSVG(selectedIcon, svgPath);
            }

            // Aplicar colores
            this.BackColor = colorFondo;
            MSNAlerta.ForeColor = colorTexto;
            FranjaTop.BackColor = colorBorde;


            // ✅ Ajustar el tamaño del formulario según el contenido
            int extra_padding = 40;
            this.Size = new Size(320, MSNAlerta.Height + extra_padding);
            this.MinimumSize = this.Size;
            this.MaximumSize = new Size(400, 150); // No permite que crezca demasiado

            // ✅ Bordes redondeados
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = new Region(RoundedRectangle(new Rectangle(0, 0, this.Width, this.Height), 15));

            // ✅ Fondo con mejor contraste y opacidad
            this.Opacity = 0.95;
        }

        private GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ✅ Mejoramos el fondo con un degradado más visible
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(60, 60, 60),  // Gris oscuro
                Color.FromArgb(30, 30, 30),  // Gris más oscuro
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        //Empieza conteo y se detiene en 3 segundos
        private void tiempo_Tick(object sender, EventArgs e)
        {
            conteoSegundos++; // 🔹 Aumenta en 1 cada segundo

            if (conteoSegundos >= 2) // 🔹 Cierra después de 30 segundos
            {
                this.Close(); // 🔹 Cierra el formulario
            }
        }

        //Inicializa el temporal
        private void FormAlerta_Load(object sender, EventArgs e)
        {
            conteoSegundos = 0; // 🔹 Resetea el conteo
            tiempo.Start(); // 🔹 Inicia el Timer
        }
        //Cuando se cierra el formulario
        private void FormAlerta_FormClosing(object sender, FormClosingEventArgs e)
        {
            tiempo.Stop(); // 🔹 Detiene el Timer
            tiempo.Dispose(); // 🔹 Libera recursos del Timer
        }
        /// <summary>
        /// Carga un archivo SVG en un PictureBox y lo convierte en un Bitmap.
        /// </summary>
        /// <param name="pictureBox">El PictureBox donde se mostrará el SVG.</param>
        /// <param name="svgPath">La ruta del archivo SVG.</param>
        public void CargarIconoSVG(PictureBox pictureBox, string svgPath)
        {
            if (pictureBox == null)
            {
                MessageBox.Show("❌ El PictureBox es NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(svgPath))
            {
                MessageBox.Show($"⚠️ Archivo SVG no encontrado: {svgPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (File.Exists(svgPath))
            {
                try
                {
                    SvgDocument svgDocument = SvgDocument.Open(svgPath);
                    if (svgDocument == null)
                    {
                        MessageBox.Show("⚠️ No se pudo cargar el SVG.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Renderizar el SVG como Bitmap
                    Bitmap bitmap = svgDocument.Draw();

                    // Verificar que el bitmap es válido
                    if (bitmap == null)
                    {
                        MessageBox.Show("⚠️ Error al convertir SVG a Bitmap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    pictureBox.Image = bitmap;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Ajuste de visualización
                    pictureBox.Refresh(); // Forzar actualización
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"⚠️ Error al cargar el archivo SVG.\n{ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Archivo SVG no encontrado.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
