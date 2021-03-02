using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
   



