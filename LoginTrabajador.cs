using System;
using System.Drawing;
using System.Windows.Forms;

namespace RFIDPrendas
{
    public partial class LoginTrabajador : Form
    {
        public LoginTrabajador()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (usuario == "Usuario" || string.IsNullOrEmpty(usuario) ||
                contraseña == "Contraseña" || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Ingrese usuario y contraseña válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Inicio de sesión exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Gray;
            }
        }

        private void TxtContraseña_Enter(object sender, EventArgs e)
        {
            txtContraseña.Text = "";
            txtContraseña.ForeColor = Color.Black;
            txtContraseña.PasswordChar = '*';
        }

        private void TxtContraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.Gray;
                txtContraseña.PasswordChar = '\0';
            }
        }
    }
}
