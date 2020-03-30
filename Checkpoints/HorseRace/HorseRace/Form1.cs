/* Program name:          HorseRace
 * Project file name:     HorseRace
 * Author:                Carthur Pongpatimet
 * Date:                  08/08/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To move multiple picture boxes at a random rate to simulate a race between them.
 * 
 * Description:           Click the 'start race' button and watch the four horse move toward the finishing line.
 *                        A message box will pop up showing which horse crossed the finish line first and won.
 *                        
 * Known bugs:            Due to the way the program reads the order of the pictureBox and where it reads the pictureBox 
 *                        location relating to the finish line, sometimes when the race is close, the horse that appear to
 *                        have won on the form is not the horse that is shown in the message box to have won.
 * 
 * Additional features:   None
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

namespace HorseRace
{
    public partial class Form1 : Form
    {
        private Random rand;
        private PictureBox[] pictureBox;
        private Controller game;
   
        public Form1()
        {
            InitializeComponent();
            rand = new Random();

            pictureBox = new PictureBox[4];
            pictureBox[0] = pictureBox1;
            pictureBox[1] = pictureBox2;
            pictureBox[2] = pictureBox3;
            pictureBox[3] = pictureBox4;

            game = new Controller(pictureBox, rand, panel1.Left);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Reset();
            game.GameOn = true;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (game.GameOn == true)
            {
                game.StartRace();
            }
            else if (game.GameOn == false)
            {
                timer1.Enabled = false;
            }
        }
    }
}
