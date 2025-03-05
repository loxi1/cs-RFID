using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Sybase.Data.AseClient;
using System.IO;

namespace RFIDPrendas
{
    class DBConsultas
    {
        private AseCommand comando_;
        private Sybase myconexion_;
        internal string s_error_;

        private Sybase myconexion = new Sybase();
        private AseConnection connectionAse;
        private AseCommand comando = new AseCommand();
        private string ss_error = "";

        private string Titulo_INI = "Login_Encriptacion";
        private string SECRET_KEY;
        private string SECRET_IV;
        private string METHOD;

        private byte[] Key;
        private byte[] IV;

        private readonly byte[] _key;
        private readonly byte[] _iv;

        public DBConsultas()
        {
            if (GetIniSecret(Titulo_INI) == 1)
            {
                _key = Create_Key(SECRET_KEY);
                _iv = Create_IV(SECRET_IV);
            }
        }

        public DataTable GetData(Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (comando.Connection = myconexion.Connect())
                {
                    // Construir la consulta SQL                    
                    string query = $"SELECT identificador, codigo, datos, empresa, estado, clave FROM usuario_timbrado ";
                    string ls_where = "";
                    int liCont = 0;
                    foreach (var parameter in whereParameters)
                    {
                        ls_where += $"{parameter.Key} = @{parameter.Key} AND ";
                        liCont++;
                    }

                    ls_where = ls_where.TrimEnd(" AND ".ToCharArray()); // Eliminar el último 'AND'

                    if (liCont > 0)
                    {
                        ls_where = " WHERE " + ls_where;
                        query += ls_where;
                    }

                    comando.CommandText = query;

                    // Añadir parámetros a la consulta
                    foreach (var parameter in whereParameters)
                    {
                        comando.Parameters.AddWithValue($"@{parameter.Key}", parameter.Value);
                    }
                    //Console.WriteLine("El Sql es: " + comando.CommandText.ToString());
                    var leer = comando.ExecuteReader();
                    dataTable.Load(leer);
                    myconexion.Disconnect();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ss_error = ex.Message;
            }
            return dataTable;
        }

