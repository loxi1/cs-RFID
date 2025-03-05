using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using Mysqlx.Crud;

namespace RFIDPrendas
{
    internal class BDDespacho
    {
        private MySQLconexion conexion = new MySQLconexion();
        private MySqlConnection connectionMySql;
        private DataTable tabla = new DataTable();
        private MySqlCommand comando = new MySqlCommand();        
        private string ss_error = "";
        public DataTable Retrieve(string psCompania, string psOP, string psHojaMarcacion, string psNumeroCaja)
        {
            try
            {
                comando.Connection = conexion.Connect();
                comando.Parameters.Clear();
                comando.CommandText = $"SELECT `compania`, `op`, `hoja_marcacion`, `nro_caja`, `cantidad_prendas`, `cantidad_prendas_rfid`, `nro_despacho`,`codigo_id`,`nro_parihuela`,`id`,`tipo` " +
                    $" FROM bd_ci_almacen.despacho_prenda " +
                    $" WHERE compania = ?compania AND op = ?op AND hoja_marcacion = ?hoja_marcacion AND nro_caja = ?nro_caja ";
                comando.Parameters.Add("?compania", MySqlDbType.String).Value = psCompania;
                comando.Parameters.Add("?op", MySqlDbType.String).Value = psOP;
                comando.Parameters.Add("?hoja_marcacion", MySqlDbType.String).Value = psHojaMarcacion;
                comando.Parameters.Add("?nro_caja", MySqlDbType.String).Value = psNumeroCaja;
                //comando.CommandType = CommandType.StoredProcedure;            
                var leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.Disconnect();                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }

            return tabla;
        }

        public long Insert(string op, int cantidad)
        {
            long ll_return;
            try
            {
                comando.Connection = conexion.Connect();
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO `despacho_prenda` (`op`, `cantidad`) VALUES (?op, ?cantidad);";
                comando.Parameters.Add("?op", MySqlDbType.VarChar).Value = op;
                comando.Parameters.Add("?cantidad", MySqlDbType.Int32).Value = cantidad;
                ll_return = comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.Disconnect();
            }
            catch (Exception ex)
            {
                ss_error = ex.Message;
                ll_return = -1;
            }
            return ll_return;
        }

        public int Update(int id, string codigo_id, int cantidad, int pcabecera_id )
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
