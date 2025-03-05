using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sybase.Data.AseClient;


namespace RFIDPrendas
{
    internal class Sybase
    {
        //dbsybase06.cofaco.com
        private AseConnection myConexion;
        private string m_SeccionIni = "Sybase";
        private string m_ServerName = "";
        private string m_Port="";
        private string m_DataBase="";
        private readonly string m_Usuario = "corporativo";
        private readonly string m_Password = "c0rp0r@t1v0";
        internal string s_error;
        
        //funcion para conectar a la Base 
        public AseConnection Connect()
        {
            //obtiene los parametros de configuracion Server, Puerto
            if (GetIni() == 1)
            {
                //string sCadenaConexion = "Data Source=dbsybase10.cofaco.com;Port=6100;Database=nexus;Uid=corporativo;Pwd=c0rp0r@t1v0;";
                string sCadenaConexion = $"Data Source={m_ServerName};Port={m_Port};Database={m_DataBase};Uid={m_Usuario};Pwd={m_Password};";
                Console.WriteLine("test db-->"+sCadenaConexion);
                try
                {
                    if (myConexion == null)
                        myConexion = new AseConnection(sCadenaConexion);

                    if (myConexion.State == ConnectionState.Closed)
                    {
                        myConexion = new AseConnection(sCadenaConexion);
                        myConexion.Open();
                    }

                }
                catch (AseException ex)
                {
                    s_error = ex.Message;
                }
            }           

            return myConexion;
        }

        //para desconectarse a la BD
        public int Disconnect()
        {
            try
            {
                if (myConexion.State == ConnectionState.Open)
                    myConexion.Close();
            }
            catch (AseException ex)
            {
                s_error = ex.Message;
            }
            return 1;
        }

        //para devolver el error del objeto
        public string GetError()
        {
            return s_error;
        }

        private int GetIni()
        {
            IniFile iniFile = new IniFile();
            //obtiene 
            bool lb_exist = iniFile.LoadConfiguracion();
            if (!lb_exist)
            {
                s_error = iniFile.GetError();                
                return 0;
            }

            m_ServerName = iniFile.GetValue(m_SeccionIni, "ServerName");
            m_Port  = iniFile.GetValue(m_SeccionIni, "Port");
            m_DataBase = iniFile.GetValue(m_SeccionIni, "DataBase");

            return 1;
        }
    }
}
