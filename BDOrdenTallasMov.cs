using System;
using System.Data;
using System.Collections.Generic;
using Sybase.Data.AseClient;

namespace RFIDPrendas
{
    class BDOrdenTallasMov
    {
        private Sybase myconexion = new Sybase();
        private AseConnection connectionAse;
        private AseCommand comando = new AseCommand();
        private string ss_error = "";
        const string ESTADO_EMBALAJE = "SALIDA EMBALAJE";
        public DataTable GetData(string compania, Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = myconexion.Connect())
                {

                    // Construir la consulta SQL                    
                    string query = $"SELECT nnope, nordencorte, nordensubcorte, cod_combinacion, cod_talla, id_talla, lacabado, ccmpn from ordenacabadostallasmov ";
                        //"WHERE ccmpn = '02' and nnope like '%' and flgestado = 'SALIDA EMBALAJE' and codQR = '0000103068611120411308AA'
                    string ls_where = "";
                    int liCont = 0;

                    ls_where += $"ccmpn = @ccmpn AND ";
                    ls_where += $"flgestado = @flgestado AND ";

                    foreach (var parameter in whereParameters)
                    {
                        ls_where += $"{parameter.Key} = @{parameter.Key} AND ";
                        liCont++;
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'

                    if (ls_where.Length > 0)
                    {
                        ls_where = " WHERE " + ls_where;
                        query += ls_where;
                    }

                    comando.CommandText = query;

                    comando.Parameters.AddWithValue($"@ccmpn", "02");
                    comando.Parameters.AddWithValue($"@flgestado", ESTADO_EMBALAJE);

                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"@{parameter.Key}", parameter.Value);
                    }

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
