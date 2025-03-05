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
    public partial class FormLogin : Form
    {
        public string CodigoUsuario { get; private set; }
        public string CodigoPerfil { get; private set; }
        private Login loginClass;
        private int li_cont;
        public FormLogin()
        {
            InitializeComponent();
            loginClass = new Login();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
            ucTextBoxUsuario.Text = loginClass.GetUsername();
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void ValidarUsuario()
        {
            string ls_password = ucTextBoxPassword.Text;
            string ls_id;
            string ls_perfilId;
            string ls_name;
            string ls_error;

            ls_password = ls_password.Trim();
            bool lb_estado;

            lb_estado = loginClass.ValidateUser(ucTextBoxUsuario.Text, ls_password);
            if (!lb_estado)
            {
                li_cont++;
                MessageBox.Show("Usuario y/o contraseña no es válida, por favor verifique.", "Iniciar Sesión", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                //ucTextBoxUsuario.Text = loginClass.GetUsername();
                ucTextBoxPassword.Text = "";
                ucTextBoxUsuario.Text = "";
                ucTextBoxUsuario.Focus();
                if (li_cont > 2)
                {
                    this.Close();
                }
                return;
            }

            string ls_username = ucTextBoxUsuario.Text;
            string ls_user = ls_username.Replace(".", "");

            int li_return = loginClass.GetUserData(ls_user, out ls_id, out ls_perfilId, out ls_name);
            if (li_return == 0)
            {
                ls_error = loginClass.GetError();
                MessageBox.Show(ls_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            CodigoUsuario = ls_id;
            CodigoPerfil = ls_perfilId;
            this.DialogResult = DialogResult.OK; // Establece el DialogResult para cerrar el formulario
            this.Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (sender == ucTextBoxUsuario)
                {
                    ucTextBoxPassword.Focus();
                }
                else
                {
                    buttonOk.Focus();
                }
            }
        }

        private void buttonOk_Enter(object sender, EventArgs e)
        {
            ValidarUsuario();
        }
    }
}
