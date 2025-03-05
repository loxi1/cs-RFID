using System;
using System.Data;
using System.Collections.Generic;
using Sybase.Data.AseClient;

namespace RFIDPrendas
{
    class BDTrabajador
    {
        private Sybase myconexion = new Sybase();
        private AseConnection connectionAse;
        private AseCommand comando = new AseCommand();
        private string ss_error = "";

        public DataTable GetData(Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = myconexion.Connect())
                {                    
                    // Construir la consulta SQL                    
                    string query = $"SELECT identificador, codigo, datos, empresa, estado, clave FROM usuario_timbrado ";
                    string ls_where = "";
                    int liCont = 0;
                    foreach (var parameter in whereParameters)
                    {
                        ls_where += $"{parameter.Key} = @{parameter.Key} AND ";
                        liCont++;
                        Console.WriteLine("!entro-->" + parameter.Key);
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'

                    if (liCont > 0)
                    {
                        ls_where = " WHERE " + ls_where;
                        query += ls_where;
                    }

                    comando.CommandText = query;

                    string queryConValores = query;
                    foreach (var parameter in whereParameters)
                    {
                        // Reemplazar cada parámetro en la cadena del query
                        queryConValores = queryConValores.Replace($"@{parameter.Key}", $"'{parameter.Value}'");
                    }

                    // Mostrar el query con los valores reales en la consola
                    Console.WriteLine("Query con valores: " + queryConValores);

                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"@{parameter.Key}", parameter.Value);
                        Console.WriteLine($"{parameter.Key} <--> {parameter.Value}");
                    }
                    Console.WriteLine("query-->" + comando.CommandText);
                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    myconexion.Disconnect();                    
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }
            return dataTable;
        }

        public DataTable GetUltimoUsuario()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = myconexion.Connect())
                {
                    // Construir la consulta SQL                    
                    string query = $"SELECT top 1 identificador, codigo, datos, empresa, estado, clave FROM usuario_timbrado order by identificador desc ";
                    
                    comando.CommandText = query;

                    Console.WriteLine("xxx query xxx-->" + comando.CommandText);
                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    myconexion.Disconnect();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }
            return dataTable;
        } 


        public AseConnection Connect()
        {
            //para iniciar una conexion para una trasaccion
            connectionAse = myconexion.Connect();
            return connectionAse;
        }

        public string GetError()
        {
            return ss_error;
        }
    }
}
