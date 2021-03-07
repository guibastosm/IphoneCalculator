using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class frmMain : Form {
        public bool auxVirgula = false;
        public bool auxSelecionado = false;
        public bool auxClear = false;
        public float firstNumber = 0;
        public float secNumber = 0;
        public string operador = "+";
        public frmMain() {
            InitializeComponent();
            this.AutoSize = false;
        }

        private void btnLimparClick(object sender, EventArgs e) {
            rtxt_Screen.Text = "";
            firstNumber = 0;
            secNumber = 0;
            operador = "+";
            auxVirgula = false;
            auxClear = false;
            btnLimparCores();
        }

        private void btnFecharClick(object sender, EventArgs e) {
            Close();
        }

        private void btnIgualClick(object sender, EventArgs e) {
            if (rtxt_Screen.Text != "") {
                firstNumber = float.Parse(rtxt_Screen.Text);
                switch (operador) {
                    case "+":
                        secNumber += firstNumber;
                        break;
                    case "-":
                        secNumber -= firstNumber;
                        break;
                    case "÷":
                        secNumber /= firstNumber;
                        break;
                    case "×":
                        secNumber *= firstNumber;
                        break;
                }
                auxSelecionado = false;
                btnLimparCores();
                auxClear = true;
                rtxt_Screen.Text = Convert.ToString(secNumber);
                rtxt_Screen.SelectionAlignment = HorizontalAlignment.Right;
                secNumber = 0;
                operador = "+";
            }
        }
        public void btnLimparCores() {
            btnMais.BackColor = Color.Orange;
            btnMenos.BackColor = Color.Orange;
            btnVezes.BackColor = Color.Orange;
            btnDividir.BackColor = Color.Orange;
            btnMais.ForeColor = Color.White;
            btnMenos.ForeColor = Color.White;
            btnVezes.ForeColor = Color.White;
            btnDividir.ForeColor = Color.White;
        }
        public void btnNumberClick(object sender, EventArgs e) {
            Button btNumber = (Button)sender;
            if (auxClear == false) {
                rtxt_Screen.Text = rtxt_Screen.Text + btNumber.Text;
            }
            else {
                rtxt_Screen.Text = "" + btNumber.Text;
                auxClear = false;
                auxVirgula = false;
            }
            auxSelecionado = false;
            rtxt_Screen.SelectionAlignment = HorizontalAlignment.Right;
            btnLimparCores();
        }

        public void btnNumber0Click(object sender, EventArgs e)
        {
            Button btNumber = (Button)sender;
            if (auxClear == false)
            {
                rtxt_Screen.Text = rtxt_Screen.Text + "0";
            }
            else
            {
                rtxt_Screen.Text = "" + "0";
                auxClear = false;
                auxVirgula = false;
            }
            auxSelecionado = false;
            rtxt_Screen.SelectionAlignment = HorizontalAlignment.Right;
            btnLimparCores();
        }

        public void btnOperadorClick(object sender, EventArgs e) {
            Button btOperador = (Button)sender;
            if (rtxt_Screen.Text != "") {
                if (auxSelecionado == false) {
                    firstNumber = float.Parse(rtxt_Screen.Text);
                    switch (operador) {
                        case "+":
                            secNumber += firstNumber;
                            break;
                        case "-":
                            secNumber -= firstNumber;
                            break;
                        case "÷":
                            secNumber /= firstNumber;
                            break;
                        case "×":
                            secNumber *= firstNumber;
                            break;
                    }
                    operador = btOperador.Text;
                    btnLimparCores();
                    btOperador.BackColor = Color.White;
                    btOperador.ForeColor = Color.Orange;

                    auxSelecionado = true;
                    auxClear = true;
                    rtxt_Screen.Text = Convert.ToString(secNumber);
                }
                else {
                    operador = btOperador.Text;
                    btnLimparCores();
                    btOperador.BackColor = Color.White;
                    btOperador.ForeColor = Color.Orange;
                }
            }
            rtxt_Screen.SelectionAlignment = HorizontalAlignment.Right;
        }


        private void btnVirgulaClick(object sender, EventArgs e) {
            Button btVirgula = (Button)sender;
            if (auxVirgula == false) {
                rtxt_Screen.Text = rtxt_Screen.Text + ",";
                auxVirgula = true;
            }
            rtxt_Screen.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void btnOperadorUnicoClick(object sender, EventArgs e) {
            Button btOperadorUnico = (Button)sender;
            if (rtxt_Screen.Text != "") {
                if (btOperadorUnico.Text == "+/-") {
                    float aux = float.Parse(rtxt_Screen.Text);
                    aux *= -1;
                    rtxt_Screen.Text = Convert.ToString(aux);
                }
                else if (btOperadorUnico.Text == "%") {
                    float aux = float.Parse(rtxt_Screen.Text);
                    aux /= 100;
                    rtxt_Screen.Text = Convert.ToString(aux);
                    if (aux * 100 % 100 != 0) {
                        auxVirgula = true;
                    }
                    
                }

            }
            rtxt_Screen.SelectionAlignment = HorizontalAlignment.Right;
        }

        public GraphicsPath RoundedRectangle(RectangleF R, float d){
            float r = d / 2;
            GraphicsPath RoundedRectanglePath = new GraphicsPath();

            RoundedRectanglePath.AddLine(R.X + r, R.Y, R.X + R.Width - d, R.Y);
            RoundedRectanglePath.AddArc(R.X + R.Width - d, R.Y, d, d, 270, 90);
            RoundedRectanglePath.AddLine(R.X + R.Width, R.Y + r, R.X + R.Width, R.Y + R.Height - d);
            RoundedRectanglePath.AddArc(R.X + R.Width - d, R.Y + R.Height - d, d, d, 0, 90);
            RoundedRectanglePath.AddLine(R.X + R.Width - d, R.Y + R.Height, R.X + r, R.Y + R.Height);
            RoundedRectanglePath.AddArc(R.X, R.Y + R.Height - d, d, d, 90, 90);
            RoundedRectanglePath.AddLine(R.X, R.Y + R.Height - d, R.X , R.Y + r);
            RoundedRectanglePath.AddArc(R.X, R.Y, d, d, 180, 90);
            RoundedRectanglePath.CloseFigure();

            return RoundedRectanglePath;
        }
        protected override void OnPaint(PaintEventArgs e) {
            GraphicsPath btnPadrao = new GraphicsPath();
            btnPadrao.AddEllipse(0, 0, btn1.Width, btn1.Height);
            RectangleF RectBtn = new RectangleF(0, 0, btn0.Width, btn0.Height);
            GraphicsPath btnSec = RoundedRectangle(RectBtn, btn1.Width);

            RectangleF RectForm = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath form = RoundedRectangle(RectForm, 50);

            btn1.Region = new Region(btnPadrao);
            btn2.Region = new Region(btnPadrao);
            btn3.Region = new Region(btnPadrao);
            btn4.Region = new Region(btnPadrao);
            btn5.Region = new Region(btnPadrao);
            btn6.Region = new Region(btnPadrao);
            btn7.Region = new Region(btnPadrao);
            btn8.Region = new Region(btnPadrao);
            btn9.Region = new Region(btnPadrao);
            btnVirgula.Region = new Region(btnPadrao);
            btnMais.Region = new Region(btnPadrao);
            btnMenos.Region = new Region(btnPadrao);
            btnDividir.Region = new Region(btnPadrao);
            btnVezes.Region = new Region(btnPadrao);
            btnPorcento.Region = new Region(btnPadrao);
            btnIgual.Region = new Region(btnPadrao);
            btnClear.Region = new Region(btnPadrao);
            btnMaisMenos.Region = new Region(btnPadrao);
            btn0.Region = new Region(btnSec);
            this.Region = new Region(form);

        }
        private Point mouseLocation;
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        private void Titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
    }
}
   



