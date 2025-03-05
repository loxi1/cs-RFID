using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Symbol.RFID3;
using System.Net.NetworkInformation;

namespace RFIDPrendas
{
    public partial class FormMain : Form
    {
        internal RFIDReader m_ReaderAPI;
        internal bool m_IsConnected;
        internal FormConnection m_ConnectionForm;
        internal FormPerfil m_FormPerfil;
        internal FormTrabajador m_FormTrabajador;
        internal FormRead m_ReadForm;
        internal FormWrite m_WriteForm;
        internal FormLock m_LockForm;
        internal FormKill m_KillForm;
        internal FormBlockErase m_BlockEraseForm;
        internal FormAntennaInfo m_AntennaInfoForm;
        internal FormCaja m_FormCaja;
        internal FormCajaCantidad m_FormCajaCantidad;
        internal FormCajaVerificar m_FormCajaVerificar;
        internal FormMiniCaja m_FormMiniCaja;
        internal FormPrenda m_FormPrenda;
        internal FormSalida m_FormSalida;
        internal FormCajaSimple m_FormCajaSimple;
        internal AccessOperationResult m_AccessOpResult;
        internal FormLecturaDeCaja m_FormLecturaDeCaja;
        internal FormPOLecturaDeCaja m_FormPOLecturaDeCaja;
        internal FormReporteLecturaCaja m_FormReporteLecturaCaja;
        internal FormReporteIncidencia m_FormReporteIncidencia;
        internal FormReportePrendaEnCaja m_FormReportePrendaEnCaja;
        internal FormReportePrendas m_FormReportePrendas;
        internal FormValidarSalidaCaja m_FormValidarSalidaCaja;
        //internal FormReportarIncidente m_FormReportarIncidente;
        internal Form_CajaCantidad m_Form_CajaCantidad;
        //internal FormCajaRotulada m_FormCajaRotulada;
        internal FormValidarSalida m_FormValidarSalida;
        internal FormMatriculaDeCajaHM m_FormMatriculaDeCajaHM;
        internal AuditarCaja m_AuditarCaja;
        internal FormReprocesarLote m_FormReprocesarLote;

        internal string m_SelectedTagID = null;

        private delegate void UpdateStatus(Events.StatusEventData eventData);
        private UpdateStatus m_UpdateStatusHandler = null;
        private delegate void UpdateRead(Events.ReadEventData eventData);
        private UpdateRead m_UpdateReadHandler = null;
        private TagData m_ReadTag = null;
        private Hashtable m_TagTable;
        private uint m_TagTotalCount;
        private string CodPl = "";
        private string datosPl = "";
        private string datos = "";
        public string CodigoUsuario { get; private set; }
        public string CodigoPerfil { get; private set; }

