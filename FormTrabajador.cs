using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace RFIDPrendas
{
    public partial class FormTrabajador : Form
    {
        public string CodTrabajador { get; private set; }
        public string Usuario { get; private set; }
        public FormTrabajador()
        {
            InitializeComponent();
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
                MessageBox.Show("Ingrese correctamente el Datos del Trabajdor", "Trabajador");
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
            Console.WriteLine("No creoo-->"+row_["identificador"]);
            if (li_rows == 0)
            {
                MessageBox.Show("Codigo de Trabajador No Existe, por favor verificar", "Trabajador");
                ucTextBox.Text = "";
                ucPassword.Text = "";
                ucTextBox.Focus();
                return;
            } else
            {
                DataRow row = ldtTrabajador.Rows[0];
                if (row["clave"].ToString() != clave)
                {
                    MessageBox.Show("Clave incorrecta, por favor verificar", "Trabajador");
                    ucTextBox.Text = "";
                    ucPassword.Text = "";
                    ucTextBox.Focus();
                    return;
                }
                Usuario = row["datos"].ToString();
                Console.WriteLine("Tipo de dato-->"+row["clave"].GetType());
                Console.WriteLine("Tipo de dato xxx-->" + ucTextBox.Text.GetType());
                Console.WriteLine("Tipo de dato DatosTrabajador-->" + DatosTrabajador.GetType());
                
            }

            CodTrabajador = ucTextBox.Text; // Asigna el valor del TextBox a la propiedad
            
            this.DialogResult = DialogResult.OK; // Establece el DialogResult para cerrar el formulario
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Establece el DialogResult en Cancel para cerrar el formulario
            this.Close();
        }

        private void ucTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ButtonOk.Focus();
            }            
        }

        private void FormTrabajador_Shown(object sender, EventArgs e)
        {
            ucTextBox.Focus();
        }
    }
}
