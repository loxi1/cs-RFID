using System;
using System.Data;
using System.Collections.Generic;
using Sybase.Data.AseClient;

namespace RFIDPrendas
{
    class BDPrenda
    {
        private Sybase myconexion = new Sybase();
        private AseConnection connectionAse;        
        private AseCommand comando = new AseCommand();
        private string ss_error = "";
        const   string ESTADO_EMBALAJE = "SALIDA EMBALAJE";

        public DataTable Retrieve(string pCodigoTrabajador, string pOp, string pNroCorte, string petiqueta)
        {
            DataTable tabla = new DataTable();
            using (connectionAse = myconexion.Connect())
            {
                try
                {
                    comando.Connection = connectionAse;
                    var trans = connectionAse.BeginTransaction();
                    tabla = Retrieve(pCodigoTrabajador, pOp, pNroCorte, petiqueta, connectionAse, trans);
                    myconexion.Disconnect();
                }
                catch (Exception ex)
                {
                    ss_error = ex.Message;
                }
            }

            return tabla;
        }

        public DataTable Retrieve(string pCodigoTrabajador, string pOp, string pNroCorte, string petiqueta, AseConnection pMyConexion, AseTransaction pMyTransaction)
        {
            DataTable tabla = new DataTable();
            try
            {
                //string ls_select = $"SELECT `cabecera_id`,`compania`,`codigo_id`,`tipo`,`tipo_codigo`,`cantidad_registrada`,`cantidad_rfid` as cantidad,`fecha_registro`,`estado` " +
                //    $" FROM cabecera_rfid ";
                string ls_select = $"select op, corte, sub_corte, color, talla, id_talla, linea, fecha, fotocheck, estado, etiqueta, cod_talla, cod_comb " +
                    $" from tmp_etiq_timbradas ";
                    //$" where estado = 'SALIDA EMBALAJE' AND fotocheck = '030447'";

                string ls_where = "";
                comando.Parameters.Clear();

                ls_where = ls_where.Trim();
                if (pOp != "%")
                {
                    if (ls_where.Length > 0) ls_where += " AND ";
                    ls_where += $"op = @Op ";
                    comando.Parameters.Add(new AseParameter("@Op", AseDbType.VarChar)).Value = pOp;                    
                }

                if (pNroCorte != "%")
                {
                    if (ls_where.Length > 0) ls_where += " AND ";
                    ls_where += $"corte = @NroCorte ";
                    comando.Parameters.Add(new AseParameter("@NroCorte", AseDbType.VarChar)).Value = pNroCorte;                  
                }

                if (pCodigoTrabajador != "%")
                {
                    if (ls_where.Length > 0) ls_where += " AND ";
                    ls_where += $"fotocheck = @CodigoTrabajador ";
                    comando.Parameters.Add(new AseParameter("@CodigoTrabajador", AseDbType.VarChar)).Value = pCodigoTrabajador;
                }

                if (petiqueta != "%")
                {
                    if (ls_where.Length > 0) ls_where += " AND ";
                    ls_where += $"etiqueta = @etiqueta ";
                    comando.Parameters.Add(new AseParameter("@etiqueta", AseDbType.VarChar)).Value = petiqueta;                  
                }

                if (ls_where.Length > 0) ls_where += " AND ";
                ls_where += $"estado = @estado ";                
                comando.Parameters.Add(new AseParameter("@estado", AseDbType.VarChar)).Value = ESTADO_EMBALAJE;

                ls_where = " WHERE " + ls_where;
                ls_select += ls_where;
                comando.Connection = pMyConexion;
                comando.Transaction = pMyTransaction;
                comando.CommandText = ls_select;
                var leer = comando.ExecuteReader();
                tabla.Load(leer);                
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;                        
            }
            return tabla;
        }

