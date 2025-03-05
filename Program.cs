using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDPrendas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ValidarProceso())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            else
            {
                // Si la validación falla, mostrar un mensaje y cerrar la aplicación
                MessageBox.Show("La validación ha fallado. La aplicación se cerrará.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        static bool ValidarProceso()
        {
            // Aquí se coloca la lógica de validación
            // Por ejemplo, validar si un archivo existe, si una configuración es correcta, etc.
            //Login classLogin = new Login();
            //string ls_username = classLogin.GetUsername();
            //string ls_userId;
            //string ls_perfilId;
            //string ls_name;
            //string ls_error;
            //ls_username = ls_username.Replace(".", "");

            //int li_rpta = classLogin.GetUserData(ls_username, out ls_userId, out ls_perfilId, out ls_name);
            //if (li_rpta == -1)
            //{
            //    ls_error = classLogin.GetError();
            //    MessageBox.Show("Error: " + ls_error, "Error al acceder al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //else if (li_rpta == 0)
            //{
            //    ls_error = classLogin.GetError();
            //    MessageBox.Show(ls_error, "Acceso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}
            
            return true;
        }
    }
}
