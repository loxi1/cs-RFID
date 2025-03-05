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
    public partial class FormBlockErase : Form
    {
        private FormMain m_MainForm;
        internal TagAccess.BlockEraseAccessParams m_BlockEraseParams;

        public FormBlockErase(FormMain mainForm)
        {
            InitializeComponent();
            m_MainForm = mainForm;
            m_BlockEraseParams = new TagAccess.BlockEraseAccessParams();
            m_BlockEraseParams.MemoryBank = MEMORY_BANK.MEMORY_BANK_USER;
            m_BlockEraseParams.AccessPassword = 0;
            m_BlockEraseParams.ByteOffset = 0;
            m_BlockEraseParams.ByteCount = 0;
            this.eraseButton.Enabled = true;
        }

        private void accessFilterButton_Click(object sender, EventArgs e)
        {
            //m_MainForm.m_AccessFilterForm.ShowDialog(this);
        }

        private void BlockErase_Load(object sender, EventArgs e)
        {
            //if (m_MainForm.inventoryList.SelectedItems.Count > 0)
            //{
            //    ListViewItem item = m_MainForm.inventoryList.SelectedItems[0];
            //    tagID_TB.Text = item.Text;
            //}
            //else
            //{
            //    tagID_TB.Text = "";
            //}
            this.memBank_CB.SelectedIndex = (int)m_BlockEraseParams.MemoryBank;
            this.Password_TB.Text = m_BlockEraseParams.AccessPassword.ToString("X");
            this.offset_TB.Text = m_BlockEraseParams.ByteOffset.ToString();
            this.length_TB.Text = m_BlockEraseParams.ByteCount.ToString();
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tagID_TB.Text.Length == 0 /*&& m_MainForm.m_AccessFilterForm.getFilter() == null*/)
                {
                    m_MainForm.functionCallStatusLabel.Text = "No TagID or Access Filter is defined";
                    return;
                }
                int length = int.Parse(this.length_TB.Text);
                if (length % 2 != 0)
                {
                    m_MainForm.functionCallStatusLabel.Text = "Data length has to be a word size (2X)";
                    return;
                }
                else
                {
                    m_MainForm.functionCallStatusLabel.Text = "";
                }

                m_BlockEraseParams.MemoryBank = (MEMORY_BANK)this.memBank_CB.SelectedIndex;
                m_BlockEraseParams.AccessPassword = 0;
                if (this.Password_TB.Text.Length > 0)
                {
                    string accessPassword = this.Password_TB.Text;
                    if (accessPassword.StartsWith("0x"))
                    {
                        accessPassword = accessPassword.Substring(2);
                    }
                    m_BlockEraseParams.AccessPassword = uint.Parse(
                        accessPassword, System.Globalization.NumberStyles.HexNumber);
                }
                m_BlockEraseParams.ByteOffset = ushort.Parse(this.offset_TB.Text);
                m_BlockEraseParams.ByteCount = ushort.Parse(this.length_TB.Text);
                m_MainForm.m_SelectedTagID = this.tagID_TB.Text;

                m_MainForm.accessBackgroundWorker.RunWorkerAsync(ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE);
                this.eraseButton.Enabled = false;
            }
            catch (Exception ex)
            {
                this.eraseButton.Enabled = true;
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
        private void memBank_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_BlockEraseParams.MemoryBank = (MEMORY_BANK)this.memBank_CB.SelectedIndex;
            if (m_BlockEraseParams.MemoryBank == MEMORY_BANK.MEMORY_BANK_EPC)
            {
                this.offset_TB.Text = "4";
                this.length_TB.Text = "12";
            }
            else
            {
                this.offset_TB.Text = "0";
                this.length_TB.Text = "0";
            }

        }
    }
}
