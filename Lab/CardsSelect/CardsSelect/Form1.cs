using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardsSelect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                pictureBox1.Image = Properties.Resources.C12;
            }
            else if (radioButton2.Checked)
            {
                pictureBox1.Image = Properties.Resources.C13;
            }
            else if (radioButton3.Checked)
            {
                pictureBox1.Image = Properties.Resources.D10;
            }

            if (radioButton4.Checked)
            {
                pictureBox2.Image = Properties.Resources.D11;
            }
            else if (radioButton5.Checked)
            {
                pictureBox2.Image = Properties.Resources.H10;
            }
            else if (radioButton6.Checked)
            {
                pictureBox2.Image = Properties.Resources.H12;
            }
        }
    }
}
