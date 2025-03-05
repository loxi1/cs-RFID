using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Symbol.RFID3;
using System.Diagnostics;
using System.IO;

namespace RFIDPrendas
{
    public partial class FormValidarSalida : Form
    {
        private FormMain m_MainForm = null;
        internal RFIDReader m_ReaderAPI;
        internal bool m_IsReading = false;
        public RFIDResults m_Result;
        //internal ReaderManagement m_ReaderMgmt;
        //internal READER_TYPE m_ReaderType;        
        internal BDPrendaScm m_bdPrendaScm;
        internal BDContenedor m_ContenedorBD;
        internal string m_cod_Trabajador;
        internal DBLecturaDeCaja m_LecturaDeCaja;
        internal DBAuditarCaja m_DBAuditarCaja = new DBAuditarCaja();
        internal BDHojaMarcacion m_bdHojaMarc = new BDHojaMarcacion();
        internal Mensaje m_Mensaje;
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
        //private int m_SortColumn = -1;
        private uint m_TagTotalCount;
        private MySqlConnection connectionMySql;
        //private Socket m_ReaderSocket;
        DataTable m_DataTableDatosPrendas = new DataTable();

        //Cronometro
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

        private readonly string iniDirectory;
        private readonly Dictionary<string, string> iconPaths;

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

        public FormValidarSalida(FormMain mainForm, RFIDReader pReaderAPI, string codTrabajador)
        {
            InitializeComponent();
            m_MainForm = mainForm;
            m_ReaderAPI = pReaderAPI;
            m_cod_Trabajador = codTrabajador;
            this.MdiParent = m_MainForm;
            m_GPIStateList = new ArrayList();
            m_UpdateStatusHandler = new UpdateStatus(myUpdateStatus);
            m_UpdateReadHandler = new UpdateRead(myUpdateRead);
            m_ReadTag = new Symbol.RFID3.TagData();

            m_TagTable = new Hashtable();
            m_TagTotalCount = 0;
            m_bdPrendaScm = new BDPrendaScm();
            configureMenuItemsUponConnectDisconnect();

            if (GetIni() == 1)
            {
                tbContentCronometro.Visible = m_VerCronometro;
            }

            // Cargar la ruta de la carpeta "Ini" una sola vez
            IniFile fileIniConfig = new IniFile();
            iniDirectory = fileIniConfig.GetDirectory();

            // Mapear los iconos con su respectivo nombre de archivo
            iconPaths = new Dictionary<string, string>
            {
                { "ok", "icono_checking_512.svg" },
                { "error", "icono_error_512.svg" },
                { "default", "icono_exclamation_512.svg" }
            };
            tbContentCronometro.Size = new System.Drawing.Size(255, 117);
            autonomous_CB.Size = new System.Drawing.Size(255, 76);
            tbFooterInfo.ColumnStyles[0].SizeType = SizeType.AutoSize;
            tbFooterInfo.RowStyles[0].SizeType = SizeType.AutoSize;
        }