        public DataTable ExtraerData(Dictionary<string, object> whereParameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (AseConnection connection = myconexion_.Connect())
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    comando_.Connection = connection;
                    comando_.Parameters.Clear();

                    string query = BuildQuery(whereParameters);

                    comando_.CommandText = query;

                    foreach (var parameter in whereParameters)
                    {
                        comando_.Parameters.AddWithValue($"@{parameter.Key}", parameter.Value);
                    }

                    using (var reader = comando_.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (AseException ex)
            {
                s_error_ = ex.Message;
                // Consider logging the error or additional error handling here
            }
            catch (Exception ex)
            {
                s_error_ = ex.Message;
                // Consider logging the error or additional error handling here
            }
            return dataTable;
        }

        private string BuildQuery(Dictionary<string, object> whereParameters)
        {
            var sb = new StringBuilder("SELECT identificador, codigo, datos, empresa, estado FROM usuario_timbrado");

            if (whereParameters.Count > 0)
            {
                var whereClause = new StringBuilder(" WHERE ");
                foreach (var parameter in whereParameters)
                {
                    whereClause.Append($"{parameter.Key} = @{parameter.Key} AND ");
                }

                // Eliminar el último 'AND'
                whereClause.Length -= 4;
                sb.Append(whereClause);
            }

            return sb.ToString();
        }

        public void SybaseDataAccess(AseCommand command, Sybase conexion)
        {
            comando_ = command ?? throw new ArgumentNullException(nameof(command));
            myconexion_ = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        private int GetIniSecret(string titulo)
        {
            IniFile iniFile = new IniFile();
            bool lb_exist = iniFile.LoadConfiguracion();
            if (!lb_exist)
            {
                ss_error = iniFile.GetError();
                return 0;
            }

            SECRET_KEY = iniFile.GetValue(titulo, "SECRET_KEY");
            SECRET_IV = iniFile.GetValue(titulo, "SECRET_IV");
            METHOD = iniFile.GetValue(titulo, "METHOD");
            Key = Encoding.UTF8.GetBytes(SECRET_KEY.PadRight(32).Substring(0, 32));
            IV = Encoding.UTF8.GetBytes(SECRET_IV.PadRight(16).Substring(0, 16));

            return 1;
        }

        public string Clave(string plainText)
        {
            byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_KEY));
            byte[] iv = new byte[16];
            Array.Copy(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_IV)), iv, iv.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Convert.ToBase64String(encrypted);
            }
        }

        public string TextoPlano(string encryptedText)
        {
            byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_KEY));
            byte[] iv = new byte[16];
            Array.Copy(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_IV)), iv, iv.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] inputBytes = Convert.FromBase64String(encryptedText);
                byte[] decrypted = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Encoding.UTF8.GetString(decrypted);
            }
        }
        public string Encrypt(string text)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_KEY));
                byte[] iv = new byte[16];
                Array.Copy(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_IV)), iv, iv.Length);

                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] inputBytes = Encoding.UTF8.GetBytes(text);
                byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Convert.ToBase64String(encrypted);
            }
        }

        public string Desemcriptar(string encryptedText)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_KEY));
                    byte[] iv = new byte[16];
                    Array.Copy(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_IV)), iv, iv.Length);

                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    byte[] inputBytes = Convert.FromBase64String(encryptedText);
                    byte[] decrypted = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                    return Encoding.UTF8.GetString(decrypted);
                }
            }
            catch (CryptographicException e)
            {
                // Manejo de la excepción de cifrado, por ejemplo, cuando el texto cifrado no es válido.
                Console.WriteLine($"Error al descifrar: {e.Message}");
                return null;
            }
        }

        public string Encriptar(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Key = Key;
                aes.IV = IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new StreamWriter(cs))
                            {
                                sw.Write(plainText);
                            }
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public string Manipularencriptacion(string text)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_KEY));
                byte[] iv = new byte[16];
                Array.Copy(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_IV)), iv, iv.Length);
                Console.WriteLine("Otro key-->" + key);
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] inputBytes = Encoding.UTF8.GetBytes(text);
                byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Convert.ToBase64String(encrypted); // Aquí el contenido cifrado se codifica en Base64.
            }
        }

        public string ManipularDesencriptar(string encryptedText)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_KEY));
                    byte[] iv = new byte[16];
                    Array.Copy(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SECRET_IV)), iv, iv.Length);

                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    byte[] inputBytes = Convert.FromBase64String(encryptedText);
                    byte[] decrypted = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                    return Encoding.UTF8.GetString(decrypted);
                }
            }
            catch (CryptographicException e)
            {
                // Manejo de la excepción de cifrado, por ejemplo, cuando el texto cifrado no es válido.
                Console.WriteLine($"Error al descifrar: {e.Message}");
                return null;
            }
        }

        public string TU_ENC(string plainText, byte[] key, byte[] iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;

            // Set key and IV
            byte[] aesKey = new byte[32];
            Array.Copy(key, 0, aesKey, 0, 32);
            encryptor.Key = aesKey;
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            // Convert the plainText string into a byte array
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // Encrypt the input plaintext string
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

            // Complete the encryption process
            cryptoStream.FlushFinalBlock();

            // Convert the encrypted data from a MemoryStream to a byte array
            byte[] cipherBytes = memoryStream.ToArray();

            // Close both the MemoryStream and the CryptoStream
            memoryStream.Close();
            cryptoStream.Close();

            // Convert the encrypted byte array to a base64 encoded string
            string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            // Return the encrypted data as a string
            return cipherText;
        }
        public string Tu_DES(string cipherText, byte[] key, byte[] iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;

            // Set key and IV
            byte[] aesKey = new byte[32];
            Array.Copy(key, 0, aesKey, 0, 32);
            encryptor.Key = aesKey;
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            // Will contain decrypted plaintext
            string plainText = String.Empty;

            try
            {
                // Convert the ciphertext string into a byte array
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                // Decrypt the input ciphertext string
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                // Complete the decryption process
                cryptoStream.FlushFinalBlock();

                // Convert the decrypted data from a MemoryStream to a byte array
                byte[] plainBytes = memoryStream.ToArray();

                // Convert the decrypted byte array to string
                plainText = Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);
            }
            finally
            {
                // Close both the MemoryStream and the CryptoStream
                memoryStream.Close();
                cryptoStream.Close();
            }

            // Return the decrypted data as a string
            return plainText;
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

        //Prueba 2
        static byte[] CreateKey(string key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                /*byte[] passwordBytes = Encoding.UTF8.GetBytes(key);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes).Substring(0, 32);*/
                byte[] passwordBytes = Encoding.UTF8.GetBytes(key);
                return sha256.ComputeHash(passwordBytes);
            }
        }

        static byte[] CreateIV(string secretIv)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] ivBytes = Encoding.UTF8.GetBytes(secretIv);
                byte[] hashBytes = sha256.ComputeHash(ivBytes);
                byte[] iv = new byte[16];
                Array.Copy(hashBytes, iv, iv.Length);
                return iv;
            }
        }

        public string Encript_a(string plaintext)
        {
            byte[] key = CreateKey(SECRET_KEY);
            Console.WriteLine("Esto es el key-->" + key);
            byte[] iv = CreateIV(SECRET_IV);
            using (Aes aes = Aes.Create())
            {
                //aes.Key = Encoding.UTF8.GetBytes(key);
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

                byte[] encryptedBytes;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plaintextBytes, 0, plaintextBytes.Length);
                    }
                    encryptedBytes = ms.ToArray();
                }

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public string Desencript_a(string encryptedText)
        {
            byte[] key = CreateKey(SECRET_KEY);
            byte[] iv = CreateIV(SECRET_IV);
            using (Aes aes = Aes.Create())
            {
                //aes.Key = Encoding.UTF8.GetBytes(key);
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

                byte[] decryptedBytes;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (System.IO.MemoryStream result = new System.IO.MemoryStream())
                        {
                            cs.CopyTo(result);
                            decryptedBytes = result.ToArray();
                        }
                    }
                }

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        //Metodo 2
        private static byte[] Create_Key(string secretKey)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(secretKey));
            }
        }

        private static byte[] Create_IV(string secretIv)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] ivBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(secretIv));
                byte[] iv = new byte[16];
                Array.Copy(ivBytes, iv, iv.Length);
                return iv;
            }
        }
        public string Encryptio_n(string text)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(text);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plaintextBytes, 0, plaintextBytes.Length);
                    }
                    // Convert the encrypted data to Base64
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        public string Decryptio_n(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
