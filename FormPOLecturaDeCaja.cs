using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Symbol.RFID3;
using System.Collections;

namespace RFIDPrendas
{
    public partial class FormPOLecturaDeCaja : Form
    {
        private FormMain m_MainForm = null;
        internal RFIDReader m_ReaderAPI;
        internal bool m_IsReading = false;
        internal string ms_OP = "";
        public RFIDResults m_Result;
        //internal ReaderManagement m_ReaderMgmt;
        //internal READER_TYPE m_ReaderType;        
        internal DBLecturaDeCaja m_DBLecturaDeCaja;

        internal string m_Cod_Trabajador = "030658";
        internal string m_cod_Compania = "02";

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
        //private int m_SortColumn = -1;
        private uint m_TagTotalCount;
        private MySqlConnection connectionMySql;
        //private Socket m_ReaderSocket;
        DataTable m_DataTableDatosPrendas = new DataTable();

        Stopwatch tmP = new Stopwatch();
        
        private readonly string m_Titulo = "Contador";
        private string m_Antena = "Antena";
        private int m_TiempoFinal = 0;
        private int m_Sensibilidad = 0;
        private bool m_VerCronometro = false;
        internal string s_error;
        private int tiempo_termina = 0;
        private string v_min = "";
        private string v_seg = "";
        private string v_hor = "";
        private int v_Segundos = 0;
        private Dictionary<int, int> tiempo_cronometro = new Dictionary<int, int>();

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

        public FormPOLecturaDeCaja(FormMain mainForm, RFIDReader pReaderAPI, string codTrabajador)
        {
            InitializeComponent();
            m_MainForm = mainForm;
            m_ReaderAPI = pReaderAPI;
            this.MdiParent = m_MainForm;
            m_Cod_Trabajador = codTrabajador;
            Console.WriteLine("EL trabajador-->" + m_Cod_Trabajador);
            m_GPIStateList = new ArrayList();
            m_UpdateStatusHandler = new UpdateStatus(myUpdateStatus);
            m_UpdateReadHandler = new UpdateRead(myUpdateRead);
            m_ReadTag = new Symbol.RFID3.TagData();

            m_TagTable = new Hashtable();
            m_TagTotalCount = 0;
            m_DBLecturaDeCaja = new DBLecturaDeCaja();

            configureMenuItemsUponConnectDisconnect();

            if (GetIni() == 1)
            {
                groupBox1.Visible = m_VerCronometro;
            }
        }

