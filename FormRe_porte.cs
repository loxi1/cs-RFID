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
    public partial class FormRe_porte : Form
    {
        public FormRe_porte()
        {
            InitializeComponent();
        }

        private void Marcacion__Click(object sender, EventArgs e)
        {

        }

        private void FormRe_porte_Resize(object sender, EventArgs e)
        {
            int li_long;
            int li_height;
            int li_width;
            float fontSize;
            int li_minnimo = 40;
            int li_maximo = 60;
            int li_min = 25;
            int li_max = 85;
            int li_factor = 1;
            string ls_tag = "";
            bool avan = false;

            foreach (Control control in this.Controls)
            {
                Console.WriteLine("<----Nombre 1--->" + control.Name+  " <----Tipo---> " + control.GetType().Name);
                foreach (Control control1 in control.Controls)
                {
                    Console.WriteLine("<----Nombre 2--->" + control1.Name + " <----Tipo---> " + control1.GetType().Name);
                    if(control1.Name== "tableLayoutPanel2" || control1.Name == "tableLayoutPanel3")
                    {
                        foreach (Control control2 in control1.Controls)
                        {
                            avan = false;
                            li_factor = 1;
                            Console.WriteLine("<----Nombre 3--->" + control2.Name + " <----Tipo---> " + control2.GetType().Name);
                            if (control2.Name == "dataGridViewReporte")
                            {
                                avan = true;
                                li_factor = li_maximo;
                            }
                            else if (control2.Name == "labelTituloReporte") {
                                avan = true;
                                li_factor = li_minnimo;
                            } else if(control2.Name == "dataGridViewReporte")
                            {
                                avan = true;
                                li_factor = li_max;
                            }
                            else if (control2.Name == "tableLayoutPanel4" || control2.Name == "tableLayoutPanel5")
                            {
                                li_factor = control2.Name == "tableLayoutPanel4" ? li_maximo : li_minnimo;
                                foreach (Control control3 in control2.Controls)
                                {
                                    if (control3.Name == "labelBuscarReporte")
                                    {
                                        li_factor = li_min;
                                    }
                                    Console.WriteLine("<----Nombre 4--->" + control3.Name + " <----Tipo---> " + control3.GetType().Name);
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
                                    control3.Font = new Font(control3.Font.FontFamily, fontSize);
                                }
                            }
                            if(avan)
                            {
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
                                control2.Font = new Font(control2.Font.FontFamily, fontSize);
                            }
                        }
                    }
                    
                }
            }
        }

        private void BTNBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
