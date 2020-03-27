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
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Num1_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("1");
        }

        private void Num2_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("2");
        }

        private void Num3_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("3");
        }

        private void Num4_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("4");
        }

        private void Num5_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("5");
        }

        private void Num6_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("6");
        }

        private void Num7_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("7");
        }

        private void Num8_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("8");
        }

        private void Num9_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("9");
        }

        private void NumPeriod_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText(".");
        }

        private void Num0_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("0");
        }

        private void FuncCalc_Click(object sender, EventArgs e)
        {
            int calculated = 0;
            int num1 = 0;
            int num2 = 0;
            Boolean num1Flag = false;
            Boolean num2Flag = false;
            String input = Input_Text.Text;
            Char[] input_array = input.ToCharArray();
            try
            {

                String function;
                while (true)
                {
                    num1 = 0;
                    num2 = 0;
                    num1Flag = false;
                    num2Flag = false;
                    int indexCalc = input.IndexOf("/");
                    if (indexCalc != -1)
                            {
                        function = "Divide";
                    }
                    else
                    {
                        indexCalc = input.IndexOf("*");
                        if (indexCalc != -1)
                        {
                            function = "Multiply";
                        }
                        else
                        {
                            indexCalc = input.IndexOf("+");
                            if (indexCalc != -1)
                            {
                                function = "Addition";
                            }
                            else
                            {
                                indexCalc = input.IndexOf("-");
                                if (indexCalc != -1)
                                {
                                    function = "Subtraction";
                                }
                                else
                                {
                                    Input_Text.Text = input;
                                    break;
                                }
                            }
                        }
                    }
                    for (int i = 1; i <= indexCalc; i++)
                    {
                        if (char.IsDigit(input_array[indexCalc - i]))
                        {
                            if (!num1Flag)
                            {
                                num1 += Convert.ToInt32(Char.GetNumericValue(input_array[indexCalc - i]) * (Math.Pow(10,i - 1)));
                            }
                        }
                        else
                        {
                            if (i == 1)
                            {
                                Input_Text.Text = "ERROR";
                                break;
                            }
                            else
                            {
                                num1Flag = true;
                                break;
                            }
                        }

                    }
                    for (int i = 1; i < input.Length-indexCalc; i++)
                    {
                        if (char.IsDigit(input_array[indexCalc + i]))
                        {
                            if (!num2Flag)
                            {
                                num2 += Convert.ToInt32(Char.GetNumericValue(input_array[indexCalc + i]) * (Math.Pow(10, i - 1)));
                            }
                        }
                        else
                        {
                            if (i == 1)
                            {
                                Input_Text.Text = "ERROR";
                                break;
                            }
                            else
                            {
                                num2Flag = true;
                                break;
                            }
                        }

                    }
                    String replace_string="";
                    switch (function)
                    {
                        case "Divide":
                            calculated = num1 / num2;
                            replace_string = num1.ToString() + "/" + num2.ToString();
                            break;
                        case "Multiply":
                            calculated = num1 * num2;
                            replace_string = num1.ToString() + "*" + num2.ToString();
                            break;
                        case "Addition":
                            calculated = num1 + num2;
                            replace_string = num1.ToString() + "+" + num2.ToString();
                            break;
                        case "Subtraction":
                            calculated = num1 - num2;
                            replace_string = num1.ToString() + "-" + num2.ToString();
                            break;
                    }
                    Boolean check = input.Contains(replace_string);
                    input = input.Replace(replace_string, calculated.ToString());
                    input_array = input.ToCharArray();
                }
            }
            catch (Exception ex)
            {
                Input_Text.Text = ("Error: " + ex.Message);
            }

    }

    private void FuncAdd_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("+");
        }

        private void FuncSub_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("-");
        }

        private void FuncMul_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("*");
        }

        private void FuncDiv_Click(object sender, EventArgs e)
        {
            Input_Text.AppendText("/");
        }
    }
}
