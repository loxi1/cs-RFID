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
    public partial class FormReprocesarLote : Form
    {
        private FormMain m_MainForm = null;
        internal RFIDReader m_ReaderAPI;
        internal string m_Cod_Trabajador = "030658";

        internal BDHojaMarcacion m_bdHojaMarc = new BDHojaMarcacion();
        internal DBReprocesar m_DBReprocesar = new DBReprocesar();
        private string v_fecha = "";
        private string v_nro_op = "";
        private string v_nro_hm = "";
        public FormReprocesarLote(FormMain mainForm, RFIDReader pReaderAPI, string codTrabajador)
        {
            InitializeComponent();
            m_MainForm = mainForm;
            this.MdiParent = m_MainForm;
            m_Cod_Trabajador = codTrabajador;
        }

        private void FormReprocesarLote_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloDataGridView();
            this.BeginInvoke(new Action(() =>
            {
                // Obtener el ancho de la celda donde está ubicado tbContCronoEstados
                int anchoCelda = this.tbContMatHM.GetColumnWidths()[0];


                // Obtener las dimensiones de la celda donde está tbContentMatricula
                int anchoCeldaMatricula = this.tbFormHM.GetColumnWidths()[0];
                int altoCeldaMatricula = this.tbFormHM.GetRowHeights()[0];

                // Definir el ancho y alto de tbContentMatricula
                this.tbContentMatricula.Width = (int)(anchoCeldaMatricula * 0.70); // 70% del ancho
                this.tbContentMatricula.Height = (int)(altoCeldaMatricula * 0.30); // 40% del alto

                // Centramos el componente dentro de su celda
                this.tbContentMatricula.Left = (this.tbFormHM.Width - this.tbContentMatricula.Width) / 2;
                this.tbContentMatricula.Top = (this.tbFormHM.Height - this.tbContentMatricula.Height) / 2;

                // Quitar Dock y Anchor para que la posición manual funcione
                this.tbContentMatricula.Dock = DockStyle.None;
                this.tbContentMatricula.Anchor = AnchorStyles.None;
            }));            
        }

        private void FormReprocesarLote_Resize(object sender, EventArgs e)
        {
            int li_height;
            int li_width;
            float fontSize;
            int li_minnimo = 10;
            int li_max = 45;
            int li_mega_max = 60;
            int li_factor = 1;

            // Validar que el formulario tenga un tamaño válido
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0)
            {
                return; // Salir si el formulario no tiene dimensiones
            }

            this.tbContentMatricula.Left = (this.tbFormHM.Width - this.tbContentMatricula.Width) / 2;
            this.tbContentMatricula.Top = (this.tbFormHM.Height - this.tbContentMatricula.Height) / 2;

            foreach (Control control in this.Controls)
            {
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    foreach (Control control1 in control.Controls)
                    {
                        li_factor = li_minnimo;
                        if (control1 is TableLayoutPanel tableLayoutPanel2)
                        {
                            if (control1.Name == "tbFormHM")
                            {
                                foreach (Control control2 in control1.Controls)
                                {
                                    if (control2.Name == "tbContentMatricula")
                                    {
                                        foreach (Control control3 in control2.Controls)
                                        {
                                            li_factor = li_mega_max;
                                            if (control3 is Button button)
                                            {
                                                li_factor = li_max;
                                            }

                                            li_height = this.ClientSize.Height / li_factor;
                                            li_width = this.ClientSize.Width / li_factor;

                                            fontSize = Math.Max(li_height, li_width);
                                            control3.Font = new Font(control3.Font.FontFamily, fontSize);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ConfigurarEstiloDataGridView()
        {
            dGVReprocesarCaja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGVReprocesarCaja.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dGVReprocesarCaja.BackgroundColor = System.Drawing.Color.White;
            dGVReprocesarCaja.BorderStyle = BorderStyle.Fixed3D;
            dGVReprocesarCaja.EnableHeadersVisualStyles = false;
            dGVReprocesarCaja.RowTemplate.Height = 30;
            dGVReprocesarCaja.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGVReprocesarCaja.ReadOnly = true;
            dGVReprocesarCaja.AllowUserToAddRows = false;
            dGVReprocesarCaja.AllowUserToDeleteRows = false;
        }

        private void TextOp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string ls_ceros;
                string ls_nro_op = textOp.Text;
                ls_nro_op = ls_nro_op.Trim();
                int li_longitud;
                int li_longitud_max = 10;

                li_longitud = ls_nro_op.Length;
                if (li_longitud < li_longitud_max && li_longitud > 0)
                {
                    ls_ceros = new string('0', li_longitud_max - li_longitud - 1);
                    ls_nro_op = "1" + ls_ceros + ls_nro_op;
                    textOp.Text = ls_nro_op;
                }

                int li_Res = m_bdHojaMarc.OPValidar(ls_nro_op);
                if (li_Res == 0)
                {
                    AlertaError($"{ls_nro_op}, no existe. Verificar!");
                    textOp.Focus();
                    return;
                }
                textOp.Enabled = false;
                textHM.Enabled = true;
                textHM.Focus();
            }
        }

        private void TextHM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string ls_nroHojMarc = textHM.Text;
                string ls_ceros;

                string ls_nro_op = textOp.Text;
                ls_nroHojMarc = ls_nroHojMarc.Trim();
                int li_longitud;
                int li_longitud_max = 3;
                li_longitud = ls_nroHojMarc.Length;


                if (li_longitud < li_longitud_max && li_longitud > 0)
                {
                    ls_ceros = new string('0', li_longitud_max - li_longitud);
                    ls_nroHojMarc = ls_ceros + ls_nroHojMarc;
                }

                if (ls_nro_op == "")
                {
                    AlertaError("Ingrese número de OP!");
                    textOp.Focus();
                    return;
                }

                int li_Res = m_bdHojaMarc.HojaMarcValidar(ls_nro_op, ls_nroHojMarc);
                textHM.Text = ls_nroHojMarc;
                if (li_Res == 0)
                {
                    AlertaError($"{ls_nro_op}  {ls_nroHojMarc}, no existe. Verificar!");
                    textHM.Focus();
                    return;
                }
                textHM.Enabled = false;
                btnSaveMatricula.Enabled = true;
                btnSaveMatricula.Focus();
            }
        }

        private void FormularioInicial()
        {
            btnSaveMatricula.Enabled = false;
            textHM.Text = "";
            textOp.Text = "";

            textOp.Enabled = true;
            textHM.Enabled = false;
            v_fecha = "";
            v_nro_hm = "";
            v_nro_op = "";
        }

        private void AlertaError(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 3);
            aler_ta.ShowDialog();
        }

        private void AlertaOk(string msn)
        {
            FormAlerta aler_ta = new FormAlerta(msn, 1);
            aler_ta.ShowDialog();
        }
        /// <summary>
        /// Muestra un cuadro de diálogo de confirmación y devuelve un booleano.
        /// </summary>
        /// <returns>True si el usuario confirmó, False en caso contrario.</returns>
        private bool Confirmacion()
        {
            try
            {
                using (FormConfirmacion confirmForm = new FormConfirmacion("¿Está seguro?", Color.FromArgb(255, 165, 0), "¡No podrás revertir esto!"))
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

        private void DesmtricularLote()
        {
            try
            {
                // ✅ Solo se ejecuta si la caja no existe
                var result = m_DBReprocesar.DesmtricularLote(textOp.Text, textHM.Text, m_Cod_Trabajador);

                Console.WriteLine($"✅ Resultado: {result.Status}, Mensaje: {result.Message}");

                int status = result.Status;

                if (status == 1)
                {
                    AgregarFilaDataGridView();
                    FormularioInicial();
                    AlertaOk(result.Message);
                }
                else
                    AlertaError(result.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"🛑 Error al buscar caja: {ex.Message}");
            }
        }

        private void AgregarFilaDataGridView()
        {
            if (dGVReprocesarCaja.InvokeRequired)
            {
                dGVReprocesarCaja.Invoke(new Action(AgregarFilaDataGridView));
            }
            else
            {
                dGVReprocesarCaja.Rows.Add(v_nro_op, v_nro_hm, v_fecha);
            }
        }

        private void BtnSaveMatricula_Click(object sender, EventArgs e)
        {
            //Validar_existe_caja
            Boolean elEstado = false;

            if (string.IsNullOrWhiteSpace(textOp.Text))
            {
                AlertaError("Ingresar OP");
                return;
            }

            if (string.IsNullOrWhiteSpace(textHM.Text))
            {
                AlertaError("Ingresar HM");
                return;
            }

            v_nro_op = textOp.Text;
            v_nro_hm = textHM.Text;

            MySqlTransaction trans = null;
            try
            {                
                using (var connectionMySql = m_DBReprocesar.Connect())
                {
                    using (trans = connectionMySql.BeginTransaction())
                    {
                        var ll_return = m_DBReprocesar.Validar_existe_caja(v_nro_op, v_nro_hm, connectionMySql, trans);
                        Console.WriteLine($"🔎 Estado: {ll_return.Status}, Mensaje: {ll_return.Message}, Cantidad: {ll_return.Cantidad}");

                        elEstado = ll_return.Status;

                        if (elEstado)
                        {
                            v_fecha = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");

                            trans.Commit(); // ✅ Committing antes de salir

                            if (!Confirmacion())
                                return;
                        }
                        else
                        {
                            AlertaError($"{ll_return.Message} OP: {v_nro_op} HM: {v_nro_hm}");
                            FormularioInicial();
                            trans.Rollback();
                            return;
                        }
                    }
                }
                DesmtricularLote();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🛑 Error al buscar caja: {ex.Message}");
            }
        }
    }
}
