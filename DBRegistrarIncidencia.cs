using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDPrendas
{
    class DBRegistrarIncidencia
    {
        private MySQLconexion conexion = new MySQLconexion();

        private MySqlCommand comando = new MySqlCommand();
        private string ss_error = "";
        private DataTable tabla = new DataTable();

        public (bool Status, string Message, int Idincidenterfid, string OP, string HojaMarcacion) Validar_existe_caja(List<string> rfidList, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            DataTable dataTable = new DataTable();
            int incidenterfidId = 0;
            int numRegistros = 0;
            string op = "", hojaMarcacion = "";

            if (rfidList == null || rfidList.Count == 0)
                return (false, "No se proporcionaron RFID válidos.", incidenterfidId, op, hojaMarcacion);

            try
            {
                string paramList = string.Join(",", rfidList.Select((s, i) => $"@rfid{i}"));
                Console.WriteLine($"paramList-->{paramList}");
                // 🔹 1️⃣ Obtener la cantidad de registros antes de leer
                using (var countCommand = new MySqlCommand($@"
            SELECT COUNT(DISTINCT incidenterfid_id) 
            FROM incidenterfid_detalle 
            WHERE id_rfid IN ({paramList}) AND estado = 1;", myconexion, myTransaction))
                {
                    for (int i = 0; i < rfidList.Count; i++)
                        countCommand.Parameters.AddWithValue($"@rfid{i}", rfidList[i]);

                    numRegistros = Convert.ToInt32(countCommand.ExecuteScalar());

                    if (numRegistros == 0)
                        return (false, "No se encontraron registros en incidenterfid_detalle con los RFID proporcionados.", incidenterfidId, op, hojaMarcacion);

                    if (numRegistros > 1)
                        return (false, "Se encontraron múltiples incidenterfid_id para los RFID proporcionados. Verifique la información.", incidenterfidId, op, hojaMarcacion);
                }

                // 🔹 2️⃣ Obtener el incidenterfid_id
                using (var incidenterfidCommand = new MySqlCommand($@"
            SELECT incidenterfid_id 
            FROM incidenterfid_detalle 
            WHERE id_rfid IN ({paramList}) AND estado = 1 
            LIMIT 1;", myconexion, myTransaction))
                {
                    for (int i = 0; i < rfidList.Count; i++)
                        incidenterfidCommand.Parameters.AddWithValue($"@rfid{i}", rfidList[i]);

                    using (var reader = incidenterfidCommand.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            incidenterfidId = Convert.ToInt32(reader["incidenterfid_id"]);
                        }
                    }
                }

                // 🔹 3️⃣ Consultar la información en la tabla `incidenterfid`
                using (var incidenterfidInfoCommand = new MySqlCommand(@"
            SELECT op, hoja_marcacion, cantidad_prendas 
            FROM incidenterfid 
            WHERE id = @incidenterfidId;", myconexion, myTransaction))
                {
                    incidenterfidInfoCommand.Parameters.AddWithValue("@incidenterfidId", incidenterfidId);

                    using (var leer = incidenterfidInfoCommand.ExecuteReader())
                    {
                        dataTable.Load(leer);
                    }

                    if (dataTable.Rows.Count == 0)
                    {
                        return (false, "No se encontraron datos en la tabla incidenterfid para el ID especificado.", incidenterfidId, op, hojaMarcacion);
                    }

                    // Obtener valores de la tabla `incidenterfid`
                    op = dataTable.Rows[0]["op"].ToString();
                    hojaMarcacion = dataTable.Rows[0]["hoja_marcacion"].ToString();
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error en Validar_existe_caja: {ex.Message}", incidenterfidId, op, hojaMarcacion);
            }

            return (true, "Registro encontrado exitosamente.", incidenterfidId, op, hojaMarcacion);
        }

        public (int Status, string Message, string Idincidenterfid, string OP, string HojaMarcacion) incidenterfidrCajaOP(string cod, int cant, string descrip, List<string> rfidList)
        {
            int status = -1;
            string message = "Ok", op = "", hojaMarcacion = "", idincidenterfid = "";

            try
            {
                string token = DateTime.Now.ToString("yyyyMMddHHmmss");
                string rfidValues = string.Join(",", rfidList);
                using (var connection = conexion.Connect())
                {
                    if (connection == null)
                    {
                        throw new InvalidOperationException("Error: No se pudo establecer la conexión con la base de datos.");
                    }

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open(); // Asegura que la conexión está abierta
                    }

                    using (var command = new MySqlCommand("usp_save_incidente_det_op", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_token", token);
                        command.Parameters.AddWithValue("ps_parametro", rfidValues);
                        command.Parameters.AddWithValue("cod_trabajador", cod);
                        command.Parameters.AddWithValue("cantidad_prendas", cant);
                        command.Parameters.AddWithValue("descrip", descrip);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read()) // Lee la primera fila si existe
                            {
                                // Validar si las columnas existen antes de acceder
                                if (reader.HasColumn("id"))
                                    idincidenterfid = reader["id"]?.ToString() ?? "";

                                if (reader.HasColumn("op"))
                                    op = reader["op"]?.ToString() ?? "";

                                if (reader.HasColumn("hoja_marcacion"))
                                    hojaMarcacion = reader["hoja_marcacion"]?.ToString() ?? "";


                                // Validar si ID de matrícula es un número válido
                                if (int.TryParse(idincidenterfid, out int id) && id > 0)
                                {
                                    status = 1;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = 0;
                message = $"Error en incidenterfidrCajaOP: {ex.Message}";
                Console.WriteLine(message);
            }

            return (status, message, idincidenterfid, op, hojaMarcacion);
        }

        public int Updateincidenterfid(long id, string descripcion, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            int li_return = -1;

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

                    comando.CommandText = "UPDATE `incidenterfid` SET `descripcion` = @descripcion WHERE `id` = @id;";

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@descripcion", descripcion);

                    li_return = comando.ExecuteNonQuery();
                }

                Console.WriteLine($"✅ SQL Ejecutado: UPDATE `incidenterfid` SET `descripcion` = '{descripcion}' WHERE `id` = {id};");
                Console.WriteLine($"🔹 Resultado li_return: {li_return}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"🛑 Error en Updateincidenterfid: {ex.Message}");
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
