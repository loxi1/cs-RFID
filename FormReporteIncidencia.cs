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
    public partial class FormReporteIncidencia : Form
    {
        private FormMain m_MainForm = null;
        internal string m_Cod_Trabajador = "030658";
        internal string defecto_Cod_Trabajador = "";
        internal DBReporteLecturaCaja m_DBReporteLecturaCaja = null;
        internal DBReportarIncidente m_DBReportarIncidente = null;

        DataTable m_DataTableDatosPrendas = new DataTable();
        DataTable ldt_reporte_mysql;
        private MySqlConnection connectionMySql;

        public FormReporteIncidencia(FormMain mainForm, string codTrabajador)
        {
            m_MainForm = mainForm;
            m_Cod_Trabajador = codTrabajador;
            defecto_Cod_Trabajador = codTrabajador;
            InitializeComponent();
            Console.WriteLine("EL trabajador-->" + m_Cod_Trabajador);
        }

        private void tableLayoutPanel3_Resize(object sender, EventArgs e)
        {
            int li_long;
            int li_height;
            int li_width;
            float fontSize;
            int li_minnimo = 40;
            int li_min = 25;
            int li_max = 60;
            int li_factor = 1;
            string ls_tag = "";
            bool avan = false;
            foreach (Control control in this.Controls)
            {
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    foreach (Control control1 in control.Controls)
                    {
                        li_factor = li_minnimo;
                        avan = false;
                        foreach (Control control2 in control1.Controls)
                        {
                            if (control2.Name == "FechaReporte" || control2.Name == "CodigoEmpleado")
                            {
                                li_factor = li_minnimo;
                                avan = true;
                            }

                            if (control2.Name == "labelTituloReporte" || control2.Name == "labelMsnReporte")
                            {
                                li_factor = li_max;
                                avan = true;
                            }

                            if (control2.Name == "labelBuscarReporte")
                            {
                                li_factor = li_min;
                                avan = true;
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
                                control2.Font = new Font(control.Font.FontFamily, fontSize);
                            }
                        }
                    }
                }
            }
        }

        private void BTNBuscar_Click(object sender, EventArgs e)
        {
            string cod_ = CodigoEmpleado.Text;
            DateTime fecha = DateTime.ParseExact(FechaReporte.Text, "dd-MM-yyyy", null);
            string fec_ = fecha.ToString("yyyy-MM-dd");

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("cod_trabajador", cod_);
            dictionary.Add("fecha_creacion", fec_);
            //dataGridViewReporte.Rows.Clear();
            // Desvincular la fuente de datos y limpiar el DataGridView
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
            //this.RegistrarCantidad();
            try
            {
                if (m_DBReportarIncidente == null)
                {
                    m_DBReportarIncidente = new DBReportarIncidente();
                }
                /*m_DBReportarIncidente.PruebaConexion();*/
                ldt_reporte_mysql = m_DBReportarIncidente.Reporte(cod_, fec_);
                dataGridViewReporte.DataSource = ldt_reporte_mysql;
                foreach (DataGridViewColumn column in dataGridViewReporte.Columns)
                {
                    if (column.HeaderText == "cod_trabajador")
                    {
                        column.HeaderText = "TRABAJADOR";
                        dataGridViewReporte.Columns["cod_trabajador"].ReadOnly = true;
                        dataGridViewReporte.Columns["cod_trabajador"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }

                    if (column.HeaderText == "descripcion")
                    {
                        column.HeaderText = "DESCRIPCION";
                        dataGridViewReporte.Columns["descripcion"].ReadOnly = true;
                        dataGridViewReporte.Columns["descripcion"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }

                    if (column.HeaderText == "fecha_creacion")
                    {
                        column.HeaderText = "FECHA";
                        dataGridViewReporte.Columns["fecha_creacion"].ReadOnly = true;
                        dataGridViewReporte.Columns["fecha_creacion"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
                Console.WriteLine("N filas-->" + dataGridViewReporte.RowCount);
                int auto_incr = 1;

                foreach (DataGridViewRow row in dataGridViewReporte.Rows)
                {
                    if (dataGridViewReporte.RowCount > auto_incr)
                    {
                        row.Cells["ORDEN"].Value = auto_incr;
                        row.ReadOnly = true;
                    }
                    auto_incr++;
                }
            }
            catch (Exception ex)
            {
                // Si ocurre algún error, hacemos rollback
                //trans.Rollback();
                //connectionMySql.Close();
                //m_MainForm.functionCallStatusLabel.Text = ex.Message;
                labelMsnReporte.Text = ex.Message;
            }
            finally
            {
            }
        }

        private int RegistrarCantidad()
        {
            MySqlTransaction trans = null;
            long ll_return;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                int cantidadEtiquetas = new Random().Next(0, 150);
                dictionary.Add("cantidad_prendas", cantidadEtiquetas);
                dictionary.Add("cod_trabajador", m_Cod_Trabajador);
                Console.WriteLine(dictionary["cantidad_prendas"]+" <---> "+ dictionary["cod_trabajador"]);
                if (m_DBReporteLecturaCaja == null)
                {
                    m_DBReporteLecturaCaja = new DBReporteLecturaCaja();
                }
                using (connectionMySql = m_DBReporteLecturaCaja.Connect())
                {
                    using (trans = connectionMySql.BeginTransaction())
                    {
                        ll_return = m_DBReporteLecturaCaja.Insert(dictionary, connectionMySql, trans);
                        if (ll_return == -1)
                        {
                            trans.Rollback();
                            string lsError = m_DBReporteLecturaCaja.GetError();
                            MessageBox.Show(lsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return 0;
                        }
                        trans.Commit();
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                connectionMySql.Close();
                labelMsnReporte.Text = ex.Message;
                return -1;
            }
            finally
            {
                connectionMySql.Dispose(); trans.Dispose();
            }
        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            CodigoEmpleado.Text = defecto_Cod_Trabajador;
            FechaReporte.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void FormReporteIncidencia_Load(object sender, EventArgs e)
        {
            this.FechaReporte.MaxDate = DateTime.Today;
            CodigoEmpleado.Text = m_Cod_Trabajador;
            if (FechaReporte != null)
            {
                FechaReporte.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
        }
    }
}
