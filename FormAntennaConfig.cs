using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;

namespace RFIDPrendas
{
    public partial class FormAntennaConfig : Form
    {
        private FormMain m_MainForm;
        private bool m_IsLoaded;

        public FormAntennaConfig(FormMain mainForm)
        {
            m_MainForm = mainForm;
            m_IsLoaded = false;
            InitializeComponent();
        }

        private void hopTableIndex_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_MainForm.m_ReaderAPI.IsConnected)
                {
                    if (m_MainForm.m_ReaderAPI.ReaderCapabilities.IsHoppingEnabled)
                    {
                        FrequencyHopInfo hopInfo = m_MainForm.m_ReaderAPI.ReaderCapabilities.FrequencyHopInfo;
                        int index = int.Parse(hopTableIndex_CB.SelectedItem.ToString());
                        int[] freqs = hopInfo[index - 1].FrequencyHopValues;

                        string hopTableFreqListMultiline = "";
                        hopFrequencies_TB.Text = "";
                        foreach (int freq in freqs)
                        {
                            if (hopTableFreqListMultiline != "")
                            {
                                hopTableFreqListMultiline = hopTableFreqListMultiline + ", ";
                            }
                            hopTableFreqListMultiline = hopTableFreqListMultiline + freq.ToString();
                        }
                        hopFrequencies_TB.Text = hopTableFreqListMultiline;
                    }
                }
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void AntennaConfig_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_MainForm.m_IsConnected)
                {
                    if (m_MainForm.m_ReaderAPI.IsConnected && !m_IsLoaded)
                    {
                        ushort[] antID = m_MainForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                        int[] rxValues = m_MainForm.m_ReaderAPI.ReaderCapabilities.ReceiveSensitivityValues;
                        int[] txValues = m_MainForm.m_ReaderAPI.ReaderCapabilities.TransmitPowerLevelValues;

                        if (antID.Length > 0)
                        {
                            foreach (ushort id in antID)
                                antennaID_CB.Items.Add(id);
                            antennaID_CB.SelectedIndex = 0;

                            Antennas.Config antConfig =
                                m_MainForm.m_ReaderAPI.Config.Antennas[antID[antennaID_CB.SelectedIndex]].GetConfig();

                            foreach (int rx in rxValues)
                                receiveSensitivity_CB.Items.Add(rx);
                            receiveSensitivity_CB.SelectedIndex = antConfig.ReceiveSensitivityIndex;

                            foreach (int tx in txValues)
                                transmitPower_CB.Items.Add(tx);

                            transmitPower_CB.SelectedIndex = antConfig.TransmitPowerIndex;

                            if (m_MainForm.m_ReaderAPI.ReaderCapabilities.IsHoppingEnabled)
                            {
                                this.Controls.Add(this.hopTable_GB);
                                FrequencyHopInfo hopInfo = m_MainForm.m_ReaderAPI.ReaderCapabilities.FrequencyHopInfo;
                                for (int i = 0; i < hopInfo.Length; i++)
                                {
                                    hopTableIndex_CB.Items.Add(hopInfo[i].HopTableID);
                                    if (hopInfo[i].HopTableID == antConfig.TransmitFrequencyIndex)
                                    {
                                        hopTableIndex_CB.SelectedIndex = i;
                                    }
                                }
                            }
                            else
                            {
                                this.Controls.Add(this.transmitFreq_GB);
                                int[] freq = m_MainForm.m_ReaderAPI.ReaderCapabilities.FixedFreqValues;
                                for (int i = 0; i < freq.Length; i++)
                                    transmitFreq_CB.Items.Add(freq[i].ToString());
                                if (freq.Length > 0)
                                    transmitFreq_CB.SelectedIndex = 0;
                            }
                        }
                    }
                }
                m_IsLoaded = true;
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void antennaConfigButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_MainForm.m_IsConnected)
                {
                    ushort[] antID = m_MainForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                    Antennas.Config antConfig =
                        m_MainForm.m_ReaderAPI.Config.Antennas[antID[antennaID_CB.SelectedIndex]].GetConfig();

                    antConfig.ReceiveSensitivityIndex = (ushort)receiveSensitivity_CB.SelectedIndex;

                    antConfig.TransmitPowerIndex = (ushort)transmitPower_CB.SelectedIndex;

                    string ls_antena = antID[antennaID_CB.SelectedIndex].ToString();
                    ushort PowerIndex = (ushort)transmitPower_CB.SelectedIndex;
                    string ls_PowerIndex = PowerIndex.ToString();

                    SetConfiguracionIni(ls_antena, ls_PowerIndex);


                    if (!m_MainForm.m_ReaderAPI.ReaderCapabilities.IsHoppingEnabled)
                    {
                        antConfig.TransmitFrequencyIndex = (ushort)(transmitFreq_CB.SelectedIndex + 1);
                    }
                    else
                    {
                        antConfig.TransmitFrequencyIndex = (ushort)(hopTableIndex_CB.SelectedIndex + 1);
                    }
                    m_MainForm.m_ReaderAPI.Config.Antennas[antID[antennaID_CB.SelectedIndex]].SetConfig(antConfig);

                    m_MainForm.functionCallStatusLabel.Text = "Set Antenna Configuration Successfully";
                }
                else
                {
                    m_MainForm.functionCallStatusLabel.Text = "Please connect to a reader";
                }
            }
            catch (InvalidUsageException iue)
            {
                m_MainForm.functionCallStatusLabel.Text = iue.VendorMessage;
            }
            catch (OperationFailureException ofe)
            {
                m_MainForm.functionCallStatusLabel.Text = ofe.StatusDescription;
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
            this.Close();
        }

        private void antennaID_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_MainForm.m_IsConnected && m_IsLoaded)
                {
                    ushort[] antID = m_MainForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                    Antennas.Config antConfig =
                       m_MainForm.m_ReaderAPI.Config.Antennas[antID[antennaID_CB.SelectedIndex]].GetConfig();
                    transmitPower_CB.SelectedIndex = antConfig.TransmitPowerIndex;
                }
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private int SetConfiguracionIni(string antena, string powerindex)
        {
            string ls_seccion = "Antena";
            IniFile fileIniConfig = new IniFile();
            fileIniConfig.LoadConfiguracion();
            fileIniConfig.SetValue(ls_seccion, antena, powerindex);
            return 1;
        }
    }
}
