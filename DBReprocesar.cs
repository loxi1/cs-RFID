using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace RFIDPrendas
{
    class DBReprocesar
    {
        private MySQLconexion conexion = new MySQLconexion();

        private MySqlCommand comando = new MySqlCommand();
        private string ss_error = "";
        private DataTable tabla = new DataTable();

        public (bool Status, string Message, int Cantidad) Validar_existe_caja(string op, string hm, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            int numRegistros = 0;
            
            try
            {
                // 🔹 1️⃣ Obtener la cantidad de registros antes de leer
                using (var countCommand = new MySqlCommand($@" SELECT count(id) FROM matricula  WHERE op=@op and hoja_marcacion=@hm AND estado = 1;", myconexion, myTransaction))
                {
                    countCommand.Parameters.AddWithValue("@op", op);
                    countCommand.Parameters.AddWithValue("@hm", hm);

                    numRegistros = Convert.ToInt32(countCommand.ExecuteScalar());

                    if (numRegistros == 0)
                        return (false, "No existen cajas Matriculadas.", numRegistros);
                }
               
            }
            catch (Exception ex)
            {
                return (false, $"Error en Validar_existe_caja: {ex.Message}", 0);
            }

            return (true, "Registro encontrado exitosamente.", numRegistros);
        }

        public (int Status, string Message) DesmtricularLote(string op, string hm, string cod)
        {
            int status = -1;
            string message = "Registro Ok", idReproceso = "";

            try
            {
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

                    using (var command = new MySqlCommand("usp_save_desmatricula_reproceso", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("op_", op);
                        command.Parameters.AddWithValue("hm_", hm);
                        command.Parameters.AddWithValue("cod_trabajador", cod);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read()) // Lee la primera fila si existe
                            {
                                // Validar si las columnas existen antes de acceder
                                if (reader.HasColumn("id"))
                                    idReproceso = reader["id"]?.ToString() ?? "";


                                // Validar si ID de matrícula es un número válido
                                if (int.TryParse(idReproceso, out int id) && id > 0)
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
                message = $"Error en Desmatricular Lote: {ex.Message}";
                Console.WriteLine(message);
            }

            return (status, message);
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
