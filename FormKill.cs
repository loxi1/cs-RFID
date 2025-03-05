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
    public partial class FormKill : Form
    {
        private FormMain m_MainForm;
        internal TagAccess.KillAccessParams m_KillParams;


        public FormKill(FormMain mainForm)
        {
            InitializeComponent();
            m_MainForm = mainForm;
            m_KillParams = new TagAccess.KillAccessParams();
            m_KillParams.KillPassword = 0;
        }

        private void Kill_Load(object sender, EventArgs e)
        {
            //if (m_AppForm.inventoryList.SelectedItems.Count > 0)
            //{
            //    ListViewItem item = m_AppForm.inventoryList.SelectedItems[0];
            //    this.tagID_TB.Text = item.Text;
            //}
            //else
            //{
            //    this.tagID_TB.Text = "";
            //}
            this.killPwd_TB.Text = m_KillParams.KillPassword.ToString("X");
        }

        private void accessFilterButton_Click(object sender, EventArgs e)
        {
            //m_MainForm.m_AccessFilterForm.ShowDialog(this);
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tagID_TB.Text.Length == 0 /*&& m_MainForm.m_AccessFilterForm.getFilter() == null*/)
                {
                    m_MainForm.functionCallStatusLabel.Text = "No TagID or Access Filter is defined";
                    return;
                }
                m_KillParams.KillPassword = 0;
                if (this.killPwd_TB.Text.Length > 0)
                {
                    string killPassword = this.killPwd_TB.Text;
                    if (killPassword.StartsWith("0x"))
                    {
                        killPassword = killPassword.Substring(2);
                    }
                    m_KillParams.KillPassword = uint.Parse(killPassword, System.Globalization.NumberStyles.HexNumber);
                }
                m_MainForm.m_SelectedTagID = this.tagID_TB.Text;

                m_MainForm.accessBackgroundWorker.RunWorkerAsync(ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL);
                killButton.Enabled = false;
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void tagID_TB_TextChanged(object sender, EventArgs e)
        {
            if (tagID_TB.Text.Length == 0 && !accessFilterButton.Enabled)
            {
                accessFilterButton.Enabled = true;
            }
            else if (tagID_TB.Text.Length > 0 && accessFilterButton.Enabled)
            {
                accessFilterButton.Enabled = false;
            }
        }
    }
}
