using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace RFIDPrendas
{
    class BDPrendaScm
    {
        private MySQLconexion conexion = new MySQLconexion();
        private MySqlConnection connectionMySql;
        private DataTable tabla = new DataTable();
        private MySqlCommand comando = new MySqlCommand();
        private string ss_error = "";
                
        public DataTable GetData(Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    string query = $"SELECT `id_prenda`,`id_rfid`,`id_barras`,`fecha_registro`,`cod_trabajador`,`op`,`corte`,`subcorte`,`cod_talla`,`id_talla`,`talla`,`cod_combinacion`,`color`,`estado`,`id_contenedor` FROM `bd_ci_scm`.`prenda` ";
                    
                    string ls_where = "";
                    int liCont = 0;
                    foreach (var parameter in whereParameters)
                    {
                        ls_where += $"{parameter.Key} = ?{parameter.Key} AND ";
                        liCont++;
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'

                    if (liCont > 0)
                    {
                        ls_where = " WHERE " + ls_where;
                        query += ls_where;
                    }
                    //Console.WriteLine("Se forma el QR-->" + query);
                    comando.Parameters.Clear();
                    comando.CommandText = query;

                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"?{parameter.Key}", parameter.Value);
                    }

                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    conexion.Disconnect();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }
            return dataTable;
        }

        public long Insert(Dictionary<string, object> columns)
        {
            long ll_return;
            try
            {
                comando.Connection = conexion.Connect();
                comando.Parameters.Clear();

                string tableName = "`prenda`";                
                string columnNames = string.Join(", ", columns.Keys.Select(key => $"`{key}`"));
                string parameterNames = string.Join(", ", columns.Keys.Select(key => $"?{key}"));                

                string sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

                comando.CommandText = sql;

                foreach (var column in columns)
                {
                    comando.Parameters.AddWithValue($"?{column.Key}", column.Value ?? DBNull.Value);
                }
                
                ll_return = comando.ExecuteNonQuery();                
                conexion.Disconnect();
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                ll_return = -1;
            }
            return ll_return;
        }

        public int Update(int id, string codigo_id, int cantidad, int pcabecera_id)
        {
            int li_return;
            try
            {
                connectionMySql = conexion.Connect();
                comando.Connection = connectionMySql;
                var trans = connectionMySql.BeginTransaction();
                li_return = Update(id, codigo_id, cantidad, pcabecera_id, connectionMySql, trans);
                conexion.Disconnect();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
                li_return = -1;
            }
            return li_return;
        }

        public int Update(int id, string codigo_id, int cantidad, int pcabecera_id, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            int li_return;
            try
            {
                comando.Connection = myconexion;
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();
                comando.CommandText = "UPDATE `despacho_prenda` SET `codigo_id` = ?codigo_id, `cantidad_prendas_rfid` =?cantidad, `fecha_actualizacion` = ?fecha_actualizacion, `cabecera_id` = ?cabecera_id WHERE id = ?id;";
                comando.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
                comando.Parameters.Add("?codigo_id", MySqlDbType.VarChar).Value = codigo_id;
                comando.Parameters.Add("?cantidad", MySqlDbType.Int32).Value = cantidad;
                comando.Parameters.Add("?fecha_actualizacion", MySqlDbType.DateTime).Value = DateTime.Now;
                comando.Parameters.Add("?cabecera_id", MySqlDbType.Int32).Value = pcabecera_id;

                li_return = comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
                li_return = -1;
            }

            return li_return;
        }

        public int SetPrendaRfid(long pi_id_caja, string ps_codigo_trabajdor, string prendasRfid, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            DataTable dataTable = new DataTable();
            string ls_token = DateTime.Now.ToString("yyyyMMddHHmmss");
            int li_return = -1;
            int li_rows = 0;
            try
            {
                comando.Connection = myconexion;
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();
                                
                string query = $"usp_set_rfid ";
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = query;
                comando.Parameters.Clear();
                comando.Parameters.Add("?p_token", MySqlDbType.String).Value = ls_token;
                comando.Parameters.Add("?pi_id_caja", MySqlDbType.Int64).Value = pi_id_caja;
                comando.Parameters.Add("?ps_cod_trabajador", MySqlDbType.String).Value = ps_codigo_trabajdor;
                comando.Parameters.Add("?ps_parametro", MySqlDbType.String).Value = prendasRfid;                

                var leer = comando.ExecuteReader();
                dataTable.Load(leer);

                li_rows = dataTable.Rows.Count;

                if (li_rows > 0)
                {
                    li_return = dataTable.Rows[0].Field<int>("estado");
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }
            return li_return;
        }
        public DataTable GetDato(Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    //string query = $"SELECT `id_prenda`,`id_rfid`,`id_barras`,`fecha_registro`,`cod_trabajador`,`op`,`corte`,`subcorte`,`cod_talla`,`id_talla`,`talla`,`cod_combinacion`,`color`,`estado`,`id_contenedor` FROM `bd_ci_scm`.`prenda` ";
                    string query = $"SELECT 0 `ORDEN`, `id_rfid`, `fecha_registro`,`cod_trabajador` FROM `bd_ci_scm`.`prenda` ";

                    string ls_where = "";
                    int liCont = 0;
                    foreach (var parameter in whereParameters)
                    {
                        ls_where += $"{parameter.Key} = ?{parameter.Key} AND ";
                        liCont++;
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'

                    if (liCont > 0)
                    {
                        ls_where = " WHERE " + ls_where;
                        query += ls_where;
                    }
                    Console.WriteLine("Nuevo query-->" + query);
                    comando.Parameters.Clear();
                    comando.CommandText = query;

                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"?{parameter.Key}", parameter.Value);
                    }

                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    conexion.Disconnect();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }
            return dataTable;
        }

        public DataTable GetPrendas(Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    //string query = $"SELECT `id_prenda`,`id_rfid`,`id_barras`,`fecha_registro`,`cod_trabajador`,`op`,`corte`,`subcorte`,`cod_talla`,`id_talla`,`talla`,`cod_combinacion`,`color`,`estado`,`id_contenedor` FROM `bd_ci_scm`.`prenda` ";
                    string query = $"SELECT 0 `ORDEN`, `pre`.`fecha_registro`,`pre`.`cod_trabajador`, `pre`.`id_rfid` FROM `bd_ci_scm`.`prenda` `pre` where `pre`.`id_contenedor` in (SELECT `cont`.`id_contenedor` FROM `bd_ci_scm`.`contenedor` `cont` where ";

                    string ls_where = "";
                    int liCont = 0;
                    foreach (var parameter in whereParameters)
                    {
                        ls_where += $"CAST({parameter.Key} AS SIGNED INTEGER) = {parameter.Value} AND ";
                        liCont++;
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'

                    if (liCont > 0)
                    {
                        query += ls_where+ ")";
                    }
                    Console.WriteLine("Nuevo query-->" + query);
                    comando.Parameters.Clear();
                    comando.CommandText = query;

                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"?{parameter.Key}", parameter.Value);
                    }

                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    conexion.Disconnect();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }
            return dataTable;
        }

        public MySqlConnection Connect()
        {
            //para iniciar una conexion para una trasaccion
            return conexion.Connect();
        }

        public string GetError()
        {
            return ss_error;
        }

        public DataTable GetMatriculaDetalle(Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    string query = $"SELECT id_rfid, hoja_marcacion,op,corte,subcorte,talla,color " +
                        $"FROM `bd_ci_scm`.`matricula_detalle` `det` " +
                        $"left join `matricula` `mat` on `det`.`matricula_id`= `mat`.`id` ";


                    string ls_where = "";
                    int liCont = 0;
                    foreach (var parameter in whereParameters)
                    {
                        ls_where += $"{parameter.Key} = ?{parameter.Key} AND ";
                        liCont++;
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'

                    if (liCont > 0)
                    {
                        ls_where = " WHERE " + ls_where;
                        query += ls_where;
                    }
                    Console.WriteLine("Se forma el QR-->" + query);
                    comando.Parameters.Clear();
                    comando.CommandText = query;

                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"?{parameter.Key}", parameter.Value);
                    }

                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    conexion.Disconnect();
                    Console.WriteLine($"Consulta ejecutada: {query}");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine($"RFID: {row["id_rfid"]}, Color: {row["color"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }
            return dataTable;
        }

    }
}
