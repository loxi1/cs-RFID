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
    public partial class FrmIncidente : Form
    {
        public FormMatriculaDeCajaHM m_MatCaja = null;
        public string incidenteText { get; private set; }
        public FrmIncidente(FormMatriculaDeCajaHM matCajaForm)
        {
            m_MatCaja = matCajaForm;
            InitializeComponent();
            incidenteText = "";
        }

        public static class ColoresBotones
        {
            public static readonly Color AceptarFondo = ColorTranslator.FromHtml("#3085d6");
            public static readonly Color AceptarTexto = ColorTranslator.FromHtml("#FFFFFF");
            public static readonly Color AceptarHover = ColorTranslator.FromHtml("#2b77c0");

            public static readonly Color CancelarFondo = ColorTranslator.FromHtml("#dd3333");
            public static readonly Color CancelarTexto = ColorTranslator.FromHtml("#FFFFFF");
            public static readonly Color CancelarHover = ColorTranslator.FromHtml("#c72e2e");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextIncidente.Text))
            {
                AlertaError("Agregar descripción");
                return;
            }
            incidenteText = TextIncidente.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void AlertaError(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 3);
            aler_ta.ShowDialog();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmIncidente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnGuardar.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BtnCancelar.PerformClick();
            }
        }

        private void FrmIncidente_Load(object sender, EventArgs e)
        {
            EstiloBoton(BtnGuardar, ColoresBotones.AceptarFondo, ColoresBotones.AceptarTexto, ColoresBotones.AceptarHover);
            EstiloBoton(BtnCancelar, ColoresBotones.CancelarFondo, ColoresBotones.CancelarTexto, ColoresBotones.CancelarHover);
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
    }
}