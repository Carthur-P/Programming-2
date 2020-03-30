/* Program name:          Pacman
 * Project file name:     Pacman
 * Author:                Carthur Pongpatimet
 * Date:                  25/09/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 *
 * Purpose:               To create a classic arcade game Pacman where you control Pacman around a maze, while trying to eat kibbles and 
 *                        avoiding ghouls. 
 *
 * Description:           Gameplay – Pacman will have three lives at the start of the game and will loose a life if it is eaten by the ghouls. 
 *                        If Pacman looses all its lives then the game ends with the player loosing. For the player to win, Pacman must eat all
 *                        the kibble on the screen by moving over them. 
 * 
 *                        Pacman – Pacman character is controlled using the arrow keys and will move one grid space per key press. Pacman 
 *                        cannot move through solid walls of the maze and will loose a life when collide with the ghoul characters.
 *                        Pacman will start off with three lives and the game will end when all three lives are lost. Pacman will also
 *                        eat the kibble that exist throughout the maze causing the kibble to disappear and granting the player 1 point.
 *                        There is only one Pacman per game.  
 *                        
 *                        Ghouls – The four ghoul characters will start in all four corners of the maze and will move in a random direction 
 *                        at the start. The ghouls will start to chase after Pacman at a 50% chance when their vertical or horizontal position
 *                        are align. If the ghouls collides with Pacman, Pacman will die and the player will lose one life. The ghoul character
 *                        cannot move through walls and when the character collide with a wall, its direction will be change randomly. 
 *                        There are four ghoul characters in the game. 
 *                        
 *                        Kibbles – The kibbles will disappear when Pacman collides with it and will grant the player 1 point that will tally up
 *                        throughout the game. The kibbles will occupy all the spaces that is not a wall in the maze at the start of the game. 
 *                        
 *                        Maze – Using the inherit data grid view properties, a maze is a 21 by 21 grid which are made up of walls, kibble and
 *                        blank spaces. The maze is the space that all the characters will move around in. 
 *                     
 * Known bugs:            Pacman can sometimes glitch through the ghouls due to collision detection code. However due to the ghoul chasing code,
 *                        the ghoul often change direction and catch pacman anyway. 
 *  
 * Additional features:   Menu – Player can use the menu to start a new game, pause the game and exit the game. New game cannot be start while 
 *                        the game is playing, if the player wish to start a new game, the player must pause the game first. The menu also shows 
 *                        the score and how many lives Pacman has left. 
 *                        
 *                        Lives – Pacman’s lives are display using three picture boxes with each picture box representing a life. The picture will 
 *                        become invisible with each Pacman’s death leaving the current amount of lives left on the screen.   
 *                        
 *                        Sounds – Adding sounds such as intro music, Pacman eating kibble and Pacman death to make the game more aesthetically 
 *                        pleasing and further engage and immerse the player. 
 *                        
 *                        Ghouls chasing Pacman - The ghouls will start to chase after Pacman at a 50% chance when their vertical or horizontal 
 *                        position are align. This ensure that the ghouls can trap Pacman instead of moving around the maze aimlessly. 
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private const int FONTSIZE1 = 12;
        private const int FONTSIZE2 = 14;
        private const int OVERX = 577;
        private const int OVERY = 364;
        private const int WINX = 590;
        private const int WINY = 364;
        private const int SLEEP = 4200;

        private Maze maze;
        private Controller controller;
        private Random rand;
        private bool pause;
        private Bitmap k;
        private Bitmap w;
        private Bitmap b;
        private SoundPlayer intro;
        private SoundPlayer win;
        private PrivateFontCollection pfc;

        public Form1()//constructor
        {
            InitializeComponent();
            intro = new SoundPlayer(Properties.Resources.Intro);
            win = new SoundPlayer(Properties.Resources.Win);
            k = Properties.Resources.Kibble;
            w = Properties.Resources.Wall;
            b = Properties.Resources.Blank;
            this.KeyPreview = true;
            maze = new Maze(k,w,b);
            rand = new Random();
            Controls.Add(maze);
            controller = new Controller(rand, maze, label1);
            maze.Draw();
            button2.Enabled = false;
            pfc = new PrivateFontCollection();

            try
            {
                pfc.AddFontFile("..\\..\\..\\..\\Resources\\Font\\Arcade.ttf");
                button1.Font = new Font(pfc.Families[0], FONTSIZE1, FontStyle.Regular);
                button2.Font = new Font(pfc.Families[0], FONTSIZE1, FontStyle.Regular);
                button3.Font = new Font(pfc.Families[0], FONTSIZE1, FontStyle.Regular);
                label1.Font = new Font(pfc.Families[0], FONTSIZE1, FontStyle.Regular);
                label2.Font = new Font(pfc.Families[0], FONTSIZE1, FontStyle.Regular);
                label3.Font = new Font(pfc.Families[0], FONTSIZE2, FontStyle.Regular);
            }

            catch (FileNotFoundException)//if font file cannot be found
            {
                MessageBox.Show("Font file is not found.\nStandard font will be use instead.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)//timer tick event 
        {
            if (controller.GameEnd == false)
            {
                controller.GamePlay();
                controller.SetLives(pictureBox1, pictureBox2, pictureBox3);
            }

            if (controller.GameEnd == true)
            {
                timer1.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = false;
                label3.Text = "Game Over";
                label3.Location = new Point(OVERX, OVERY);
                label3.Visible = true;
            }

            if (controller.GameWin == true)
            {
                win.Play();
                timer1.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = false;
                label3.Text = "You Win!";
                label3.Location = new Point(WINX, WINY);
                label3.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//key press event
        {
            if (controller.GameEnd == false)//ensure that the key press event only do something when the game has not ended
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            controller.MovePacman(Direction.up);
                            break;
                        }

                    case Keys.Down:
                        {
                            controller.MovePacman(Direction.down);
                            break;
                        }

                    case Keys.Left:
                        {
                            controller.MovePacman(Direction.left);
                            break;
                        }

                    case Keys.Right:
                        {
                            controller.MovePacman(Direction.right);
                            break;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//new game button click event
        {
            button2.Text = "Pause";
            pause = false;
            timer1.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = true;
            intro.Play();
            Thread.Sleep(SLEEP);
            controller.StartNewGame();
            label3.Visible = false;
            Application.DoEvents();
        }

        private void button2_Click(object sender, EventArgs e)//pause and start button click event
        {
            if (pause == false)
            {
                timer1.Enabled = false;
                button1.Enabled = true;
                button2.Text = "Start";
                pause = true;
            }
            else if (pause == true)
            {
                timer1.Enabled = true;
                button1.Enabled = false;
                button2.Text = "Pause";
                pause = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)//exit button click event
        {
            Application.Exit();
        }
    }
}
