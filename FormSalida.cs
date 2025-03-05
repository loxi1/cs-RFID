using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDPrendas
{
    public partial class FormSalida : Form
    {
        private FormMain m_MainForm = null;
        internal string m_Empresa = "COFACO";
        internal string m_Usuario = "";
        internal int m_contador = 0;
        internal string m_CodBarra = "";
        internal string m_CodRfid = "";
        internal string m_Cod_Trabajador = "030658";
        private string cadenaTags = null;

        internal string m_SelectedTagID = "";
        internal DateTime gdt_Fecha;

        internal DBLecturaDeCaja m_LecturaDeCaja;
        private MySqlConnection connectionMySql;

        internal Mensaje m_Mensaje;
        string[] rfidLectura_ = { };
        public FormSalida(FormMain mainForm, string codTrabajdor)
        {
            InitializeComponent();
            m_Cod_Trabajador = codTrabajdor;
            m_MainForm = mainForm;
        }

        private void FormSalida_Load(object sender, EventArgs e)
        {
            SeConEnSegundos.Text = "";
            
            gdt_Fecha = DateTime.Now;
            CrearLectura();
        }

        private void FormSalida_Resize(object sender, EventArgs e)
        {
            int li_long;
            int li_height;
            int li_width;
            float fontSize;
            int li_minnimo = 10;
            int li_intermedio = 20;
            int li_max = 45;
            int li_factor = 1;
            string ls_tag = "";

            // Validar que el formulario tenga un tamaño válido
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0)
            {
                return; // Salir si el formulario no tiene dimensiones
            }

            foreach (Control control in this.Controls)
            {
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    foreach (Control control1 in control.Controls)
                    {
                        foreach (Control control2 in control1.Controls)
                        {
                            li_factor = li_minnimo;
                            if (control2.Name == "readButton")
                            {
                                li_factor = li_intermedio;
                                li_height = this.ClientSize.Height / li_factor;
                                li_width = this.ClientSize.Width / li_factor;

                                fontSize = Math.Max(li_height, li_width);
                                control2.Font = new Font(control.Font.FontFamily, fontSize);
                            }
                            else if (control2.Name == "totalTagValueLabel" || control2.Name == "textoPrenda")
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
                            else if (control2.Name == "detalleRta")
                            {
                                foreach (Control control3 in control2.Controls)
                                {
                                    if (control3.Name == "rfidFaltaMatricula" || control3.Name == "rfidFaltaLectura" || control3.Name == "rfidMatriculada")
                                    {
                                        li_factor = li_max;
                                        li_height = this.ClientSize.Height / li_factor;
                                        li_width = this.ClientSize.Width / li_factor;

                                        fontSize = Math.Min(li_height, li_width);
                                        control3.Font = new Font(control.Font.FontFamily, fontSize);
                                        Console.WriteLine($"Nombre -->{control3.Name}");
                                    }
                                }
                            }
                            else if(control2.Name == "tablaMsnError")
                            {
                                Console.WriteLine($"Tabla--->{control2.Name} tiene altura-->{control2.Height}");
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
                            else if(control2.Name == "MensajeError")
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

                        if (control1.Name == "tablaDetalle" || control1.Name == "tablaContenedor")
                        {
                            foreach (Control control2 in control1.Controls)
                            {
                                if (control2.Name == "inventoryList")
                                {
                                    if (control2 is ListView listView)
                                    {
                                        foreach (ColumnHeader column in listView.Columns)
                                        {
                                            column.Width = (listView.ClientSize.Width - SystemInformation.VerticalScrollBarWidth) / listView.Columns.Count;
                                        }
                                    }
                                }
                                else if (control2.Name == "dgv_etiquetas")
                                {
                                    fontSize = Math.Max(10, this.ClientSize.Width / 120);
                                    control.Font = new Font(control.Font.FontFamily, fontSize);
                                }
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

        private void ReadButton_Click(object sender, EventArgs e)
        {
            retrieveData();
        }

        private void retrieveData()
        {
            MySqlTransaction trans = null;
            bool codigoerror = false;
            //string tipo = "error";
            //string msn = "Verificar caja";
            var ls_datosList = new List<string>();

            string[] rfidLectura = rfidLectura_;
            string[] faltaLectura = { };
            string[] faltaMatricula = { };
            string[] elementosMatricula = { };
            bool codeRta = false;
            string msnRta = "Error";

            Dictionary<string, object> detalleMatricula = new Dictionary<string, object>();

            if (m_LecturaDeCaja == null) m_LecturaDeCaja = new DBLecturaDeCaja();

            foreach (var rfid in rfidLectura)
            {
                try
                {
                    using (connectionMySql = m_LecturaDeCaja.Connect())
                    {
                        using (trans = connectionMySql.BeginTransaction())
                        {
                            var lv_result = m_LecturaDeCaja.BuscarCajaMatriculada(rfid.ToString(), connectionMySql, trans);
                            if (lv_result.Matricula.Rows.Count != 0 || lv_result.Elementos.Length != 0 || lv_result.Detalle.Count != 0)
                            {
                                codigoerror = true;
                                dgv_etiquetas.DataSource = lv_result.Matricula;
                                faltaLectura = Diferencia(rfidLectura, lv_result.Elementos);
                                faltaMatricula = Diferencia(lv_result.Elementos, rfidLectura);
                                detalleMatricula = lv_result.Detalle;
                                codeRta = (rfidLectura.Length == lv_result.Elementos.Length) ? true : codeRta;
                                msnRta = codeRta ? "Ok" : msnRta;
                                Console.WriteLine($"Difrencias Lectura-->{faltaLectura.Length} Matricula-->{faltaMatricula.Length}");
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    m_MainForm.functionCallStatusLabel.Text = ex.Message;
                }
            }

            if(!codigoerror)
            {
                MensajeError.Text = "Caja no matriculada";
                CambiarIcono("error");
                return;
            }

            //Sobran elementos matriculados
            if (faltaLectura.Length != 0)
            {
                dgv_faltaLectura.DataSource = EliminarElementosPorColumna(faltaLectura, 0);
                ls_datosList.Add("Exiten más Prendas");
            }
            //Faltan elementos matriculados
            if (faltaMatricula.Length != 0)
            {
                ls_datosList.Add("Faltan prendas");
                var data = FiltrarDetallesPorIdRfid(faltaMatricula, detalleMatricula);
                var rta = DeDicicionarioADataTable(data);
                dgv_MatriculaFaltante.DataSource = rta;
                foreach (DataGridViewColumn column in dgv_etiquetas.Columns)
                {
                    if (column.HeaderText == "id_rfid")
                        column.HeaderText = "RFID";
                    else if (column.HeaderText == "corte")
                        column.HeaderText = "Corte";
                    else if (column.HeaderText == "subcorte")
                        column.HeaderText = "Sub corte";
                    else if (column.HeaderText == "talla")
                        column.HeaderText = "Talla";
                    else if (column.HeaderText == "color")
                        column.HeaderText = "Color";
                    column.DefaultCellStyle.Font = new Font("Arial", 20);
                }
            }
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

        private void CrearLectura()
        {
            List<string> difference = new List<string>();
            var data = new[]
            {
                new { id_rfid = "S40069990000700A8R407201", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003301", talla = 12, color = "WHITE" },
                new { id_rfid = "Q40069990000700A8R407201", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003302", talla = 4, color = "WHITE" },
                new { id_rfid = "csAF4lT6PaK8FTehjjPyb8VI", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003302", talla = 4, color = "WHITE" },
                new { id_rfid = "F3wxuWAjoXLauvsU7ZK8L2ia", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003302", talla = 4, color = "WHITE" },
                new { id_rfid = "Ty8EYfmyacggWlJANzZjG74T", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003302", talla = 4, color = "WHITE" },
                new { id_rfid = "TLsYQ0faNGojHLRejHx1Jq96", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003302", talla = 4, color = "WHITE" },
                new { id_rfid = "HdQccvcl3Yj6Jy61DTRph9Zm", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003302", talla = 4, color = "WHITE" },
                new { id_rfid = "DfuPR54YMZxZjlf6rthNcnh9", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003301", talla = 12, color = "WHITE" },
                new { id_rfid = "1aoLWVR6vXVNoji98NfzIL6P", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003301", talla = 12, color = "WHITE" },
                new { id_rfid = "8Js7CRrKa8gp50t6h3dVhY6k", op = "1000038004", hoja_marcacion = "xxx125454xxx", corte = "0033", subcorte = "003301", talla = 12, color = "WHITE" },
                new { id_rfid = "EXC7CRrKa8gp50t6h3dVhY6k", op = "", hoja_marcacion = "", corte = "", subcorte = "", talla = 0, color = "" },
                new { id_rfid = "XXQ7CRrKa8gp50t6h3dVhY6k", op = "", hoja_marcacion = "", corte = "", subcorte = "", talla = 0, color = "" }
            };

            // Cargar cada registro del arreglo de datos en el ListView
            foreach (var item in data)
            {
                ListViewItem listItem = new ListViewItem(item.id_rfid);  // Primer columna
                listItem.SubItems.Add(item.op);  // Segunda columna
                listItem.SubItems.Add(item.hoja_marcacion);  // Tercera columna
                listItem.SubItems.Add(item.corte);  // Cuarta columna
                listItem.SubItems.Add(item.subcorte);  // Quinta columna
                listItem.SubItems.Add(item.talla.ToString());  // Sexta columna (Convertir a string)
                listItem.SubItems.Add(item.color);  // Septima columna

                // Añadir el item al ListView
                inventoryList.Items.Add(listItem);
                difference.Add(item.id_rfid);
            }

            // Ajustar el tamaño de las columnas al contenido
            inventoryList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // Ajustar las columnas al tamaño porcentual deseado
            SetColumnWidthsByPercentage();

            rfidLectura_ = difference.ToArray();
        }

        private void SetColumnWidthsByPercentage()
        {
            int totalWidth = inventoryList.ClientSize.Width;
            Console.WriteLine($"totalWidth-->{totalWidth}");
            // Asignar tamaños en función del porcentaje del ancho total
            inventoryList.Columns[0].Width = (int)(totalWidth * 0.16);  // 40% para RFID
            inventoryList.Columns[1].Width = (int)(totalWidth * 0.14);  // 20% para OP
            inventoryList.Columns[2].Width = (int)(totalWidth * 0.14);  // 20% para HM
            inventoryList.Columns[3].Width = (int)(totalWidth * 0.14);  // 10% para Corte
            inventoryList.Columns[4].Width = (int)(totalWidth * 0.14);  // 10% para SubCorte
            inventoryList.Columns[5].Width = (int)(totalWidth * 0.14);  // 10% para Talla
            inventoryList.Columns[6].Width = (int)(totalWidth * 0.14);  // 10% para Color
        }

        public void CambiarIcono(string tipoIcono)
        {
            if (iconoMensaje == null) return;

            switch (tipoIcono.ToLower())
            {
                case "ok":
                    iconoMensaje.Image = RFIDPrendas.Properties.Resources.icon_ok;
                    break;
                case "error":
                    iconoMensaje.Image = RFIDPrendas.Properties.Resources.icon_error;
                    break;
                case "adm":
                    iconoMensaje.Image = RFIDPrendas.Properties.Resources.icon_admiracion;
                    break;
                default:
                    iconoMensaje.Image = RFIDPrendas.Properties.Resources.notify; // Ícono por defecto
                    break;
            }

            // Ajuste para que la imagen mantenga la proporción
            iconoMensaje.SizeMode = PictureBoxSizeMode.Zoom;

            Console.WriteLine($"Icono cambiado a: {tipoIcono}");
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            CambiarIcono("ok");
        }
    }
}
