using System;
using System.Runtime.InteropServices;
using Sybase.Data.AseClient;

namespace RFIDPrendas
{
    class Login
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool LogonUser(
        string lpszUsername,
        string lpszDomain,
        string lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        out IntPtr phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private extern static bool CloseHandle(IntPtr handle);

        private const int LOGON32_LOGON_INTERACTIVE = 2;
        private const int LOGON32_PROVIDER_DEFAULT = 0;
        private Sybase myconexion = new Sybase();
        private AseConnection connectionAse;
        private AseCommand comando = new AseCommand();
        private string ss_error;
        private const string IS_NOACTIVO = "R";

        public string GetUsername()
        {
            string username = Environment.UserName;
                        
            return username;
        }

        public string GetDominio()
        {
            // Obtener el dominio del usuario
            string dominio = Environment.UserDomainName;
            return dominio;
        }

        public bool ValidateUser(string username, string password)
        {
            IntPtr tokenHandle = IntPtr.Zero;
            string domain = GetDominio();

            // Llamada a la API LogonUser para validar las credenciales
            bool result = LogonUser(username, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out tokenHandle);

            if (result)
            {
                // Cerrar el token después de la validación
                CloseHandle(tokenHandle);
            }

            return result;
        }

        public int GetUserData(string username, out string userId, out string perfilId, out string name )
        {
            string ls_id = null;
            string ls_perfilId = null;
            string ls_name = null;
            string ls_tipo = null;
            string ls_estado = null;
            string ls_isActivo = null;
            int li_cont = 0;

            userId = null; ;
            perfilId = null;
            name = null;

            using (connectionAse = myconexion.Connect())
            {
                string ls_select;
                ls_select = $"SELECT cusro as codigo, tlgn as username, stuser as tipo, sactivo as estado, cnvl1 as nivel, tusro as name " +
                    $"FROM smmusr WHERE tlgn = @username; ";
                try
                {
                    comando.Connection = connectionAse;                    
                    comando.CommandText = ls_select;
                    comando.Parameters.Add(new AseParameter("@username", AseDbType.VarChar)).Value = username;
                    using (AseDataReader reader = comando.ExecuteReader())
                    {
                        if (!reader.HasRows)    //si la consulta no retorna registros finaliza
                        {
                            myconexion.Disconnect();
                            ss_error = "No se encuentra registrado el usuario " + username;
                            return 0;
                        }
                                                    
                        while (reader.Read())   // Leer los datos
                        {
                            // Obtener los valores de las columnas
                            ls_id = reader["codigo"].ToString();
                            ls_name = reader["name"].ToString();
                            ls_tipo = reader["tipo"].ToString();
                            ls_estado = reader["estado"].ToString();
                            li_cont++;
                            if (li_cont > 0)
                                break;
                        }
                    }

                    if (ls_id != null)
                    {
                        if (ls_estado == IS_NOACTIVO)
                        {
                            myconexion.Disconnect();
                            ss_error = username + ", no tiene permisos para acceder al Sistema.";
                            return 0;
                        }

                        ls_select = $"SELECT UsuarioPerfil.PerfilID as perfilId, UsuarioPerfil.UserPerfilEstado as estado, Perfil.PerfilDescrip, Perfil.PerfilActivo as isActivo" +
                            $" FROM UsuarioPerfil INNER JOIN Perfil ON UsuarioPerfil.PerfilID = Perfil.PerfilID " +
                            $" WHERE UsuarioPerfil.cusro = @id ; ";

                        comando.Parameters.Clear();
                        comando.Parameters.Add(new AseParameter("@id", AseDbType.VarChar)).Value = ls_id;
                        using (AseDataReader reader = comando.ExecuteReader())
                        {
                            if (!reader.HasRows)    //si la consulta no retorna registros finaliza
                            {
                                myconexion.Disconnect();
                                ss_error = "No se ha encontrado el perfil asociado al usuario " + username;
                                return 0;
                            }

                            li_cont = 0;
                            while (reader.Read())   // Leer los datos
                            {
                                // Obtener los valores de las columnas
                                ls_perfilId = reader["perfilId"].ToString();
                                ls_estado = reader["estado"].ToString();
                                ls_isActivo = reader["isActivo"].ToString();
                                li_cont++;
                                if (li_cont > 0)
                                    break;
                            }
                        }

                        if (ls_perfilId != null)
                        {
                            if (ls_estado == IS_NOACTIVO || ls_isActivo == IS_NOACTIVO )
                            {
                                myconexion.Disconnect();
                                ss_error = username + ", no tiene permisos para acceder al Sistema." ;
                                return 0;
                            }
                        }

                        userId = ls_id; ;
                        perfilId = ls_perfilId;
                        name = ls_name;

                    }
                    myconexion.Disconnect();
                }
                catch (Exception ex)
                {
                    ss_error = ex.Message;
                    return -1;
                }
            }

            return 1;
        }

        public string GetError()
        {
            return ss_error;
        }


    }
}
