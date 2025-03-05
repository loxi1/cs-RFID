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
    public partial class FormIncidente : Form
    {
        internal string m_Cod_Trabajador = "030658";
        internal int m_tipo = 1;
        internal int m_ContenedorId = 0;
        internal DBReportarIncidente m_DBReportarIncidente = null;
        private MySqlConnection connectionMySql;
        /// <summary>
        /// Constructor de la clase FormIncidente.
        /// </summary>
        /// <param name="codTrabajado">Código del trabajador.</param>
        public FormIncidente(string codTrabajado, int tipo)
        {
            InitializeComponent();
            m_Cod_Trabajador = codTrabajado;
            m_tipo = tipo;
            m_ContenedorId = 0;
        }

        public FormIncidente(string codTrabajado, int tipo, int ContenedorId)
        {
            InitializeComponent();
            m_Cod_Trabajador = codTrabajado;
            m_tipo = tipo;
            m_ContenedorId = ContenedorId;
        }

        private int RegistrarIncidente()
        {
            MySqlTransaction trans = null;
            long ll_return;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                string descripcion = TextIncidente.Text;
                dictionary.Add("tipo", m_tipo);
                dictionary.Add("descripcion", descripcion);
                dictionary.Add("cod_trabajador", m_Cod_Trabajador);
                if(m_ContenedorId>0)
                {
                    dictionary.Add("contenedor_id", m_ContenedorId);
                }
                Console.WriteLine(dictionary["descripcion"] + " <---> " + dictionary["cod_trabajador"]);
                //DBReportarIncidente m_DBReportarIncidente
                if (m_DBReportarIncidente == null)
                {
                    m_DBReportarIncidente = new DBReportarIncidente();
                }
                using (connectionMySql = m_DBReportarIncidente.Connect())
                {
                    using (trans = connectionMySql.BeginTransaction())
                    {
                        ll_return = m_DBReportarIncidente.Insertar(dictionary, connectionMySql, trans);
                        if (ll_return == -1)
                        {
                            trans.Rollback();
                            string lsError = m_DBReportarIncidente.GetError();
                            AlertaError(lsError);
                            //MessageBox.Show(lsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return 0;
                        } else if(ll_return == 1)
                        {
                            AlertaOk("Guardo Ok");
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
                AlertaError(ex.Message);
                //labelMsnReporte.Text = ex.Message;
                return -1;
            }
            finally
            {
                connectionMySql.Dispose(); trans.Dispose();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            RegistrarIncidente();
            TextIncidente.Text = "";
            this.Close();
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
