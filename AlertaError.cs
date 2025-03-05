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
    public partial class AlertaError : Form
    {
        public AlertaError()
        {
            InitializeComponent();
        }

        public AlertaError(string titulo, string detalle, Color pColor)
        {
            InitializeComponent();
            TituloAviso.Text = titulo;
            DescripcionAviso.Text = detalle;
            FranjaAbajo.BackColor = pColor;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
