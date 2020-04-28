using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Font font;
        public Form1()
        {
            InitializeComponent();

            graphics = CreateGraphics();

            font = new Font("Arial", 9, FontStyle.Regular);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int x = 0, number = 0; x < Width; x = x + 30, number = number + 30)
            {
                graphics.DrawString(Convert.ToString(number), font, Brushes.Black, new Point(x, 0));
                graphics.DrawLine(Pens.Black, new Point(x, 0), new Point(x, Height));
            }

            for (int y = 0, number = 0; y < Width; y = y + 30, number = number + 30)
            {
                graphics.DrawString(Convert.ToString(number), font, Brushes.Black, new Point(0, y));
                graphics.DrawLine(Pens.Black, new Point(0, y), new Point(Width, y));
            }
        }
    }
}
