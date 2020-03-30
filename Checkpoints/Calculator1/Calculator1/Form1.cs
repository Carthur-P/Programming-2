/* Program name:          Calculator
 * Project file name:     Calculator1
 * Author:                Carthur Pongpatimet
 * Date:                  21/07/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To make a simple calculator
 * 
 * Description:           Buttons - when the button is click, the corresponding mathematical calculation is done
 *  
 *                        Textbox - the two top textboxes are use to enter the numbers that will be use in the
 *                        mathematical calculation. The bottom textbox will show the answer
 *                        
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class Form1 : Form
    {
        int Num1, Num2;
        public Form1()//constructor
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//do addition to the numbers
        {
            int plus;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            plus = Num1 + Num2;
            textBox3.Text = Convert.ToString(plus);
        }

        private void button2_Click(object sender, EventArgs e)//do subtraction to the numbers
        {
            int minus;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            minus = Num1 - Num2;
            textBox3.Text = Convert.ToString(minus);
        }

        private void button3_Click(object sender, EventArgs e)//do multiplication to the numbers
        {
            int multiply;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            multiply = Num1 * Num2;
            textBox3.Text = Convert.ToString(multiply);
        }

        private void button4_Click(object sender, EventArgs e)//do a division to the numbers
        {
            double divide;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            divide = (double)Num1 / Num2;
            textBox3.Text = Convert.ToString(divide);
        }

        private void button5_Click(object sender, EventArgs e)//clear the textboxes
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = " ";
        }

        private void button6_Click(object sender, EventArgs e)//show the remainders from a division of the numbers
        {
            int mod;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            mod = Num1 % Num2;
            textBox3.Text = Convert.ToString(mod);

        }

        private void button7_Click(object sender, EventArgs e)//show how many times the numbers can be divided without remainders (decimals) 
        {
            int div;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            div = Num1 / Num2;
            textBox3.Text = Convert.ToString(div);
        }
    }
}
