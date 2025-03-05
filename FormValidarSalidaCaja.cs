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
    public partial class FormValidarSalidaCaja : Form
    {
        private FormMain m_MainForm = null;
        internal RFIDReader m_ReaderAPI;
        internal bool m_IsReading = false;
        public RFIDResults m_Result;
        //internal ReaderManagement m_ReaderMgmt;
        //internal READER_TYPE m_ReaderType;        
        internal BDPrendaScm m_bdPrendaScm;
        internal BDContenedor m_ContenedorBD;
        internal BDHojaMarcacion m_bdHojaMarc;
        internal string m_cod_Trabajador;
        internal DBLecturaDeCaja m_LecturaDeCaja;
        internal DBAuditarCaja m_DBAuditarCaja = new DBAuditarCaja();
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

        public FormValidarSalidaCaja(FormMain mainForm, RFIDReader pReaderAPI, string codTrabajador)
        {
            InitializeComponent();
            m_MainForm = mainForm;
            m_ReaderAPI = pReaderAPI;
            m_cod_Trabajador = codTrabajador;
            this.MdiParent = m_MainForm;
            //FormBorderStyle = FormBorderStyle.FixedDialog;            
            //StartPosition = FormStartPosition.WindowsDefaultLocation;
            m_GPIStateList = new ArrayList();
            m_UpdateStatusHandler = new UpdateStatus(myUpdateStatus);
            m_UpdateReadHandler = new UpdateRead(myUpdateRead);
            m_ReadTag = new Symbol.RFID3.TagData();

            m_TagTable = new Hashtable();
            m_TagTotalCount = 0;
            m_bdPrendaScm = new BDPrendaScm();
            m_bdHojaMarc = new BDHojaMarcacion();
            configureMenuItemsUponConnectDisconnect();

            if (GetIni() == 1)
            {
            }
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
                        }

                        if (isFound)
                        {
                            
                        }
                        else
                        {
                            ListViewItem item = new ListViewItem(tag.TagID);

                            inventoryList.BeginUpdate();
                            inventoryList.Items.Add(item);
                            inventoryList.EndUpdate();

                            lock (m_TagTable.SyncRoot)
                            {
                                m_TagTable.Add(tagID, item);
                            }

                            //int cantidadEtiquetas = m_TagTable.Count;
                        }
                    }
                }

                totalTagValueLabel.Text = m_TagTable.Count.ToString();

            }
        }

        private void myUpdateStatus(Events.StatusEventData eventData)
        {
            switch (eventData.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    m_MainForm.functionCallStatusLabel.Text = "Procesando...";
                    this.readButton.Enabled = false;
                    this.readButton.Text = "Detener";
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

        private void AccessBackgroundWorker_DoWork(object sender, DoWorkEventArgs accessEvent)
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

        private void AccessBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void AccessBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs accessEvents)
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

                                        if (!isFound)
                                        {
                                            ListViewItem newItem = new ListViewItem(m_ReadTag.TagID);

                                            string memoryBank = m_ReadTag.MemoryBank.ToString();
                                            int index = memoryBank.LastIndexOf('_');
                                            if (index != -1)
                                            {
                                                memoryBank = memoryBank.Substring(index + 1);
                                            }

                                            inventoryList.BeginUpdate();
                                            inventoryList.Items.Add(newItem);
                                            inventoryList.EndUpdate();

                                            lock (m_TagTable.SyncRoot)
                                            {
                                                m_TagTable.Add(tagID, newItem);
                                            }
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

        private void TimerCronome_tro_Tick(object sender, EventArgs e)
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

                        //retrieveData();
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

                Console.WriteLine($"idRfid:{idRfid} corte:{corte} subcorte:{subcorte} idRfid:{talla} idRfid:{color} idRfid:{color}");
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

        public void CambiarIcono(string tipoIcono)
        {
            if (pictureBox1 == null) return;

            // Determinar el icono a usar, si no coincide, usa el de advertencia
            string svgFileName = iconPaths.ContainsKey(tipoIcono.ToLower()) ? iconPaths[tipoIcono.ToLower()] : iconPaths["default"];
            string svgPath = Path.Combine(iniDirectory, svgFileName);

            // Mostrar la alerta con el nuevo icono
            new FormAlerta(pictureBox1, svgPath);
        }

        private void AlertaError(string msn)
        {
            AlertaError aler_ta = new AlertaError("Upss...", msn, Color.FromArgb(238, 26, 36));
            aler_ta.ShowDialog();
        }

        private void FormValidarSalidaCaja_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F:
                    if (e.Control)
                        readButton.PerformClick();
                    break;
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
    }
}