        public Tuple<int, string, DataTable> SetRfid(string sCodBarra, string sCompania, string sCodTrabajador, string sIDRfid) 
        {
            int li_return = 0;
            string s_mensaje = "";
            DataTable tabla = new DataTable();

            using (connectionAse = myconexion.Connect())
            {
                try
                {
                    //connectionAse.Open();                    
                    var trans = connectionAse.BeginTransaction();

                    // Nombre del procedimiento almacenado
                    string storedProcedureName = "USP_SAL_EMB_CON_RFID";

                    // Crear el comando
                    using (AseCommand command = new AseCommand(storedProcedureName, connectionAse))
                    {
                        command.Connection = connectionAse;
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros si el procedimiento almacenado los requiere
                        command.Parameters.Add(new AseParameter("@etqt", AseDbType.VarChar)).Value = sCodBarra;
                        command.Parameters.Add(new AseParameter("@empresa", AseDbType.VarChar)).Value = sCompania;
                        command.Parameters.Add(new AseParameter("@usr", AseDbType.VarChar)).Value = sCodTrabajador;
                        command.Parameters.Add(new AseParameter("@rfid", AseDbType.VarChar)).Value = sIDRfid;                        

                        // Ejecutar el comando y obtener el resultado
                        using (AseDataReader reader = command.ExecuteReader())
                        {
                            tabla.Load(reader);                            
                            int li_Columns = 0;                                                        
                            li_return = tabla.Rows.Count;
                            if (li_return > 0)
                            {
                                li_Columns = tabla.Columns.Count;
                                DataRow firstRow = tabla.Rows[0];
                                if (li_Columns > 0)
                                {
                                    //columnName = tabla.Columns[0].ColumnName;
                                    li_return = (int)Convert.ChangeType(firstRow[0], typeof(int));
                                }

                                if (li_Columns > 1)
                                {
                                    s_mensaje = (string)Convert.ChangeType(firstRow[1], typeof(string));
                                }
                                trans.Commit();
                                tabla = Retrieve(sCodTrabajador, "%", "%", sCodBarra, connectionAse, trans);
                            }
                            myconexion.Disconnect();                            
                        }
                    }
                }
                catch (AseException ex)
                {
                    ss_error = ex.Message;
                    li_return = -1;
                }
            }            
            return Tuple.Create(li_return, s_mensaje, tabla);
        }


        public DataTable GetCajasxPrendas(string sCompania, string sDatosPrendas )
        {
            DataTable tabla = new DataTable();
            ss_error = "";

            using (connectionAse = myconexion.Connect())
            {
                try
                {
                    //connectionAse.Open();                    
                    //var trans = connectionAse.BeginTransaction();

                    // Nombre del procedimiento almacenado
                    string storedProcedureName = "usp_get_caja_x_prenda";

                    // Crear el comando
                    using (AseCommand command = new AseCommand(storedProcedureName, connectionAse))
                    {
                        command.Connection = connectionAse;
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros si el procedimiento almacenado los requiere
                        command.Parameters.Add(new AseParameter("@as_Compania", AseDbType.VarChar)).Value = sCompania;
                        command.Parameters.Add(new AseParameter("@as_prendas", AseDbType.VarChar)).Value = sDatosPrendas;

                        // Ejecutar el comando y obtener el resultado
                        AseDataReader reader = command.ExecuteReader();
                        tabla.Load(reader);                           
                        
                    }
                }
                catch (AseException ex)
                {
                    ss_error = ex.Message;                    
                }
            }
            return tabla;
        }


        //public long Insert(string pcompania, string pcodigo_id, string ptipo, string ptipo_codigo, int pcantidad_registrada, int pcantidad_rfid)
        //{
        //    long ll_return;
        //    try
        //    {
        //        connectionMySql = conexion.Connect();
        //        comando.Connection = connectionMySql;
        //        var trans = connectionMySql.BeginTransaction();
        //        ll_return = Insert(pcompania, pcodigo_id, ptipo, ptipo_codigo, pcantidad_registrada, pcantidad_rfid, connectionMySql, trans);
        //        conexion.Disconnect();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        ss_error = ex.Message;
        //        ll_return = -1;
        //    }

        //    return ll_return;
        //}

