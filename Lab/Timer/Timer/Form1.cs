using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        private int num;
        private bool timer;
        public Form1()
        {
            InitializeComponent();
            timer = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            num = Convert.ToInt32(textBox1.Text);
            num = num + 1;
            textBox1.Text = Convert.ToString(num);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer == false)
            {
                timer1.Enabled = true;
                timer = true;
                button1.Text = "Stop";
            }
            else if (timer == true) 
            {
                timer1.Enabled = false;
                timer = false;
                button1.Text = "Start";
            }
            
        }
    }
}
