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
    public partial class FormConsultas : Form
    {
        private FormMain m_MainForm;
        public FormConsultas(FormMain mainForm)
        {
            m_MainForm = mainForm;
            InitializeComponent();
        }

        private void button1Login_Click(object sender, EventArgs e)
        {
            DBConsultas DBConsul = new DBConsultas();
            //string psw = "NnorSXNlWWkyVTYyVUJMZ2xxSzRMZz09";
            DataTable ldtTrabajador;
            //int li_rows = 0;

            Dictionary<string, object> whereParameters = new Dictionary<string, object>
                {
                    { "codigo", textBoxCodTrabajador.Text }
                };
            ldtTrabajador = DBConsul.GetData(whereParameters);
            if (ldtTrabajador.Rows.Count > 0)
            {
                Console.WriteLine("Si existen registros-->");

                string ls_cod = ldtTrabajador.Rows[0]["codigo"].ToString();
                string ls_dat = ldtTrabajador.Rows[0]["datos"].ToString();
                string ls_cla = ldtTrabajador.Rows[0]["clave"].ToString();
                rta_1.Text = ls_cod;
                rta_2.Text = ls_dat;
                rta_3.Text = ls_cla;
                //FormMessageBox.Show("¿Está seguro de registrar " + ls_cod + " para " + ls_dat + ")", "Cantidad de Prendas ("+ ls_dat+")", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            }
            PrintDataTable(ldtTrabajador);
            /*foreach(DataRow row in ldtTrabajador.Rows)
            {
                int id = (int)row["identificador"];
                string codigo = (string)row["codigo"];
                string nombre = (string)row["datos"];
                Console.WriteLine("<---Perrisss--->");
                Console.WriteLine($"Id: {id}, Código: {codigo}, Nombre: {nombre}");
                Console.WriteLine("<---Perrisss--->");
            }*/
            string enviarclave = "1234";
            Console.WriteLine("Dime el valor-->" + enviarclave);
            string clave = DBConsul.Manipularencriptacion(enviarclave);
            Console.WriteLine("Encriptar (" + enviarclave + ") --> " + clave);
            string desenci = DBConsul.ManipularDesencriptar(clave);
            Console.WriteLine("Desemcripto (" + clave + ") --> " + desenci);

            string prueba = DBConsul.Encrypt(enviarclave);
            Console.WriteLine("Demuestra1-->" + prueba);
            string prueba1 = DBConsul.Desemcriptar(prueba);
            Console.WriteLine("Demuestra2-->" + prueba1);

            string xxx = DBConsul.Clave(enviarclave);
            Console.WriteLine("xxx-->" + xxx);
            string ddd = DBConsul.TextoPlano(xxx);
            Console.WriteLine("ddd-->" + ddd);


            // Create secret IV

            string encrypted = DBConsul.Encript_a(enviarclave);
            string decrypted = DBConsul.Desencript_a(encrypted);

            Console.WriteLine("<--encrypted-->" + encrypted);
            Console.WriteLine("<--decrypted-->" + decrypted);


            string encrypte_d = DBConsul.Encryptio_n(enviarclave);
            string decrypte_d = DBConsul.Decryptio_n(encrypted);

            Console.WriteLine("<--encrypte_d-->" + encrypte_d);
            Console.WriteLine("<--decrypte_d-->" + decrypte_d);
        }

        static void PrintDataTable(DataTable table)
        {
            // Imprimir los nombres de las columnas
            foreach (DataColumn column in table.Columns)
            {
                Console.Write(column.ColumnName.PadRight(15));
            }
            Console.WriteLine();

            // Imprimir las filas
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write("<--->" + item.ToString().PadRight(15) + "<--->");
                }
                Console.WriteLine();
            }
        }
    }
}
