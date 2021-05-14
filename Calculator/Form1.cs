using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        double memoryValue = 0;
        string memoryOperationPerformed = "";

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button_number(object sender, EventArgs e)
        {
            if (textBox_result.Text == "0" || (isOperationPerformed))
                textBox_result.Clear();

            isOperationPerformed = false;
            Button button=(Button)sender;
            if (button.Text==".")
            {
                if (!textBox_result.Text.Contains("."))
                    textBox_result.Text = textBox_result.Text + button.Text;
            }
            else
            {
                textBox_result.Text = textBox_result.Text + button.Text;
            }
        }

        private void button_operation(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;
            resultValue = double.Parse(textBox_result.Text);
            labelCurrent.Text = resultValue + " " + operationPerformed;
            isOperationPerformed = true;
        }

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
            resultValue = 0;
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+" :
                    textBox_result.Text = (resultValue + double.Parse(textBox_result.Text)).ToString();
                    break;

                case "-":
                    textBox_result.Text = (resultValue - double.Parse(textBox_result.Text)).ToString();
                    break;

                case "*":
                    textBox_result.Text = (resultValue * double.Parse(textBox_result.Text)).ToString();
                    break;

                case "/":
                    textBox_result.Text = (resultValue / double.Parse(textBox_result.Text)).ToString();
                    break;
                case "sqRoot":
                    textBox_result.Text = Math.Sqrt(resultValue).ToString();
                    break;
                default:
                    break;
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = "sqRoot";
            resultValue = double.Parse(textBox_result.Text);
            labelCurrent.Text = "√"+ "(" + resultValue + ")";
            textBox_result.Text = Math.Sqrt(resultValue).ToString();
            isOperationPerformed = true;
        }

        private void memory_button(object sender, EventArgs e)
        {
            Button memButton = (Button)sender;
            memoryOperationPerformed = memButton.Text;
            if (memButton.Text == "M+")
            {
                memoryValue += double.Parse(textBox_result.Text);
                label1.Visible = true;
                labelMemValue.Visible = true;
            }
            if (memButton.Text == "M-")
            {
                memoryValue -= double.Parse(textBox_result.Text);
                label1.Visible = true;
                labelMemValue.Visible = true;
            }
            if (memButton.Text == "MR")
            {
                textBox_result.Text = labelMemValue.Text;
                label1.Visible = true;
                labelMemValue.Visible = true;
            }
            if (memButton.Text == "MC")
            {
                label1.Visible = false;
                labelMemValue.Visible = false;
                memoryValue = 0;
                labelMemValue.Text = "0";
            }
            labelMemValue.Text = memoryValue.ToString();
            return;
        }
    }
}