        private void myUpdateStatus(Events.StatusEventData eventData)
        {
            switch (eventData.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Procesando...";
                    this.readButton.Enabled = false;
                    this.readButton.Text = "Procesando...";
                    this.readButton.Tag = "Stop Reading";
                    m_IsReading = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Proceso detenido.";
                    this.readButton.Enabled = true;
                    this.readButton.Text = "Iniciar";
                    this.readButton.Tag = "Start Reading";
                    m_IsReading = false;

                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Operación de acceso iniciada.";
                    this.readButton.Enabled = true;
                    this.readButton.Text = "Detener";
                    this.readButton.Tag = "Stop Reading";
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
                    this.readButton.Enabled = true;
                    this.readButton.Text = "Iniciar";
                    this.readButton.Tag = "Start Reading";
                    m_IsReading = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
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
                                count = uint.Parse(item.SubItems[7].Text) + tagData[nIndex].TagSeenCount;
                                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                            }
                            catch (FormatException fe)
                            {
                                m_MainForm.functionCallStatusLabel.Text = fe.Message;
                                break;
                            }
                            item.SubItems[1].Text = tag.AntennaID.ToString();
                            item.SubItems[7].Text = count.ToString();
                            item.SubItems[8].Text = getTagEvent(tag);
                            item.SubItems[9].Text = tag.PeakRSSI.ToString();
                            item.SubItems[10].Text = GetPhaseInDegree(tag.PhaseInfo);
                        }
                        else
                        {
                            ListViewItem item = new ListViewItem(tag.TagID);
                            ListViewItem.ListViewSubItem subItem;
                            // 1 - antenna ID
                            subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
                            item.SubItems.Add(subItem);

                            //para obtener la infomacion de OP, COrte Talla de la Etiqueta 
                            //Dictionary<string, object> dicprenda = GetInformacionPrenda(tag.TagID);
                            //if (dicprenda.Count > 0)
                            //{
                            //    // 2 - OP
                            //    //if (dicprenda.ContainsKey("op"))
                            //    //{
                            //    //    subItem = new ListViewItem.ListViewSubItem(item, dicprenda["op"].ToString());
                            //    //    item.SubItems.Add(subItem);
                            //    //}

                            //    //// 3 - Corte
                            //    //if (dicprenda.ContainsKey("corte"))
                            //    //{
                            //    //    subItem = new ListViewItem.ListViewSubItem(item, dicprenda["corte"].ToString());
                            //    //    item.SubItems.Add(subItem);
                            //    //}

                            //    //// 4 - talla
                            //    //if (dicprenda.ContainsKey("talla"))
                            //    //{
                            //    //    subItem = new ListViewItem.ListViewSubItem(item, dicprenda["talla"].ToString());
                            //    //    item.SubItems.Add(subItem);
                            //    //}

                            //    //// 5 - color
                            //    //if (dicprenda.ContainsKey("color"))
                            //    //{
                            //    //    subItem = new ListViewItem.ListViewSubItem(item, dicprenda["color"].ToString());
                            //    //    item.SubItems.Add(subItem);
                            //    //}

                            //    //// 6 - id_talla
                            //    //if (dicprenda.ContainsKey("id_talla"))
                            //    //{
                            //    //    subItem = new ListViewItem.ListViewSubItem(item, dicprenda["id_talla"].ToString());
                            //    //    item.SubItems.Add(subItem);
                            //    //}

                            //}
                            //else
                            //{
                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem(item, "");
                            item.SubItems.Add(subItem);
                            //}


                            // 7 - tag seen count
                            subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
                            m_TagTotalCount += tag.TagSeenCount;
                            item.SubItems.Add(subItem);

                            // 8 - tag event
                            subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
                            item.SubItems.Add(subItem);

                            // 9 - RSSI
                            subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                            item.SubItems.Add(subItem);

                            //10 - phase
                            subItem = new ListViewItem.ListViewSubItem(item, GetPhaseInDegree(tag.PhaseInfo));
                            item.SubItems.Add(subItem);

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

                totalTagValueLabel.Text = m_TagTable.Count.ToString();

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

                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
                {

                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
                {

                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
                {

                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_WRITE)
                {

                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
                {

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
                                /*
                                if (inventoryList.Items.Count > 0 && inventoryList.SelectedItems.Count > 0) // ensure that a tag item is currently selected in the TagListView
                                {
                                    ListViewItem item = inventoryList.SelectedItems[0];
                                    string tagID = m_ReadTag.TagID + m_ReadTag.MemoryBank.ToString()
                                        + m_ReadTag.MemoryBankDataOffset.ToString();

                                    if (item.SubItems[6].Text.Length > 0)
                                    {
                                        bool isFound = false;

                                        // Search or add new one
                                        lock (m_TagTable.SyncRoot)
                                        {
                                            isFound = m_TagTable.ContainsKey(tagID);
                                        }

                                        if (!isFound)
                                        {
                                            ListViewItem newItem = new ListViewItem(m_ReadTag.TagID);
                                            // 1 - Antenna ID
                                            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.AntennaID.ToString());
                                            newItem.SubItems.Add(subItem);

                                            // 2
                                            subItem = new ListViewItem.ListViewSubItem(item, "");
                                            item.SubItems.Add(subItem);

                                            // 3
                                            subItem = new ListViewItem.ListViewSubItem(item, "");
                                            item.SubItems.Add(subItem);

                                            // 4
                                            subItem = new ListViewItem.ListViewSubItem(item, "");
                                            item.SubItems.Add(subItem);

                                            // 5
                                            subItem = new ListViewItem.ListViewSubItem(item, "");
                                            item.SubItems.Add(subItem);

                                            // 6
                                            subItem = new ListViewItem.ListViewSubItem(item, "");
                                            item.SubItems.Add(subItem);

                                            // 7 - tag Seent count 
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.TagSeenCount.ToString());
                                            newItem.SubItems.Add(subItem);

                                            // 8 - tagEvent (New, Invisible, Back to Visible 
                                            subItem = new ListViewItem.ListViewSubItem(newItem, getTagEvent(m_ReadTag));
                                            m_TagTotalCount += m_ReadTag.TagSeenCount;
                                            newItem.SubItems.Add(subItem);

                                            // 9 - RSSI
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PeakRSSI.ToString());
                                            newItem.SubItems.Add(subItem);

                                            // 10 - Phase
                                            subItem = new ListViewItem.ListViewSubItem(item, GetPhaseInDegree(m_ReadTag.PhaseInfo));
                                            newItem.SubItems.Add(subItem);
                                            // 11 - PC bits
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PC.ToString("X"));
                                            newItem.SubItems.Add(subItem);
                                            // 12 - Memory Bank Data
                                            subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankData);
                                            newItem.SubItems.Add(subItem);

                                            string memoryBank = m_ReadTag.MemoryBank.ToString();
                                            int index = memoryBank.LastIndexOf('_');
                                            if (index != -1)
                                            {
                                                memoryBank = memoryBank.Substring(index + 1);
                                            }
                                            //// 8 - Memory Bank
                                            //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                            //newItem.SubItems.Add(subItem);

                                            //// 9 - Memory Bank Offset
                                            //subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankDataOffset.ToString());
                                            //newItem.SubItems.Add(subItem);


                                            // 10 - Brand ID check status
                                            //if (checkBoxEnableBrandIDCheck.Checked)
                                            //{
                                            //    subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.BrandValid.ToString());
                                            //    newItem.SubItems.Add(subItem);
                                            //}
                                            inventoryList.BeginUpdate();
                                            inventoryList.Items.Add(newItem);
                                            inventoryList.EndUpdate();

                                            lock (m_TagTable.SyncRoot)
                                            {
                                                m_TagTable.Add(tagID, newItem);
                                            }
                                        }
                                        else
                                        {
                                            //item.SubItems[7].Text = m_ReadTag.MemoryBankData;
                                            //item.SubItems[9].Text = m_ReadTag.MemoryBankDataOffset.ToString();
                                        }
                                    }
                                    else
                                    {
                                        lock (m_TagTable.SyncRoot)
                                        {
                                            m_TagTable.Remove(m_ReadTag.TagID);
                                            m_TagTable.Add(tagID, item);
                                        }
                                    }
                                }
                                */
                                //this.m_ReadForm.ReadData_TB.Text = m_ReadTag.MemoryBankData;
                                m_MainForm.functionCallStatusLabel.Text = "Se leyó con éxito";

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
            //this.autonomous_CB.Enabled = m_MainForm.m_IsConnected;
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
            updateGPIState();
        }

        internal void configureMenuItemsBasedOnCapabilities()
        {
            //m_MainForm.configureMenuItemsBasedOnCapabilities();
        }

        private void FormPOLecturaDeCaja_Load(object sender, EventArgs e)
        {
            SeConEnSegundos.Text = "";
            if (m_MainForm.m_IsConnected == false)
            {
                m_MainForm.functionCallStatusLabel.Text = "Conéctese primero al lector";
                MessageBox.Show("No está conectado al Lector. \nConéctese primero al lector para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            else
            {
                //Valor guardado para la antena
                int index_antena = 0;
                int valor_antena = 0;
                string txt_antena = "";
                ushort[] antID = m_MainForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
                int[] txValues = m_MainForm.m_ReaderAPI.ReaderCapabilities.TransmitPowerLevelValues;
                //Console.WriteLine("El final-->" + txValues[200]);
                //GPI States
                for (int index = 0; index < 4; index++)
                {
                    int tabIndex = 1;

                    Label gpiStateLabel = new System.Windows.Forms.Label();
                    gpiStateLabel.AutoSize = false;
                    gpiStateLabel.BackColor = System.Drawing.Color.Transparent;
                    gpiStateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    gpiStateLabel.Location = new System.Drawing.Point(5 + (index * 60), 20);
                    gpiStateLabel.Name = "GPI Estados " + index;
                    gpiStateLabel.Size = new System.Drawing.Size(55, 20);
                    gpiStateLabel.TabIndex = tabIndex++;
                    gpiStateLabel.Text = "   ";
                    gpiStateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)))));
                    autonomous_CB.Controls.Add(gpiStateLabel);
                    m_GPIStateList.Add(gpiStateLabel);

                    int name = index + 1;
                    //Identificar que valor tiene configurada la antena
                    index_antena = GetIniAntena(name);
                    valor_antena = txValues[index_antena];
                    txt_antena = name + " [" + valor_antena + "]";
                    Label gpiStateNumLabel = new System.Windows.Forms.Label();
                    gpiStateNumLabel.AutoSize = true;
                    float fontSize = Math.Max(10, this.ClientSize.Width / 250);
                    gpiStateNumLabel.Font = new System.Drawing.Font(
                        "Microsoft Sans Serif",
                        fontSize,
                        System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point,
                        ((byte)(0)));
                    gpiStateNumLabel.Location = new System.Drawing.Point(7 + (index * 61), 40);
                    gpiStateNumLabel.Name = "label" + index;
                    gpiStateNumLabel.Size = new System.Drawing.Size(55, 10);
                    gpiStateNumLabel.TabIndex = tabIndex++;
                    gpiStateNumLabel.Text = txt_antena.ToString();
                    autonomous_CB.Controls.Add(gpiStateNumLabel);
                }
                configureMenuItemsUponConnectDisconnect();
                updateGPIState();

                //actualiza la información de m_ReaderApi
                updateReaderApi();

                readButton.Enabled = m_MainForm.m_IsConnected;
                gdt_Fecha = DateTime.Now;

                /*this.BeginInvoke(new Action(() =>
                {
                    retrieveData();
                }));*/
            }
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

        private void FormPOLecturaDeCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_MainForm.m_IsConnected)
                {
                    if (Convert.ToString(readButton.Tag) == "Stop Reading")
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                        }
                        else
                        {
                            m_ReaderAPI.Actions.Inventory.Stop();
                        }

                        readButton.Text = "Iniciar";
                        readButton.Tag = "Start Reading";
                        m_IsReading = false;
                    }
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

