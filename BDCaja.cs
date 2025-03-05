using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace RFIDPrendas
{
    internal class BDCaja
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
                    string query = $"SELECT `id`, `op`, `hoja_marcacion`, `nro_caja`, `cantidad_prendas`, `nro_po`, `nro_cea`, `nro_packinglist`, `codigo_compania`, `fecha`, `usuario_modificacion`, estados.valor_mostrar as estado " +
                                   $" FROM `caja` " +
                                   $" LEFT JOIN bd_ci_comun.caracteristica estados ON (estados.valor_grabar = bd_ci_scm.caja.estado AND estados.nombre = 'estado_corporativo'); ";
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

                string tableName = "`caja`";
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

        public int Update(int id, int cantidad_prendas, string cod_Trabajdor,  int estado )
        {
            int li_return;
            try
            {
                connectionMySql = conexion.Connect();
                comando.Connection = connectionMySql;
                var trans = connectionMySql.BeginTransaction();
                li_return = Update(id, cantidad_prendas, cod_Trabajdor, estado, connectionMySql, trans);
                conexion.Disconnect();
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                li_return = -1;
            }
            return li_return;
        }

        public int Update(long id, int cantidad_prendas, string cod_Trabajador, int estado, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            int li_return;
            try
            {
                comando.Connection = myconexion;
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.Text;
                
                
                comando.CommandText = "UPDATE `caja` SET `cantidad_prendas` =?cantidad_prendas, `fecha_modificacion` = ?fecha_modificacion, `usuario_modificacion` = ?usuario_modificacion, `estado` = ?estado WHERE `id` = ?id;";
                
                
                
                comando.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
                comando.Parameters.Add("?cantidad_prendas", MySqlDbType.Int32).Value = cantidad_prendas;
                comando.Parameters.Add("?fecha_modificacion", MySqlDbType.DateTime).Value = DateTime.Now;
                comando.Parameters.Add("?usuario_modificacion", MySqlDbType.String).Value = cod_Trabajador;                
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
                
        public MySqlConnection Connect()
        {
            //para iniciar una conexion para una trasaccion
            return conexion.Connect();
        }

        public string GetError()
        {
            return ss_error;
        }
    }
}

