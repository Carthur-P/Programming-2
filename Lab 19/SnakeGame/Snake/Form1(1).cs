using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public Form1()
        {
            InitializeComponent();

            // set the Properties of the form
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;
            KeyPreview = true;

            random = new Random();
            grid = new Grid(Properties.Resources.blank);
            // important, need to add the grid object to the list of controls on the form
            Controls.Add(grid);

            gameManager = new GameManager(grid, random);
            gameManager.StartNewGame();

            // remember the Timer Enabled Property is set to false as a default
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (gameManager.PlayGame())
            {
                case ErrorMessage.snakeHitSelf:
                {
                        break;
                }

                case ErrorMessage.snakeHitWall:
                {
                        break;
                }

                case ErrorMessage.snakeEatenFrog:
                {
                        break;
                }

                default:
                {
                    break;
                }
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
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
  