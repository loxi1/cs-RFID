using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDPrendas
{
    public partial class FormConfirmacion : Form
    {
        public FormConfirmacion(PictureBox pictureBox, string svgPath)
        {
            InitializeComponent();
        }

        public FormConfirmacion(string titulo, Color PColor, string mensaje, string m_aceptar = "Sí, Desvincular", string m_cancelar = "No, Cancelar")
        {
            InitializeComponent();
            IniFile fileIniConfig = new IniFile();

            // Obtener la ruta de la carpeta "Ini"
            string iniDirectory = fileIniConfig.GetDirectory();

            // Nombre del archivo SVG dentro de "Ini"
            string svgFileName = "icono_exclamation_512.svg";
            string svgPath = Path.Combine(iniDirectory, svgFileName);
            FormAlerta alerta = new FormAlerta(pictureBox1, svgPath);

            EstiloBoton(btnAceptar, "#3085d6", "#FFFFFF", "#2b77c0");
            EstiloBoton(btnCancelar, "#dd3333", "#FFFFFF", "#c72e2e");
            TituloAviso.Text = titulo;
            DescripcionAviso.Text = mensaje;

            btnAceptar.Text = m_aceptar;
            btnCancelar.Text = m_cancelar;

            AplicarEstilos();         
        }

        private void AplicarEstilos()
        {
            // 🔹 Aplicar degradado al fondo
            this.Paint += (sender, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    this.ClientRectangle, Color.White, Color.FromArgb(230, 230, 230), LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            };

            // 🔹 Aplicar estilos a los botones
            EstiloBoton(btnAceptar, "#3085d6", "#FFFFFF", "#1f6ac1");
            EstiloBoton(btnCancelar, "#dd3333", "#FFFFFF", "#b52b2b");

            // 🔹 Aplicar estilos a los textos
            TituloAviso.ForeColor = Color.Black;
            DescripcionAviso.ForeColor = Color.FromArgb(100, 100, 100);

            // 🔹 Bordes redondeados
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void EstiloBoton(Button btn, string colorFondo, string colorTexto, string colorHover)
        {
            btn.BackColor = ColorTranslator.FromHtml(colorFondo);
            btn.ForeColor = ColorTranslator.FromHtml(colorTexto);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(colorHover);
            btn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            btn.Cursor = Cursors.Hand;
        }

        // 🔹 Método para crear bordes redondeados
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);


        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
