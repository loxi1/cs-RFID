using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RFIDPrendas
{
    class DBReporteLecturaCaja
    {
        private MySQLconexion conexion = new MySQLconexion();
        private DataTable tabla = new DataTable();
        private MySqlCommand comando = new MySqlCommand();
        private string ss_error = "";

        public DataTable Reporte(string cod_, string date_)
        {
            try
            {
                Console.WriteLine("el codigo es==>" + cod_);
                comando.Connection = conexion.Connect();
                comando.Parameters.Clear();
                comando.CommandText = $"SELECT 0 `ORDEN`, `cod_trabajador`, `cantidad_prendas`, `fecha_creacion` " +
                    $" FROM `bd_ci_scm`.`matricula` " +
                    $" WHERE cod_trabajador = ?cod_trabajador " +
                    $" AND fecha_creacion like ?fecha_creacion ";
                comando.Parameters.Add("?cod_trabajador", MySqlDbType.String).Value = cod_;
                comando.Parameters.Add("?fecha_creacion", MySqlDbType.String).Value = $"{date_}%";
                Console.WriteLine("El Sql es: " + comando.CommandText.ToString());
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

        public long Insert(Dictionary<string, object> columns, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            long ll_return;
            try
            {
                comando.Connection = myconexion;
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();

                string tableName = "`matricula`";
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

        public void PruebaConexion()
        {
            conexion.Connect();
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
