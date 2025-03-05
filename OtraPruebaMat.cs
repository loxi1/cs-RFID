using System;
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
    public partial class OtraPruebaMat : Form
    {
        private FormMain m_MainForm = null;
        public OtraPruebaMat(FormMain mainForm)
        {
            InitializeComponent();
            m_MainForm = mainForm;
        }

        private void OtraPruebaMat_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                // Obtener el ancho de la celda donde está ubicado tbContCronoEstados
                int anchoCelda = this.tbContMatHM.GetColumnWidths()[0];

                // Asignar el 60% del ancho y 100% del alto a tbContCronoEstados
                this.tbContCronoEstados.Width = (int)(anchoCelda * 0.6);
                this.tbContCronoEstados.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                this.tbContCronoEstados.Dock = DockStyle.None;

                // Obtener las dimensiones de la celda donde está tbContentMatricula
                int anchoCeldaMatricula = this.tbFormHM.GetColumnWidths()[0];
                int altoCeldaMatricula = this.tbFormHM.GetRowHeights()[0];

                // Definir el ancho y alto de tbContentMatricula
                this.tbContentMatricula.Width = (int)(anchoCeldaMatricula * 0.70); // 70% del ancho
                this.tbContentMatricula.Height = (int)(altoCeldaMatricula * 0.25); // 25% del alto

                // Centramos el componente dentro de su celda
                this.tbContentMatricula.Left = (this.tbFormHM.Width - this.tbContentMatricula.Width) / 2;
                this.tbContentMatricula.Top = (this.tbFormHM.Height - this.tbContentMatricula.Height) / 2;

                // Quitar Dock y Anchor para que la posición manual funcione
                this.tbContentMatricula.Dock = DockStyle.None;
                this.tbContentMatricula.Anchor = AnchorStyles.None;
            }));
        }

        private void OtraPruebaMat_Resize(object sender, EventArgs e)
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

            this.tbContentMatricula.Left = (this.tbFormHM.Width - this.tbContentMatricula.Width) / 2;
            this.tbContentMatricula.Top = (this.tbFormHM.Height - this.tbContentMatricula.Height) / 2;

            foreach (Control control in this.Controls)
            {
                Console.WriteLine($"Nombre (1) -->{control.Name}");
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    Console.WriteLine($"Tabla (2) -->{control.Name}");
                    foreach (Control control1 in control.Controls)
                    {
                        Console.WriteLine($"Nombre (2) -->{control1.Name}");
                        li_factor = li_minnimo;
                        if (control1 is TableLayoutPanel tableLayoutPanel2)
                        {
                            Console.WriteLine($" la tabla es-->{control1.Name} {tableLayoutPanel2.Name}");
                            if (control1.Name == "tbContentNumPrendas")
                            {
                                if (control1.Name == "totalTagValueLabel" || control1.Name == "label13")
                                {
                                    li_factor = control1.Name == "totalTagValueLabel" ? li_minnimo : li_max;

                                    li_height = this.ClientSize.Height / li_factor;
                                    li_width = this.ClientSize.Width / li_factor;
                                    ls_tag = (string)control1.Tag;
                                    if (ls_tag != null)
                                    {
                                        if (int.TryParse(ls_tag, out li_long))
                                        {
                                            li_height /= li_long;
                                            li_width /= li_long;
                                        }
                                    }
                                    fontSize = Math.Max(li_height, li_width);
                                    control1.Font = new Font(control.Font.FontFamily, fontSize);
                                }
                            }
                            else if (control1.Name == "tbFormHM")
                            {
                                foreach (Control control2 in control1.Controls)
                                {
                                    if(control2.Name == "tbContentMatricula")
                                    {
                                        Console.WriteLine($"tabla-->{control2.Name}");
                                        foreach (Control control3 in control2.Controls)
                                        {
                                            Console.WriteLine($"Elemento-->{control3.Name}");
                                            li_factor = li_mega_max;
                                            li_height = this.ClientSize.Height / li_factor;
                                            li_width = this.ClientSize.Width / li_factor;

                                            fontSize = Math.Max(li_height, li_width);
                                            control3.Font = new Font(control3.Font.FontFamily, fontSize);
                                        }
                                    }
                                }                                
                            }
                        }
                        else if (control1.Name == "readButton")
                        {
                            li_factor = li_max;
                            li_height = this.ClientSize.Height / li_factor;
                            li_width = this.ClientSize.Width / li_factor;

                            fontSize = Math.Max(li_height, li_width);
                            control1.Font = new Font(control.Font.FontFamily, fontSize);
                            Console.WriteLine($"Entro por el btn-->{control1.Name}<--");
                        }                        
                    }
                }
            }
        }
    }
}
