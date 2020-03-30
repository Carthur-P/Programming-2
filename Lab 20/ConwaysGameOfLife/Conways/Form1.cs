/* Program name:          Conways
 * Project file name:     ConwayGameOfLife
 * Author:                Carthur Pongpatimet
 * Date:                  27/10/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 *
 * Purpose:               To make the simulation 'Conway's Game of Life'
 *
 * Description:           Grid - This will set up the grid for the simulation
 *                        
 *                        World - Acts as the game engine and controls the behaviour such as drawing the cells and 
 *                        setting the colours of the cells
 *                        
 *                        Cell - This implements the rules of the game and check to see if the cell will be alive in 
 *                        the next generation or not 
 *                          
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Windows.Forms;

namespace Conways
{
    public partial class Form1 : Form
    {
        private const int FORMHEIGHT = 600;
        private const int FORMWIDTH = 700; 
        
        private Random random;
        private Grid grid;
        private World world;
        private int nGeneration;

        public Form1()//constructor
        {
            InitializeComponent();
            random = new Random();
            nGeneration = 0;
            grid = new Grid();
            world = new World(random, grid);
            Controls.Add(grid);

            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;
        }

        private void timer1_Tick(object sender, EventArgs e)//every timer tick the following action will occur
        {
            world.UpdateWorld();
            world.Draw();
            nGeneration = nGeneration + 1;
            label1.Text = nGeneration.ToString();
        }

        private void button1_Click(object sender, EventArgs e)//generating a new simulation
        {
            world.Clear();
            world.Fill();
            world.Draw();
            nGeneration = 0;
            label1.Text = nGeneration.ToString();

        }

        private void button2_Click(object sender, EventArgs e)//clearing the datagridview 
        {
            world.Clear();
            world.Draw();
            nGeneration = 0;
            label1.Text = nGeneration.ToString();
        }
        
        private void button3_Click(object sender, EventArgs e)//running the simulation
        {
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)//pausing the simulation
        {
            timer1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)//going to the next step without the timer ticking (acts as one timer tick)
        {
            world.UpdateWorld();
            world.Draw();
            nGeneration = nGeneration + 1;
            label1.Text = nGeneration.ToString();
        }
    }
}
