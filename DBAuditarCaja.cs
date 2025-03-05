using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace RFIDPrendas
{
    class DBAuditarCaja
    {

        private MySQLconexion conexion = new MySQLconexion();

        private MySqlCommand comando = new MySqlCommand();
        private string ss_error = "";
        private DataTable tabla = new DataTable();

        public int UpdateMatricula(long id, Dictionary<string, object> whereParameters, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            int li_return = -1;
            Console.WriteLine($"Mira-->{id} -->");

            try
            {
                if (myconexion == null || myTransaction == null)
                {
                    Console.WriteLine("⚠️ Error: La conexión o la transacción es NULL.");
                    return li_return;
                }

                if (myconexion.State != ConnectionState.Open)
                {
                    Console.WriteLine("⚠️ Error: La conexión no está abierta.");
                    return li_return;
                }

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = myconexion;
                    comando.Transaction = myTransaction;
                    comando.CommandType = CommandType.Text;

                    // 🔹 Construcción del SET correctamente formateado
                    string setClause = string.Join(", ", whereParameters.Keys.Select(key => $"{key} = @{key}"));
                    string updateQuery = $"UPDATE `matricula` SET {setClause} WHERE `id` = @id;";
                    comando.CommandText = updateQuery;

                    Console.WriteLine($"query---{updateQuery}---");

                    // Agregar los parámetros dinámicos
                    comando.Parameters.Clear();
                    foreach (var param in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"@{param.Key}", param.Value);
                    }
                    comando.Parameters.AddWithValue("@id", id);

                    li_return = comando.ExecuteNonQuery();
                    Console.WriteLine($"🔹 Filas afectadas en `matricula`: {li_return}");

                    if (li_return > 0 && whereParameters.ContainsKey("estado"))
                    {
                        string updateDetalleQuery = $"UPDATE `matricula_detalle` SET estado = @estado WHERE `matricula_id` = @id;";
                        comando.CommandText = updateDetalleQuery;
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@estado", whereParameters["estado"]);
                        comando.Parameters.AddWithValue("@id", id);

                        li_return = comando.ExecuteNonQuery();
                        Console.WriteLine($"🔹 Filas afectadas en `matricula_detalle`: {li_return}");
                    }
                    else
                    {
                        Console.WriteLine("⚠️ `estado` no se encuentra en whereParameters, no se actualiza `matricula_detalle`.");
                    }

                    // 🔹 Confirmar transacción si hubo cambios
                    if (li_return > 0)
                    {
                        myTransaction.Commit();
                        Console.WriteLine($"✅ Cambios confirmados en la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🛑 Error en UpdateMatricula: {ex.Message}");
                try
                {
                    myTransaction.Rollback();
                    Console.WriteLine("🔄 Transacción revertida.");
                }
                catch (Exception rollbackEx)
                {
                    Console.WriteLine($"⚠️ Error al hacer rollback: {rollbackEx.Message}");
                }
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
