using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Symbol.RFID3;

namespace RFIDPrendas
{
    public partial class FormDatosConfig : Form
    {
        private FormMain m_MainForm;
        private string m_Titulo = "Contador";
        private string conf_inical = "Contadordefecto";
        private int m_tiempo = 0;
        private int m_sensibilidad = 0;
        private int m_vercronometro = 0;
        private int m_editarconexion = 0;
        private string m_ip_reader = "";
        internal string s_error;
        public FormDatosConfig(FormMain mainForm)
        {
            m_MainForm = mainForm;
            InitializeComponent();
            if (GetIni(m_Titulo) == 1)
            {
                textBoxSegundos.Text = m_tiempo.ToString();
                textBoxSensibilidad.Text = m_sensibilidad.ToString();
                checkBox1VerCronometro.Checked = (m_vercronometro == 1);
                checkBox1Conexion.Checked = (m_editarconexion == 1);
                ipReader.Text = m_ip_reader;
            }
        }

        private int GetIni(string titulo)
        {
            IniFile iniFile = new IniFile();
            bool lb_exist = iniFile.LoadConfiguracion();
            if (!lb_exist)
            {
                s_error = iniFile.GetError();
                return 0;
            }

            m_tiempo = Int32.Parse(iniFile.GetValue(titulo, "Valor"));
            m_sensibilidad = Int32.Parse(iniFile.GetValue(titulo, "Sensibilidad"));
            m_vercronometro = Int32.Parse(iniFile.GetValue(titulo, "Vercronometro"));
            m_editarconexion = Int32.Parse(iniFile.GetValue(titulo, "Editarconexion"));
            m_ip_reader = iniFile.GetValue(titulo, "IPReader");

            return 1;
        }

        private void FormDatosConfig_Load(object sender, EventArgs e)
        {

        }

        private void button1GuardarConfiguracion_Click(object sender, EventArgs e)
        {
            m_tiempo = Int32.Parse(textBoxSegundos.Text);
            m_sensibilidad = Int32.Parse(textBoxSensibilidad.Text);
            m_vercronometro = checkBox1VerCronometro.Checked ? 1 : 0;
            m_editarconexion = checkBox1Conexion.Checked ? 1 : 0;
            m_ip_reader = ipReader.Text;

            if (m_tiempo > 0 && m_tiempo <= 20)
            {
                if (m_sensibilidad > 0 && m_sensibilidad <= 5)
                {
                    if (m_tiempo > m_sensibilidad && IsValid_IP(m_ip_reader))
                    {
                        SetConfiguracionIni(m_Titulo, "Valor", m_tiempo.ToString());
                        SetConfiguracionIni(m_Titulo, "Sensibilidad", m_sensibilidad.ToString());
                        SetConfiguracionIni(m_Titulo, "Vercronometro", m_vercronometro.ToString());
                        SetConfiguracionIni(m_Titulo, "Editarconexion", m_editarconexion.ToString());
                        SetConfiguracionIni(m_Titulo, "IPReader", m_ip_reader);
                        SetConfiguracionIni(conf_inical, "IPReader", m_ip_reader);
                    }
                    else
                    {
                        MessageBox.Show("Error\n La sensibilidad es menor al tiempo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("Error\n Ingresar valor Menor a 5", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Error\n Ingresar valore Menor a 20", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            this.Close();
        }

        private int SetConfiguracionIni(string titulo, string parametro, string dato)
        {
            IniFile iniFile = new IniFile();
            IniFile fileIniConfig = iniFile;
            fileIniConfig.LoadConfiguracion();
            fileIniConfig.SetValue(titulo, parametro, dato);
            return 1;
        }

        private void button1Configuracioninicial_Click(object sender, EventArgs e)
        {
            if (GetIni(conf_inical) == 1)
            {
                textBoxSegundos.Text = m_tiempo.ToString();
                textBoxSensibilidad.Text = m_sensibilidad.ToString();
                checkBox1VerCronometro.Checked = (m_vercronometro == 1);
                checkBox1Conexion.Checked = (m_editarconexion == 1);
                SetConfiguracionIni(m_Titulo, "Valor", m_tiempo.ToString());
                SetConfiguracionIni(m_Titulo, "Sensibilidad", m_sensibilidad.ToString());
                SetConfiguracionIni(m_Titulo, "Vercronometro", m_vercronometro.ToString());
                SetConfiguracionIni(m_Titulo, "Editarconexion", m_editarconexion.ToString());
            }
            this.Close();
        }

        private void IpReader_TextChanged(object sender, EventArgs e)
        {
            string ip = ipReader.Text;

            // Validar que el texto tenga el formato correcto para una IP
            if (IsValidIP(ip))
            {
                ipReader.BackColor = Color.White;  // Fondo blanco si es válida
            }
            else
            {
                ipReader.BackColor = Color.LightCoral;  // Fondo rojo si no es válida
            }
        }

        private bool IsValidIP(string ip)
        {
            // Verifica si la dirección IP tiene el formato correcto
            string[] parts = ip.Split('.');

            // Debe tener 4 partes
            if (parts.Length != 4)
                return false;

            foreach (string part in parts)
            {
                // Verifica que cada parte sea un número entre 0 y 255
                if (!int.TryParse(part, out int num) || num < 0 || num > 255)
                {
                    return false;
                }
            }
            return true;
        }
        // Método para validar si el texto es una dirección IP válida
        public static bool IsValid_IP(string ip)
        {
            // Usar el método TryParse de la clase IPAddress
            return IPAddress.TryParse(ip, out _);
        }
    }
}