        private void myUpdateStatus(Events.StatusEventData eventData)
        {
            switch (eventData.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Procesando...";
                    this.readButton.Enabled = false;
                    this.readButton.Text = "Detener...";
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
                    this.readButton.Text = "Detener...";
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
                            //uint count = 0;
                            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                            try
                            {
                                //count = uint.Parse(item.SubItems[7].Text) + tagData[nIndex].TagSeenCount;
                                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                            }
                            catch (FormatException fe)
                            {
                                m_MainForm.functionCallStatusLabel.Text = fe.Message;
                                break;
                            }
                            /*item.SubItems[1].Text = tag.AntennaID.ToString();
                            item.SubItems[7].Text = count.ToString();
                            item.SubItems[8].Text = getTagEvent(tag);
                            item.SubItems[9].Text = tag.PeakRSSI.ToString();
                            item.SubItems[10].Text = GetPhaseInDegree(tag.PhaseInfo);*/
                        }
                        else
                        {
                            ListViewItem item = new ListViewItem(tag.TagID);
                            ListViewItem.ListViewSubItem subItem;
                            // 1 - antenna ID
                            /*subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
                            item.SubItems.Add(subItem);*/

                            //para obtener la infomacion de OP, COrte Talla de la Etiqueta 
                            Dictionary<string, object> dicprenda = GetInformacionPrenda(tag.TagID);


                            // Aplicando la estructura simplificada
                            string _op_ = (dicprenda.ContainsKey("op")) ? dicprenda["op"].ToString() : "";
                            string _hojaMarcacion_ = (dicprenda.ContainsKey("hoja_marcacion")) ? dicprenda["hoja_marcacion"].ToString() : "";
                            string _corte_ = (dicprenda.ContainsKey("corte")) ? dicprenda["corte"].ToString() : "";
                            string _subcorte_ = (dicprenda.ContainsKey("subcorte")) ? dicprenda["subcorte"].ToString() : "";
                            string _talla_ = (dicprenda.ContainsKey("talla")) ? dicprenda["talla"].ToString() : "";
                            string _color_ = (dicprenda.ContainsKey("color")) ? dicprenda["color"].ToString() : "";

                            // Agregar subitems al ListViewItem
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, _op_));
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, _hojaMarcacion_));
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, _corte_));
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, _subcorte_));
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, _talla_));
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, _color_));

                            inventoryList.BeginUpdate();
                            inventoryList.Items.Add(item);
                            inventoryList.EndUpdate();

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
                                        Console.WriteLine("Sergio");
                                        if (!isFound)
                                        {
                                            ListViewItem newItem = new ListViewItem(m_ReadTag.TagID);
                                            // 1 - Antenna ID
                                            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.AntennaID.ToString());
                                            newItem.SubItems.Add(subItem);
                                            Console.WriteLine("PCCC");
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
                                            /*
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
                                            newItem.SubItems.Add(subItem);*/

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
                                        //// Empty Memory Bank Slot
                                        //item.SubItems[6].Text = m_ReadTag.MemoryBankData;

                                        //string memoryBank = ""; //m_ReadForm.m_ReadParams.MemoryBank.ToString();
                                        //int index = memoryBank.LastIndexOf('_');
                                        //if (index != -1)
                                        //{
                                        //    memoryBank = memoryBank.Substring(index + 1);
                                        //}
                                        //item.SubItems[8].Text = memoryBank;
                                        //item.SubItems[9].Text = m_ReadTag.MemoryBankDataOffset.ToString();

                                        lock (m_TagTable.SyncRoot)
                                        {
                                            m_TagTable.Remove(m_ReadTag.TagID);
                                            m_TagTable.Add(tagID, item);
                                        }
                                    }
                                }

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
            this.autonomous_CB.Enabled = m_MainForm.m_IsConnected;
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

        private void FormValidarSalida_Load(object sender, EventArgs e)
        {
            SeConEnSegundos.Text = "";
            if (m_MainForm.m_IsConnected == false)
            {
                m_MainForm.functionCallStatusLabel.Text = "Conéctese primero al lector";
                MessageBox.Show("No está conectado al Lector. \nConéctese primero al lector para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            //Valor guardado para la antena
            int index_antena = 0;
            int valor_antena = 0;
            string txt_antena = "";
            ushort[] antID = m_MainForm.m_ReaderAPI.Config.Antennas.AvailableAntennas;
            int[] txValues = m_MainForm.m_ReaderAPI.ReaderCapabilities.TransmitPowerLevelValues;
            int antenas = m_MainForm.m_ReaderAPI.Config.Antennas.Length;
            string texto = $"ON";
            Console.WriteLine("El # de antenas son-->" + antenas);
            //Console.WriteLine("El final-->" + txValues[200]);
            //GPI States
            for (int index = 0; index < antID.Length; index++)
            {
                int tabIndex = 1;
                // Obtener las propiedades físicas de la antena
                var antennaProperties = m_MainForm.m_ReaderAPI.Config.Antennas[index + 1];
                var physicalProperties = antennaProperties.GetPhysicalProperties();

                // Verificar si la antena está conectada
                bool isAntennaConnected = physicalProperties.IsConnected;

                Label gpiStateLabel = new System.Windows.Forms.Label();
                gpiStateLabel.AutoSize = false;
                gpiStateLabel.BackColor = System.Drawing.Color.Transparent;
                gpiStateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                gpiStateLabel.Location = new System.Drawing.Point(3+(index * 60), 20);
                gpiStateLabel.Name = "GPI Estados " + index;
                gpiStateLabel.Size = new System.Drawing.Size(55, 20);
                texto = $"ON";
                // Configuramos colores y texto en base al estado
                if (isAntennaConnected)
                {
                    gpiStateLabel.ForeColor = System.Drawing.Color.Black; // Texto en verde
                    gpiStateLabel.BackColor = System.Drawing.Color.GreenYellow; // Fondo predeterminado
                }
                else
                {
                    texto = $"OFF";
                    gpiStateLabel.ForeColor = System.Drawing.Color.Red; // Texto en rojo
                    gpiStateLabel.BackColor = System.Drawing.Color.LightGray; // Fondo gris
                }
                gpiStateLabel.TabIndex = tabIndex++;
                gpiStateLabel.Text = texto;
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
                float fontSize = Math.Max(10, this.ClientSize.Width / 200);
                gpiStateNumLabel.Font = new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    fontSize,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));
                gpiStateNumLabel.Location = new System.Drawing.Point(1 + (index * 61), 40);
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

        private void FormValidarSalida_FormClosing(object sender, FormClosingEventArgs e)
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
                        //else if (checkBoxEnableBrandIDCheck.Checked)
                        //{
                        //    m_ReaderAPI.Actions.BrandIdChk.Stop();
                        //}
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

            m_MainForm.m_FormValidarSalida = null;
        }

        private void retrieveData()
        {
            MySqlTransaction trans = null;
            bool codigoerror = false;
            bool entraBucle = false;
            string tipo = "error";
            string msn = "Caja no matriculada";
            int cantidadTotatal = Convert.ToInt32(totalTagValueLabel.Text);
            int tipoError = 5;
            var ls_datosList = new List<string>();

            if (m_TagTable.Count < 1)
                return;

            string[] rfidLectura = m_TagTable.Keys.Cast<string>().ToArray();
            string[] faltaLectura = { };
            string[] faltaMatricula = { };
            string[] elementosMatricula = { };
            bool codeRta = false;
            string msnRta = "Error";
            string[] Elementos = { };
            long MatriculaId = 0;

            Dictionary<string, object> detalleMatricula = new Dictionary<string, object>();
            Dictionary<string, object> detalleDifenciasRFID = new Dictionary<string, object>();


            string datokeys = string.Join(",", m_TagTable.Keys.Cast<string>().Select(key => key));
            Console.WriteLine(datokeys);
            datokeys = string.Join(",", m_TagTable.Keys.Cast<string>().Select(key => $"'{key}'"));
            Console.WriteLine(datokeys);
            //string datokeys = string.Join(",", m_TagTable.Keys.Cast<string>().Select(key => $"'{key}'"));
            //datokeys = "'S40069990000700A8R407201','Q40069990000700A8R407201','csAF4lT6PaK8FTehjjPyb8VI'";

            //Hashtable m_TagTables = new Hashtable();
            //m_TagTables.Add(1, "S40069990000700A8R407201");
            //m_TagTables.Add(2, "Q40069990000700A8R407201");
            //m_TagTables.Add(3, "csAF4lT6PaK8FTehjjPyb8VI");
            //m_TagTables.Add(4, "E280699500007004C456B641");
            //string[]  rfidLectura = m_TagTables.Values.Cast<string>().ToArray();

            if (m_LecturaDeCaja == null) m_LecturaDeCaja = new DBLecturaDeCaja();

            foreach (var rfid in rfidLectura)
            {
                try
                {
                    using (connectionMySql = m_LecturaDeCaja.Connect())
                    {
                        using (trans = connectionMySql.BeginTransaction())
                        {
                            var lv_result = m_LecturaDeCaja.BuscarCajaMatriculada(rfid, connectionMySql, trans);
                            Console.WriteLine($"idmatricula={lv_result.MatricualId}");
                            if (lv_result.MatricualId > 0)
                            {
                                codigoerror = true;
                                dgv_etiquetas.DataSource = lv_result.Matricula;

                                Console.WriteLine($"Existen elementos de la matricula {lv_result.Matricula.Rows.Count}");
                                foreach (DataRow row in lv_result.Matricula.Rows)
                                {
                                    foreach (var item in row.ItemArray)
                                    {
                                        Console.WriteLine(item); // Imprime cada valor de la fila
                                    }
                                }
                                detalleMatricula = lv_result.Detalle;
                                Elementos = lv_result.Elementos;
                                MatriculaId = lv_result.MatricualId;

                                Console.WriteLine($"✅ MatriculaId encontrado: {MatriculaId}, saliendo del bucle...");

                                // 🔴 SALIR INMEDIATAMENTE DEL BUCLE
                                entraBucle = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error en retrieveData: {ex.Message}");
                }
                if (!entraBucle)
                    break;
            }
            Console.WriteLine($"entraBucle: {entraBucle}");
            //En caso no exita algun registro matriculado muestra error
            if (MatriculaId < 1)
            {
                MensajeError.Text = msn;
                CambiarIcono(tipo);
                AlertaError(msn);
                LimpiarDataGrids();
                return;
            }

            codigoerror = false;
            Console.WriteLine($"codigoerror: {entraBucle}");
            //Elementos que faltan
            faltaMatricula = Diferencia(Elementos, rfidLectura);
            foreach (var item in faltaMatricula)
            {
                Console.WriteLine($"faltan->{item}");
            }
            Console.WriteLine($"Diferencia-->faltaMatricula");
            //Elementos que sobran
            faltaLectura = Diferencia(rfidLectura, Elementos);
            foreach (var item in faltaLectura)
            {
                Console.WriteLine($"Sobran->{item}");
            }
            Console.WriteLine($"Diferencia-->faltaLectura");
            //Comparar lectura del GABINETE con RFID matriculados
            // Asegurar que detalleDifenciasRFID tenga datos antes de enviar a CompararPrendasXRFID
            if (detalleMatricula.Count > 0)
            {
                Console.WriteLine($"Checka si entra");
                detalleDifenciasRFID = CompararPrendasXRFID(detalleMatricula);
            }
            else
            {
                Console.WriteLine("⚠️ Advertencia: detalleMatricula está vacío, no se puede comparar.");
                detalleDifenciasRFID = new Dictionary<string, object>(); // Se inicializa vacío para evitar null references.
            }
            Console.WriteLine($"Diferencia-->detalleDifenciasRFID");
            //Faltan elementos matriculados
            if (faltaMatricula.Length != 0)
            {
                ls_datosList.Add("Faltan prendas");
                Console.WriteLine("Exiten más Prendas");
                var data = FiltrarDetallesPorIdRfid(faltaMatricula, detalleMatricula);
                foreach (var kvp in data)
                {
                    string rfid = kvp.Key;
                    dynamic detalles = kvp.Value; // Usamos `dynamic` para acceder a las propiedades
                    Console.WriteLine($"🔹 RFID: {rfid}, Corte: {detalles.Corte}, Subcorte: {detalles.Subcorte}, Talla: {detalles.Talla}, Color: {detalles.Color}");
                }

                var rta = DeDicicionarioADataTable(data);
                dgv_MatriculaFaltante.DataSource = rta;
            }

            //Sobran elementos matriculados
            if (faltaLectura.Length != 0)
            {
                dgv_faltaLectura.DataSource = EliminarElementosPorColumna(faltaLectura, 0);
                ls_datosList.Add("Exiten más Prendas");
                Console.WriteLine("Exiten más Prendas");
            }

            //No coinciden las prendas
            if (detalleDifenciasRFID.Count > 0)
            {
                ls_datosList.Add("Prendas no corresponden");
                var rta = DeDicicionarioADataTable(detalleDifenciasRFID);
                dgv_NoCoinciden.DataSource = rta;
            }

            codigoerror = ls_datosList.Count > 0 ? codigoerror : true;
            msn = codigoerror ? "Caja completa" : string.Join(" | ", ls_datosList);
            Console.WriteLine($"msn: {msn}");
            tipo = codigoerror ? "ok" : tipo;
            MensajeError.Text = msn;
            if (!codigoerror)
            {
                AlertaError(msn);
            }

            Console.WriteLine($"el id: {MatriculaId}");

            if (MatriculaId < 1)
                return;
            Console.WriteLine($"el id222: {MatriculaId}");

            tipoError = codigoerror ? 4 : 5;
            try
            {
                using (var connectionMySql = m_DBAuditarCaja.Connect())
                using (var transi = connectionMySql.BeginTransaction())
                {
                    var parametros = new Dictionary<string, object>
                    {
                        { "estado", tipoError },
                        { "comentario", msn },
                        { "cod_trabajador_modifica", m_cod_Trabajador}
                    };

                    if (m_DBAuditarCaja.UpdateMatricula(MatriculaId, parametros, connectionMySql, transi) > 0)
                    {
                        Console.WriteLine($"ingressssoooo");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al desmatricular caja: {ex.Message}");
            }

            CambiarIcono(tipo);
        }

        void LimpiarDataGrids()
        {
            dgv_etiquetas.DataSource = null;
            dgv_MatriculaFaltante.DataSource = null;
            dgv_faltaLectura.DataSource = null;
            dgv_NoCoinciden.DataSource = null;

            dgv_etiquetas.Rows.Clear();
            dgv_MatriculaFaltante.Rows.Clear();
            dgv_faltaLectura.Rows.Clear();
            dgv_NoCoinciden.Rows.Clear();
        }


        private void VerificarColumnasYDatos()
        {
            Console.WriteLine("📋 Verificando columnas y datos de inventoryList...");

            // Verificar si la columna "Color" existe
            bool tieneColor = inventoryList.Columns.Cast<ColumnHeader>().Any(col => col.Text == "Color");

            if (!tieneColor)
            {
                Console.WriteLine("⚠️ La columna 'Color' NO está presente en inventoryList.");
                return;
            }

            Console.WriteLine("✅ La columna 'Color' está presente.");

            // Verificar datos en cada fila
            foreach (ListViewItem item in inventoryList.Items)
            {
                string colorValue = item.SubItems.Count > 6 ? item.SubItems[6].Text : "N/A";
                Console.WriteLine($"🎨 RFID: {item.SubItems[0].Text} | Color: {colorValue}");
            }
        }


        private void RecorrerInventoryList()
        {
            Console.WriteLine("📋 Recorriendo InventoryList...");

            // Validar si hay elementos en inventoryList
            if (inventoryList.Items.Count == 0)
            {
                Console.WriteLine("⚠️ InventoryList está vacío.");
                return;
            }

            // Obtener los nombres de las columnas
            string[] columnNames = inventoryList.Columns.Cast<ColumnHeader>().Select(col => col.Text).ToArray();

            // Imprimir encabezados de columnas
            Console.WriteLine($"🔹 Columnas: {string.Join(" | ", columnNames)}");

            // Recorrer cada fila del ListView
            foreach (ListViewItem item in inventoryList.Items)
            {
                List<string> rowValues = new List<string>();

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    rowValues.Add($"{columnNames[i]}: {item.SubItems[i].Text}");
                }

                Console.WriteLine($"🔸 {string.Join(" | ", rowValues)}");
            }
        }


        private Dictionary<string, object> CompararPrendasXRFID(Dictionary<string, object> detalleMatricula)
        {
            //List<string> diferencias = new List<string>();
            Dictionary<string, object> diferencias = new Dictionary<string, object>();

            foreach (ListViewItem item in inventoryList.Items)
            {
                Console.WriteLine($"📌 Verificando fila: RFID {item.SubItems[0].Text}, Total Columnas: {item.SubItems.Count}");
            }

            // Validar si hay elementos en inventoryList
            if (inventoryList.Items.Count == 0)
            {
                Console.WriteLine("⚠️ InventoryList está vacío.");
                return diferencias;
            }


            foreach (ListViewItem item in inventoryList.Items)
            {
                Console.WriteLine($"Esta x aca");
                string idRfid = item.SubItems[0].Text;  // RFID
                Console.WriteLine($"idRfid:{idRfid}");
                string corte = item.SubItems[3].Text; // Corte
                Console.WriteLine($"corte:{corte}");
                string subcorte = item.SubItems[4].Text; // Sub Corte
                Console.WriteLine($"subcorte:{subcorte}");
                string talla = item.SubItems[5].Text; // Talla
                Console.WriteLine($"talla:{talla}");
                string color = item.SubItems[6].Text; // Color
                Console.WriteLine($"color:{color}");

                Console.WriteLine($"idRfid:{idRfid} corte:{corte} subcorte:{subcorte} idRfid:{talla} idRfid:{color} idRfid:{color}" );
                // Verificar si el id_rfid existe en los detalles de la matrícula
                if (detalleMatricula.ContainsKey(idRfid))
                {
                    dynamic detalle = detalleMatricula[idRfid];

                    // Comparar los valores de corte, subcorte, talla y color
                    if (detalle.Corte != corte || detalle.Subcorte != subcorte || detalle.Talla != talla || detalle.Color != color)
                    {
                        diferencias[idRfid] = detalle;
                        // Si hay alguna diferencia, agregar el id_rfid a la lista de diferencias
                        Console.WriteLine($"Diferencia encontrada en ID: {idRfid}");
                    }
                }
            }
            return diferencias;
        }

        public DataTable DeDicicionarioADataTable(Dictionary<string, object> detalleMatricula)
        {
            DataTable dataTable = new DataTable();

            // Definir columnas basadas en la estructura de los objetos en el diccionario
            dataTable.Columns.Add("id_rfid", typeof(string));
            dataTable.Columns.Add("corte", typeof(string));
            dataTable.Columns.Add("subcorte", typeof(string));
            dataTable.Columns.Add("talla", typeof(string));
            dataTable.Columns.Add("color", typeof(string));

            foreach (var entry in detalleMatricula)
            {
                var detalles = entry.Value as dynamic; // Usar dynamic para acceder a las propiedades
                dataTable.Rows.Add(
                    entry.Key,
                    detalles.Corte,
                    detalles.Subcorte,
                    detalles.Talla,
                    detalles.Color
                );
            }

            return dataTable;
        }

        public Dictionary<string, object> FiltrarDetallesPorIdRfid(string[] array1, Dictionary<string, object> detalleMatricula)
        {
            // Crear una lista para los elementos a eliminar
            HashSet<string> idsAEliminar = new HashSet<string>(array1);

            // Crear un nuevo diccionario para almacenar los detalles filtrados
            Dictionary<string, object> detallesFiltrados = new Dictionary<string, object>();

            foreach (var entry in detalleMatricula)
            {
                // Comprobar si el id_rfid no está en la lista de elementos a eliminar
                if (idsAEliminar.Contains(entry.Key))
                {
                    detallesFiltrados[entry.Key] = entry.Value;
                }
            }

            // Retornar el diccionario filtrado
            return detallesFiltrados;
        }

        public DataTable EliminarElementosPorColumna(string[] valoresAEliminar, int columnHeader1)
        {
            HashSet<string> valoresSet = new HashSet<string>(valoresAEliminar);

            // Crear un DataTable para almacenar los datos filtrados
            DataTable filteredTable = new DataTable();

            // Definir las columnas del DataTable basadas en las columnas del ListView
            foreach (ColumnHeader column in inventoryList.Columns)
            {
                filteredTable.Columns.Add(column.Text, typeof(string));
            }

            // Iterar sobre los elementos del ListView
            foreach (ListViewItem item in inventoryList.Items)
            {
                // Comprobar si el valor en columnHeader1 no está en valoresSet
                if (valoresSet.Contains(item.SubItems[columnHeader1].Text))
                {
                    // Crear una nueva fila en el DataTable
                    DataRow row = filteredTable.NewRow();
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        row[i] = item.SubItems[i].Text;
                    }
                    filteredTable.Rows.Add(row);
                }
            }

            return filteredTable;
        }

        private static string[] Diferencia(string[] array1, string[] array2)
        {
            // Lista para almacenar los elementos de array1 que no están en array2
            List<string> difference = new List<string>();

            // Recorrer los elementos de array1
            foreach (var item in array1)
            {
                // Comprobar si el elemento de array1 no existe en array2
                if (!Array.Exists(array2, element => element == item))
                {
                    difference.Add(item); // Agregar a la lista de diferencia
                }
            }

            // Convertir la lista a un arreglo y devolverlo
            return difference.ToArray();
        }

        private void setCantidadTag()
        {
            if (dgv_etiquetas.DataSource == null) return;

            if (dgv_etiquetas.Rows.Count <= 1) return;

            if (dgv_etiquetas.SelectedCells.Count == 0) return;

        }

        private int RegistertData()
        {
            long ll_return = 0;
            long ll_id_contenedor_relacionado = 0;
            long ll_id = 0;
            int li_RowsCount = 0;
            int li_Estado = 0;
            string ls_compania = "02";
            string ls_tipo = "1";
            string ls_codigo_compuesto = "";
            DataTable ldp_DataTable = null;
            MySqlTransaction trans = null;

            ICollection tags = m_TagTable.Keys;
            int cantidadEtiquetas = m_TagTable.Count;

            if (dgv_etiquetas.DataSource == null || dgv_etiquetas.Rows.Count == 0) return 0;

            if (dgv_etiquetas.SelectedCells.Count == 0) return 0;

            if (dgv_etiquetas.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna fila seleccionada.");
                return 0;
            }

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            DataGridViewRow selectedRow = dgv_etiquetas.SelectedRows[0];    // Obtener la fila seleccionada

            ls_codigo_compuesto = selectedRow.Cells["nro_op"].Value.ToString() + selectedRow.Cells["nro_hoja_marc"].Value.ToString() + selectedRow.Cells["nro_caja"].Value.ToString();
            long.TryParse(ls_codigo_compuesto, out ll_id_contenedor_relacionado);
            dictionary.Add("id_contenedor_relacionado", ll_id_contenedor_relacionado);

            bool lb_existeId = dgv_etiquetas.Columns.Contains("id");
            if (lb_existeId) ll_id = Convert.ToInt32(selectedRow.Cells["id"].Value);

            if (ll_id == 0)    //verifica si no se ha registrado en la Tabla Contenedor como Caja       
            {
                dictionary.Add("codigo_compania", ls_compania);
                dictionary.Add("tipo", ls_tipo);
                dictionary.Add("secuencial_contenedor", selectedRow.Cells["nro_caja"].Value.ToString());
                dictionary.Add("op", selectedRow.Cells["nro_op"].Value.ToString());
                dictionary.Add("hoja_marcacion", selectedRow.Cells["nro_hoja_marc"].Value.ToString());
                dictionary.Add("nro_po", selectedRow.Cells["po_cliente"].Value.ToString());
                dictionary.Add("nro_cea", selectedRow.Cells["nro_cea"].Value.ToString());
                dictionary.Add("nro_packinglist", selectedRow.Cells["packinglist"].Value.ToString());
                dictionary.Add("cantidad_prendas", Convert.ToInt32(selectedRow.Cells["cant_prendas"].Value));
                //dictionary.Add("usuario_creacion", m_MainForm.CodigoUsuario);
                dictionary.Add("usuario_creacion", m_cod_Trabajador);

                try
                {
                    if (m_ContenedorBD == null) m_ContenedorBD = new BDContenedor();
                    ldp_DataTable = m_ContenedorBD.GetData(dictionary); //recupera registros de tabla Contenedor según codigo y tipo

                    li_RowsCount = ldp_DataTable.Rows.Count;
                    if (li_RowsCount > 0)   //si existen registros obtiene el ID de tabla contenedor
                        ll_id = Convert.ToInt32(ldp_DataTable.Rows[li_RowsCount]["id_contenedor"]);
                }
                catch (Exception ex)
                {
                    m_MainForm.functionCallStatusLabel.Text = ex.Message;
                    return -1;
                }
            }

            dictionary.Add("cantidad_prendas_leidas", cantidadEtiquetas);

            try
            {
                using (connectionMySql = m_ContenedorBD.Connect())
                {
                    using (trans = connectionMySql.BeginTransaction())  //iniciamos la transacion
                    {
                        if (ll_id > 0)   //si existen registros en tabla Contenedor hace un update
                        {
                            ll_return = m_ContenedorBD.Update(ll_id, ll_id_contenedor_relacionado, cantidadEtiquetas, li_Estado, connectionMySql, trans);
                        }
                        else    // sino existe hará un insert en la tabla
                        {
                            ll_return = m_ContenedorBD.Insert(dictionary, connectionMySql, trans);
                            if (ll_return >= 0) ll_id = Convert.ToInt32(ll_return);
                        }

                        if (ll_id <= 0)
                        {
                            trans.Rollback();
                            if (ll_return == -1)
                            {
                                string lsError = m_ContenedorBD.GetError();
                                MessageBox.Show(lsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return 0;
                        }

                        trans.Commit();                    //confirmo la trasaccion
                        m_MainForm.functionCallStatusLabel.Text = "Se guardó con éxito.";
                        //DataGridViewRow filaActual = dgv_etiquetas.CurrentRow;

                        //filaActual.Cells["Mensaje"].Value = "Este es un mensaje informativo.";
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
                return -1;
            }
            finally
            {
                connectionMySql.Dispose(); trans.Dispose(); //command.Dispose();                
            }
        }

        private Dictionary<string, object> GetInformacionPrenda(string pCodigoRFID)
        {
            Dictionary<string, object> dicPrenda = new Dictionary<string, object>();
            DataTable ldtPrenda = new DataTable();
            int li_RowsCount = 0;
            dicPrenda.Clear();

            dicPrenda.Add("id_rfid", pCodigoRFID);
            ldtPrenda = m_bdPrendaScm.GetMatriculaDetalle(dicPrenda);
            li_RowsCount = ldtPrenda.Rows.Count;
            if (li_RowsCount > 0)
            {
                dicPrenda.Add("op", ldtPrenda.Rows[0]["op"].ToString());
                dicPrenda.Add("hoja_marcacion", ldtPrenda.Rows[0]["hoja_marcacion"].ToString());
                dicPrenda.Add("corte", ldtPrenda.Rows[0]["corte"].ToString());
                dicPrenda.Add("subcorte", ldtPrenda.Rows[0]["subcorte"].ToString());
                dicPrenda.Add("talla", ldtPrenda.Rows[0]["talla"].ToString());
                dicPrenda.Add("color", ldtPrenda.Rows[0]["color"] == DBNull.Value ? "Sin Color" : ldtPrenda.Rows[0]["color"].ToString());

                Console.WriteLine($"RFID: {pCodigoRFID} - Color: {dicPrenda["color"]}");

                //almacena la infomracion de la prenda en un DataTable acumulador
                if (m_DataTableDatosPrendas.Rows.Count == 0)
                {
                    m_DataTableDatosPrendas = ldtPrenda.Clone();
                }
                m_DataTableDatosPrendas.ImportRow(ldtPrenda.Rows[0]);
            }
            return dicPrenda;
        }

        /*private void dataButton_Click(object sender, EventArgs e)
        {
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
                }

                readButton.Text = "Iniciar";
                readButton.Tag = "Start Reading";
                m_IsReading = false;

                //paa recuperar las cajas según las etiquetas RFID registradas anterioemente.
                retrieveData();
            }
            catch (Exception ex)
            {
                m_MainForm.functionCallStatusLabel.Text = ex.Message;
                label1.Text = ex.Message;
            }
        }*/

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
                    for (int index = 0; index < 8; index++)
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
            this.inventoryList.Items.Clear();
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
            this.inventoryList.Items.Clear();
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

        private void FormCaja_Activated(object sender, EventArgs e)
        {
            updateReaderApi();
            updateGPIState();
        }

        private void tB_Op_Leave(object sender, EventArgs e)
        {
            string ls_nro_op = "";
            string ls_ceros;
            //ls_nro_op = uctb_Op.Text;
            ls_nro_op = ls_nro_op.Trim();
            int li_longitud;
            int li_longitud_max = 10;
            li_longitud = ls_nro_op.Length;
            if (li_longitud < li_longitud_max && li_longitud > 0)
            {
                ls_ceros = new string('0', li_longitud_max - li_longitud - 1);

                ls_nro_op = "1" + ls_ceros + ls_nro_op;
                //uctb_Op.Text = ls_nro_op;
            }

        }

        private void tB_nroCaja_Leave(object sender, EventArgs e)
        {
            string ls_nrocaja = "";
            string ls_ceros;
            //ls_nrocaja = uctb_nroCaja.Text;
            ls_nrocaja = ls_nrocaja.Trim();
            int li_longitud;
            int li_longitud_max = 6;
            li_longitud = ls_nrocaja.Length;
            if (li_longitud < li_longitud_max && li_longitud > 0)
            {
                ls_ceros = new string('0', li_longitud_max - li_longitud);

                ls_nrocaja = ls_ceros + ls_nrocaja;
                //uctb_nroCaja.Text = ls_nrocaja;
            }
        }

        private void tB_Op_Enter(object sender, EventArgs e)
        {
            //uctb_Op.SelectAll();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                /*if (sender == uctb_idCaja)
                {
                    RegistertData();
                    //dgv_etiquetas.Focus();
                }*/
            }
        }

        private void FormValidarSalida_Resize(object sender, EventArgs e)
        {
            int li_long;
            int li_height;
            int li_width;
            float fontSize;
            int li_minnimo = 10;
            int li_intermedio = 20;
            int li_max = 45;
            int li_mega_max = 60;
            int li_factor = 1;
            string ls_tag = "";

            // Validar que el formulario tenga un tamaño válido
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0)
            {
                return; // Salir si el formulario no tiene dimensiones
            }

            foreach (Control control in this.Controls)
            {
                Console.Write($" 1-->{control.Name}");
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    Console.Write($" 2-->{tableLayoutPanel.Name}");
                    foreach (Control control1 in control.Controls)
                    {
                        foreach (Control control2 in control1.Controls)
                        {
                            Console.Write($" 3-->{control2.Name}");
                            li_factor = li_minnimo;
                            if (control2.Name == "tbFooter")
                            {
                                foreach (Control control3 in control2.Controls) {
                                    Console.Write($" 4-->{control3.Name}");
                                    if (control3.Name == "readButton")
                                    {
                                        li_factor = li_intermedio;
                                        li_height = this.ClientSize.Height / li_factor;
                                        li_width = this.ClientSize.Width / li_factor;

                                        fontSize = Math.Max(li_height, li_width);
                                        control3.Font = new Font(control.Font.FontFamily, fontSize);
                                    }
                                    if (control3.Name == "tbFooterInfo")
                                    {
                                        foreach (Control control4 in control3.Controls)
                                        {
                                            Console.Write($" 5-->{control4.Name} \n");
                                            if (control4.Name == "tbContador")
                                            {
                                                foreach (Control control5 in control4.Controls)
                                                {
                                                    Console.Write($" 6-->{control5.Name} \n");
                                                    if (control5.Name == "totalTagValueLabel" || control5.Name == "textoPrenda")
                                                    {
                                                        li_factor = li_intermedio;

                                                        li_height = this.ClientSize.Height / li_factor;
                                                        li_width = this.ClientSize.Width / li_factor;
                                                        ls_tag = (string)control5.Tag;
                                                        if (ls_tag != null)
                                                        {
                                                            if (int.TryParse(ls_tag, out li_long))
                                                            {
                                                                li_height /= li_long;
                                                                li_width /= li_long;
                                                            }
                                                        }
                                                        fontSize = Math.Max(li_height, li_width);
                                                        control5.Font = new Font(control.Font.FontFamily, fontSize);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }                                
                            }
                            else if(control2.Name == "detalleRta")
                            {
                                foreach (Control control3 in control2.Controls)
                                {
                                        Console.WriteLine($"Nombre -->{control3.Name}");
                                    if (control3.Name == "rfidFaltaMatricula" || control3.Name == "rfidFaltaLectura" || control3.Name == "rfidMatriculada" || control3.Name == "rfidNoCoincideMatricula")
                                    {
                                        li_factor = li_mega_max;
                                        li_height = this.ClientSize.Height / li_factor;
                                        li_width = this.ClientSize.Width / li_factor;

                                        fontSize = Math.Min(li_height, li_width);
                                        control3.Font = new Font(control.Font.FontFamily, fontSize);
                                    }
                                }
                            }
                            else if (control2.Name == "tablaMsnError")
                            {
                                AjustarIconoError();

                                foreach (Control control3 in control2.Controls)
                                {
                                    if (control3.Name == "MensajeError")
                                    {
                                        li_factor = li_max;
                                        li_height = this.ClientSize.Height / li_factor;
                                        li_width = this.ClientSize.Width / li_factor;

                                        fontSize = Math.Min(li_height, li_width);
                                        control3.Font = new Font(control.Font.FontFamily, fontSize);
                                        Console.WriteLine($"Nombre -->{control3.Name}");
                                        break;
                                    }
                                }
                            }
                            else if (control2.Name == "MensajeError")
                            {
                                li_factor = li_max;

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

        public void AjustarIconoError()
        {
            if (this.iconoMensaje == null || this.tablaMsnError == null) return;

            // Ajustar el PictureBox para ocupar la celda sin forzar el tamaño
            iconoMensaje.Dock = DockStyle.Fill;

            // Establecer SizeMode en Zoom para mantener la relación de aspecto
            iconoMensaje.SizeMode = PictureBoxSizeMode.Zoom;

            // Eliminar la redimensión manual para evitar distorsión
            // Solo si la imagen es nula se asigna la imagen original
            if (iconoMensaje.Image == null)
            {
                iconoMensaje.Image = RFIDPrendas.Properties.Resources.icon_error;
            }

            Console.WriteLine($"Icono ajustado a Width->{iconoMensaje.Width} Height->{iconoMensaje.Height}");
        }

        private void FormValidarSalida_SizeChanged(object sender, EventArgs e)
        {
            //Form childForm = sender as Form;

            //// Lógica para evitar que el cambio de tamaño afecte el menú del formulario MDI
            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    // Ajustar el tamaño del formulario hijo si es necesario
            //    // Por ejemplo, podrías establecer un tamaño mínimo
            //    if (this.Width < 400)
            //    {
            //        this.Width = 400;
            //    }
            //    if (this.Height < 300)
            //    {
            //        this.Height = 300;
            //    }
            //}
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_ReaderAPI != null && m_MainForm.m_IsConnected && m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
            {
                //this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                //    "Power On Radio" : "Power Off Radio";
            }
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

                m0Cronometro.Text = v_hor + ":" + v_min + ":" + v_seg;
                v_Segundos = Int32.Parse(v_seg);
            }
            else
            {
                tmP.Reset();
                timerCronome_tro.Stop();
                timerCronome_tro.Enabled = false;
                tiempo_cronometro.Clear();
                //this.RegistrarCantidad();
                //ReportaIncidente.Visible = true;
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
                        SeConEnSegundos.Text = "¡Se contó en tan solo " + v_Segundos + " seg!";
                        SeConEnSegundos.Visible = true;

                        retrieveData();
                    }
                    else
                    {
                        m_MainForm.functionCallStatusLabel.Text = "Conéctese primero al lector RFID";
                        //label1.Text = "Conéctese primero al lector RFID";
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
                    //label1.Text = ex.Message;
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

        private void ReportaIncidente_Click(object sender, EventArgs e)
        {
            FormIncidente fromIncidente = new FormIncidente(m_cod_Trabajador, 3);//Tipo 3(Verificacion)
            fromIncidente.StartPosition = FormStartPosition.CenterParent; // Centrar con respecto al padre
            fromIncidente.ShowDialog(this);
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_MainForm.m_IsConnected)
                {
                    if (Convert.ToString(readButton.Tag) == "Start Reading")
                    {
                        //Inicia el cronometro
                        tmP.Start();
                        timerCronome_tro.Enabled = true;
                        tiempo_cronometro.Clear();
                        totalTagValueLabel.Text = "0";
                        SeConEnSegundos.Text = "";
                        SeConEnSegundos.Visible = false;

                        m_DataTableDatosPrendas.Clear();
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
                            inventoryList.Items.Clear();
                            m_TagTable.Clear();
                            m_TagTotalCount = 0;

                            // Before inventory purge all tags
                            m_ReaderAPI.Actions.PurgeTags();
                            m_ReaderAPI.Actions.Inventory.Perform(
                                null,
                                null,
                                m_MainForm.m_AntennaInfoForm.getInfo());
                            //m_ReaderAPI.Actions.Inventory.Perform(
                            //    m_MainForm.m_PostFilterForm.getFilter(),
                            //    m_MainForm.m_TriggerForm.getTriggerInfo(),
                            //    m_MainForm.m_AntennaInfoForm.getInfo());
                        }

                        readButton.Text = "Detener...";
                        readButton.Tag = "Stop Reading";
                        m_IsReading = true;
                    }
                    else if (Convert.ToString(readButton.Tag) == "Stop Reading")
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

                        readButton.Text = "Iniciar";
                        readButton.Tag = "Start Reading";
                        m_IsReading = false;

                        //Detiene el cronometro
                        timerCronome_tro.Stop();
                        timerCronome_tro.Enabled = false;
                    }
                }
                else
                {
                    m_MainForm.functionCallStatusLabel.Text = "Please connect to a reader first";
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

        public void CambiarIcono(string tipoIcono)
        {
            if (iconoMensaje == null) return;

            // Determinar el icono a usar, si no coincide, usa el de advertencia
            string svgFileName = iconPaths.ContainsKey(tipoIcono.ToLower()) ? iconPaths[tipoIcono.ToLower()] : iconPaths["default"];
            string svgPath = Path.Combine(iniDirectory, svgFileName);

            // Mostrar la alerta con el nuevo icono
            new FormAlerta(iconoMensaje, svgPath);
        }

        private void FormValidarSalida_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F:
                    if (e.Control)
                        readButton.PerformClick();
                    break;
            }
        }

        private void TotalTagValueLabel_Click(object sender, EventArgs e)
        {

        }

        private void AlertaError(string msn)
        {
            AlertaError aler_ta = new AlertaError("Upss...", msn, Color.FromArgb(238, 26, 36));
            aler_ta.ShowDialog();
        }
    }
}
