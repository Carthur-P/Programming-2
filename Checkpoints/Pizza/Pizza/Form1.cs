using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class Form1 : Form
    {
        double price;
        public Form1()
        {
            InitializeComponent();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                price = price + 1.5;
                listBox1.Items.Add("Extra bacon");
            }
            else
            {
                listBox1.Items.Remove("Extra bacon");
                price = price - 1.5;
            }                   
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                price = price + 1;
                listBox1.Items.Add("Extra cheese");
            }
            else
            {
                listBox1.Items.Remove("Extra cheese");
                price = price - 1;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                price = price + 0.75;
                listBox1.Items.Add("Extra olives");
            }
            else
            {
                listBox1.Items.Remove("Extra olives");
                price = price - 0.75;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                price = price + 0.75;
                listBox1.Items.Add("Extra mushrooms");
            }
            else
            {
                listBox1.Items.Remove("Extra mushrooms");
                price = price - 0.75;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                price = price + 1;
                listBox1.Items.Add("Extra pepperoni");
            }
            else
            {
                listBox1.Items.Remove("Extra pepperoni");
                price = price - 1;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                price = price + 0.5;
                listBox1.Items.Add("Extra sauce");
            }
            else
            {
                listBox1.Items.Remove("Extra sauce");
                price = price - 0.5;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The price of your order is $" + price);//displaying the final price in a message box
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if simply cheese pizza is checked, do the following
            listBox1.Items.Clear();
            listBox1.Items.Add("Simply cheese pizza");
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            price = 5;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //if meatlovers pizza is checked do the following
            listBox1.Items.Clear();
            listBox1.Items.Add("Meatlovers pizza");
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            price = 10;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //if pepperoni pizza is checked, do the following
            listBox1.Items.Clear();
            listBox1.Items.Add("Pepperoni pizza");
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            price = 8;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //if hawaiian pizza is checked do the following
            listBox1.Items.Clear();
            listBox1.Items.Add("Hawaiian pizza");
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            price = 8;
        }

    }
}
