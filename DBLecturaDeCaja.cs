using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace RFIDPrendas
{
    class DBLecturaDeCaja
    {
        private MySQLconexion conexion = new MySQLconexion();

        private MySqlCommand comando = new MySqlCommand();
        private string ss_error = "";
        private DataTable tabla = new DataTable();
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

        //Matricular caja
        public long Insertar(Dictionary<string, object> columns, MySqlConnection myconexion, MySqlTransaction myTransaction)
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
                comando.ExecuteNonQuery();
                comando.CommandText = "SELECT LAST_INSERT_ID();";
                ll_return = Convert.ToInt64(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                ll_return = -1;
            }
            return ll_return;
        }
        //Verificar si existe caja

        //Insertar detalle de matricula
        public long Insertar_detalle(long idMatricula, List<string> rfids, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            long ll_return = -1;
            string vv_op = null;
            try
            {
                comando.Connection = myconexion;
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();

                // Construir el SELECT con IN para los valores de rfids
                string rfidValues = string.Join(",", rfids.Select(rfid => $"'{rfid}'"));
                string selectQuery = $@"SELECT op, id_rfid, id_barras, corte, subcorte, cod_talla, id_talla, talla, color FROM prenda WHERE id_rfid IN ({rfidValues});";
                comando.CommandText = selectQuery;
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    List<(string id_rfid, string id_barras, string corte, string subcorte, string cod_talla, string id_talla, string talla, string color)> records = new List<(string, string, string, string, string, string, string, string)>();

                    // Leer los resultados y almacenarlos en una lista
                    while (reader.Read())
                    {
                        vv_op = reader["op"].ToString();
                        records.Add((
                            reader["id_rfid"].ToString(),
                            reader["id_barras"].ToString(),
                            reader["corte"].ToString(),
                            reader["subcorte"].ToString(),
                            reader["cod_talla"].ToString(),
                            reader["id_talla"].ToString(),
                            reader["talla"].ToString(),
                            reader["color"].ToString()
                        ));
                    }

                    reader.Close();

                    // Insertar los registros en la nueva tabla
                    string insertQuery = $@"INSERT INTO matricula_detalle (id_rfid, id_barras, corte, subcorte, cod_talla, id_talla, talla, color, matricula_id) VALUES (@id_rfid, @id_barras, @corte, @subcorte, @cod_talla, @id_talla, @talla, @color, @matricula_id);";
                    
                    foreach (var record in records)
                    {
                        comando.Parameters.Clear();
                        comando.CommandText = insertQuery;

                        comando.Parameters.AddWithValue("@id_rfid", record.id_rfid);
                        comando.Parameters.AddWithValue("@id_barras", record.id_barras);
                        comando.Parameters.AddWithValue("@corte", record.corte);
                        comando.Parameters.AddWithValue("@subcorte", record.subcorte);
                        comando.Parameters.AddWithValue("@cod_talla", record.cod_talla);
                        comando.Parameters.AddWithValue("@id_talla", record.id_talla);
                        comando.Parameters.AddWithValue("@talla", record.talla);
                        comando.Parameters.AddWithValue("@color", record.color);
                        comando.Parameters.AddWithValue("@matricula_id", idMatricula);

                        comando.ExecuteNonQuery();
                    }

                    // Actualizar la tabla matricula con el valor de op
                    if (records.Count > 0)
                    {
                        string opValue = records[0].Item1; // El valor 'op' del primer registro
                        string updateQuery = $@"UPDATE matricula SET po = '"+ vv_op+"' WHERE id = @matricula_id;";
                        comando.Parameters.Clear();
                        comando.CommandText = updateQuery;
                        comando.Parameters.AddWithValue("@po", opValue);
                        comando.Parameters.AddWithValue("@matricula_id", idMatricula);

                        comando.ExecuteNonQuery();
                    }

                    ll_return = 0; // Operación exitosa
                }
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                ll_return = -1; // Indicar error
            }
            return ll_return;
        }

        public (DataTable Matricula, Dictionary<string, object> Detalle, string[] Elementos, int MatricualId) BuscarCajaMatriculada(
    string rdid, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            DataTable matricula = new DataTable();
            Dictionary<string, object> detalle = new Dictionary<string, object>();
            string[] elementos = null;
            int matricula_id = 0;

            try
            {
                Console.WriteLine($"rdid-->{rdid}");
                // Obtener ID de matrícula
                int ? matriculaId = ObtenerMatriculaId(rdid, myconexion, myTransaction);
                matricula_id = matriculaId.Value;
                Console.WriteLine($" matriculaId->{matriculaId}");

                Console.WriteLine($" matricula_id->{matriculaId}");
                if (matriculaId == null)
                {
                    return (matricula, detalle, elementos, matricula_id);
                }

                // Cargar información de la matrícula
                matricula = CargarMatricula(matriculaId.Value, myconexion, myTransaction);

                if (matricula.Rows.Count == 0)
                {
                    return (matricula, detalle, elementos, matricula_id);
                }

                // Cargar detalles de matrícula utilizando la nueva versión mejorada del método
                var (detalleMatricula, elementosMatricula) = CargarDetallesMatricula(matriculaId.Value, myconexion, myTransaction);

                // Asignar los valores obtenidos
                detalle = detalleMatricula;
                elementos = elementosMatricula;
                /*foreach(var kvp in detalle)
                {
                    string rfid = kvp.Key;
                    dynamic detalles = kvp.Value; // Usamos `dynamic` para acceder a las propiedades
                    Console.WriteLine($"🔹 RFID: {rfid}, Corte: {detalles.Corte}, Subcorte: {detalles.Subcorte}, Talla: {detalles.Talla}, Color: {detalles.Color}");
                }*/
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }

            return (matricula, detalle, elementos, matricula_id);
        }

        private long CLng(int? matriculaId)
        {
            throw new NotImplementedException();
        }

        private int? ObtenerMatriculaId(string rdid, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"SELECT matricula_id FROM matricula_detalle WHERE id_rfid = @rdid AND estado = 1 ORDER BY id DESC LIMIT 1;";

            Console.WriteLine($"Ejecutando consulta: {query} con RFID: {rdid}");

            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("La conexión a la base de datos no está abierta.");
            }

            using (var command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@rdid", rdid);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("matricula_id")))
                    {
                        int matriculaId = reader.GetInt32(reader.GetOrdinal("matricula_id"));
                        Console.WriteLine($"matricula_id encontrado: {matriculaId}");
                        return matriculaId;
                    }
                    else
                    {
                        Console.WriteLine("⚠️ No se encontró ningún resultado para el RFID proporcionado.");
                    }
                }
            }

            return null;
        }


        private DataTable CargarMatricula(int matriculaId, MySqlConnection connection, MySqlTransaction transaction)
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT op, hoja_marcacion, cantidad_prendas FROM matricula WHERE id = @matriculaId;";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@matriculaId", matriculaId);

                using (var reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }

        private (Dictionary<string, object> Detalle, string[] Elementos) CargarDetallesMatricula(
    int matriculaId, MySqlConnection connection, MySqlTransaction transaction)
        {
            Dictionary<string, object> detalle = new Dictionary<string, object>();
            List<string> elementos = new List<string>();

            string query = @"SELECT id_rfid, corte, subcorte, talla, color 
                     FROM matricula_detalle 
                     WHERE matricula_id = @matriculaId;";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@matriculaId", matriculaId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string idRfid = reader["id_rfid"].ToString();

                        var detalles = new
                        {
                            Corte = reader["corte"].ToString(),
                            Subcorte = reader["subcorte"].ToString(),
                            Talla = reader["talla"].ToString(),
                            Color = reader["color"].ToString()
                        };

                        // Guardar en el diccionario de detalles
                        detalle[idRfid] = detalles;

                        // Agregar al listado de elementos
                        elementos.Add(idRfid);
                    }
                }
            }

            return (detalle, elementos.ToArray());
        }


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
                        return (false, "No hay registros con los RFID proporcionados.", matriculaId, op, hojaMarcacion);

                    if (numRegistros > 1)
                        return (false, "Se encontraron múltiples registros matriculados. Verificar.", matriculaId, op, hojaMarcacion);
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
                        return (false, "No se encontraron registros matriculados.", matriculaId, op, hojaMarcacion);
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


        public DataTable Buscar_caja(string rfidValues, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            DataTable dataTable = new DataTable();
            try
            {
                List<int> matriculaid = new List<int>();

                comando.Connection = myconexion;
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();

                // Construir el SELECT con IN para los valores de rfids
                string selectQuery = $@"SELECT matricula_id FROM matricula_detalle WHERE id_rfid IN ({rfidValues}) and estado=5 group by matricula_id;";
                comando.CommandText = selectQuery;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matriculaid.Add(Convert.ToInt32(reader["matricula_id"]));
                    }
                }

                if(matriculaid.Count>0)
                {
                    comando.Parameters.Clear();
                    rfidValues = string.Join(",", matriculaid);
                    selectQuery = $@"SELECT op, hoja_marcacion, cantidad_prendas from matricula where id IN ({rfidValues});";
                    comando.CommandText = selectQuery;
                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                }

            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }
            return dataTable;
        }

        public long MatricularCaja(string cod, int cant, string prendasRfid)
        {
            long ll_return = -1;
            try
            {
                string ls_token = DateTime.Now.ToString("yyyyMMddHHmmss");
                using (comando.Connection = conexion.Connect())
                {
                    string query = $"usp_save_matricula";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = query;
                    comando.Parameters.Clear();
                    comando.Parameters.Add("?p_token", MySqlDbType.String).Value = ls_token;
                    comando.Parameters.Add("?ps_parametro", MySqlDbType.String).Value = prendasRfid;
                    comando.Parameters.Add("?cod_trabajador", MySqlDbType.String).Value = cod;
                    comando.Parameters.Add("?cantidad_prendas", MySqlDbType.Int32).Value = cant;

                    var leer = comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Disconnect();
                    ll_return = 1;
                }
            }
            catch (Exception ex)
            {
                ll_return = 0;
                Console.WriteLine("query-->" + ex.Message);
            }
            return ll_return;
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

        public DataTable Buscar_RFID(string rfidValues, MySqlConnection myconexion, MySqlTransaction myTransaction)
        {
            DataTable dataTable = new DataTable();
            try
            {
                comando.Connection = myconexion;
                comando.Transaction = myTransaction;
                comando.Parameters.Clear();

                // Construir el SELECT con IN para los valores de rfids
                string selectQuery = $@"SELECT id_rfid, corte, subcorte, talla, color FROM matricula_detalle WHERE id_rfid IN ({rfidValues}) and estado=5;";
                comando.CommandText = selectQuery;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                }

            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
            }
            return dataTable;
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
