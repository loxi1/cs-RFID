using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace RFIDPrendas
{
    class DBMatricularCaja
    {
        private MySQLconexion conexion = new MySQLconexion();

        private MySqlCommand comando = new MySqlCommand();
        private string ss_error = "";
        private DataTable tabla = new DataTable();

        public (bool Status, string Message, int IdMatricula, string OP, string HojaMarcacion) Validar_existe_caja(List<string> rfidList, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            DataTable dataTable = new DataTable();
            int matriculaId = 0;
            int numRegistros = 0;
            string message = "Ok", op = "", hojaMarcacion = "";

            if (rfidList == null || rfidList.Count == 0)
                return (false, "No se proporcionaron RFID válidos.", matriculaId, op, hojaMarcacion);

            try
            {
                string paramList = string.Join(",", rfidList.Select((s, i) => $"@rfid{i}"));
                Console.WriteLine($"paramList-->{paramList}");
                // 🔹 1️⃣ Obtener la cantidad de registros antes de leer
                using (var countCommand = new MySqlCommand($@"
            SELECT COUNT(DISTINCT matricula_id) 
            FROM matricula_detalle 
            WHERE id_rfid IN ({paramList}) AND estado = 1;", myconexion, myTransaction))
                {
                    for (int i = 0; i < rfidList.Count; i++)
                        countCommand.Parameters.AddWithValue($"@rfid{i}", rfidList[i]);

                    numRegistros = Convert.ToInt32(countCommand.ExecuteScalar());

                    if (numRegistros == 0)
                        return (false, "No se encontraron registros en matricula_detalle con los RFID proporcionados.", matriculaId, op, hojaMarcacion);

                    if (numRegistros > 1)
                        return (false, "Se encontraron múltiples matricula_id para los RFID proporcionados. Verifique la información.", matriculaId, op, hojaMarcacion);
                }

                // 🔹 2️⃣ Obtener el matricula_id
                using (var matriculaCommand = new MySqlCommand($@"
            SELECT matricula_id 
            FROM matricula_detalle 
            WHERE id_rfid IN ({paramList}) AND estado = 1 
            LIMIT 1;", myconexion, myTransaction))
                {
                    for (int i = 0; i < rfidList.Count; i++)
                        matriculaCommand.Parameters.AddWithValue($"@rfid{i}", rfidList[i]);

                    using (var reader = matriculaCommand.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            matriculaId = Convert.ToInt32(reader["matricula_id"]);
                        }
                    }
                }

                // 🔹 3️⃣ Consultar la información en la tabla `matricula`
                using (var matriculaInfoCommand = new MySqlCommand(@"
            SELECT op, hoja_marcacion, cantidad_prendas 
            FROM matricula 
            WHERE id = @matriculaId;", myconexion, myTransaction))
                {
                    matriculaInfoCommand.Parameters.AddWithValue("@matriculaId", matriculaId);

                    using (var leer = matriculaInfoCommand.ExecuteReader())
                    {
                        dataTable.Load(leer);
                    }

                    if (dataTable.Rows.Count == 0)
                    {
                        return (false, "No se encontraron datos en la tabla matricula para el ID especificado.", matriculaId, op, hojaMarcacion);
                    }

                    // Obtener valores de la tabla `matricula`
                    op = dataTable.Rows[0]["op"].ToString();
                    hojaMarcacion = dataTable.Rows[0]["hoja_marcacion"].ToString();
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error en Validar_existe_caja: {ex.Message}", matriculaId, op, hojaMarcacion);
            }

            return (true, "Registro encontrado exitosamente.", matriculaId, op, hojaMarcacion);
        }

        public (int Status, string Message, string IdMatricula, string OP, string HojaMarcacion) MatricularCajaOP(string cod, int cant, List<string> rfidList)
        {
            int status = -1;
            string message = "Ok", op = "", hojaMarcacion = "", idMatricula = "";

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

                    using (var command = new MySqlCommand("usp_save_matricula_det_op", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_token", token);
                        command.Parameters.AddWithValue("ps_parametro", rfidValues);
                        command.Parameters.AddWithValue("cod_trabajador", cod);
                        command.Parameters.AddWithValue("cantidad_prendas", cant);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read()) // Lee la primera fila si existe
                            {
                                // Validar si las columnas existen antes de acceder
                                if (reader.HasColumn("id"))
                                    idMatricula = reader["id"]?.ToString() ?? "";

                                if (reader.HasColumn("op"))
                                    op = reader["op"]?.ToString() ?? "";

                                if (reader.HasColumn("hoja_marcacion"))
                                    hojaMarcacion = reader["hoja_marcacion"]?.ToString() ?? "";


                                // Validar si ID de matrícula es un número válido
                                if (int.TryParse(idMatricula, out int id) && id > 0)
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
                message = $"Error en MatricularCajaOP: {ex.Message}";
                Console.WriteLine(message);
            }

            return (status, message, idMatricula, op, hojaMarcacion);
        }

        public int UpdateMatricula(long id, string op, string hm, MySqlConnection myconexion, MySqlTransaction myTransaction)
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

                    comando.CommandText = "UPDATE `matricula` SET `hoja_marcacion` = @hoja_marcacion, `op` = @op WHERE `id` = @id;";

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@hoja_marcacion", hm);
                    comando.Parameters.AddWithValue("@op", op);

                    li_return = comando.ExecuteNonQuery();
                }

                Console.WriteLine($"✅ SQL Ejecutado: UPDATE `matricula` SET `hoja_marcacion` = '{hm}', `op` = '{op}' WHERE `id` = {id};");
                Console.WriteLine($"🔹 Resultado li_return: {li_return}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"🛑 Error en UpdateMatricula: {ex.Message}");
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
