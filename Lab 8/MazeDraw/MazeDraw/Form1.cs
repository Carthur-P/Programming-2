using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeDraw
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int endPoint;
        private int lastLine;
        private Pen pen;
        public Form1()
        {
            InitializeComponent();

            graphics = CreateGraphics();

            pen = new Pen(Brushes.Black, 3.0F);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            endPoint = Convert.ToInt32(textBox1.Text);
            lastLine = endPoint - 10;

            graphics.DrawLine(pen, new Point(50, 50), new Point(endPoint, 50));
        }
    }
}
