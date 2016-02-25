using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_App
{
    public partial class Form1 : Form
    {
        private double leftOperand = 0;
        private double rightOperand = 0;
        private string operation = string.Empty;
        private bool isAppliedOperation = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Digit_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(isAppliedOperation)
            {
                leftOperand += double.Parse(textBox1.Text);
                textBox1.ResetText();
                isAppliedOperation = false;
            }
            textBox1.Text += button.Text;   
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                Button button = sender as Button;
                operation = button.Text;
                isAppliedOperation = true;
            }
            
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                return;

            rightOperand += double.Parse(textBox1.Text);
            double result = 0;

            if (operation.Contains("+"))
            {
                result = leftOperand + rightOperand;
                textBox1.Text = result.ToString();
            }
            else if (operation.Contains("-"))
            {
                result = leftOperand - rightOperand;
                textBox1.Text = result.ToString();
            }
            else if (operation.Contains("*"))
            {
                result = leftOperand * rightOperand;
                textBox1.Text = result.ToString();
            }
            else if (operation.Contains("/"))
            {
                result = leftOperand / rightOperand;
                textBox1.Text = result.ToString();
            }
            else if (operation.Contains("^"))
            {
                result = Math.Pow(leftOperand, rightOperand);
                textBox1.Text = result.ToString();
            }

            leftOperand = 0;    // zero both operands so we can use them again
            rightOperand = 0;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            leftOperand = 0;
            rightOperand = 0;
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                double sqrt = Math.Sqrt(double.Parse(textBox1.Text));
                textBox1.Text = sqrt.ToString();
            }
        }

        private void Pow2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                double number = double.Parse(textBox1.Text);
                textBox1.Text = (number * number).ToString();
            }
        }

        private void PowN_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                operation = "^";
                isAppliedOperation = true;
            }
        }

        private void Ln_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                double number = double.Parse(textBox1.Text);
                textBox1.Text = (Math.Log(number)).ToString();
            }
        }

        private void Log2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                double number = double.Parse(textBox1.Text);
                textBox1.Text = (Math.Log(number)/Math.Log(2)).ToString();
            }
        }
    }
}