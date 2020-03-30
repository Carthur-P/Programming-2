using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class Form1 : Form
    {
        int Num1, Num2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int minus;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            minus = Num1 - Num2;
            textBox3.Text = Convert.ToString(minus);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int multiply;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            multiply = Num1 * Num2;
            textBox3.Text = Convert.ToString(multiply);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double divide;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            divide = (double)Num1 / Num2;
            textBox3.Text = Convert.ToString(divide);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int mod;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            mod = Num1 % Num2;
            textBox3.Text = Convert.ToString(mod);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int div;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            div = Num1 / Num2;
            textBox3.Text = Convert.ToString(div);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int plus;
            Num1 = Convert.ToInt32(textBox1.Text);
            Num2 = Convert.ToInt32(textBox2.Text);
            plus = Num1 + Num2;
            textBox3.Text = Convert.ToString(plus);
        }
    }
}
