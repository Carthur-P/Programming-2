/* Program name:          TrafficLights
 * Project file name:     TrafficLights
 * Author:                Carthur Pongpatimet
 * Date:                  08/09/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 *
 * Purpose:               To make three circles flash diffrent colours at varied speeds depending on the colour and speed
 *                        selected in the menu strip
 *
 * Description:           Lights - this will control each individual cirle and will draw the circle onto the form in the
 *                        colour set in the trafficlight class
 *                        
 *                        TrafficLight - this is the program's engine, it will set all three circles colours and the 
 *                        interval of the circles displaying a different colour. 
 *                          
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class Form1 : Form
    {
        private const int SLOW = 3000;
        private const int MEDIUM = 1000;
        private const int FAST = 500;

        private Graphics graphics;
        private TrafficLight trafficlight;
        private Random rand;

        public Form1()
        {
            InitializeComponent();
            graphics = CreateGraphics();
            rand = new Random();
            trafficlight = new TrafficLight(graphics,rand);
        }

        private void traditionalToolStripMenuItem_Click(object sender, EventArgs e)//when the traditional menu strip is selected, set colour
        {
            trafficlight.SetTraditionalColor();
        }

        private void mixedTraditionalToolStripMenuItem_Click(object sender, EventArgs e)//when the mixed traditional menu strip is selected, set colour
        {
            trafficlight.SetMixedColor();
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)//when the slow menu strip is selected, set sleepinterval
        {
            trafficlight.SetSleepInterval(SLOW);
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)//when the medium menu strip is selected, set sleepinterval
        {
            trafficlight.SetSleepInterval(MEDIUM);
        }

        private void fastToolStripMenuItem_Click(object sender, EventArgs e)//when the fast menu strip is selected, set sleepinterval
        {
            trafficlight.SetSleepInterval(FAST);
        }

        private void button1_Click(object sender, EventArgs e)//when button1 is clicked flash the lights
        {
            trafficlight.Flash();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)//when the graphics is painted onto the form, draw the lights onto the form
        {
            trafficlight.Draw();
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)//when the random menu strip is selected, set colour
        {
            trafficlight.SetRandomColor();
        }
    }
}