        private int Tipo_de_red = 0;

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
        public FormMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            m_ReadTag = new Symbol.RFID3.TagData();
            m_UpdateStatusHandler = new UpdateStatus(myUpdateStatus);
            m_UpdateReadHandler = new UpdateRead(myUpdateRead);
            m_ConnectionForm = new FormConnection(this);
            m_AntennaInfoForm = new FormAntennaInfo(this);
            m_ReadForm = new FormRead(this);
            m_TagTable = new Hashtable();
            m_AccessOpResult = new AccessOperationResult();
            m_IsConnected = false;
            m_TagTotalCount = 0;

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                // Verificar si la interfaz está activa y conectada
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    // Identificar si es una conexión Ethernet o Wi-Fi
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        Console.WriteLine("Conectado por cable (RJ45) a través de: " + ni.Name);
                        Tipo_de_red = 2;
                    }
                    else if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        Console.WriteLine("Conectado por Wi-Fi a través de: " + ni.Name);
                        Tipo_de_red = 1;
                    }
                }
            }
        }
                
        private void myUpdateStatus(Events.StatusEventData eventData)
        {
            switch (eventData.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    functionCallStatusLabel.Text = "Antenna Status Update";
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData.ReaderExceptionEventData.ReaderExceptionEventInfo;
                    break;
                default:
                    break;
            }
        }

        private void myUpdateRead(Events.ReadEventData eventData)
        {
            int index = 0;
            ListViewItem item;

            Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
            if (tagData != null)
            {
                for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                {
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
                            if (!isFound)
                            {
                                tagID += ((uint)tag.MemoryBank + tag.MemoryBankDataOffset);
                                isFound = m_TagTable.ContainsKey(tagID);
                            }
                        }

                        if (isFound)
                        {
                            uint count = 0;
                            item = (ListViewItem)m_TagTable[tagID];
                            try
                            {
                                count = uint.Parse(item.SubItems[2].Text) + tagData[nIndex].TagSeenCount;
                                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                            }
                            catch (FormatException fe)
                            {
                                functionCallStatusLabel.Text = fe.Message;
                                break;
                            }
                            item.SubItems[1].Text = tag.AntennaID.ToString();
                            item.SubItems[2].Text = count.ToString();
                            item.SubItems[3].Text = tag.PeakRSSI.ToString();

                            string memoryBank = tag.MemoryBank.ToString();
                            index = memoryBank.LastIndexOf('_');
                            if (index != -1)
                            {
                                memoryBank = memoryBank.Substring(index + 1);
                            }
                            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                            {
                                item.SubItems[5].Text = tag.MemoryBankData;
                                item.SubItems[6].Text = memoryBank;
                                item.SubItems[7].Text = tag.MemoryBankDataOffset.ToString();

                                lock (m_TagTable.SyncRoot)
                                {
                                    m_TagTable.Remove(tagID);
                                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        + tag.MemoryBankDataOffset.ToString(), item);
                                }
                            }
                        }
                        else
                        {
                            item = new ListViewItem(tag.TagID);
                            ListViewItem.ListViewSubItem subItem;

                            subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
                            m_TagTotalCount += tag.TagSeenCount;
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                            item.SubItems.Add(subItem);
                            subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);
                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);
                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);

                            lock (m_TagTable.SyncRoot)
                            {
                                m_TagTable.Add(tagID, item);
                            }
                        }
                    }
                }
                //totalTagValueLabel.Text = m_TagTable.Count + "(" + m_TagTotalCount + ")";
            }
        }

        private void Events_ReadNotify(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler, new object[] { readEventArgs.ReadEventData });
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
                m_AccessOpResult.m_OpCode = (ACCESS_OPERATION_CODE)accessEvent.Argument;
                m_AccessOpResult.m_Result = RFIDResults.RFID_API_SUCCESS;

                if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReadTag = m_ReaderAPI.Actions.TagAccess.ReadWait(
                        m_SelectedTagID, m_ReadForm.m_ReadParams, null);
                    }
                    else
                    {
                        functionCallStatusLabel.Text = "Enter Tag-Id";
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.WriteWait(
                            m_SelectedTagID, m_WriteForm.m_WriteParams, null);
                    }
                    else
                    {
                        functionCallStatusLabel.Text = "Enter Tag-Id";
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.LockWait(
                            m_SelectedTagID, m_LockForm.m_LockParams, null);
                    }
                    else
                    {
                        functionCallStatusLabel.Text = "Enter Tag-Id";
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.KillWait(
                            m_SelectedTagID, m_KillForm.m_KillParams, null);
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockEraseWait(
                            m_SelectedTagID, m_BlockEraseForm.m_BlockEraseParams, null);
                    }
                    else
                    {
                        functionCallStatusLabel.Text = "Enter Tag-Id";
                    }
                }
            }
            catch (OperationFailureException ofe)
            {
                m_AccessOpResult.m_Result = ofe.Result;
                m_AccessOpResult.m_StatusDescription = ofe.StatusDescription;
                m_AccessOpResult.m_VendorMessage = ofe.VendorMessage;
            }
            catch (InvalidUsageException ex)
            {
                m_AccessOpResult.m_Result = RFIDResults.RFID_API_PARAM_ERROR;
                m_AccessOpResult.m_StatusDescription = ex.Info;
                m_AccessOpResult.m_VendorMessage = ex.VendorMessage;
            }
            accessEvent.Result = m_AccessOpResult;
        }

        private void accessBackgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs pce)
        {

        }

        private void accessBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs accessEvents)
        {
            //int index = 0;
            if (accessEvents.Error != null)
            {
                functionCallStatusLabel.Text = accessEvents.Error.Message;
            }
            else
            {
                // Handle AccessWait Operations              
                AccessOperationResult accessOpResult = (AccessOperationResult)accessEvents.Result;
                if (accessOpResult.m_Result == RFIDResults.RFID_API_SUCCESS)
                {
                    if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ)
                    {
            //            if (inventoryList.SelectedItems.Count > 0)
            //            {
            //                ListViewItem item = inventoryList.SelectedItems[0];
            //                string tagID = m_ReadTag.TagID + m_ReadTag.MemoryBank.ToString()
            //                    + m_ReadTag.MemoryBankDataOffset.ToString();

            //                if (item.SubItems[5].Text.Length > 0)
            //                {
            //                    bool isFound = false;

            //                    // Search or add new one
            //                    lock (m_TagTable.SyncRoot)
            //                    {
            //                        isFound = m_TagTable.ContainsKey(tagID);
            //                    }

            //                    if (!isFound)
            //                    {
            //                        ListViewItem newItem = new ListViewItem(m_ReadTag.TagID);
            //                        ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(newItem, m_ReadTag.AntennaID.ToString());
            //                        newItem.SubItems.Add(subItem);
            //                        subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.TagSeenCount.ToString());
            //                        newItem.SubItems.Add(subItem);
            //                        subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PeakRSSI.ToString());
            //                        newItem.SubItems.Add(subItem);
            //                        subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PC.ToString("X"));
            //                        newItem.SubItems.Add(subItem);
            //                        subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankData);
            //                        newItem.SubItems.Add(subItem);

            //                        string memoryBank = m_ReadTag.MemoryBank.ToString();
            //                        index = memoryBank.LastIndexOf('_');
            //                        if (index != -1)
            //                        {
            //                            memoryBank = memoryBank.Substring(index + 1);
            //                        }

            //                        subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
            //                        newItem.SubItems.Add(subItem);
            //                        subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankDataOffset.ToString());
            //                        newItem.SubItems.Add(subItem);

            //                        inventoryList.BeginUpdate();
            //                        inventoryList.Items.Add(newItem);
            //                        inventoryList.EndUpdate();

            //                        lock (m_TagTable.SyncRoot)
            //                        {
            //                            m_TagTable.Add(tagID, newItem);
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    // Empty Memory Bank Slot
            //                    item.SubItems[5].Text = m_ReadTag.MemoryBankData;

            //                    string memoryBank = m_ReadForm.m_ReadParams.MemoryBank.ToString();
            //                    index = memoryBank.LastIndexOf('_');
            //                    if (index != -1)
            //                    {
            //                        memoryBank = memoryBank.Substring(index + 1);
            //                    }
            //                    item.SubItems[6].Text = memoryBank;
            //                    item.SubItems[7].Text = m_ReadTag.MemoryBankDataOffset.ToString();

            //                    lock (m_TagTable.SyncRoot)
            //                    {
            //                        if (m_ReadTag.TagID != null)
            //                        {
            //                            m_TagTable.Remove(m_ReadTag.TagID);
            //                        }
            //                        m_TagTable.Add(tagID, item);
            //                    }
            //                }
            //                this.m_ReadForm.ReadData_TB.Text = m_ReadTag.MemoryBankData;
            //                functionCallStatusLabel.Text = "Read Succeed";
            //            }
            //        }
            //        else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
            //        {
            //            functionCallStatusLabel.Text = "Write Succeed";
            //        }
            //        else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
            //        {
            //            functionCallStatusLabel.Text = "Lock Succeed";
            //        }
            //        else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
            //        {
            //            functionCallStatusLabel.Text = "Kill Succeed";
            //        }
            //        else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
            //        {
            //            functionCallStatusLabel.Text = "BlockErase Succeed";
                    }
                }
                else
                {
                    functionCallStatusLabel.Text = accessOpResult.m_StatusDescription + " [" + accessOpResult.m_VendorMessage + "]";
                }
                resetButtonState();
            }
        }

        private void resetButtonState()
        {
            if (m_ReadForm != null)
                m_ReadForm.readButton.Enabled = true;
            if (m_WriteForm != null)
                m_WriteForm.writeButton.Enabled = true;
            if (m_LockForm != null)
                m_LockForm.lockButton.Enabled = true;
            if (m_KillForm != null)
                m_KillForm.killButton.Enabled = true;
            if (m_BlockEraseForm != null)
                m_BlockEraseForm.eraseButton.Enabled = true;
        }

        private void connectBackgroundWorker_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            connectBackgroundWorker.ReportProgress(0, workEventArgs.Argument);

            if ((string)workEventArgs.Argument == "Connect")
            {
                m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);

                try
                {
                    m_ReaderAPI.Connect();
                    m_IsConnected = true;
                    workEventArgs.Result = "Connect Succeed";

                    //para obtener la configuración de las antenas del ini
                    IniFile fileIniConfig = new IniFile();
                    string ls_seccion = "Antena";                    
                    fileIniConfig.LoadConfiguracion();                   
                    ushort[] antID = m_ReaderAPI.Config.Antennas.AvailableAntennas;
                    
                    foreach (ushort id in antID)
                    {
                        string ls_antena = id.ToString();
                        string ls_powerindex = fileIniConfig.GetValue(ls_seccion, ls_antena);
                        if (ls_powerindex != "")
                        {
                            Antennas.Config antConfig = m_ReaderAPI.Config.Antennas[int.Parse(ls_antena)].GetConfig();
                            antConfig.TransmitPowerIndex = ushort.Parse(ls_powerindex);
                            m_ReaderAPI.Config.Antennas[int.Parse(ls_antena)].SetConfig(antConfig);     
                        }                       
                    }
                }
                catch (OperationFailureException operationException)
                {
                    workEventArgs.Result = operationException.StatusDescription;
                }
                catch (Exception ex)
                {
                    workEventArgs.Result = ex.Message;
                }
            }
            else if ((string)workEventArgs.Argument == "Disconnect")
            {
                try
                {
                    m_ReaderAPI.Disconnect();
                    m_IsConnected = false;
                    workEventArgs.Result = "Disconnect Succeed";
                    m_ReaderAPI = null;

                }
                catch (OperationFailureException ofe)
                {
                    workEventArgs.Result = ofe.Result;
                }
            }

        }

        private void connectBackgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs progressEventArgs)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs connectEventArgs)
        {
            if (Convert.ToString(m_ConnectionForm.connectionButton.Tag) == "Connect")
            {
                if (connectEventArgs.Result.ToString() == "Connect Succeed")
                {
                    /*
                     *  UI Updates
                     */
                    m_ConnectionForm.connectionButton.Text = "Desconectar";
                    m_ConnectionForm.connectionButton.Tag = "Disconnect";
                    m_ConnectionForm.hostname_TB.Enabled = false;
                    m_ConnectionForm.port_TB.Enabled = false;
                    m_ConnectionForm.Close();
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";

                    /*
                     *  Events Registration
                     */
                    m_ReaderAPI.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify);
                    m_ReaderAPI.Events.AttachTagDataWithReadEvent = false;
                    m_ReaderAPI.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify);
                    m_ReaderAPI.Events.NotifyGPIEvent = true;
                    m_ReaderAPI.Events.NotifyBufferFullEvent = true;
                    m_ReaderAPI.Events.NotifyBufferFullWarningEvent = true;
                    m_ReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                    m_ReaderAPI.Events.NotifyReaderExceptionEvent = true;
                    m_ReaderAPI.Events.NotifyAccessStartEvent = true;
                    m_ReaderAPI.Events.NotifyAccessStopEvent = true;
                    m_ReaderAPI.Events.NotifyInventoryStartEvent = true;
                    m_ReaderAPI.Events.NotifyInventoryStopEvent = true;

                    this.Text = "Conectado a " + m_ConnectionForm.IpText;
                    this.connectionStatus.BackgroundImage =
                        global::RFIDPrendas.Properties.Resources.connected;
                }
            }
            else if (Convert.ToString(m_ConnectionForm.connectionButton.Tag) == "Disconnect")
            {
                if (connectEventArgs.Result.ToString() == "Disconnect Succeed")
                {
                    this.Text = "RFID3";
                    this.connectionStatus.BackgroundImage =
                        global::RFIDPrendas.Properties.Resources.disconnected;

                    m_ConnectionForm.connectionButton.Text = "Conectar";
                    m_ConnectionForm.connectionButton.Tag = "Connect";
                    m_ConnectionForm.hostname_TB.Enabled = true;
                    m_ConnectionForm.port_TB.Enabled = true;
                    //this.readButton.Enabled = false;
                    //this.readButton.Text = "Start Reading";

                }
            }
            functionCallStatusLabel.Text = connectEventArgs.Result.ToString();
            m_ConnectionForm.connectionButton.Enabled = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Login loginClass = new Login();
            string ls_id;
            string ls_perfilId;
            string ls_name;
            string ls_error;
            string ls_user;
            int li_return;

            string ls_username = loginClass.GetUsername();

            ls_user = ls_username.Replace(".", "");
            //connectionToolStripMenuItem_Click(this, EventArgs.Empty);

            // Sincronizar el ícono del formulario principal con el ícono del menú principal
            if (configToolStripMenuItem.Image != null)
            {
                this.Icon = Icon.FromHandle(((Bitmap)configToolStripMenuItem.Image).GetHicon());
            }
            //Validar la Red
            if (Tipo_de_red < 2)
            {
                AlertaCableInternet();
                return;
            }

            if (string.IsNullOrWhiteSpace(CodPl))
            {
                FormLoginPersonal();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_IsConnected)
                {
                    connectBackgroundWorker.RunWorkerAsync("Disconnect");
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_ConnectionForm.ShowDialog(this);
        }

        private void capabilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
