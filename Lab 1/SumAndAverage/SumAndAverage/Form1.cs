using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumAndAverage
{
    public partial class Form1 : Form
    {
        int num1, num2, num3, num4, num5;

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = " ";
            textBox7.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double average;
            num1 = Convert.ToInt32(textBox1.Text);
            num2 = Convert.ToInt32(textBox2.Text);
            num3 = Convert.ToInt32(textBox3.Text);
            num4 = Convert.ToInt32(textBox4.Text);
            num5 = Convert.ToInt32(textBox5.Text);
            average = (num1 + num2 + num3 + num4 + num5) / (double)5;
            textBox7.Text = Convert.ToString(average);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum;
            num1 = Convert.ToInt32(textBox1.Text);
            num2 = Convert.ToInt32(textBox2.Text);
            num3 = Convert.ToInt32(textBox3.Text);
            num4 = Convert.ToInt32(textBox4.Text);
            num5 = Convert.ToInt32(textBox5.Text);
            sum = num1 + num2 + num3 + num4 + num5;
            textBox6.Text = Convert.ToString(sum);

        }
    }
}
