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
    public partial class FormPerfil : Form
    {
        private FormMain m_MainForm;
        public FormPerfil(FormMain MainForm, string codigo, string datos)
        {
            InitializeComponent();
            m_MainForm = MainForm;
            lblCodigo.Text = codigo;
            lblDatos.Text = datos;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
