/* Program name:          Bouncing Shapes
 * Project file name:     BouncingShapes
 * Author:                Carthur Pongpatimet
 * Date:                  22/08/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To generate a circle which will move around the the form and bounce of the edge of the 
 *                        form
 * 
 * Description:           Controller - This is the application engine which controls what happens when the program 
 *                        is running
 *                       
 *                        Balls - The three balls will move around the form and bounce of the edge of the form. 
 *                        The speed of the ball is controlled by the three trackbars, one for each ball
 *                        
 * Known bugs:            The ball changes direction if its moving in a negative direction when the trackbar is
 *                        scrolled
 * 
 * Additional features:   Adding a double buffer to make the movement smoother
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace BouncingShapes
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Graphics bufferGraphics;
        private Controller controller;
        private int width;
        private int height;
        private Image bufferImage;


        public Form1()//constuctor
        {
            InitializeComponent();
            graphics = CreateGraphics();
            width = ClientSize.Width;
            height = ClientSize.Height;
            bufferImage = new Bitmap(width, height);
            bufferGraphics = Graphics.FromImage(bufferImage);
            controller = new Controller(bufferGraphics, width, height);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)//timer 1 tick
        {
            bufferGraphics.FillRectangle(Brushes.White, 0, 0, width, height);
            controller.Run();
            graphics.DrawImage(bufferImage, 0, 0);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)//setting the velocity using trackbar 1
        {
            Point velocity = new Point(trackBar1.Value, trackBar1.Value);
            controller.ChangeGreenBallVelocity(velocity);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)//setting the velocity using trackbar 2
        {
            Point velocity = new Point(trackBar2.Value, trackBar2.Value);
            controller.ChangeRedBallVelocity(velocity);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)//setting the velocity using trackbar 3
        {
            Point velocity = new Point(trackBar3.Value, trackBar3.Value);
            controller.ChangeBlueBallVelocity(velocity);
        }
    }
}
