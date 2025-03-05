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
    [DefaultEvent("_TextChanged")]
    public partial class UCTextBox : UserControl
    {
        private Color borderColor = Color.MediumSeaGreen;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.YellowGreen;
        private bool isfocus = false;
        private bool isPlaceHolder = true;
        private string _placeHolderText;
        private int _maxLength;

        //Constructor
        public UCTextBox()
        {
            InitializeComponent();
        }

        //Events
        public event EventHandler _TextChanged;

        //Properties
        [Category("UC Properties Advance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("UC Properties Advance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("UC Properties Advance")]
        public bool UnderlinedStyle
        {
            get
            {
                return underlinedStyle;
            }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("UC Properties Advance")]
        public bool PasswordChar
        {
            get { return textBox.UseSystemPasswordChar; }
            set { textBox.UseSystemPasswordChar = value; }
        }

        [Category("UC Properties Advance")]
        public bool Multiline
        {
            get { return textBox.Multiline; }
            set { textBox.Multiline = value; }
        }

        [Category("UC Properties Advance")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox.BackColor = value;
            }
        }

        [Category("UC Properties Advance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox.ForeColor = value;
            }
        }

        [Category("UC Properties Advance")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox.Font = value;
                UpdateFontSize(value.Size);                
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        //public string Texts
        //{
        //    get
        //    {
        //        return isPlaceHolder ? string.Empty : textBox.Text; ;
        //    }
        //    set
        //    {
        //        textBox.Text = value;
        //    }
        //}

        [Category("UC Properties Advance")]
        public new string Text
        {
            //get => isPlaceHolder ? string.Empty : textBox.Text;
            get => textBox.Text;
            set => textBox.Text = value;
        }


        [Category("UC Properties Advance")]
        public Color BorderFocusColor
        {
            get
            {
                return borderFocusColor;
            }
            set
            {
                borderFocusColor = value;
            }
        }

        [Category("UC Properties Advance")]
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set { _placeHolderText = value; SetPlaceholder(); }
        }

        private void SetPlaceholder()
        {
            isPlaceHolder = string.IsNullOrWhiteSpace(textBox.Text);
            if (isPlaceHolder)
            {
                textBox.Text = _placeHolderText;
            }
        }

        [Category("UC Properties Advance")]
        public int cantidadMaxima
        {
            get { return _maxLength; }
            set { _maxLength = value; SetCantidadMaxima(); }
        }

        private void SetCantidadMaxima()
        {
            // Asignar el valor a la propiedad MaxLength del TextBox interno
            if (textBox != null)
            {
                textBox.MaxLength = _maxLength;
            }
        }

        //overridden methods
        private void UpdateFontSize(float fontSize)
        {
            textBox.Font = new Font(textBox.Font.FontFamily, fontSize);            
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (!isfocus)
                {
                    if (underlinedStyle)
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
                else
                {
                    penBorder.Color = borderFocusColor;

                    if (underlinedStyle)
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if (textBox.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox.Multiline = true;
                textBox.MinimumSize = new Size(0, txtHeight);
                textBox.Multiline = false;

                SuspendLayout();
                this.Height = textBox.Height + this.Padding.Top + this.Padding.Bottom;
                ResumeLayout();
            }

            if (textBox.Height > this.Height )
            {
                textBox.Height = this.Height - (this.Padding.Top + this.Padding.Bottom);
            }
            //this.Height = textBox.Height + this.Padding.Top + this.Padding.Bottom;

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            //this.OnEnter(e);
            isfocus = true;
            this.Invalidate();
            if (textBox.Text == _placeHolderText)
                textBox.Text = "";
            else
                textBox.SelectAll();
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            //this.OnLeave(e);
            isfocus = false;
            this.Invalidate();
            this.SetPlaceholder();
            this.SetCantidadMaxima();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void UCTextBox_Resize(object sender, EventArgs e)
        {
            //UpdateControlHeight();
        }
    }
}
