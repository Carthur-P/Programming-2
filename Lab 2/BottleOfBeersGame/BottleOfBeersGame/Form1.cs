using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BottleOfBeersGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            number = Convert.ToInt32(textBox1.Text);//reading the text from the (textBox1)
            listBox1.Items.Clear();

            if ((number > 0) && (number < 99))//if the number is between 0 and 99 move on
            {
                for (int i = 0; i < number; i++)//loop that wont go out until variable (i) is the same as (number) 
                {
                    listBox1.Items.Add((99 - i) + " bottles of beers");
                }
            }
            else
            {
                //(MessageBox.Show) will bring up another window that the user will have to click okay to continue 
                MessageBox.Show("Please enter a number between 0 and 99");
            }


          

        }
    }
}
