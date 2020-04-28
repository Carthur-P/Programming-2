using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingObject
{
    public partial class Form1 : Form
    {
        private const int DISTANCE = 50;
        private const int CHANGE = 20;

        private Graphics graphics;
        private int distance;
        public Form1()
        {
            InitializeComponent();

            graphics = CreateGraphics();

            timer1.Enabled = true;
            distance = DISTANCE;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                Refresh();
            }

            graphics.FillEllipse(Brushes.Red, new Rectangle(distance, 50, 50, 50));
            graphics.DrawEllipse(Pens.Black, new Rectangle(distance, 50, 50, 50));
            distance = distance + CHANGE;

            if (distance > Width)
            {
                distance = - DISTANCE;
            }

        }
    }
}