            m_MainForm.m_FormPOLecturaDeCaja = null;
        }

        private void retrieveData()
        {
            DateTime ldt_fechaActual = DateTime.Now.Date;

            if (m_DBLecturaDeCaja == null)
            {
                m_DBLecturaDeCaja = new DBLecturaDeCaja();
            }
        }


        private void setCantidadTag()
        {
            /*if (dgv_cajas.DataSource == null) return;

                        if (dgv_cajas.Rows.Count <= 1) return;

                        if (dgv_cajas.SelectedCells.Count == 0) return;*/

        }

        private int RegistertData()
        {
            /*long ll_return = 0;

            MySqlTransaction trans = null;
            //MessageBox.Show("HELP_1");
            m_TagTable.Clear();
            m_TagTable.Add("E28068900000500DBA999986", 1);
            m_TagTable.Add("E28068900000500DBA999985", 2);
            m_TagTable.Add("E28068900000500DBA999984", 3);
            m_TagTable.Add("E28068900000500DBA999983", 4);

            int cantidadEtiquetas = m_TagTable.Count;

            if (dgv_cajas.DataSource == null || dgv_cajas.Rows.Count == 0) return 0;

            if (dgv_cajas.SelectedCells.Count == 0) return 0;

            if (dgv_cajas.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna fila seleccionada.");
                return 0;
            }

            DataGridViewRow selectedRow = dgv_cajas.SelectedRows[0];    // Obtener la fila seleccionada
            DialogResult rpta = FormMessageBox.Show("¿Está seguro de registrar " + cantidadEtiquetas.ToString() + " prendas en la caja?", "Cantidad de Prendas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);


            if (rpta != DialogResult.Yes)
                return 0;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            string ls_nro_op = selectedRow.Cells["op"].Value.ToString();
            string ls_hoja_marcacion = selectedRow.Cells["hoja_marcacion"].Value.ToString();
            string ls_nro_caja = selectedRow.Cells["nro_caja"].Value.ToString();
            string ls_nro_cea = selectedRow.Cells["nro_cea"].Value.ToString();
            string ls_nro_packinglist = selectedRow.Cells["nro_packinglist"].Value.ToString();
            string ls_nro_po = selectedRow.Cells["nro_po"].Value.ToString();

            bool lb_existeId = dgv_cajas.Columns.Contains("id");

            if (selectedRow.IsNewRow) // Ignorar la fila nueva que aún está en edició
                return 0;

            ls_nro_op = ls_nro_op.Trim();
            if (ls_nro_op != string.Empty)
            {
                dictionary.Add("op", ls_nro_op);
            }

            ls_hoja_marcacion = ls_hoja_marcacion.Trim();
            if (ls_hoja_marcacion != string.Empty)
            {
                dictionary.Add("hoja_marcacion", ls_hoja_marcacion);
            }

            ls_nro_caja = ls_nro_caja.Trim();
            if (ls_nro_caja != string.Empty)
            {
                dictionary.Add("nro_caja", ls_nro_caja);
            }

            ls_nro_cea = ls_nro_cea.Trim();
            if (ls_nro_cea != string.Empty)
            {
                dictionary.Add("nro_cea", ls_nro_cea);
            }

            ls_nro_packinglist = ls_nro_packinglist.Trim();
            if (ls_nro_packinglist != string.Empty)
            {
                dictionary.Add("nro_packinglist", ls_nro_packinglist);
            }

            ls_nro_po = ls_nro_po.Trim();
            if (ls_nro_po != string.Empty)
            {
                dictionary.Add("nro_po", ls_nro_po);
            }

            dictionary.Add("cantidad_prendas", cantidadEtiquetas);
            dictionary.Add("codigo_compania", m_cod_Compania);
            dictionary.Add("fecha", DateTime.Now.Date);
            dictionary.Add("fecha_creacion", DateTime.Now);
            dictionary.Add("usuario_creacion", m_Cod_Trabajador);
            dictionary.Add("fecha_modificacion", DateTime.Now);
            dictionary.Add("usuario_modificacion", m_Cod_Trabajador);


            try
            {
                using (connectionMySql = m_DBLecturaDeCaja.Connect())
                {
                    using (trans = connectionMySql.BeginTransaction())  //iniciamos la transacion
                    {
                        ll_return = m_DBLecturaDeCaja.Insert(dictionary, connectionMySql, trans);
                        if (ll_return == -1)
                        {
                            trans.Rollback();
                            string lsError = m_DBLecturaDeCaja.GetError();
                            MessageBox.Show(lsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return 0;
                        }

                        trans.Commit();                    //confirmo la trasaccion
                        this.BeginInvoke(new Action(() =>
                        {
                            m_MainForm.functionCallStatusLabel.Text = "Se guardó con éxito.";
                            labelmsj.Text = "Se guardó con éxito.";
                        }));

                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre algún error, hacemos rollback
                trans.Rollback();
                connectionMySql.Close();
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
                labelmsj.Text = ex.Message;
                return -1;
            }
            finally
            {
                connectionMySql.Dispose(); trans.Dispose(); //command.Dispose();                    
            }*/
            return 1;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nroPO = textPO.Text;
                nroPO = nroPO.Trim();
                string ls_msn = "";
                if (nroPO == "")
                {
                    ls_msn = "Ingrese número de PO.";
                    textPO.Focus();
                    AlertaError(ls_msn);
                    return;
                }
                if (m_MainForm.m_IsConnected)
                {
                    if (Convert.ToString(readButton.Tag) == "Start Reading")
                    {
                        tmP.Start();
                        timerCronome_tro.Enabled = true;
                        m_DataTableDatosPrendas.Clear();
                        tiempo_cronometro.Clear();
                        totalTagValueLabel.Text = "0";
                        SeConEnSegundos.Text = "";
                        ReportaIncidente.Visible = false;
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            // Before inventory purge all tags
                            m_ReaderAPI.Actions.PurgeTags();
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(null,
                                null, m_MainForm.m_AntennaInfoForm.getInfo());
                            //m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_MainForm.m_AccessFilterForm.getFilter(),
                            //    m_MainForm.m_TriggerForm.getTriggerInfo(), m_MainForm.m_AntennaInfoForm.getInfo());
                        }
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

                        readButton.Text = "Detener";
                        readButton.Tag = "Stop Reading";
                        m_IsReading = true;
                    }
                    else if (Convert.ToString(readButton.Tag) == "Stop Reading")
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                        }
                        else
                        {
                            m_ReaderAPI.Actions.Inventory.Stop();
                        }

