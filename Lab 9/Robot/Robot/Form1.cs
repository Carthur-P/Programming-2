/* Program name:          Robot
 * Project file name:     Robot
 * Author:                Carthur Pongpatimet
 * Date:                  15/08/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To draw a line using the mouse and to get a picture box to follow the line.
 * 
 * Description:           Draw a line by clicking and holding the mouse down while dragging the mouse to form the
 *                        the desired line. Now click the 'start robot' button and watch the robot follow the line 
 *                        that was drawn.
 *                        
 * Known bugs:            None
 * 
 * Additional features:   Only one line can be drawn at a time, when mouse click to draw another line, the form will 
 *                        clear the previously drawn line.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Pen pen;
        private Path path;
        private Robot robot;
        public Form1()
        {
            InitializeComponent();

            graphics = CreateGraphics();

            pen = new Pen(Brushes.Black, 4.0F);
            path = new Path();
            robot = new Robot(pictureBox1);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Refresh();
            //this will refresh the form which will clear all the previous drawn line
            path.StartPath(e.Location);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            path.DrawPath(graphics, pen, e.Location);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            path.EndPath();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            robot.WalkPath(path);
        }
    }
}
