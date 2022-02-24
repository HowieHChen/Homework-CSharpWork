using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinForm
{
    public partial class Form1 : Form
    {
        private double number1, number2, result;
        private int op;
        private bool allowDot;
        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            labelResult.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelResult.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelResult.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelResult.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelResult.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labelResult.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            labelResult.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            labelResult.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            labelResult.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            labelResult.Text += "9";
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (allowDot)
            {
                labelResult.Text += ".";
                allowDot = false;
            }
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            op = 3;
            labelOp.Text = "/";
            if (labelExp.Text == "")
            {
                labelExp.Text += labelResult.Text;
                labelResult.Text = "";
            }
            allowDot = true;
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            op = 2;
            labelOp.Text = "*";
            if (labelExp.Text == "")
            {
                labelExp.Text += labelResult.Text;
                labelResult.Text = "";
            }
            allowDot = true;
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            op = 1;
            labelOp.Text = "-";
            if (labelExp.Text == "")
            {
                labelExp.Text += labelResult.Text;
                labelResult.Text = "";
            }
            allowDot = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            op = 0;
            labelOp.Text = "+";
            if (labelExp.Text == "")
            {
                labelExp.Text += labelResult.Text;
                labelResult.Text = "";
            }
            allowDot = true;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            if(!double.TryParse(labelExp.Text, out number1) || !double.TryParse(labelResult.Text, out number2))
            {
                System.Diagnostics.Debug.WriteLine("类型转换失败");
            }
            if(number1 == 0 && number2 == 0)
            {
                System.Diagnostics.Debug.WriteLine("无需计算");
                return;
            }
            switch (op)
            {
                case 0:
                    result = number1 + number2;
                    labelResult.Text = result.ToString();
                    break;
                case 1:
                    result = number1 - number2;
                    labelResult.Text = result.ToString();
                    break;
                case 2:
                    result = number1 * number2;
                    labelResult.Text = result.ToString();
                    break;
                case 3:
                    result = number1 / number2;
                    labelResult.Text = result.ToString();
                    break;
                case -1:

                    break;
                default:
                    number1 = number2 = result = 0;
                    labelExp.Text = "";
                    labelResult.Text = "ERROR";
                    break;
            }
            labelExp.Text = "";
            labelOp.Text = "";
            number1 = number2 = 0;
            op = -1;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelExp.Text = "";
            labelResult.Text = "";
            labelOp.Text = "";
            number1 = number2 = result = 0;
            op = -1;
            allowDot = true;
        }

        private void buttonNeg_Click(object sender, EventArgs e)
        {
            if (labelResult.Text.StartsWith("-"))
            {
                labelResult.Text = labelResult.Text.TrimStart('-');
            }
            else
            {
                labelResult.Text = "-" + labelResult.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelExp.Text = "";
            labelResult.Text = "";
            labelOp.Text = "";
            number1 = number2 = result = 0;
            op = -1;
            allowDot = true;
        }
    }
}
