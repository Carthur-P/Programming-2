/* Program name:          Molecules Simulation
 * Project file name:     MoleculeSimulation
 * Author:                Carthur Pongpatimet
 * Date:                  18/08/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To creat a program that would simulate dispersion of different coloured liquid over a long 
 *                        period of time
 * 
 * Description:           When the 'start' button is clicked, the program will run and generate 150 different dots, 
 *                        representing molecule particles. These are seperated into 3 different colours. The dots will 
 *                        start to move in random directions and over time, these different coloured dots will be all 
 *                        mixed up and scattered all over the form. When the 'pause' button is clicked, the simulation
 *                        will pause. When the 'exit' button is clicked, the program will exit.
 *                        
 * Known bugs:            None
 * 
 * Additional features:   Adding an exit button to the program which will close down the program when clicked.
 */

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MoleculeSimulation
{
    public partial class Form1 : Form
    {
        private Controller controller;
        private Random rand;
        private Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            graphics = CreateGraphics();
            rand = new Random();
            controller = new Controller(rand, graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        //this will start the timer

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        //this will stop the timer

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            controller.Run();
            Thread.Sleep(100);
        }
        //everytime the timer ticks, refresh the form and run the 'run' method from controller class 

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        //exit the program
    }
}
