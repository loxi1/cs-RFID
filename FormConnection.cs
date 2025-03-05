using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Symbol.RFID3;

namespace RFIDPrendas
{
    public partial class FormConnection : Form
    {
        private FormMain m_MainForm;
        internal string s_error;
        internal string m_Titulo = "Contador";
        private int m_Editarconexion = 0;
        private string m_IPReader = "";
        public FormConnection(FormMain MainForm)
        {
            m_MainForm = MainForm;
            InitializeComponent();
        }

        public string IpText
        {
            get
            {
                return hostname_TB.Text;
            }
        }

        public string PortText
        {
            get
            {
                return port_TB.Text;
            }
        }

        public String CertFilePath
        {
            get
            {
                return certFilePath_TB.Text;
            }
        }

        public string PrivateKeyFilePath
        {
            get
            {
                return privateKeyFilePath_TB.Text;
            }
        }

        public string KeyPassPhrase
        {
            get
            {
                return keyPassPhrase_TB.Text;
            }
        }

        public string RootCertFilePath
        {
            get
            {
                return rootCertFilePath_TB.Text;
            }
        }

        private void connectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                m_MainForm.connectBackgroundWorker.RunWorkerAsync(connectionButton.Tag);
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            if (GetIni() != 1)
            {
                return;
            }
            //bool s_check = m_Editarconexion==1 ? true : false;
            bool isEditable = m_Editarconexion == 1;
            hostname_TB.Enabled = isEditable;
            port_TB.Enabled = isEditable;
            secureModeCheckBox.Enabled = isEditable;
            validatePeerCertCheckBox.Enabled = isEditable;
            hostname_TB.Text = m_IPReader;
        }

        private String getModulePath()
        {
            string filePath = System.Windows.Forms.Application.ExecutablePath;
            int location = filePath.LastIndexOf('\\');
            return filePath.Substring(0, location);
        }

        private void secureModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (secureModeCheckBox.Checked)
                {
                    // Enabled all the controls for secure connection
                    validatePeerCertCheckBox.Enabled = true;
                    certFilePath_TB.Enabled = true;
                    certFilePathBrowseButton.Enabled = true;
                    privateKeyFilePath_TB.Enabled = true;
                    privateKeyFileBrowseButton.Enabled = true;
                    keyPassPhrase_TB.Enabled = true;
                    rootCertFilePath_TB.Enabled = true;
                    rootCertFilePathBrowseButton.Enabled = true;

                    port_TB.Text = "5085";
                    String modulePath = getModulePath();

                    // If text box doesn't cotain any path/text before
                    if (0 == certFilePath_TB.Text.Length)
                    {
                        String certFilePath = modulePath;
                        certFilePath += @"\client_crt.pem";
                        certFilePath_TB.Text = certFilePath;
                    }
                    if (0 == privateKeyFilePath_TB.Text.Length)
                    {
                        String privateKeyFilePath = modulePath;
                        privateKeyFilePath += @"\client_key.pem";
                        privateKeyFilePath_TB.Text = privateKeyFilePath;
                    }
                    if (0 == rootCertFilePath_TB.Text.Length)
                    {
                        String rootCertFilePath = modulePath;
                        rootCertFilePath += @"\cacert.pem";
                        rootCertFilePath_TB.Text = rootCertFilePath;
                    }

                    keyPassPhrase_TB.Text = "abcd12345";
                }
                else
                {
                    // Disable all the controls for secure connection
                    validatePeerCertCheckBox.Enabled = false;
                    certFilePath_TB.Enabled = false;
                    certFilePathBrowseButton.Enabled = false;
                    privateKeyFilePath_TB.Enabled = false;
                    privateKeyFileBrowseButton.Enabled = false;
                    keyPassPhrase_TB.Enabled = false;
                    rootCertFilePath_TB.Enabled = false;
                    rootCertFilePathBrowseButton.Enabled = false;

                    port_TB.Text = "5084";
                }
            }
            catch { }
        }

        private void certFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog certFilePathDialog = new OpenFileDialog();
            DialogResult result = certFilePathDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                certFilePath_TB.Text = certFilePathDialog.FileName;
            }
        }

        private void privateKeyFileBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog privateKeyFileDialog = new OpenFileDialog();
            DialogResult result = privateKeyFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                privateKeyFilePath_TB.Text = privateKeyFileDialog.FileName;
            }
        }

        private void rootCertFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog rootCertFileDialog = new OpenFileDialog();
            DialogResult result = rootCertFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                rootCertFilePath_TB.Text = rootCertFileDialog.FileName;
            }
        }

        private int GetIni()
        {
            IniFile iniFile = new IniFile();
            bool lb_exist = iniFile.LoadConfiguracion();
            if (!lb_exist)
            {
                s_error = iniFile.GetError();
                return 0;
            }

            m_Editarconexion = Int32.Parse(iniFile.GetValue(m_Titulo, "Editarconexion")); ;
            m_IPReader = iniFile.GetValue(m_Titulo, "IPReader");

            return 1;
        }

        public string GetError()
        {
            return s_error;
        }

        private System.Windows.Forms.Label readerIPLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label connectionLabel;
        internal System.Windows.Forms.Button connectionButton;
        internal System.Windows.Forms.TextBox port_TB;
        internal System.Windows.Forms.TextBox hostname_TB;
        internal System.Windows.Forms.CheckBox secureModeCheckBox;
        internal CheckBox validatePeerCertCheckBox;
        internal System.Windows.Forms.TextBox certFilePath_TB;
        internal System.Windows.Forms.Button certFilePathBrowseButton;
        internal System.Windows.Forms.Label CertFileLabel;
        internal System.Windows.Forms.Label PrivateKeyFileLabel;
        internal System.Windows.Forms.Button privateKeyFileBrowseButton;
        internal System.Windows.Forms.TextBox privateKeyFilePath_TB;
        internal System.Windows.Forms.Label KeyPassPhraseLabel;
        internal System.Windows.Forms.TextBox keyPassPhrase_TB;
        internal System.Windows.Forms.Label RootCertFilePathLabel;
        internal System.Windows.Forms.Button rootCertFilePathBrowseButton;
        internal TextBox rootCertFilePath_TB;
    }
}
