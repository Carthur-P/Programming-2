using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingImage
{
    public partial class Form1 : Form
    {
        private const int HORIZONTAL = 10;
        private const int VERTICAL = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = pictureBox1.Top + VERTICAL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Left = pictureBox2.Left + HORIZONTAL;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox3.Left = pictureBox3.Left - HORIZONTAL;
            pictureBox3.Top = pictureBox3.Top + VERTICAL;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            
        }
    }
}