//            CapabilitiesForm capabilitiesForm = new CapabilitiesForm(this);
//            capabilitiesForm.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                connectBackgroundWorker.RunWorkerAsync("Disconnect");
            }
            this.Dispose();
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_ReadForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = "Read Form:" + ex.Message;
            }
        }

        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_WriteForm)
            {
                m_WriteForm = new FormWrite(this, false);
            }
            m_WriteForm.ShowDialog(this);
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_LockForm)
            {
                m_LockForm = new FormLock(this);
            }
            m_LockForm.ShowDialog(this);
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_KillForm)
            {
                m_KillForm = new FormKill(this);
            }
            m_KillForm.ShowDialog(this);
        }

        private void blockWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_WriteForm)
            {
                m_WriteForm = new FormWrite(this, true);
            }
            m_WriteForm.ShowDialog(this);
        }

        private void blockEraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_BlockEraseForm)
            {
                m_BlockEraseForm = new FormBlockErase(this);
            }
            m_BlockEraseForm.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNosotros helpDialog = new FormNosotros(this);
            if (helpDialog.ShowDialog(this) == DialogResult.Yes)
            {

            }
            helpDialog.Dispose();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_IsConnected)
                {
                //    if (readButton.Text == "Start Reading")
                //    {
                //        m_ReaderAPI.Actions.Inventory.Perform(null, null, null);

                //        //inventoryList.Items.Clear();
                //        m_TagTable.Clear();
                //        m_TagTotalCount = 0;

                //        //readButton.Text = "Stop Reading";
                //    }
                //    else if (readButton.Text == "Stop Reading")
                //    {
                //        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //        {
                //            m_ReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                //        }
                //        else
                //        {
                //            m_ReaderAPI.Actions.Inventory.Stop();
                //        }

                //        readButton.Text = "Start Reading";
                //    }
                }
                else
                {
                    functionCallStatusLabel.Text = "Please connect to a reader";
                }
            }
            catch (InvalidOperationException ioe)
            {
                functionCallStatusLabel.Text = ioe.Message;
            }
            catch (InvalidUsageException iue)
            {
                functionCallStatusLabel.Text = iue.Info;
            }
            catch (OperationFailureException ofe)
            {
                functionCallStatusLabel.Text = ofe.Result + ":" + ofe.StatusDescription;
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void tagDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TagDataForm tagDataForm = new TagDataForm(this);
            //tagDataForm.ShowDialog(this);
        }

        private void readDataContextMenuItem_Click(object sender, EventArgs e)
        {
            m_ReadForm.ShowDialog(this);
        }

        private void writeDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_WriteForm)
            {
                m_WriteForm = new FormWrite(this, false);
            }
            m_WriteForm.ShowDialog(this);
        }

        private void lockDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_LockForm)
            {
                m_LockForm = new FormLock(this);
            }
            m_LockForm.ShowDialog(this);
        }

        private void killDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_KillForm)
            {
                m_KillForm = new FormKill(this);
            }
            m_KillForm.ShowDialog(this);
        }

        private void blockWriteDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_WriteForm)
            {
                m_WriteForm = new FormWrite(this, true);
            }
            m_WriteForm.ShowDialog(this);
        }

        private void blockEraseDataContextMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_BlockEraseForm)
            {
                m_BlockEraseForm = new FormBlockErase(this);
            }
            m_BlockEraseForm.ShowDialog(this);
        }

        private void resetToFactoryDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ReaderAPI.IsConnected)
                {
                    m_ReaderAPI.Config.ResetFactoryDefaults();
                }
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }       

        private void FormMain_ClientSizeChanged(object sender, EventArgs e)
        {
            functionCallStatusLabel.Width = this.Width - 85;
            this.mainMenuStrip.Size = new System.Drawing.Size(this.Width, 24);
        }

        private void prendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_FormPrenda == null)
            {
                m_FormPrenda = new FormPrenda(this, m_ReaderAPI, "36104");
                m_FormPrenda.MdiParent = this;
                m_FormPrenda.WindowState = FormWindowState.Maximized;
                m_FormPrenda.Show();
            }
            else
            {
                m_FormPrenda.Activate();
            }

        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_FormCaja == null)
            {
                m_FormCaja = new FormCaja(this, m_ReaderAPI);
                m_FormCaja.MdiParent = this;
                m_FormCaja.WindowState = FormWindowState.Maximized;
                m_FormCaja.Show();
            }
            else
            {
                m_FormCaja.Activate();
            }
        }

        private void antenatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAntennaConfig FormAntena = new FormAntennaConfig(this); // Crea una instancia del formulario secundario
            FormAntena.ShowDialog();

            //m_AntennaInfoForm

            //     if (null == m_AntennaModeForm)
            //{
            //    m_AntennaModeForm = new AntennaModeForm(this);
            //}
            //m_AntennaModeForm.ShowDialog(this);
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.mainMenuStrip.Size = new System.Drawing.Size(this.Width, 24);
        }

        private void cajaCantidadtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tipo_de_red < 2)
            {
                AlertaCableInternet();
                return;
            }
            else
            {
                if (m_IsConnected)
                {
                    string ls_cod_trabajador = "";
                    labelUsuario.Text = "";
                    if (m_FormCajaCantidad == null)
                    {
                        FormTrabajador formResponse = new FormTrabajador();
                        if (formResponse.ShowDialog() != DialogResult.OK)
                            return;

                        ls_cod_trabajador = formResponse.CodTrabajador;
                        string usuario = Explode(" ", formResponse.Usuario);
                        labelUsuario.Text = usuario;
                        CodigoUsuario_.Text = ls_cod_trabajador;

                        m_Form_CajaCantidad = new Form_CajaCantidad(this, m_ReaderAPI, ls_cod_trabajador)
                        {
                            MdiParent = this,
                            WindowState = FormWindowState.Maximized
                        };
                        m_Form_CajaCantidad.FormClosed += (s, args) => m_Form_CajaCantidad = null;
                        m_Form_CajaCantidad.Show();


                        /*m_FormCajaRotulada = new FormCajaRotulada(this, m_ReaderAPI, ls_cod_trabajador)
                        {
                            MdiParent = this,
                            WindowState = FormWindowState.Maximized
                        };
                        m_FormCajaRotulada.FormClosed += (s, args) => m_FormCajaRotulada = null;
                        m_FormCajaRotulada.Show();
                        m_FormCajaCantidad = new FormCajaCantidad(this, m_ReaderAPI, ls_cod_trabajador)
                        {
                            MdiParent = this,
                            WindowState = FormWindowState.Maximized
                        };
                        m_FormCajaCantidad.FormClosed += (s, args) => m_FormCajaCantidad = null;
                        m_FormCajaCantidad.Show();*/
                    }
                }
                else
                {
                    AlertaAntena();
                    connectionToolStripMenuItem_Click(this, EventArgs.Empty);
                }
            }
        }

        private void cajasVerificartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_FormCajaVerificar = new FormCajaVerificar(this, m_ReaderAPI, CodPl);
                m_FormCajaVerificar.MdiParent = this;
                m_FormCajaVerificar.WindowState = FormWindowState.Maximized;
                m_FormCajaVerificar.FormClosed += (s, args) => m_FormCajaVerificar = null;
                m_FormCajaVerificar.Show();
                DatosUsuario();
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void CajaSimpletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_FormMiniCaja == null)
            {
                if (m_IsConnected)
                {
                    string ls_cod_trabajador = "";
                    m_FormMiniCaja = new FormMiniCaja(this, m_ReaderAPI, ls_cod_trabajador);
                    m_FormMiniCaja.MdiParent = this;
                    m_FormMiniCaja.WindowState = FormWindowState.Maximized;
                    //Colocar nulo para volver abrir
                    m_FormMiniCaja.FormClosed += (s, args) => m_FormMiniCaja = null;
                    m_FormMiniCaja.Show();
                } else
                {
                    AlertaAntena();
                    connectionToolStripMenuItem_Click(this, EventArgs.Empty);
                }
            }
        }

        private void LeerCaja_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_FormLecturaDeCaja = new FormLecturaDeCaja(this, m_ReaderAPI, CodPl)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                m_FormLecturaDeCaja.FormClosed += (s, args) => m_FormLecturaDeCaja = null;
                m_FormLecturaDeCaja.Show();
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void toolStripMenuItem1Reporte_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_FormReporteLecturaCaja = new FormReporteLecturaCaja(this, CodPl)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                m_FormReporteLecturaCaja.FormClosed += (s, args) => m_FormReporteLecturaCaja = null;
                m_FormReporteLecturaCaja.Show();
                DatosUsuario();
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void Configurar_Click(object sender, EventArgs e)
        {
            FormDatosConfig FormCongif = new FormDatosConfig(this);
            FormCongif.ShowDialog();
        }

        public string Explode(string separator, string source)
        {
            string[] data = source.Split(new string[] { separator }, StringSplitOptions.None);
            return data[0];
        }

        private void toolStripMenuItemPrueba_Click(object sender, EventArgs e)
        {
            m_FormValidarSalidaCaja = new FormValidarSalidaCaja(this, m_ReaderAPI, CodPl)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            m_FormValidarSalidaCaja.FormClosed += (s, args) => m_FormValidarSalidaCaja = null;
            m_FormValidarSalidaCaja.Show();

            /*FormTrabajador formResponse = new FormTrabajador();
            if (formResponse.ShowDialog() != DialogResult.OK)
                return;
            ls_cod_trabajador = formResponse.CodTrabajador;*/

            //string usuario = Explode(" ", formResponse.Usuario);
            //labelUsuario.Text = usuario;
            //CodigoUsuario_.Text = ls_cod_trabajador;

            //ls_cod_trabajador = "36104";
            //m_FormSalida = new FormSalida(this, ls_cod_trabajador)
            //{
            //    MdiParent = this,
            //    WindowState = FormWindowState.Maximized
            //};
            //m_FormSalida.FormClosed += (s, args) => m_FormPrenda = null;
            //m_FormSalida.Show();

            //m_FormPrenda = new FormPrenda(this, m_ReaderAPI, ls_cod_trabajador)
            //{
            //    MdiParent = this,
            //    WindowState = FormWindowState.Maximized
            //};
            //m_FormPrenda.FormClosed += (s, args) => m_FormPrenda = null;
            //m_FormPrenda.Show();
            /*m_FormLecturaDeCaja = new FormLecturaDeCaja(this, m_ReaderAPI, ls_cod_trabajador)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            m_FormLecturaDeCaja.FormClosed += (s, args) => m_FormLecturaDeCaja = null;
            m_FormLecturaDeCaja.Show();
            m_FormLecturaDeCaja = new FormLecturaDeCaja(this, m_ReaderAPI, ls_cod_trabajador)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            m_FormLecturaDeCaja.FormClosed += (s, args) => m_FormLecturaDeCaja = null;
            m_FormLecturaDeCaja.Show();
            m_Form_CajaCantidad = new Form_CajaCantidad(this, m_ReaderAPI, ls_cod_trabajador)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            m_Form_CajaCantidad.FormClosed += (s, args) => m_Form_CajaCantidad = null;
            m_Form_CajaCantidad.Show();

            
             ls_cod_trabajador = "5";
                m_FormCajaRotulada = new FormCajaRotulada(this, m_ReaderAPI, ls_cod_trabajador)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                m_FormCajaRotulada.FormClosed += (s, args) => m_FormCajaRotulada = null;
                m_FormCajaRotulada.Show();
             */

            //Color.FromArgb(16,175,76) Verde
            //Color.FromArgb(254, 206, 40) Amarillo
            //Color.FromArgb(238, 26, 36) Rojo
            //FormAlerta aler_ta = new FormAlerta("Registro bien.", Color.FromArgb(16, 175, 76), 1);
            //aler_ta.ShowDialog();

            /*if (Tipo_de_red < 2)
            {
                string msn = Tipo_de_red == 1 ? "Esta conectador x Wifi debe ser por Cable" : "Conectarse a la red por cable";
                MessageBox.Show(msn, "Trabajador");
                return;
            }
            else
            {
                if (m_IsConnected)
                {
                } else
                {
                    MessageBox.Show("Verificar la conexión de las antenas", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connectionToolStripMenuItem_Click(this, EventArgs.Empty);
                }
            }
            string ls_cod_trabajador = "";
            labelUsuario.Text = "";
            if (m_Prueba == null)
            {
                FormTrabajador formResponse = new FormTrabajador();
                if (formResponse.ShowDialog() != DialogResult.OK)
                    return;

                ls_cod_trabajador = formResponse.CodTrabajador;
                string usuario = Explode(" ", formResponse.Usuario);
                labelUsuario.Text = usuario;

                m_Prueba = new FormPrueba(this, m_ReaderAPI, ls_cod_trabajador)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                m_Prueba.Show();
            }
            else
            {
                m_Prueba.Activate();
            }*/
        }

        private void toolStripMenuReporteIncidencias_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_FormReporteIncidencia = new FormReporteIncidencia(this, CodPl)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                m_FormReporteIncidencia.FormClosed += (s, args) => m_FormReporteIncidencia = null;
                m_FormReporteIncidencia.Show();
                DatosUsuario();
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void ConteoxCajaReporte_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_FormReportePrendaEnCaja = new FormReportePrendaEnCaja(this, CodPl)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                m_FormReportePrendaEnCaja.FormClosed += (s, args) => m_FormReportePrendaEnCaja = null;
                m_FormReportePrendaEnCaja.Show();
                DatosUsuario();
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        public void AlertaAntena()
        {
            FormAlerta aler_ta = new FormAlerta("Verificar la conexión de las antenas", 3);
            aler_ta.ShowDialog(); 
        }

        public void AlertaCableInternet()
        {
            string msn = Tipo_de_red == 1 ? "Esta conectador x Wifi debe ser por Cable" : "Conectarse a la red por cable";
            FormAlerta aler_ta = new FormAlerta(msn, 3);
            aler_ta.ShowDialog();
        }

        public void AlertaError(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 3);
            aler_ta.ShowDialog();
        }

        private void toolStripMenuItemLogin_Click(object sender, EventArgs e)
        {
            FormCaja
            m_FormCaja = new FormCaja(this, m_ReaderAPI)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            m_FormCaja.FormClosed += (s, args) => m_FormCaja = null;
            m_FormCaja.Show();
            /*string ls_cod_trabajador = "";
            FormTrabajador formResponse = new FormTrabajador();
            if (formResponse.ShowDialog() != DialogResult.OK)
                return;
            ls_cod_trabajador = formResponse.CodTrabajador;

            string usuario = Explode(" ", formResponse.Usuario);
            FormAlerta aler_ta = new FormAlerta(usuario+" La clave es "+ls_cod_trabajador, Color.FromArgb(238, 26, 36), 3);
            aler_ta.ShowDialog();*/
        }

        private void ReporteOPHM_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_FormReportePrendas = new FormReportePrendas(this, CodPl)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                m_FormReportePrendas.FormClosed += (s, args) => m_FormReportePrendas = null;
                m_FormReportePrendas.Show();
                DatosUsuario();
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void ConteoXPO_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_FormPOLecturaDeCaja = new FormPOLecturaDeCaja(this, m_ReaderAPI, CodPl)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                m_FormPOLecturaDeCaja.FormClosed += (s, args) => m_FormPOLecturaDeCaja = null;
                m_FormPOLecturaDeCaja.Show();
                DatosUsuario();
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void ValidarSalidaStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                m_FormValidarSalida = new FormValidarSalida(this, m_ReaderAPI, CodPl)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };

                m_FormValidarSalida.FormClosed += (s, args) => m_FormValidarSalida = null;
                m_FormValidarSalida.Show();
                DatosUsuario();
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*m_OtraPruebaMat = new OtraPruebaMat(this)
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            m_OtraPruebaMat.FormClosed += (s, args) => m_OtraPruebaMat = null;
            m_OtraPruebaMat.Show();*/

            /*if (Tipo_de_red < 2)
            {
                AlertaCableInternet();
                return;
            }
            else
            {
                if (m_IsConnected)
                {
                    string ls_cod_trabajador = "";
                    labelUsuario.Text = "";
                    if (m_FormMatriculaDeCajaHM == null)
                    {
                        FormTrabajador formResponse = new FormTrabajador();
                        if (formResponse.ShowDialog() != DialogResult.OK)
                            return;

                        ls_cod_trabajador = formResponse.CodTrabajador;
                        string usuario = Explode(" ", formResponse.Usuario);
                        labelUsuario.Text = usuario;
                        CodigoUsuario_.Text = ls_cod_trabajador;

                        m_FormMatriculaDeCajaHM = new FormMatriculaDeCajaHM(this, m_ReaderAPI, ls_cod_trabajador)
                        {
                            MdiParent = this,
                            WindowState = FormWindowState.Maximized
                        };
                        m_FormMatriculaDeCajaHM.FormClosed += (s, args) => m_FormMatriculaDeCajaHM = null;
                        m_FormMatriculaDeCajaHM.Show();
                    }
                }
                else
                {
                    AlertaAntena();
                    connectionToolStripMenuItem_Click(this, EventArgs.Empty);
                }
            }*/
            m_FormMatriculaDeCajaHM = new FormMatriculaDeCajaHM(this, m_ReaderAPI, "36104")
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            m_FormMatriculaDeCajaHM.FormClosed += (s, args) => m_FormMatriculaDeCajaHM = null;
            m_FormMatriculaDeCajaHM.Show();
        }

        private void LecturaCajaXOP_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                labelUsuario.Text = "";
                if (m_FormMatriculaDeCajaHM == null)
                {
                    m_FormMatriculaDeCajaHM = new FormMatriculaDeCajaHM(this, m_ReaderAPI, CodPl)
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized
                    };
                    m_FormMatriculaDeCajaHM.FormClosed += (s, args) => m_FormMatriculaDeCajaHM = null;
                    m_FormMatriculaDeCajaHM.Show();
                    DatosUsuario();
                }
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void DesmatricularCajaAuditoria_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                labelUsuario.Text = "";
                if (m_AuditarCaja == null)
                {
                    m_AuditarCaja = new AuditarCaja(this, m_ReaderAPI, CodPl)
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized
                    };
                    m_AuditarCaja.FormClosed += (s, args) => m_AuditarCaja = null;
                    m_AuditarCaja.Show();
                    DatosUsuario();
                }
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }                
        }

        private void ReprocesarCajaOPHM_Click(object sender, EventArgs e)
        {
            if (m_IsConnected)
            {
                if (m_FormReprocesarLote == null)
                {
                    m_FormReprocesarLote = new FormReprocesarLote(this, m_ReaderAPI, CodPl)
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized
                    };
                    m_FormReprocesarLote.FormClosed += (s, args) => m_FormReprocesarLote = null;
                    m_FormReprocesarLote.Show();
                    DatosUsuario();
                }
            }
            else
            {
                AlertaAntena();
                connectionToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void FormLoginPersonal()
        {
            FormLoginPersonal formLogin = new FormLoginPersonal(this);
            bool loginExitoso = false;

            while (!loginExitoso)
            {
                DialogResult result = formLogin.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Validar que el usuario ingresó correctamente
                    if (!string.IsNullOrWhiteSpace(formLogin.CodTrabajador))
                    {
                        CodPl = formLogin.CodTrabajador;

                        datosPl = formLogin.Usuario;

                        datos = formLogin.Datos;

                        DatosUsuario();

                        loginExitoso = true; // Salir del bucle

                        // ✅ Si el login es correcto y no esta conectado, mostrar `m_ConnectionForm`
                        if(!m_IsConnected)
                            m_ConnectionForm.ShowDialog(this);
                    }
                }
                else
                {
                    // Si el usuario presionó "Cancelar", mostrar la alerta y mantener el login abierto
                    AlertaError("Debe iniciar sesión para continuar");
                }
            }
        }

        //Colocar Usuario y Nombre cada vez que se abre cada menu
        private void DatosUsuario()
        {
            labelUsuario.Text = datosPl;
            CodigoUsuario_.Text = CodPl;
        }

        private void LogouttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Confirmacion()) // Si el usuario confirma
            {
                CerrarSesion();
            }
        }

        /// <summary>
        /// Muestra un cuadro de diálogo de confirmación y devuelve un booleano.
        /// </summary>
        private bool Confirmacion()
        {
            try
            {
                using (FormConfirmacion confirmForm = new FormConfirmacion(
                    "¿Cerrar sesión?", Color.FromArgb(255, 165, 0), "¡Se cerrará la sesión actual!", "Si, Continuar", "No, Cerrar"))
                {
                    return confirmForm.ShowDialog() == DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Confirmacion(): {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cierra la sesión y vuelve al login.
        /// </summary>
        private void CerrarSesion()
        {
            // Usuario autenticado, actualizar variables
            CodPl = "";
            datosPl = "";
            datos = "";
            labelUsuario.Text = "";
            CodigoUsuario_.Text = "";

            FormLoginPersonal();
        }

        private void PerfiltoolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario con los parámetros adecuados
            FormPerfil perfilForm = new FormPerfil(this, CodPl, datos);

            // Mostrar el formulario de perfil como diálogo modal
            perfilForm.ShowDialog();
        }
    }
}
 