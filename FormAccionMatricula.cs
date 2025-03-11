using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDPrendas
{
    public partial class FormAccionMatricula : Form
    {
        public FormMatriculaDeCajaHM m_MatCaja= null;
        public int opcionBtn { get; private set; }
        public FormAccionMatricula(FormMatriculaDeCajaHM matCajaForm)
        {
            m_MatCaja = matCajaForm;
            InitializeComponent();
        }

        private void FormAccionMatricula_Load(object sender, EventArgs e)
        {
            EstiloBoton(btnAceptar, ColoresBotones.AceptarFondo, ColoresBotones.AceptarTexto, ColoresBotones.AceptarHover);
            EstiloBoton(btnVoverAContar, ColoresBotones.VolverContarFondo, ColoresBotones.VolverContarTexto, ColoresBotones.VolverContarHover);
            EstiloBoton(btnIncidente, ColoresBotones.IncidenteFondo, ColoresBotones.IncidenteTexto, ColoresBotones.IncidenteHover);


            IniFile fileIniConfig = new IniFile();

            // Obtener la ruta de la carpeta "Ini"
            string iniDirectory = fileIniConfig.GetDirectory();

            // Nombre del archivo SVG dentro de "Ini"
            string svgFileName = "icono_exclamation_512.svg";
            string svgPath = Path.Combine(iniDirectory, svgFileName);
            FormAlerta alerta = new FormAlerta(pictureBox1, svgPath);
        }

        private void EstiloBoton(Button btn, Color colorFondo, Color colorTexto, Color colorHover)
        {
            btn.BackColor = colorFondo;
            btn.ForeColor = colorTexto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = colorHover;
            btn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            btn.Cursor = Cursors.Hand;
        }

        public static class ColoresBotones
        {
            public static readonly Color AceptarFondo = ColorTranslator.FromHtml("#3085d6");
            public static readonly Color AceptarTexto = ColorTranslator.FromHtml("#FFFFFF");
            public static readonly Color AceptarHover = ColorTranslator.FromHtml("#2b77c0");

            public static readonly Color VolverContarFondo = ColorTranslator.FromHtml("#ffc107");
            public static readonly Color VolverContarTexto = ColorTranslator.FromHtml("#212529");
            public static readonly Color VolverContarHover = ColorTranslator.FromHtml("#ffc107");

            public static readonly Color IncidenteFondo = ColorTranslator.FromHtml("#dd3333");
            public static readonly Color IncidenteTexto = ColorTranslator.FromHtml("#FFFFFF");
            public static readonly Color IncidenteHover = ColorTranslator.FromHtml("#c72e2e");
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            opcionBtn = 1;
            this.Close();
        }

        private void BtnVoverAContar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            opcionBtn = 2;
            this.Close();
        }

        private void BtnIncidente_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            opcionBtn = 3;
            this.Close();
        }

        private void FormAccionMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Control)
                        btnAceptar.PerformClick();
                    break;

                case Keys.S:
                    if (e.Control)
                        btnVoverAContar.PerformClick();
                    break;

                case Keys.D:
                    if (e.Control)
                        btnIncidente.PerformClick();
                    break;
            }
        }
    }
}
