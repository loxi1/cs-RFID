using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RFIDPrendas
{
    internal class MySQLconexion
    {
        //private SqlConnection myConexion = new SqlConnection("Database=192.168.150.51; Data Source=facturaelectronica; User Id=gestionSunat; Password=certificado123;");
        private MySqlConnection myConexion;
        private string m_SeccionIni = "MySQL";
        private string m_ServerName = "";
        private string m_Port = "";
        private string m_DataBase = "";
        private string m_Usuario = "fjurado";
        private string m_Password = "987960662";
        internal string s_error;
        
        public MySqlConnection Connect()
        {
            if (GetIni() == 1)
            {
                //string sCadenaConexion = "Database=bd_ci_scm; Port=3306; Data Source=192.168.150.35; User Id=fjurado; Password=987960662;";
                string sCadenaConexion = $"Database={m_DataBase};Port={m_Port};Data Source={m_ServerName};Uid={m_Usuario};Pwd={m_Password};";
                try
                {
                    if (myConexion == null)
                        myConexion = new MySqlConnection(sCadenaConexion);

                    if (myConexion.State == ConnectionState.Closed)
                    {
                        myConexion = new MySqlConnection(sCadenaConexion);
                        myConexion.Open();
                    }

                }
                catch (MySqlException ex)
                {
                    s_error = ex.Message;
                }
            }
            return myConexion;

        }

        public MySqlConnection Disconnect()
        {
            if (myConexion.State == ConnectionState.Open)
                myConexion.Close();
            return myConexion;
        }

        //para devolver el error del objeto
        public string GetError()
        {
            return s_error;
        }

        private int GetIni()
        {
            IniFile iniFile = new IniFile();
            bool lb_exist = iniFile.LoadConfiguracion();
            if (!lb_exist)
            {
                s_error = iniFile.GetError();
                return 0;
            }

            m_ServerName = iniFile.GetValue(m_SeccionIni, "ServerName");
            m_Port = iniFile.GetValue(m_SeccionIni, "Port");
            m_DataBase = iniFile.GetValue(m_SeccionIni, "DataBase");

            return 1;
        }
    }
}
