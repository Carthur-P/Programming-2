/* Program name:          ScreenSaver
 * Project file name:     Screen Saver
 * Author:                Carthur Pongpatimet
 * Date:                  16/10/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 *
 * Purpose:               To make a screensaver that slowly fills up with shapes
 *
 * Description:           Controller - controls what polygon is created and drawing it onto the form
 *                        Polygon - a base class for all polygon objects
 *                        Square - creating a square shape polygon
 *                        Triangle - creating a triangle shape polygon
 *                        Circle - creating a circle shape polygon
 *                          
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class Form1 : Form
    {
        private const int MAXCOUNT = 1000;

        private Controller controller;
        private Graphics graphics;
        private Random rand;
        private int count;
        private int width;
        private int height;

        public Form1()//constructor
        {
            InitializeComponent();
            graphics = CreateGraphics();
            rand = new Random();
            width = ClientSize.Width;
            height = ClientSize.Height;
            controller = new Controller(graphics, rand);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)//everytime the timer ticks create a polygon and draw it
        {
            count = count + 1;

            if (count <= MAXCOUNT)
            {
                controller.CreatePolygon(width, height);
                controller.Draw();
            }

            else
            {
                count = 0;
                Refresh();
            }
        }
    }
}
