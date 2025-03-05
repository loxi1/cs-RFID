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
    public partial class FormLoginPersonal : Form
    {
        private FormMain m_MainForm;
        public string CodTrabajador { get; private set; }
        public string Usuario { get; private set; }
        public string Datos { get; private set; }
        public FormLoginPersonal(FormMain MainForm)
        {
            m_MainForm = MainForm;
            InitializeComponent();
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel; // Establece el DialogResult en Cancel para cerrar el formulario
            //this.Close();
            AlertaError("Tiene que iniciar sessión");
        }

        private void FormLoginPersonal_Shown(object sender, EventArgs e)
        {
            ucTextBox.Focus();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            string lsCodTrabajador;
            string lsPassword;
            lsCodTrabajador = ucTextBox.Text;
            lsCodTrabajador = lsCodTrabajador.Trim();
            lsPassword = ucPassword.Text;
            lsPassword = lsPassword.Trim();

            if (lsCodTrabajador == string.Empty || lsPassword == string.Empty)
            {
                AlertaError("Por favor Ingrese datos");
                ucTextBox.Text = "";
                ucTextBox.Focus();
                return;
            }
            DBConsultas Encriptar = new DBConsultas();
            BDTrabajador DatosTrabajador = new BDTrabajador();
            DataTable ldtTrabajador;
            int li_rows = 0;
            string clave = Encriptar.Clave(lsPassword);
            Dictionary<string, object> whereParameters = new Dictionary<string, object>
                {
                    { "codigo", lsCodTrabajador }
                };

            ldtTrabajador = DatosTrabajador.GetData(whereParameters);
            li_rows = ldtTrabajador.Rows.Count;

            DataTable ltd_trabajador = DatosTrabajador.GetUltimoUsuario();
            DataRow row_ = ltd_trabajador.Rows[0];
            if (li_rows == 0)
            {
                AlertaError("Codigo de Trabajador No Existe, por favor verificar");
                ucTextBox.Text = "";
                ucPassword.Text = "";
                ucTextBox.Focus();
                return;
            }
            else
            {
                DataRow row = ldtTrabajador.Rows[0];
                if (row["clave"].ToString() != clave)
                {
                    AlertaError("Clave incorrecta, por favor verificar");
                    ucTextBox.Text = "";
                    ucPassword.Text = "";
                    ucTextBox.Focus();
                    return;
                }
                Datos = row["datos"].ToString();
                Usuario = Explode(" ", Datos);
            }

            CodTrabajador = ucTextBox.Text; // Asigna el valor del TextBox a la propiedad

            this.DialogResult = DialogResult.OK; // Establece el DialogResult para cerrar el formulario
            this.Close();
        }

        public string Explode(string separator, string source)
        {
            string[] data = source.Split(new string[] { separator }, StringSplitOptions.None);
            return data[0];
        }

        public void AlertaError(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 3);
            aler_ta.ShowDialog();
        }

        private void UcTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonOk.Focus();
            }
        }

        private void UcTextBox_Enter(object sender, EventArgs e)
        {
            if (ucTextBox.Text == "Ingrese su usuario...")
            {
                ucTextBox.Text = "";
                //ucTextBox.ForeColor = Color.Black; // Cambia el color del texto a negro cuando el usuario escribe
            }
        }

        private void UcTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ucTextBox.Text))
            {
                ucTextBox.Text = "Ingrese su usuario...";
                //ucTextBox.ForeColor = Color.Gray; // Cambia el color del texto a gris para parecer un placeholder
            }
        }

        private void UcTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ucPassword.Focus();
            }
        }

        private void UcPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                buttonOk.Focus();
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
