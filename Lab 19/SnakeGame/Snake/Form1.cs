/* Program name:          SnakeGame
 * Project file name:     SnakeGame
 * Author:                Carthur Pongpatimet
 * Date:                  24/10/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 *
 * Purpose:               To make a classic game snake 
 *
 * Description:           GameManager - acts as the game engine which controlls the all aspect of the gameplay
 * 
 *                        Creature - base class for all creatures in the game
 *                        
 *                        Snake - The snake creature which is controlled by the player using the arrow keys, the 
 *                        snake will move in the same direction until the direction is change with the arrow keys.
 *                        The snake will eat the frog using its head and will gain one length of body per frog eaten.
 *                        The snake cannot eat itelf or hit the grid walls with its head, this will cause the game to
 *                        end.
 *                        
 *                        Frog - The frog once spawn will not move. If the snake eats the frog the frog will move to
 *                        a new random position that is free on the grid
 *                          
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private const int FORMHEIGHT = 600;
        private const int FORMWIDTH = 800; 
        
        private Grid grid;
        private Random random;
        private GameManager gameManager;
        private bool gameRun;

        public Form1()//constructor
        {
            InitializeComponent();

            // set the Properties of the form
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;
            KeyPreview = true;

            gameRun = true;
            random = new Random();
            grid = new Grid(Properties.Resources.blank);
            Controls.Add(grid); // important, need to add the grid object to the list of controls on the form
            grid.Draw();

            gameManager = new GameManager(grid, random);
            gameManager.StartNewGame();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)//every timer tick
        {
            switch (gameManager.PlayGame())
            {
                case ErrorMessage.snakeHitSelf:
                {
                        timer1.Enabled = false;
                        MessageBox.Show("You ate yourself");
                        break;
                }

                case ErrorMessage.snakeHitWall:
                {
                        timer1.Enabled = false;
                        MessageBox.Show("You have hit the wall");
                        break; 
                }

                case ErrorMessage.snakeEatenFrog:
                {
                        int numberOfFrog = Convert.ToInt32(textBox1.Text);
                        numberOfFrog = numberOfFrog + 1;
                        textBox1.Text = numberOfFrog.ToString();
                        break;
                }

                default:
                {
                    break;
                }
            } 
        }

        private void button1_Click(object sender, EventArgs e)//new game button
        {
            gameManager.StartNewGame();
            timer1.Enabled = true;
            textBox1.Text = "0";
        }
        
        private void button2_Click(object sender, EventArgs e)//start/stop button
        {
            if (gameRun == true)
            {
                timer1.Enabled = false;
                button2.Text = "Stop";
                gameRun = false;
            }

            else if (gameRun == false)
            {
                timer1.Enabled = true;
                button2.Text = "Start";
                gameRun = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)//exit button
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//arrow key press
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    gameManager.SetSnakeDirection(Direction.Left);
                    break;

                case Keys.Right:
                    gameManager.SetSnakeDirection(Direction.Right);
                    break;

                case Keys.Up:
                    gameManager.SetSnakeDirection(Direction.Up);
                    break;

                case Keys.Down:
                    gameManager.SetSnakeDirection(Direction.Down);
                    break;

                default:
                    break;
            }
        }

    }
}
  