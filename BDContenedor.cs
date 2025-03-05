using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace RFIDPrendas
{
    internal class BDContenedor
    {
        private MySQLconexion conexion = new MySQLconexion();
        private MySqlConnection connectionMySql;
        private DataTable tabla = new DataTable();
        private MySqlCommand comando = new MySqlCommand();
        private string ss_error = "";
        public DataTable Retrieve(string pidContenedorRelacionado, string pCodigoCompania, string pTipo, string pNumeroCaja)
        {
            try
            {
                comando.Connection = conexion.Connect();
                comando.Parameters.Clear();
                comando.CommandText = $"SELECT `codigo_compania`, `tipo`, `secuencial_contenedor`, `cantidad_prendas`, `cantidad_prendas_leidas`, `id_contenedor`, `id_contenedor_relacionado`,`codigo_id`,`id_contenedor_padre`,`id_despacho` " +
                    $" FROM bd_ci_scm`.`contenedor` " +
                    $" WHERE compania = ?compania AND op = ?op AND hoja_marcacion = ?hoja_marcacion AND nro_caja = ?nro_caja ";
                comando.Parameters.Add("?id_contenedor_relacionado", MySqlDbType.Int32).Value = pidContenedorRelacionado;
                comando.Parameters.Add("?codigo_compania", MySqlDbType.String).Value = pCodigoCompania;
                comando.Parameters.Add("?tipo", MySqlDbType.String).Value = pTipo;
                comando.Parameters.Add("?secuencial_contenedor", MySqlDbType.String).Value = pNumeroCaja;                       
                var leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.Disconnect();
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }
            return tabla;
        }

        public DataTable GetData(Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    //string query = $"SELECT  `op`, `hoja_marcacion`, `secuencial_contenedor`, `cantidad_prendas`, `cantidad_prendas_leidas`, `nro_po`, `nro_cea`, `nro_packinglist`, `codigo_compania`, `tipo`,`id_contenedor`, `id_contenedor_relacionado`,`id_contenedor_padre`, `id_despacho` FROM contenedor ";
                    string query = $"SELECT  `op`, `hoja_marcacion`, `secuencial_contenedor`, `cantidad_prendas`, `cantidad_prendas_leidas`,`id_contenedor` FROM contenedor ";
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
                ss_error = ex.Message;
            }
            return dataTable;
        }

        public long Insert(Dictionary<string, object> columns, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            long ll_return;
            try
            {
                comando.Connection = myconexion;                
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();

                string tableName = "`contenedor`";
                string columnNames = string.Join(", ", columns.Keys.Select(key => $"`{key}`"));
                string parameterNames = string.Join(", ", columns.Keys.Select(key => $"?{key}"));

                string sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;

                foreach (var column in columns)
                {
                    comando.Parameters.AddWithValue($"?{column.Key}", column.Value ?? DBNull.Value);
                }
                ll_return = comando.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                ll_return = -1;
            }
            return ll_return;
        }

        public int Update(int id, long id_contenedor_relacionado, int cantidad, int pcabecera_id)
        {
            int li_return;
            try
            {
                connectionMySql = conexion.Connect();
                comando.Connection = connectionMySql;
                var trans = connectionMySql.BeginTransaction();
                li_return = Update(id, id_contenedor_relacionado, cantidad, pcabecera_id, connectionMySql, trans);
                conexion.Disconnect();
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                li_return = -1;
            }
            return li_return;
        }

        public int Update(long id_contenedor, long id_contenedor_relacionado, int cantidad_prendas_leidas, int estado, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            int li_return;
            try
            {
                comando.Connection = myconexion;
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.Text;
                if (id_contenedor_relacionado > 0)
                {
                    comando.CommandText = "UPDATE `contenedor` SET `id_contenedor_relacionado` = ?id_contenedor_relacionado, `cantidad_prendas_leidas` =?cantidad_prendas_leidas, `fecha_modificacion` = ?fecha_modificacion, `estado` = ?estado WHERE id_contenedor = ?id_contenedor;";
                }
                else
                {
                    comando.CommandText = "UPDATE `contenedor` SET `cantidad_prendas_leidas` =?cantidad_prendas_leidas, `fecha_modificacion` = ?fecha_modificacion, `estado` = ?estado WHERE id_contenedor = ?id_contenedor;";
                }
                
                comando.Parameters.Add("?id_contenedor", MySqlDbType.Int32).Value = id_contenedor;
                if (id_contenedor_relacionado > 0)
                {
                    comando.Parameters.Add("?id_contenedor_relacionado", MySqlDbType.Int64).Value = id_contenedor_relacionado;
                }
                comando.Parameters.Add("?cantidad_prendas_leidas", MySqlDbType.Int32).Value = cantidad_prendas_leidas;
                comando.Parameters.Add("?fecha_modificacion", MySqlDbType.DateTime).Value = DateTime.Now;
                comando.Parameters.Add("?estado", MySqlDbType.Int32).Value = estado;

                li_return = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                li_return = -1;
            }
            return li_return;
        }

        public DataTable GetCajas(string ps_compania, string ps_cajas)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    string query = $"usp_get_cajas ";                    
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = query;
                    comando.Parameters.Clear();
                    comando.Parameters.Add("?ps_compania", MySqlDbType.String).Value = ps_compania;
                    comando.Parameters.Add("?ps_op_hm_caja", MySqlDbType.String).Value = ps_cajas;                    

                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    conexion.Disconnect();
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }
            return dataTable;
        }

        public DataTable GetCajasxRFID(string prendasRfid)
        {
            DataTable dataTable = new DataTable();
            string ls_token = DateTime.Now.ToString("yyyyMMddHHmmss");
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    string query = $"usp_verificar_pds_caja ";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = query;
                    comando.Parameters.Clear();
                    comando.Parameters.Add("?p_token", MySqlDbType.String).Value = ls_token;
                    comando.Parameters.Add("?ps_parametro", MySqlDbType.String).Value = prendasRfid;

                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    conexion.Disconnect();
                }
            }
            catch (Exception ex)
            {
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

        public int GetIdContenedor(Dictionary<string, object> whereParameters)
        {
            int rta = 0;
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    //string query = $"SELECT  `op`, `hoja_marcacion`, `secuencial_contenedor`, `cantidad_prendas`, `cantidad_prendas_leidas`, `nro_po`, `nro_cea`, `nro_packinglist`, `codigo_compania`, `tipo`,`id_contenedor`, `id_contenedor_relacionado`,`id_contenedor_padre`, `id_despacho` FROM contenedor ";
                    string query = $"SELECT  `id_contenedor` FROM contenedor";
                    string query_ = $"SELECT  `id_contenedor` FROM contenedor";
                    string ls_where = "";
                    string ls_where_ = "";
                    int liCont = 0;
                    foreach (var parameter in whereParameters)
                    {
                        if (parameter.Key == "secuencial_contenedor")
                        {
                            ls_where_ += $"CAST({parameter.Key} AS SIGNED INTEGER) = {parameter.Value} AND ";
                            ls_where += $"CAST({parameter.Key} AS SIGNED INTEGER) = ?{parameter.Key} AND ";
                        }
                        else
                        {
                            ls_where_ += $"{parameter.Key} = '{parameter.Value}' AND ";
                            ls_where += $"{parameter.Key} = ?{parameter.Key} AND ";
                        }
                        liCont++;
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'
                    ls_where_ = ls_where_.TrimEnd(" AND ".ToCharArray());
                    if (liCont > 0)
                    {
                        ls_where = " WHERE " + ls_where;
                        ls_where_ = " WHERE " + ls_where_;
                        query += ls_where;
                        query_ += ls_where_;
                    }
                    query += " limit 1";
                    query_ += " limit 1";
                    comando.Parameters.Clear();
                    comando.CommandText = query;
                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"?{parameter.Key}", parameter.Value);

                        Console.WriteLine("Tipo elemento (" + parameter.Value + ") " + parameter.Value.GetType());
                    }
                    Console.WriteLine("Que formo-->" + query);
                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    int li_rows = dataTable.Rows.Count;
                    if(li_rows >0)
                    {
                        DataRow row = dataTable.Rows[0];
                        if (Int32.Parse((string)row["id_contenedor"])>0)
                        {
                            rta = Int32.Parse((string)row["id_contenedor"]);
                        }
                    }
                    conexion.Disconnect();
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }
            return rta;
        }

        public int GetIdContenedor_(Dictionary<string, object> whereParameters)
        {
            int rta = 0;
            DataTable dataTable = new DataTable();

            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    StringBuilder query = new StringBuilder("SELECT `id_contenedor` FROM contenedor");
                    StringBuilder ls_where = new StringBuilder();
                    int liCont = 0;

                    // Construir la cláusula WHERE con los parámetros proporcionados
                    foreach (var parameter in whereParameters)
                    {
                        if (parameter.Key == "secuencial_contenedor")
                        {
                            // Uso de CAST si es el secuencial_contenedor
                            ls_where.Append($"CAST({parameter.Key} AS SIGNED INTEGER) = ?{parameter.Key} AND ");
                        }
                        else
                        {
                            // Caso general
                            ls_where.Append($"{parameter.Key} = ?{parameter.Key} AND ");
                        }
                        liCont++;
                    }

                    // Eliminar el último "AND" si hay parámetros
                    if (liCont > 0)
                    {
                        ls_where.Length -= 5; // Eliminar los últimos 5 caracteres (" AND ")
                        query.Append(" WHERE ").Append(ls_where);
                    }

                    // Limitar a un solo resultado
                    query.Append(" LIMIT 1");

                    // Establecer el comando y limpiar parámetros
                    comando.CommandText = query.ToString();
                    comando.Parameters.Clear();

                    // Añadir los parámetros al comando
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"?{parameter.Key}", parameter.Value);
                        Console.WriteLine($"Tipo elemento ({parameter.Value}): {parameter.Value.GetType()}");
                    }

                    // Ejecutar la consulta
                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);

                    // Verificar si hay resultados
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];

                        // Convertir el resultado a entero de forma segura
                        if (row["id_contenedor"] != DBNull.Value)
                        {
                            rta = Convert.ToInt32(row["id_contenedor"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }
            finally
            {
                // Asegurar desconexión de la base de datos
                conexion.Disconnect();
            }
            return rta;
        }

        public string GetContenedorInfo(Dictionary<string, object> whereParameters, string tipo)
        {
            string rta = "";
            DataTable dataTable = new DataTable();
            string ll_tipo = tipo;
            try
            {
                using (comando.Connection = conexion.Connect())
                {
                    StringBuilder query = new StringBuilder("SELECT `id_contenedor`,`op`,`hoja_marcacion`,`secuencial_contenedor` FROM contenedor");
                    StringBuilder ls_where = new StringBuilder();
                    int liCont = 0;

                    // Construir la cláusula WHERE con los parámetros proporcionados
                    foreach (var parameter in whereParameters)
                    {
                        ls_where.Append($"CAST({parameter.Key} AS SIGNED INTEGER) = ?{parameter.Key} AND ");
                        liCont++;
                    }

                    // Eliminar el último "AND" si hay parámetros
                    if (liCont > 0)
                    {
                        ls_where.Length -= 5; // Eliminar los últimos 5 caracteres (" AND ")
                        query.Append(" WHERE ").Append(ls_where);
                    }

                    // Limitar a un solo resultado
                    query.Append(" LIMIT 1");

                    // Establecer el comando y limpiar parámetros
                    comando.CommandText = query.ToString();
                    comando.Parameters.Clear();
                    Console.WriteLine(query.ToString());
                    // Añadir los parámetros al comando
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"?{parameter.Key}", parameter.Value);
                        Console.WriteLine($"Tipo elemento ({parameter.Value}): {parameter.Value.GetType()}");
                    }
                    Console.WriteLine("Otro-->" + comando.CommandText);
                    // Ejecutar la consulta
                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);

                    // Verificar si hay resultados
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];

                        // Convertir el resultado a entero de forma segura
                        if (row["id_contenedor"] != DBNull.Value)
                        {
                            rta = (string)row[ll_tipo];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }
            finally
            {
                // Asegurar desconexión de la base de datos
                conexion.Disconnect();
            }
            return rta;
        }
    }
}