                        readButton.Text = "Iniciar";
                        readButton.Tag = "Start Reading";
                        m_IsReading = false;

                        timerCronome_tro.Stop();
                        timerCronome_tro.Enabled = false;
                    }
                }
                else
                {
                    m_MainForm.functionCallStatusLabel.Text = "Please connect to a reader first";
                    //labelmsj.Text = "Conéctese primero al lector RFID";
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
                //labelmsj.Text = ex.Message;
            }
        }

        void inventoryList_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //dataContextMenuStrip.Show(inventoryList, new Point(e.X, e.Y));
            }
        }

        void inventoryList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //if (e.Column != this.m_SortColumn)
            //{
            //    m_SortColumn = e.Column;
            //    inventoryList.Sorting = SortOrder.Ascending;
            //}
            //else
            //{
            //    if (inventoryList.Sorting == SortOrder.Ascending)
            //        inventoryList.Sorting = SortOrder.Descending;
            //    else
            //        inventoryList.Sorting = SortOrder.Ascending;
            //}
            //this.inventoryList.Sort();
            //this.inventoryList.ListViewItemSorter = new ListViewItemComparer(e.Column, inventoryList.Sorting);
        }

        private void updateGPIState()
        {
            try
            {
                if (m_MainForm.m_IsConnected)
                {
                    for (int index = 0; index < 4; index++)
                    {
                        if (index < m_ReaderAPI.ReaderCapabilities.NumGPIPorts)
                        {
                            Label gpiLabel = (Label)m_GPIStateList[index];
                            GPIs.GPI_PORT_STATE portState = m_ReaderAPI.Config.GPI[index + 1].PortState;

                            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                            {
                                gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
                            }
                            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                            {
                                gpiLabel.BackColor = System.Drawing.Color.Red;
                            }
                            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                            {

                            }
                        }
                    }
                }
                else
                {
                    for (int index = 0; index < 8; index++)
                    {
                        ((Label)m_GPIStateList[index]).BackColor = System.Drawing.Color.Transparent;
                    }
                }
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
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
            this.totalTagValueLabel.Text = "0  (0)";
            m_TagTotalCount = 0;
            //this.inventoryList.Items.Clear();
            ReportaIncidente.Visible = false;
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

        private void FormPOLecturaDeCaja_Activated(object sender, EventArgs e)
        {
            updateReaderApi();
            updateGPIState();
        }

        private void FormPOLecturaDeCaja_Resize(object sender, EventArgs e)
        {
            int li_long;
            int li_height;
            int li_width;
            float fontSize;
            int li_minnimo = 10;
            int li_max = 45;
            int li_factor = 1;
            string ls_tag = "";
            foreach (Control control in this.Controls)
            {
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    foreach (Control control1 in control.Controls)
                    {
                        li_factor = li_minnimo;
                        if (control1.Name == "readButton")
                        {
                            li_factor = li_max;
                            li_height = this.ClientSize.Height / li_factor;
                            li_width = this.ClientSize.Width / li_factor;

                            fontSize = Math.Max(li_height, li_width);
                            control1.Font = new Font(control.Font.FontFamily, fontSize);
                        }
                        if (control1.Name == "tableLayoutPanel2")
                        {
                            foreach (Control control2 in tableLayoutPanel2.Controls)
                            {
                                if (control2.Name == "totalTagValueLabel" || control2.Name == "label13")
                                {
                                    li_factor = control2.Name == "totalTagValueLabel" ? li_minnimo : li_max;

                                    li_height = this.ClientSize.Height / li_factor;
                                    li_width = this.ClientSize.Width / li_factor;
                                    ls_tag = (string)control2.Tag;
                                    if (ls_tag != null)
                                    {
                                        if (int.TryParse(ls_tag, out li_long))
                                        {
                                            li_height /= li_long;
                                            li_width /= li_long;
                                        }
                                    }

                                    fontSize = Math.Max(li_height, li_width);
                                    control2.Font = new Font(control.Font.FontFamily, fontSize);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void dgv_etiquetas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la fila seleccionada sea válida
            if (e.RowIndex >= 0)
            {
                //RegistertData();
            }
        }

        private void dataButton_Enter(object sender, EventArgs e)
        {
            //retrieveData();
        }

        private void dataButton_Click(object sender, EventArgs e)
        {
            //retrieveData();
        }

        private void dgv_cajas_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            /*if (dgv_cajas.Rows.Count > 1) // Excluye la fila de edición actual
            {
                // Obtén la última fila con datos (fila anterior)
                DataGridViewRow previousRow = dgv_cajas.Rows[dgv_cajas.Rows.Count - 2];

                // Asigna valores predeterminados tomando los valores del registro anterior
                e.Row.Cells["op"].Value = previousRow.Cells["op"].Value;
                e.Row.Cells["hoja_marcacion"].Value = previousRow.Cells["hoja_marcacion"].Value;

            }

            e.Row.Cells["codigo_compania"].Value = m_cod_Compania;
            e.Row.Cells["fecha"].Value = DateTime.Now.Date;
            e.Row.Cells["fecha_modificacion"].Value = DateTime.Now;
            e.Row.Cells["usuario_modificacion"].Value = m_Cod_Trabajador; // Por ejemplo, 1 para activo
            e.Row.ReadOnly = false;*/
        }

        private void textBoxAsignarTiempo_Enter(object sender, EventArgs e)
        {
            /*if (!string.IsNullOrEmpty(textBoxAsignarTiempo.Text))
            {
                if (Int32.Parse(textBoxAsignarTiempo.Text) > 0 && Int32.Parse(textBoxAsignarTiempo.Text) <= 20)
                {
                    readButton.Focus();
                }
                else
                {
                    MessageBox.Show("Ingresar\n Numero entre 1 y 20", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Error\n Ingresar valores", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }*/
        }

        private void textBoxAsignarTiempo_Leave(object sender, EventArgs e)
        {

        }

        private void textBoxAsignarTiempo_LostFocus(object sender, EventArgs e)
        {
            /*if (!string.IsNullOrEmpty(textBoxAsignarTiempo.Text))
            {
                if(Int32.Parse(textBoxAsignarTiempo.Text) >0 && Int32.Parse(textBoxAsignarTiempo.Text)<=20)
                {
                    readButton.Focus();
                } else
                {
                    MessageBox.Show("Ingresar\n Numero entre 1 y 20", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            } else
            {
                MessageBox.Show("Error\n Ingresar valores", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }*/
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_ReaderAPI != null && m_MainForm.m_IsConnected && m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
            {
                //this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                //    "Power On Radio" : "Power Off Radio";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormPOLecturaDeCaja_Shown(object sender, EventArgs e)
        {
            if (m_MainForm.m_IsConnected == false)
            {
                m_MainForm.functionCallStatusLabel.Text = "Conéctese primero al lectorx";
                MessageBox.Show("No está conectado al Lector. \nConéctese primero al lector para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
        }

        private void InitializeTimer()
        {

        }

        //para devolver el error del objeto
        public string GetError()
        {
            return s_error;
        }
        private void timerCronome_tro_Tick(object sender, EventArgs e)
        {
            TimeSpan tiempomili = new TimeSpan(0, 0, 0, 0, (int)tmP.ElapsedMilliseconds);
            //Segundo actual del cronometro
            tiempo_termina = tiempomili.Seconds;
            //Lectura actual del RFID
            int valorfinal = Int32.Parse(totalTagValueLabel.Text);
            //Agregar valor
            // Verificar si la clave ya existe en el diccionario
            if (tiempo_cronometro.ContainsKey(tiempo_termina))
            {
                // Si la clave ya existe, puedes actualizar el valor si es necesario
                // tiempo_cronometro[tiempo_termina] = valorfinal;

                // O, si prefieres no hacer nada, puedes simplemente omitir esta línea
                // De todas maneras, el error no se lanzará
            }
            else
            {
                // Agregar el nuevo valor al diccionario
                tiempo_cronometro.Add(tiempo_termina, valorfinal);
            }
            //Buscar coincidentia del ultimo valor y contar
            int sumaiguales = 0;
            foreach (var kvp in tiempo_cronometro)
            {
                if (kvp.Value == valorfinal)
                {
                    sumaiguales++;
                }
                //Console.WriteLine("Tiempo final:"+ m_TiempoFinal + " tiempo actual: "+tiempo_termina+" valor actual: "+kvp.Value +" Ultimo valor: "+valorfinal);
            }
            //Si la coincidencia coincide con la sensibilidad se coloca falso sino seria verdadero
            bool es_contado = ((m_Sensibilidad + 1) == sumaiguales) ? false : true;
            //Console.WriteLine("Cuantas veces exite valor: " + sumaiguales);
            //Si el teimpo actual es mayor o igual al tiempo establecido del cronometro y ademas compara el valor es_contado
            if (m_TiempoFinal >= tiempo_termina && es_contado)
            {
                v_min = tiempomili.Minutes.ToString().Length < 2 ? "0" + tiempomili.Minutes.ToString() : tiempomili.Minutes.ToString();
                v_seg = tiempo_termina.ToString().Length < 2 ? "0" + tiempo_termina.ToString() : tiempo_termina.ToString();
                v_hor = tiempomili.Hours.ToString().Length < 2 ? "0" + tiempomili.Hours.ToString() : tiempomili.Hours.ToString();

                m0Cronometro.Text = v_hor + " : " + v_min + " : " + v_seg;
                v_Segundos = Int32.Parse(v_seg);
            }
            else
            {
                tmP.Reset();
                timerCronome_tro.Stop();
                timerCronome_tro.Enabled = false;
                tiempo_cronometro.Clear();
                this.RegistrarCantidad();
                ReportaIncidente.Visible = true;
                try
                {
                    if (m_MainForm.m_IsConnected)
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                        }
                        else
                        {
                            m_ReaderAPI.Actions.Inventory.Stop();
                        }

                        readButton.Text = "Iniciar";
                        readButton.Tag = "Start Reading";
                        m_IsReading = false;
                        SeConEnSegundos.Text = "¡Se contó en tan solo "+ v_Segundos + " seg!";                         
                    }
                    else
                    {
                        m_MainForm.functionCallStatusLabel.Text = "Conéctese primero al lector RFID";
                        //labelmsj.Text = "Conéctese primero al lector RFID";
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
                    //labelmsj.Text = ex.Message;
                }
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

            m_Sensibilidad = Int32.Parse(iniFile.GetValue(m_Titulo, "Sensibilidad")); ;
            m_TiempoFinal = Int32.Parse(iniFile.GetValue(m_Titulo, "Valor"));
            m_VerCronometro = (iniFile.GetValue(m_Titulo, "Vercronometro") == "1");


            return 1;
        }

        private int SetConfiguracionIni(string valor)
        {
            IniFile fileIniConfig = new IniFile();
            fileIniConfig.LoadConfiguracion();
            fileIniConfig.SetValue(m_Titulo, "Valor", valor);
            return 1;
        }


        private int GetIniAntena(int orden)
        {
            IniFile iniFile = new IniFile();
            bool lb_exist = iniFile.LoadConfiguracion();
            if (!lb_exist)
            {
                s_error = iniFile.GetError();
                return 0;
            }

            return Int32.Parse(iniFile.GetValue(m_Antena, orden.ToString()));
        }

        private int InsertarConteo()
        {
            long ll_return = 0;
            long ll_id = 0;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("cantidad_prendas", Int32.Parse(totalTagValueLabel.Text));
            dictionary.Add("cod_trabajador", m_Cod_Trabajador);
            MySqlTransaction trans = null;
            try
            {
                using (connectionMySql = m_DBLecturaDeCaja.Connect())
                {
                    using (trans = connectionMySql.BeginTransaction())
                    {
                        ll_return = m_DBLecturaDeCaja.Insert(dictionary, connectionMySql, trans);
                        if (ll_id <= 0)
                        {
                            trans.Rollback();
                            if (ll_return == -1)
                            {
                                string lsError = m_DBLecturaDeCaja.GetError();
                                MessageBox.Show(lsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return 0;
                        }

                        trans.Commit();                    //confirmo la trasaccion
                        m_MainForm.functionCallStatusLabel.Text = "Se guardó con éxito.";
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                connectionMySql.Close();
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
                //labelmsj.Text = ex.Message;
                return -1;
            }
            finally
            {
                connectionMySql.Dispose(); trans.Dispose();
            }
        }

        private void ReportaIncidente_Click(object sender, EventArgs e)
        {
            FormIncidente fromIncidente = new FormIncidente(m_Cod_Trabajador,1);    //Tipo 1(Contar Prendas)
            fromIncidente.StartPosition = FormStartPosition.CenterParent; // Centrar con respecto al padre
            fromIncidente.ShowDialog(this);
        }

        private int RegistrarCantidad()
        {
            MySqlTransaction trans = null;
            long ll_return;
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                int cantidadEtiquetas = Int32.Parse(totalTagValueLabel.Text);
                dictionary.Add("cantidad_prendas", cantidadEtiquetas);
                dictionary.Add("cod_trabajador", m_Cod_Trabajador);
                dictionary.Add("nro_po", textPO.Text);
                Console.WriteLine(dictionary["cantidad_prendas"] + " <---> " + dictionary["cod_trabajador"]);
                //DBLecturaDeCaja m_DBLecturaDeCaja
                if (m_DBLecturaDeCaja == null)
                {
                    m_DBLecturaDeCaja = new DBLecturaDeCaja();
                }
                using (connectionMySql = m_DBLecturaDeCaja.Connect())
                {
                    using (trans = connectionMySql.BeginTransaction())
                    {
                        ll_return = m_DBLecturaDeCaja.Insertar(dictionary, connectionMySql, trans);
                        if (ll_return == -1)
                        {
                            trans.Rollback();
                            string lsError = m_DBLecturaDeCaja.GetError();
                            MessageBox.Show(lsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return 0;
                        }
                        trans.Commit();
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                connectionMySql.Close();
                //labelMsnReporte.Text = ex.Message;
                return -1;
            }
            finally
            {
                connectionMySql.Dispose(); trans.Dispose();
            }
        }

        private void AlertaError(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 3);
            aler_ta.ShowDialog();
        }
    }
}