        //public long Insert(string pcompania, string pcodigo_id, string ptipo, string ptipo_codigo, int pcantidad_registrada, int pcantidad_rfid, MySqlConnection myconexion, MySqlTransaction myTransaction)
        //{
        //    long ll_return = 0;
        //    string ls_select;
        //    try
        //    {
        //        comando.Connection = myconexion;
        //        comando.Transaction = myTransaction;
        //        ls_select = $"INSERT INTO `cabecera_rfid` (`compania`,`codigo_id`,`tipo`,`tipo_codigo`,`cantidad_registrada`,`cantidad_rfid`,`estado`) " +
        //            $" VALUES (?compania, ?codigo_id ,?tipo, ?tipo_codigo, ?cantidad_registrada, ?cantidad_rfid, ?estado);";
        //        comando.CommandText = ls_select;
        //        comando.Parameters.Clear();
        //        comando.Parameters.Add("?compania", AseDbType.VarChar).Value = pcompania;
        //        comando.Parameters.Add("?codigo_id", AseDbType.VarChar).Value = pcodigo_id;
        //        comando.Parameters.Add("?tipo", AseDbType.VarChar).Value = ptipo;
        //        comando.Parameters.Add("?tipo_codigo", AseDbType.VarChar).Value = ptipo_codigo;
        //        comando.Parameters.Add("?cantidad_registrada", AseDbType.Integer).Value = pcantidad_registrada;
        //        comando.Parameters.Add("?cantidad_rfid", AseDbType.Integer).Value = pcantidad_rfid;
        //        comando.Parameters.Add("?estado", AseDbType.VarChar).Value = "P";
        //        comando.ExecuteNonQuery();

        //        //ll_return = comando.LastInsertedId;

        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        ss_error = ex.Message;
        //        ll_return = -1;
        //    }

        //    return ll_return;
        //}

        //public int Update(int id, int pcantidad_registrada, int pcantidad_rfid)
        //{
        //    int li_return;
        //    try
        //    {
        //        connectionAse = myconexion.Connect();
        //        var trans = connectionAse.BeginTransaction();
        //        comando.Connection = connectionAse;
        //        li_return = Update(id, pcantidad_registrada, pcantidad_rfid, connectionAse, trans);
        //        myconexion.Disconnect();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        ss_error = ex.Message;
        //        li_return = -1;
        //    }
        //    return li_return;
        //}

        //public int Update(int id, int pcantidad_registrada, int pcantidad_rfid, MySqlConnection myconexion, MySqlTransaction myTransaction)
        //{
        //    int li_return;
        //    try
        //    {
        //        comando.Connection = myconexion;
        //        comando.Transaction = myTransaction;
        //        comando.Parameters.Clear();
        //        comando.CommandText = "UPDATE `cabecera_rfid` SET `cantidad_registrada` =?cantidad_registrada, `cantidad_rfid` = ?cantidad_rfid WHERE cabecera_id = ?id;";
        //        comando.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
        //        comando.Parameters.Add("?cantidad_registrada", MySqlDbType.Int32).Value = pcantidad_registrada;
        //        comando.Parameters.Add("?cantidad_rfid", MySqlDbType.Int32).Value = pcantidad_rfid;

        //        li_return = comando.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        ss_error = ex.Message;
        //        li_return = -1;
        //    }
        //    return li_return;
        //}

        //public int DeleteRows(int id, string pcompania)
        //{
        //    int li_return;
        //    try
        //    {
        //        comando.Connection = myconexion.Connect();
        //        comando.CommandText = "DELETE FROM tmp_etiq_timbradas ";
        //        comando.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
        //        comando.Parameters.Add("?compania", MySqlDbType.VarChar).Value = pcompania;
        //        li_return = comando.ExecuteNonQuery();
        //        comando.Parameters.Clear();
        //        myconexion.Disconnect();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        ss_error = ex.Message;
        //        li_return = -1;
        //    }
        //    return li_return;
        //}


        public int DeleteRows(Dictionary<string, object> whereParameters)
        {
            int li_return = 0;
            try
            {
                using (comando.Connection = myconexion.Connect())
                {
                    
                    // Construir la consulta SQL                    
                    string query = $"DELETE FROM tmp_etiq_timbradas ";
                    string ls_where = "";
                    int liCont = 0;
                    ls_where += $"estado = @estado AND ";
                    foreach (var parameter in whereParameters)
                    {
                        ls_where += $"{parameter.Key} = @{parameter.Key} AND ";
                        liCont ++;
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'

                    if (ls_where.Length > 0)
                    {
                        ls_where = " WHERE " + ls_where;
                        query += ls_where;
                    }

                    comando.CommandText = query;

                    comando.Parameters.AddWithValue($"@estado", ESTADO_EMBALAJE);
                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"@{parameter.Key}", parameter.Value);
                    }

                    li_return = comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    myconexion.Disconnect();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }
            return li_return;
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
