using Symbol.RFID3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDPrendas
{
    public partial class FormPrenda : Form
    {

        private FormMain m_MainForm = null;
        internal RFIDReader m_ReaderAPI;
        internal bool m_IsReading = false;
        public RFIDResults m_Result;
        internal string m_Empresa = "COFACO";
        internal string m_Usuario = "";        
        internal int m_contador = 0;
        internal string m_CodBarra = "";
        internal string m_CodRfid = "";
        internal string m_Cod_Trabajador = "030658";
        //internal ReaderManagement m_ReaderMgmt;
        //internal READER_TYPE m_ReaderType;
        //internal BDDespacho m_despachoBD;
        //internal BDCabecera m_cabeceraBD;
        //internal BDDetalleRfid m_RfidBD;

        internal Socket m_ListeningSocket = null, m_AcceptedSocket = null;

        internal ArrayList m_GPIStateList;
        internal string m_SelectedTagID = "";
        internal DateTime gdt_Fecha;

        private delegate void UpdateStatus(Events.StatusEventData eventData);
        private readonly UpdateStatus m_UpdateStatusHandler = null;
        private delegate void UpdateRead(Events.ReadEventData eventData);
        private UpdateRead m_UpdateReadHandler = null;
        private TagData m_ReadTag = null;
        private Hashtable m_TagTable;        
        private uint m_TagTotalCount;
        private BDPrenda m_BDPrenda;
        private BDPrendaScm m_BDPrendaScm;
        private BDContenedor m_BDContenedor;
        private DataTable m_DTPrendaTmp;
        //private MySqlConnection connectionMySql;                

        internal class AccessOperationResult
        {
            public RFIDResults m_Result;
            public String m_VendorMessage;
            public String m_StatusDescription;
            public ACCESS_OPERATION_CODE m_OpCode;

            public AccessOperationResult()
            {
                m_Result = RFIDResults.RFID_NO_ACCESS_IN_PROGRESS;
                m_OpCode = ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ;
            }
        }

        public FormPrenda(FormMain mainForm, RFIDReader pReaderAPI, string codTrabajdor)
        {
            InitializeComponent();
            m_BDPrenda = new BDPrenda();
            m_BDPrendaScm = new BDPrendaScm();
            m_BDContenedor = new BDContenedor();
            m_Cod_Trabajador = codTrabajdor;
            m_MainForm = mainForm;
            m_ReaderAPI = pReaderAPI;
            FormBorderStyle = FormBorderStyle.FixedDialog;            
            StartPosition = FormStartPosition.WindowsDefaultLocation;
            m_GPIStateList = new ArrayList();
            m_UpdateStatusHandler = new UpdateStatus(myUpdateStatus);
            m_UpdateReadHandler = new UpdateRead(myUpdateRead);
            m_ReadTag = new Symbol.RFID3.TagData();

            m_TagTable = new Hashtable();
            m_TagTotalCount = 0;
            configureMenuItemsUponConnectDisconnect();

        }

        private void myUpdateStatus(Events.StatusEventData eventData)
        {
            switch (eventData.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Procesando...";                    
                    m_IsReading = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Proceso detenido.";
                    m_IsReading = false;

                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Operación de acceso iniciada.";
                    m_IsReading = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Operación de acceso detendida.";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        m_MainForm.functionCallStatusLabel.Text = "Acceso finalizado - Total OK : " + successCount.ToString()
                            + ", Total fallos: " + failureCount.ToString();
                    }
                    resetButtonState();                    
                    m_IsReading = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    m_MainForm.functionCallStatusLabel.Text = "Antenna " + eventData.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = " Buffer full warning";
                    myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Buffer full";
                    myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Disconnection Event " + eventData.DisconnectionEventData.DisconnectEventInfo.ToString();
                    m_MainForm.connectBackgroundWorker.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.TEMPERATURE_ALARM_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Temperature Alarm " + eventData.TemperatureAlarmEventData.SourceName.ToString() + " Temperature " + eventData.TemperatureAlarmEventData.CurrentTemperature.ToString() + " Level " + eventData.TemperatureAlarmEventData.AlarmLevel.ToString();
                    break;
                default:
                    break;
            }
        }

        private void myUpdateRead(Events.ReadEventData eventData)
        {
            Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
            if (tagData != null)
            {
                for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                {
                    if (tagData[nIndex].ContainsLocationInfo)
                    {
                        //m_MainForm.m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                    }

                    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                    {
                        Symbol.RFID3.TagData tag = tagData[nIndex];
                        string tagID = tag.TagID;
                        bool isFound = false;

                        lock (m_TagTable.SyncRoot)
                        {
                            isFound = m_TagTable.ContainsKey(tagID);
                            //if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                            //{
                            //    tagID = tag.TagID + tag.MemoryBank.ToString()
                            //        + tag.MemoryBankDataOffset.ToString();
                            //    isFound = m_TagTable.ContainsKey(tagID);
                            //}
                        }

                        if (isFound)
                        {
                            uint count = 0;
                            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                            try
                            {
                                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                            }
                            catch (FormatException fe)
                            {
                                m_MainForm.functionCallStatusLabel.Text = fe.Message;
                                break;
                            }
                            item.SubItems[2].Text = tag.AntennaID.ToString();
                            item.SubItems[3].Text = count.ToString();
                            item.SubItems[4].Text = tag.PeakRSSI.ToString();
                            item.SubItems[5].Text = GetPhaseInDegree(tag.PhaseInfo);

                            string memoryBank = tag.MemoryBank.ToString();
                            int index = memoryBank.LastIndexOf('_');
                            if (index != -1)
                            {
                                memoryBank = memoryBank.Substring(index + 1);
                            }
                            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[6].Text))
                            {
                                item.SubItems[7].Text = tag.MemoryBankData;
                                item.SubItems[8].Text = memoryBank;
                                item.SubItems[9].Text = tag.MemoryBankDataOffset.ToString();

                                lock (m_TagTable.SyncRoot)
                                {
                                    m_TagTable.Remove(tagID);
                                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        + tag.MemoryBankDataOffset.ToString(), item);
                                }
                            }
                            item.SubItems[1].Text = getTagEvent(tag);

                        }
                        else
                        {
                            ListViewItem item = new ListViewItem(tag.TagID);
                            // 1 - tag event
                            ListViewItem.ListViewSubItem subItem;
                            subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
                            item.SubItems.Add(subItem);
                            // 2 - antenna ID
                            subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
                            item.SubItems.Add(subItem);
                            // 3 - tag seen count
                            subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
                            m_TagTotalCount += tag.TagSeenCount;
                            item.SubItems.Add(subItem);
                            // 4 - RSSI
                            subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                            item.SubItems.Add(subItem);
                            // 5 - phase
                            subItem = new ListViewItem.ListViewSubItem(item, GetPhaseInDegree(tag.PhaseInfo));
                            item.SubItems.Add(subItem);
                            // 6 - PC bits
                            subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                            item.SubItems.Add(subItem);

                            //if (memBank_CB.SelectedIndex >= 1)
                            //{
                            //    // 7 - Memory bank data
                            //    subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                            //    item.SubItems.Add(subItem);

                            //    string memoryBank = tag.MemoryBank.ToString();
                            //    int index = memoryBank.LastIndexOf('_');
                            //    if (index != -1)
                            //    {
                            //        memoryBank = memoryBank.Substring(index + 1);
                            //    }

                            //    // 8 - Memory Bank
                            //    subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                            //    item.SubItems.Add(subItem);

                            //    // 9 - memory bank offset
                            //    subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                            //    item.SubItems.Add(subItem);
                            //}
                            //else
                            //{
                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);
                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);
                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);
                            //}
                            // 10 - Brand ID check status
                            //if (checkBoxEnableBrandIDCheck.Checked)
                            //{
                            //    if (tag.BrandValid != 0)
                            //    {
                            //        subItem = new ListViewItem.ListViewSubItem(item, "Passed");
                            //    }
                            //    else
                            //    {
                            //        subItem = new ListViewItem.ListViewSubItem(item, "Failed");
                            //    }
                            //    item.SubItems.Add(subItem);
                            //}
                            //inventoryList.BeginUpdate();
                            //inventoryList.Items.Add(item);
                            //inventoryList.EndUpdate();

                            lock (m_TagTable.SyncRoot)
                            {
                                m_TagTable.Add(tagID, item);
                            }

                            //int cantidadEtiquetas = m_TagTable.Count;                            

                            setCantidadTag();
                        }
                    }
                }
                //totalTagValueLabel.Text = m_TagTable.Count + "  (" + m_TagTotalCount + ")";
            }
        }

        private void Events_ReadNotify(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }

        public void Events_StatusNotify(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }

        private void accessBackgroundWorker_DoWork(object sender, DoWorkEventArgs accessEvent)
        {
            try
            {
                m_MainForm.m_AccessOpResult.m_OpCode = (ACCESS_OPERATION_CODE)accessEvent.Argument;
                m_MainForm.m_AccessOpResult.m_Result = RFIDResults.RFID_API_SUCCESS;

                if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        //m_ReadTag = m_ReaderAPI.Actions.TagAccess.ReadWait(
                        //m_SelectedTagID, m_MainForm.m_ReadForm.m_ReadParams, m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        //m_ReaderAPI.Actions.TagAccess.ReadEvent(m_MainForm.m_ReadForm.m_ReadParams,
                        //    m_MainForm.m_AccessFilterForm.getFilter(), m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        //m_ReaderAPI.Actions.TagAccess.WriteWait(
                        //    m_SelectedTagID, m_MainForm.m_WriteForm.m_WriteParams, m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        //m_ReaderAPI.Actions.TagAccess.WriteEvent(
                        //    m_MainForm.m_WriteForm.m_WriteParams, m_MainForm.m_AccessFilterForm.getFilter(), m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        //m_ReaderAPI.Actions.TagAccess.LockWait(
                        //    m_SelectedTagID, m_MainForm.m_LockForm.m_LockParams, m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        //m_ReaderAPI.Actions.TagAccess.LockEvent(
                        //    m_MainForm.m_LockForm.m_LockParams, m_MainForm.m_AccessFilterForm.getFilter(), m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        //m_ReaderAPI.Actions.TagAccess.KillWait(
                        //    m_SelectedTagID, m_MainForm.m_KillForm.m_KillParams, m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        //m_ReaderAPI.Actions.TagAccess.KillEvent(
                        //    m_MainForm.m_KillForm.m_KillParams, m_MainForm.m_AccessFilterForm.getFilter(), m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_WRITE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        //m_ReaderAPI.Actions.TagAccess.BlockWriteWait(
                        //    m_SelectedTagID, m_MainForm.m_BlockWriteForm.m_WriteParams, m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        //m_ReaderAPI.Actions.TagAccess.BlockWriteEvent(
                        //    m_MainForm.m_BlockWriteForm.m_WriteParams, m_MainForm.m_AccessFilterForm.getFilter(), m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        //m_ReaderAPI.Actions.TagAccess.BlockEraseWait(
                        //    m_SelectedTagID, m_MainForm.m_BlockEraseForm.m_BlockEraseParams, m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        //m_ReaderAPI.Actions.TagAccess.BlockEraseEvent(
                        //    m_MainForm.m_BlockEraseForm.m_BlockEraseParams, m_MainForm.m_AccessFilterForm.getFilter(), m_MainForm.m_AntennaInfoForm.getInfo());
                    }
                }
            }
            catch (OperationFailureException ofe)
            {
                m_MainForm.m_AccessOpResult.m_Result = ofe.Result;
                m_MainForm.m_AccessOpResult.m_StatusDescription = ofe.StatusDescription;
                m_MainForm.m_AccessOpResult.m_VendorMessage = ofe.VendorMessage;
            }
            catch (InvalidUsageException ex)
            {
                m_MainForm.m_AccessOpResult.m_Result = RFIDResults.RFID_API_PARAM_ERROR;
                m_MainForm.m_AccessOpResult.m_StatusDescription = ex.Info;
                m_MainForm.m_AccessOpResult.m_VendorMessage = ex.VendorMessage;
            }

            accessEvent.Result = m_MainForm.m_AccessOpResult;
        }

        private void accessBackgroundWorker_ProgressChanged(object sender,
           ProgressChangedEventArgs pce)
        {

        }

        private void accessBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs accessEvents)
        {
            if (accessEvents.Error != null)
            {
                m_MainForm.functionCallStatusLabel.Text = accessEvents.Error.Message;
                //reset button state if an exception is captured (e.g InvalidUsageException)
                resetButtonState();
                //memBank_CB.Enabled = true;
            }
            else
            {
                // Handle AccessWait Operations              
                AccessOperationResult accessOpResult = (AccessOperationResult)accessEvents.Result;
                if (accessOpResult.m_Result == RFIDResults.RFID_API_SUCCESS)
                {
                    if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ)
                    {
                        if (m_SelectedTagID != String.Empty)
                        {
                            if (m_ReadTag.OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                m_ReadTag.OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS)
                            {
                                //if (inventoryList.Items.Count > 0 && inventoryList.SelectedItems.Count > 0) // ensure that a tag item is currently selected in the TagListView
                                //if (0 > 0) // ensure that a tag item is currently selected in the TagListView
                                //{
                                //    //ListViewItem item;
                                //    string tagID = m_ReadTag.TagID + m_ReadTag.MemoryBank.ToString()
                                //        + m_ReadTag.MemoryBankDataOffset.ToString();

                                //    //if (item.SubItems[6].Text.Length > 0)
                                //    //{
                                //    bool isFound = false;

                                //    // Search or add new one
                                //    lock (m_TagTable.SyncRoot)
                                //    {
                                //        isFound = m_TagTable.ContainsKey(tagID);
                                //    }

                                //    if (!isFound)
                                //    {
                                //        //ListViewItem newItem = new ListViewItem(m_ReadTag.TagID);
                                //        // 1 - tagEvent (New, Invisible, Back to Visible 
                                //        //ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(newItem, getTagEvent(m_ReadTag));
                                //        m_TagTotalCount += m_ReadTag.TagSeenCount;
                                //        //newItem.SubItems.Add(subItem);
                                //        // 2 - Antenna ID
                                //        //subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.AntennaID.ToString());
                                //        //newItem.SubItems.Add(subItem);
                                //        //// 3 - tag Seent count 
                                //        //subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.TagSeenCount.ToString());
                                //        //newItem.SubItems.Add(subItem);
                                //        //// 4 - RSSI
                                //        //subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PeakRSSI.ToString());
                                //        //newItem.SubItems.Add(subItem);
                                //        //// 5 - Phase
                                //        //subItem = new ListViewItem.ListViewSubItem(item, GetPhaseInDegree(m_ReadTag.PhaseInfo));
                                //        //newItem.SubItems.Add(subItem);
                                //        //// 6 - PC bits
                                //        //subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PC.ToString("X"));
                                //        //newItem.SubItems.Add(subItem);
                                //        //// 7 - Memory Bank Data
                                //        //subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankData);
                                //        //newItem.SubItems.Add(subItem);

                                //        string memoryBank = m_ReadTag.MemoryBank.ToString();
                                //        int index = memoryBank.LastIndexOf('_');
                                //        if (index != -1)
                                //        {
                                //            memoryBank = memoryBank.Substring(index + 1);
                                //        }
                                //        // 8 - Memory Bank
                                //        //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                //        //newItem.SubItems.Add(subItem);

                                //        // 9 - Memory Bank Offset
                                //        //subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankDataOffset.ToString());
                                //        //newItem.SubItems.Add(subItem);

                                //        // 10 - Brand ID check status
                                //        //if (checkBoxEnableBrandIDCheck.Checked)
                                //        //{
                                //        //    subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.BrandValid.ToString());
                                //        //    newItem.SubItems.Add(subItem);
                                //        //}
                                //        //inventoryList.BeginUpdate();
                                //        //inventoryList.Items.Add(newItem);
                                //        //inventoryList.EndUpdate();

                                //        //lock (m_TagTable.SyncRoot)
                                //        //{
                                //        //    m_TagTable.Add(tagID, newItem);
                                //        //}
                                //        //}
                                //        //else
                                //        //{
                                //        //item.SubItems[7].Text = m_ReadTag.MemoryBankData;
                                //        //item.SubItems[9].Text = m_ReadTag.MemoryBankDataOffset.ToString();
                                //        //}
                                //    }
                                //    else
                                //    {
                                //        // Empty Memory Bank Slot
                                //        //item.SubItems[6].Text = m_ReadTag.MemoryBankData;

                                //        string memoryBank = ""; //m_ReadForm.m_ReadParams.MemoryBank.ToString();
                                //        int index = memoryBank.LastIndexOf('_');
                                //        if (index != -1)
                                //        {
                                //            memoryBank = memoryBank.Substring(index + 1);
                                //        }
                                //        //item.SubItems[8].Text = memoryBank;
                                //        //item.SubItems[9].Text = m_ReadTag.MemoryBankDataOffset.ToString();

                                //        lock (m_TagTable.SyncRoot)
                                //        {
                                //            m_TagTable.Remove(m_ReadTag.TagID);
                                //            //m_TagTable.Add(tagID, item);
                                //        }
                                //    }
                                //}

                                //this.m_ReadForm.ReadData_TB.Text = m_ReadTag.MemoryBankData;
                                m_MainForm.functionCallStatusLabel.Text = "Read Succeed";

                            }
                        }
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
                    {
                        m_MainForm.functionCallStatusLabel.Text = "Write Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
                    {
                        m_MainForm.functionCallStatusLabel.Text = "Lock Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
                    {
                        m_MainForm.functionCallStatusLabel.Text = "Kill Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_WRITE)
                    {
                        m_MainForm.functionCallStatusLabel.Text = "BlockWrite Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
                    {
                        m_MainForm.functionCallStatusLabel.Text = "BlockErase Succeed";
                    }
                }
                else
                {
                    m_MainForm.functionCallStatusLabel.Text = accessOpResult.m_StatusDescription + " [" + accessOpResult.m_VendorMessage + "]";
                }
                resetButtonState();
            }
        }

        private void resetButtonState()
        {
            if (m_MainForm.m_ReadForm != null)
                m_MainForm.m_ReadForm.readButton.Enabled = true;
            if (m_MainForm.m_WriteForm != null)
                m_MainForm.m_WriteForm.writeButton.Enabled = true;
            if (m_MainForm.m_LockForm != null)
                m_MainForm.m_LockForm.lockButton.Enabled = true;
            if (m_MainForm.m_KillForm != null)
                m_MainForm.m_KillForm.killButton.Enabled = true;
            //if (m_MainForm.m_BlockWriteForm != null)
            //    m_MainForm.m_BlockWriteForm.writeButton.Enabled = true;
            if (m_MainForm.m_BlockEraseForm != null)
                m_MainForm.m_BlockEraseForm.eraseButton.Enabled = true;
        }

        internal void configureMenuItemsUponConnectDisconnect()
        {
            if (m_ReaderAPI != null && m_MainForm.m_IsConnected && m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
            {
                //this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                //    "Power On Radio" : "Power Off Radio";
            }
            else
            {
                //this.radioPowerGetSetToolStripMenuItem.Visible = false;
            }

        }

        private void connectBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs connectEventArgs)
        {
            //updateGPIState();
        }

        internal void configureMenuItemsBasedOnCapabilities()
        {
            //m_MainForm.configureMenuItemsBasedOnCapabilities();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            //configureMenuItemsUponConnectDisconnect();
            //updateGPIState();

            //actualiza la información de m_ReaderApi
            //updateReaderApi();
            limpiarImput();
            ucTextBox1.Text = "Código de barras prenda";
        }

        private void updateReaderApi()
        {
            try
            {
                if (m_MainForm.m_IsConnected)
                {
                    m_ReaderAPI.Actions.PreFilters.DeleteAll();

                    m_ReaderAPI.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify);
                    m_ReaderAPI.Events.AttachTagDataWithReadEvent = false;
                    m_ReaderAPI.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify);
                    m_ReaderAPI.Events.NotifyGPIEvent = true;
                    m_ReaderAPI.Events.NotifyAntennaEvent = true;
                    m_ReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                    m_ReaderAPI.Events.NotifyBufferFullEvent = true;
                    m_ReaderAPI.Events.NotifyBufferFullWarningEvent = true;
                    m_ReaderAPI.Events.NotifyAccessStartEvent = true;
                    m_ReaderAPI.Events.NotifyAccessStopEvent = true;
                    m_ReaderAPI.Events.NotifyInventoryStartEvent = true;
                    m_ReaderAPI.Events.NotifyInventoryStopEvent = true;
                    m_ReaderAPI.Events.NotifyReaderExceptionEvent = true;
                    m_ReaderAPI.Events.NotifyTemperatureAlarmEvent = true;
                }
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_MainForm.m_IsConnected)
                {
                    /*if (Convert.ToString(ButtonConsultar.Tag) == "Stop Reading")
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                        }
                        //else if (checkBoxEnableBrandIDCheck.Checked)
                        //{
                        //    m_ReaderAPI.Actions.BrandIdChk.Stop();
                        //}
                        else
                        {
                            m_ReaderAPI.Actions.Inventory.Stop();
                        }

                        //ButtonConsultar.Text = "Iniciar";
                        //ButtonConsultar.Tag = "Start Reading";
                        m_IsReading = false;
                    }*/
                }
            }
            catch (InvalidOperationException ioe)
            {
                m_MainForm.functionCallStatusLabel.Text = ioe.Message;
            }
            catch (InvalidUsageException iue)
            {
                m_MainForm.functionCallStatusLabel.Text = iue.Info;
            }
            catch (OperationFailureException ofe)
            {
                m_MainForm.functionCallStatusLabel.Text = ofe.Result + ":" + ofe.StatusDescription;
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }

            m_MainForm.m_FormPrenda = null;
        }

        private void retrieveData()
        {
            //string ls_Compania = "02";
            //string ls_OP;
            //string ls_HojaMarcacion;
            //string ls_NumeroCaja;
            //DataTable tabla = new DataTable();
            //int li_indexColumn;

            //ls_OP = tB_Op.Text;
            try
            {
                //m_despachoBD = new BDDespacho();

                //Dictionary<string, object> whereParameters = new Dictionary<string, object>
                //{
                //    { "op", "1000037635" }                    
                //};

                //DataTable result = m_BDContenedor.GetData( whereParameters);

                DataTable prenda_ = new DataTable("Prenda");
                prenda_.Columns.Add("op", typeof(string));
                prenda_.Columns["op"].ColumnName = "OP";
                prenda_.Columns.Add("corte", typeof(string));
                prenda_.Columns["corte"].ColumnName = "Corte";
                prenda_.Columns.Add("sub_corte", typeof(string));
                prenda_.Columns["sub_corte"].ColumnName = "Sub Corte";

                prenda_.Columns.Add("talla", typeof(string));
                prenda_.Columns["talla"].ColumnName = "Talla";
                prenda_.Columns.Add("id_talla", typeof(string));
                prenda_.Columns["id_talla"].ColumnName = "ID";
                prenda_.Columns.Add("linea", typeof(string));
                prenda_.Columns["linea"].ColumnName = "Línea";
                prenda_.Columns.Add("fecha", typeof(string));
                prenda_.Columns["fecha"].ColumnName = "Fecha";
                dataGridView.DataSource = prenda_;
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }

            //if (dgv_etiquetas.Rows.Count <= 1)
            //{
            //    m_MainForm.functionCallStatusLabel.Text = "No se encontraron registros.";
            //    tB_Op.Focus();
            //}
        }

        private void ClearBD()
        {
            string ls_error;
            int li_return;

            Dictionary<string, object> whereParameters = new Dictionary<string, object>
            {
                { "fotocheck", m_Usuario }
            };
                        
            li_return = m_BDPrenda.DeleteRows(whereParameters);

            if (li_return < 0)
            {
                ls_error = m_BDPrenda.GetError();
                MessageBox.Show("Error, "+ ls_error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            retrieveData();
        }

        private int setCantidadTag()
        {
            if (m_contador == 0)
            {
                m_contador ++ ;
                return RegistertData();
            }

            return 0;
                
        }

        //private async Task<int> RegistertData()
        private int RegistertData()
        {
            DataTable ldt_RTA;

            string sCodigoRFID = m_CodRfid;
            string ls_datos = "";
            string ls_error = "";
            int li_rows;
            long ll_return;

            //verificar si la etiqueta RFID ya fue registrada
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            Console.WriteLine("<---RFID--->"+ sCodigoRFID);
            dictionary.Add("id_rfid", sCodigoRFID);
            ldt_RTA = m_BDPrendaScm.GetData(dictionary);

            if (ldt_RTA.Rows.Count > 0)
            {
                ls_datos = BuildDataString(ldt_RTA.Rows[0]);

                label_mensaje.Text = "RFID ya está rcegistrada en " + ls_datos + " , por favor verifique.";
                //Console.WriteLine("RFID ya está rcegistrada en " + ls_datos + " , por favor verifique.");
                return 0;
            }

            var lv_result = m_BDPrenda.SetRfid(m_CodBarra, m_Empresa, m_Cod_Trabajador, sCodigoRFID);

            //ucTextBox1.Text = "";
            m_MainForm.functionCallStatusLabel.Text = lv_result.Item2;
            label_mensaje.Text = lv_result.Item2;

            if (lv_result.Item1 != 0)
            {
                label_mensaje.Text = $"Error al registrar RFID: {lv_result.Item2}";
                return 0;
            }

            ldt_RTA = lv_result.Item3;

            if (ldt_RTA.Rows.Count > 0)
            {
                li_rows = ldt_RTA.Rows.Count;
                DataRow row = ldt_RTA.Rows[0];
                //m_DTPrendaTmp.ImportRow(ldrFirstRow);

                var columns = new Dictionary<string, string>
                {
                    { "id_barras", "etiqueta" },
                    { "op", "op" },
                    { "corte", "corte" },
                    { "subcorte", "sub_corte" },
                    { "cod_talla", "cod_talla" },
                    { "id_talla", "id_talla" },
                    { "talla", "talla" },
                    { "cod_combinacion", "cod_comb" },
                    { "color", "color" },
                    { "cod_trabajador", "fotocheck" }
                };

                foreach (var column in columns)
                {
                    dictionary.Add(column.Key, row[column.Value].ToString());
                }

                ll_return = m_BDPrendaScm.Insert(dictionary);

                if (ll_return == -1)
                {
                    ls_error = m_BDPrendaScm.GetError();
                    label_mensaje.Text = "Error al registrar datos en MySQL " + ls_error;
                }

                label_mensaje.Text = "";

                if (ldt_RTA.Columns.Contains("color"))
                {
                    ldt_RTA.Columns.Remove("color");
                }
                if (ldt_RTA.Columns.Contains("fotocheck"))
                {
                    ldt_RTA.Columns.Remove("fotocheck");
                }
                if (ldt_RTA.Columns.Contains("estado"))
                {
                    ldt_RTA.Columns.Remove("estado");
                }
                if (ldt_RTA.Columns.Contains("cod_talla"))
                {
                    ldt_RTA.Columns.Remove("cod_talla");
                }
                if (ldt_RTA.Columns.Contains("etiqueta"))
                {
                    ldt_RTA.Columns.Remove("etiqueta");
                }
                if (ldt_RTA.Columns.Contains("cod_comb"))
                {
                    ldt_RTA.Columns.Remove("cod_comb");
                }

                dataGridView.DataSource = ldt_RTA;
            }

            return 0;
        }

        // Método para construir la cadena de datos
        private string BuildDataString(DataRow row)
        {
            var ls_datosList = new List<string>();
            ls_datosList.Add($"OP: {row["op"]}");

            AddIfNotEmpty(ls_datosList, "Corte", row["corte"]);
            AddIfNotEmpty(ls_datosList, "SubCorte", row["subcorte"]);
            AddIfNotEmpty(ls_datosList, "Talla", row["talla"]);
            AddIfNotEmpty(ls_datosList, "Color", row["color"]);

            return string.Join(" ", ls_datosList);
        }

        // Método auxiliar para agregar a la lista solo si el valor no es vacío
        private void AddIfNotEmpty(List<string> list, string label, object value)
        {
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                list.Add($"{label}: {value}");
            }
        }

        private Task<List<string>> GetRFID()
        {           
            List<string> lista = new List<string>();
            foreach (DictionaryEntry entry in m_TagTable)
            {
                lista.Add(entry.Key.ToString());
            }

            return Task.FromResult(lista);
        }

        /*private void ButtonConsultar_Click(object sender, EventArgs e)
        {
            retrieveData();
        }*/

        private void Procesar()
        {
            m_contador = 0;
            string sCodBarra = ucTextBox1.Text;
            sCodBarra = sCodBarra.Trim();

            string sCodigoRfid = ucTexRfid.Text;
            sCodigoRfid = sCodigoRfid.Trim();

            if (sCodBarra == string.Empty)
            {
                label_mensaje.Text = "Ingrese correctamente el Código de barras de la prenda.";
                return;
            }

            if (sCodigoRfid == string.Empty)
            {
                label_mensaje.Text = "Ingrese correctamente el Código de RFID.";
                return;
            }
            
            m_CodBarra = sCodBarra;
            m_CodRfid = sCodigoRfid;
            
            label_mensaje.Text = "";

            //read(true);
            RegistertData();
            limpiarImput();
        }

        private void limpiarImput()
        {
            ucTextBox1.Text = "";
            ucTexRfid.Text = "";

            ucTexRfid.Focus();
            ucTextBox1.Enabled = false;
        }

        private void read(bool estado)
        {
            try
            {
                if (m_MainForm.m_IsConnected)
                {
                    //if (Convert.ToString(ButtonConsultar.Tag) == "Start Reading")
                    if ( estado ) 
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            // Before inventory purge all tags
                            m_ReaderAPI.Actions.PurgeTags();
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(null,
                                null, m_MainForm.m_AntennaInfoForm.getInfo());                            
                        }
                        //else if (checkBoxEnableBrandIDCheck.Checked)
                        //{
                        //    ushort brandIDToCheck = Convert.ToUInt16(textBoxBrandID.Text, 16);
                        //    inventoryList.Items.Clear();
                        //    m_TagTable.Clear();
                        //    m_TagTotalCount = 0;

                        //    // Before inventory purge all tags
                        //    m_ReaderAPI.Actions.PurgeTags();
                        //    m_ReaderAPI.Actions.BrandIdChk.Perform(
                        //        m_MainForm.m_PostFilterForm.getFilter(),
                        //        m_MainForm.m_TriggerForm.getTriggerInfo(),
                        //        m_MainForm.m_AntennaInfoForm.getInfo(),
                        //        brandIDToCheck);
                        //}
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_TagTable.Clear();
                            m_TagTotalCount = 0;

                            // Before inventory purge all tags
                            m_ReaderAPI.Actions.PurgeTags();
                            m_ReaderAPI.Actions.Inventory.Perform(
                                null,
                                null,
                                m_MainForm.m_AntennaInfoForm.getInfo());
                        }

                        //ButtonConsultar.Text = "Detener";
                        //ButtonConsultar.Tag = "Stop Reading";
                        m_IsReading = true;

                    }
                    //else if (Convert.ToString(ButtonConsultar.Tag) == "Stop Reading")
                    else
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                        }
                        //else if (checkBoxEnableBrandIDCheck.Checked)
                        //{
                        //    m_ReaderAPI.Actions.BrandIdChk.Stop();
                        //}
                        else
                        {
                            m_ReaderAPI.Actions.Inventory.Stop();
                        }

                        //ButtonConsultar.Text = "Iniciar";
                        //ButtonConsultar.Tag = "Start Reading";
                        m_IsReading = false;
                    }
                }
                else
                {
                    m_MainForm.functionCallStatusLabel.Text = "Conéctese primero al lector";
                    label_mensaje.Text = "Conéctese primero al lector";
                }
            }
            catch (InvalidOperationException ioe)
            {
                m_MainForm.functionCallStatusLabel.Text = ioe.Message;
            }
            catch (InvalidUsageException iue)
            {
                m_MainForm.functionCallStatusLabel.Text = iue.Info;
            }
            catch (OperationFailureException ofe)
            {
                m_MainForm.functionCallStatusLabel.Text = ofe.Result + ":" + ofe.StatusDescription;
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        void inventoryList_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //dataContextMenuStrip.Show(inventoryList, new Point(e.X, e.Y));
            }
        }

        private void resetToFactoryDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ReaderAPI.IsConnected)
                {
                    m_ReaderAPI.Config.ResetFactoryDefaults();
                    //if (m_TagStorageSettingsForm != null)
                    //    m_TagStorageSettingsForm.Reset();
                    m_MainForm.functionCallStatusLabel.Text = "Reset Factory Defaults Successfully";
                }
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void clearReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.inventoryList.Items.Clear();
            this.m_TagTable.Clear();
        }


        private void memBank_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_MainForm.m_IsConnected)
            {
                m_ReaderAPI.Actions.TagAccess.OperationSequence.DeleteAll();
                //if (memBank_CB.SelectedIndex >= 1)
                //{
                //    TagAccess.Sequence.Operation op = new TagAccess.Sequence.Operation();
                //    op.AccessOperationCode = ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ;
                //    op.ReadAccessParams.MemoryBank = (MEMORY_BANK)memBank_CB.SelectedIndex - 1;
                //    op.ReadAccessParams.ByteCount = 0;
                //    op.ReadAccessParams.ByteOffset = m_MainForm.m_ReadForm.m_ReadParams.ByteOffset;
                //    op.ReadAccessParams.AccessPassword = m_MainForm.m_ReadForm.m_ReadParams.AccessPassword;
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.Add(op);
                //}
            }
        }

        private void systemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (null == m_ReaderInfoForm)
            //{
            //    m_ReaderInfoForm = new ReaderInfoForm(this);
            //}
            //m_ReaderInfoForm.ShowDialog(this);
        }

        private void reset()    // para limpiar los registros
        {
            m_TagTotalCount = 0;
            this.m_TagTable.Clear();
        }

        private string getTagEvent(TagData tag)
        {
            string eventString = "None";
            if (tag.TagEvent != TAG_EVENT.NONE)
            {
                switch (tag.TagEvent)
                {
                    case TAG_EVENT.NEW_TAG_VISIBLE:
                        eventString = "New";
                        break;
                    case TAG_EVENT.TAG_BACK_TO_VISIBILITY:
                        eventString = "Back";
                        break;
                    case TAG_EVENT.TAG_NOT_VISIBLE:
                        eventString = "Gone";
                        break;
                    case TAG_EVENT.TAG_MOVING:
                        eventString = "Moving";
                        break;
                    case TAG_EVENT.TAG_STATIONARY:
                        eventString = "Stationary";
                        break;
                    default:
                        eventString = "None";
                        break;
                }
            }
            return eventString;
        }

        private void locateTagDataContextMenuItem_Click(object sender, EventArgs e)
        {
            //if (null == m_LocateForm)
            //{
            //    m_LocateForm = new LocateForm(this);
            //}
            //m_LocateForm.ShowDialog(this);
        }


        private string GetPhaseInDegree(short phase)
        {
            double PhaseInfo = (180.0 / 32767) * phase;
            return PhaseInfo.ToString("#0.00#");
        }

        private void AppForm_Activated(object sender, EventArgs e)
        {
            updateReaderApi();
        }

        private void ucTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Procesar();              
            }
        }

        
        private void FormPrenda_Shown(object sender, EventArgs e)
        {
            /*if (m_MainForm.m_IsConnected == false)
            {
                m_MainForm.functionCallStatusLabel.Text = "Conéctese primero al lector";
                MessageBox.Show("No está conectado al Lector. \nConéctese primero al lector para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
                
            using (FormTrabajador formResponse = new FormTrabajador())
            {
                if (formResponse.ShowDialog() == DialogResult.OK)
                {
                    m_Usuario = formResponse.CodTrabajador;
                }
                else
                {                    
                    // Aquí puedes decidir si cerrar el formulario principal
                    this.Close();
                    return;
                }
            }*/
                        
            gdt_Fecha = DateTime.Now;
            ucTexRfid.Focus();
            retrieveData();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearBD();

            limpiarImput();
            ucTextBox1.Text = "Código de barras prenda";
        }

        private void FormPrenda_Resize(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                float fontSize = Math.Max(10, this.ClientSize.Width / 90);
                control.Font = new Font(control.Font.FontFamily, fontSize);

                // Ajusta el tamaño de la fuente para las celdas del DataGridView
                if (control is DataGridView dataGridView)
                {
                    //foreach (DataGridViewColumn column in dataGridView.Columns)
                    //{
                    //    column.DefaultCellStyle.Font = new Font(column.DefaultCellStyle.Font.FontFamily, fontSize);
                    //}
                }

                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    foreach (Control control1 in control.Controls)
                    {
                        control1.Font = new Font(control1.Font.FontFamily, fontSize);                        
                    }
                }
            }
        }

        private void enterRFID()
        {
            ucTextBox1.Focus();
            ucTextBox1.Enabled = true;
            ucTextBox1.Text = "";
        }

        private void UcTexRfid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterRFID();
            }
        }

        private void UcTexRfid__TextChanged(object sender, EventArgs e)
        {
            if(ucTexRfid.Text.Length == 24)
            {
                enterRFID();
            }
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_ReaderAPI != null && m_MainForm.m_IsConnected && m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
            {
                //this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                //    "Power On Radio" : "Power Off Radio";
            }
        }

    }
}
