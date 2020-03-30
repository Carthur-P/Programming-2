using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicClass
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Font font;
        public Form1()
        {
            InitializeComponent();

            graphics = CreateGraphics();
            font = new Font("consolas", 20, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.DrawLine(Pens.Green, new Point(10, 10), new Point(50, 30));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.DrawLine(Pens.Green, new Point(10, 30), new Point(50, 10));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            graphics.FillRectangle(Brushes.Red, new Rectangle(100, 10, 200, 50));
            graphics.DrawRectangle(Pens.Black, new Rectangle(100, 10, 200, 50));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            graphics.FillEllipse(Brushes.GreenYellow, new Rectangle(120, 120, 250, 100));
            graphics.FillEllipse(Brushes.Yellow, new Rectangle(100, 100, 250, 100));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            graphics.DrawString("Hi there!!", font, Brushes.Black, new Point(110, 110));
        }
    }
}
