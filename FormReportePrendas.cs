using MySql.Data.MySqlClient;
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
    public partial class FormReportePrendas : Form
    {
        private FormMain m_MainForm = null;
        internal string m_Cod_Trabajador = "030658";
        internal string defecto_Cod_Trabajador = "";
        internal BDContenedor m_BDContenedor = null;
        internal BDPrendaScm m_BDPrendaScm = null;

        DataTable m_DataTableDatosPrendas = new DataTable();
        DataTable ldt_reporte_mysql;
        private MySqlConnection connectionMySql;

        public FormReportePrendas(FormMain mainForm, string codTrabajador)
        {
            InitializeComponent();
            m_MainForm = mainForm;
            m_Cod_Trabajador = codTrabajador;
            defecto_Cod_Trabajador = codTrabajador;
        }

        private void BTNBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Op_Buscar.Text))
            {
                MessageBox.Show("Ingresar OP");
                return;
            }
            if (string.IsNullOrWhiteSpace(Marca_Buscar.Text))
            {
                MessageBox.Show("Ingresar Marcación");
                return;
            }

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("op", Op_Buscar.Text);
            dictionary.Add("hoja_marcacion", Marca_Buscar.Text);            

            try
            {
                if (m_BDPrendaScm == null)
                {
                    m_BDPrendaScm = new BDPrendaScm();
                }

                ldt_reporte_mysql = m_BDPrendaScm.GetPrendas(dictionary);
                dataGridViewReporte.DataSource = ldt_reporte_mysql;

                foreach (DataGridViewColumn column in dataGridViewReporte.Columns)
                {
                    if (column.HeaderText == "ORDEN")
                    {
                        column.HeaderText = "#";
                        dataGridViewReporte.Columns["ORDEN"].ReadOnly = true;
                        dataGridViewReporte.Columns["ORDEN"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }

                    if (column.HeaderText == "fecha_registro")
                    {
                        column.HeaderText = "FECHA";
                        dataGridViewReporte.Columns["fecha_registro"].ReadOnly = true;
                        dataGridViewReporte.Columns["fecha_registro"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }

                    if (column.HeaderText == "cod_trabajador")
                    {
                        column.HeaderText = "TRABAJADOR";
                        dataGridViewReporte.Columns["cod_trabajador"].ReadOnly = true;
                        dataGridViewReporte.Columns["cod_trabajador"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }

                    if (column.HeaderText == "id_rfid")
                    {
                        column.HeaderText = "ETIQUETA";
                        dataGridViewReporte.Columns["id_rfid"].ReadOnly = true;
                        dataGridViewReporte.Columns["id_rfid"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }

                    column.DefaultCellStyle.Font = new Font("Arial", 15);
                }

                Console.WriteLine("N filas-->" + dataGridViewReporte.RowCount);
                int auto_incr = 1;

                foreach (DataGridViewRow row in dataGridViewReporte.Rows)
                {
                    if (dataGridViewReporte.RowCount > auto_incr)
                    {
                        row.Cells["ORDEN"].Value = auto_incr;
                        row.ReadOnly = true;
                        Console.WriteLine("ORDEN-->" + auto_incr);
                    }
                    auto_incr++;
                }

                float col1WidthPercentage = 10f; // 30%
                float col2WidthPercentage = 25f; // 50%
                float col3WidthPercentage = 20f; // 20%
                float col4WidthPercentage = 45f; // 20%

                float totalWidth = dataGridViewReporte.Width;

                dataGridViewReporte.Columns[0].Width = (int)(totalWidth * (col1WidthPercentage / 100));
                dataGridViewReporte.Columns[1].Width = (int)(totalWidth * (col2WidthPercentage / 100));
                dataGridViewReporte.Columns[2].Width = (int)(totalWidth * (col3WidthPercentage / 100));
                dataGridViewReporte.Columns[3].Width = (int)(totalWidth * (col4WidthPercentage / 100));

            }
            catch (Exception ex)
            {

            }
        }

        private void FormReportePrendas_Load(object sender, EventArgs e)
        {
            dataGridViewReporte.Dock = DockStyle.Fill;
            Op_Buscar.Focus();
            Op_Buscar.Text = "";
            Op_Buscar.Enabled = true;
        }
        private void FormReportePrendas_Resize(object sender, EventArgs e)
        {
            int li_long;
            int li_height;
            int li_width;
            float fontSize;
            int li_minnimo = 40;
            int li_maximo = 60;
            int li_min = 25;
            int li_max = 95;
            int li_factor = 1;
            string ls_tag = "";
            bool avan = false;

            foreach (Control control in this.Controls)
            {
                Console.WriteLine("<----Nombre 1--->" + control.Name + " <----Tipo---> " + control.GetType().Name);
                foreach (Control control1 in control.Controls)
                {
                    Console.WriteLine("<----Nombre 2--->" + control1.Name + " <----Tipo---> " + control1.GetType().Name);
                    if (control1.Name == "tableLayoutPanel2" || control1.Name == "tableLayoutPanel3")
                    {
                        foreach (Control control2 in control1.Controls)
                        {
                            avan = false;
                            li_factor = 1;
                            Console.WriteLine("<----Nombre 3--->" + control2.Name + " <----Tipo---> " + control2.GetType().Name);
                            if (control2.Name == "dataGridViewReporte")
                            {
                                avan = true;
                                li_factor = li_max;
                            }
                            else if (control2.Name == "labelTituloReporte")
                            {
                                avan = true;
                                li_factor = li_minnimo;
                            }
                            else if (control2.Name == "tableLayoutPanel4" || control2.Name == "tableLayoutPanel5")
                            {
                                li_factor = control2.Name == "tableLayoutPanel4" ? li_maximo : li_minnimo;
                                foreach (Control control3 in control2.Controls)
                                {
                                    if (control3.Name == "labelBuscarReporte")
                                    {
                                        li_factor = li_min;
                                    }
                                    Console.WriteLine("<----Nombre 4--->" + control3.Name + " <----Tipo---> " + control3.GetType().Name);
                                    li_height = this.ClientSize.Height / li_factor;
                                    li_width = this.ClientSize.Width / li_factor;
                                    ls_tag = (string)control2.Tag;
                                    if (ls_tag != null)
                                    {
                                        if (int.TryParse(ls_tag, out li_long))
                                        {
                                            li_height /= li_long;
                                            li_width /= li_long;
                                        }
                                    }

                                    fontSize = Math.Max(li_height, li_width);
                                    control3.Font = new Font(control3.Font.FontFamily, fontSize);
                                }
                            }
                            if (avan)
                            {
                                li_height = this.ClientSize.Height / li_factor;
                                li_width = this.ClientSize.Width / li_factor;
                                ls_tag = (string)control2.Tag;
                                if (ls_tag != null)
                                {
                                    if (int.TryParse(ls_tag, out li_long))
                                    {
                                        li_height /= li_long;
                                        li_width /= li_long;
                                    }
                                }

                                fontSize = Math.Max(li_height, li_width);
                                control2.Font = new Font(control2.Font.FontFamily, fontSize);
                            }
                        }
                    }

                }
            }
        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            Op_Buscar.Text = "";
            Op_Buscar.Enabled = true;
            Marca_Buscar.Text = "";
            Marca_Buscar.Enabled = false;
            BTNBuscar.Enabled = false;

            if (dataGridViewReporte.DataSource is DataTable dataTable)
            {
                dataTable.Clear(); // Limpia el DataTable
            }
            else if (dataGridViewReporte.DataSource is BindingSource bindingSource)
            {
                DataTable dataTableFromBindingSource = bindingSource.DataSource as DataTable;
                if (dataTableFromBindingSource != null)
                {
                    dataTableFromBindingSource.Clear(); // Limpia el DataTable subyacente
                }
            }
            else
            {
                dataGridViewReporte.Rows.Clear(); // Limpia las filas si no hay una fuente de datos
            }
        }

        private void Op_Buscar_Enter(object sender, EventArgs e)
        {

        }

        private void Op_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni la tecla de retroceso, anular la entrada
                e.Handled = true;
            }
        }

        private void Marca_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni la tecla de retroceso, anular la entrada
                e.Handled = true;
            }
        }

        private void Op_Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (string.IsNullOrWhiteSpace(Op_Buscar.Text))
                {
                    AlertaError("Ingresar OP");
                    return;
                }
                if (Int32.Parse(Op_Buscar.Text) < 1)
                {
                    AlertaError("Ingresar un #");
                    return;
                }
                int cantidadCaracteres = Op_Buscar.Text.Length;
                if (cantidadCaracteres != 5)
                {
                    AlertaError("Ingresar número de 5 dígitos");
                    return;
                }
                if (m_BDContenedor == null)
                {
                    m_BDContenedor = new BDContenedor();
                }
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                string ll_tipo = "op";
                dictionary.Add(ll_tipo, int.Parse("10000" + Op_Buscar.Text)); //int.Parse(Op_Buscar.Text)
                string valor = m_BDContenedor.GetContenedorInfo(dictionary, ll_tipo);
                if (string.IsNullOrWhiteSpace(valor))
                {
                    Op_Buscar.Text = "";
                    Op_Buscar.Focus();
                    return;
                }
                else
                {
                    Console.WriteLine("Hizo enter en OP-->" + valor);
                    Op_Buscar.Text = valor;
                    Op_Buscar.Enabled = false;
                    Marca_Buscar.Enabled = true;
                    Marca_Buscar.Visible = true;
                    Marca_Buscar.Text = "";
                    Marca_Buscar.Focus();
                }
                Console.WriteLine("OP-->" + valor);
            }
        }

        private void Marca_Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (string.IsNullOrWhiteSpace(Marca_Buscar.Text))
                {
                    AlertaError("Ingresar Marcación");
                    return;
                }
                if (Int32.Parse(Marca_Buscar.Text) < 1)
                {
                    Marca_Buscar.Text = "";
                    Marca_Buscar.Focus();
                    AlertaError("Ingresar un #");
                    return;
                }
                int cantidadCaracteres = Marca_Buscar.Text.Length;
                if (cantidadCaracteres < 1 || cantidadCaracteres > 3)
                {
                    AlertaError("Ingresar número de máximo 3 dígitos");
                    return;
                }
                if (m_BDContenedor == null)
                {
                    m_BDContenedor = new BDContenedor();
                }
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                string ll_tipo = "hoja_marcacion";
                dictionary.Add(ll_tipo, int.Parse(Marca_Buscar.Text)); //int.Parse(hoja_marcacion.Text)
                dictionary.Add("op", int.Parse(Op_Buscar.Text));
                string valor = m_BDContenedor.GetContenedorInfo(dictionary, ll_tipo);
                Marca_Buscar.Text = valor;
                Marca_Buscar.Enabled = false;
                BTNBuscar_Click(this, EventArgs.Empty);
                BTNBuscar.Focus();
                BTNBuscar.Enabled = true;
                Console.WriteLine("Marcación-->" + valor);
            }
        }

        private void AlertaInfo(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 2);
            aler_ta.ShowDialog();
        }

        private void AlertaError(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 3);
            aler_ta.ShowDialog();
        }

        private void AlertaOk(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 1);
            aler_ta.ShowDialog();
        }
    }
}
