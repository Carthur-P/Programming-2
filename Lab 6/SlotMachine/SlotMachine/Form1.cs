using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine
{  
    public partial class Form1 : Form
    {
        private Random rand;
        private Spinner slot1;
        private Spinner slot2;
        private Spinner slot3;
        private double balance;
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            slot1 = new Spinner(rand, pictureBox1);
            slot2 = new Spinner(rand, pictureBox2);
            slot3 = new Spinner(rand, pictureBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            balance = balance - 10;
            if (balance >= 0)
            {
                textBox2.Text = Convert.ToString(balance);
                button1.Enabled = false;
                button3.Enabled = false;
                slot1.Spin();
                slot2.Spin();
                slot3.Spin();
                
                if ((slot1.ImageNumber == slot2.ImageNumber) && (slot2.ImageNumber == slot3.ImageNumber) && (slot3.ImageNumber == slot1.ImageNumber))
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    label8.Text = "Result: You won $100!";
                    balance = balance + 100;
                    textBox2.Text = Convert.ToString(balance);
                }//end of winning if statement
                else if ((slot1.ImageNumber == slot2.ImageNumber) || (slot2.ImageNumber == slot3.ImageNumber) || (slot1.ImageNumber == slot3.ImageNumber))
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    label8.Text = "Result: You won $30";
                    balance = balance + 30;
                    textBox2.Text = Convert.ToString(balance);
                }//end of if statement for two matching images
                else
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    label8.Text = "Result: You loss";
                }//end of loosing if statement

            }//end of play slot game if statement
            else 
            {
                MessageBox.Show("You don't have enough money");
                textBox1.Enabled = true;
                button2.Enabled = true;
            }//end of not haveing enough money if statement
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            balance = Convert.ToDouble(textBox1.Text);
            if (balance < 10)
            {
                MessageBox.Show("The amount you have entered is below the minimum bet");
            }
            else if (balance > 200)
            {
                MessageBox.Show("You can only load $200 at a time");
            }
            else
            {
                textBox2.Text = Convert.ToString(balance);
                textBox1.Enabled = false;
                button2.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (balance > 0)
            {
                MessageBox.Show("You have claim $" + balance);
            }
            else
            {
                MessageBox.Show("You have claim $" + (balance + 10));
            }
            Application.Exit();
        }
    }
}
