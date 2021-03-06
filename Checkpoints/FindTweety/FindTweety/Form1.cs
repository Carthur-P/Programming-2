﻿/* Program name:          FindTweety
 * Project file name:     Find Tweety 
 * Author:                Carthur Pongpatimet
 * Date:                  03/11/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 *
 * Purpose:               To create a clickable area on the form which will then display something behind it. The 
 *                        goal is the find Tweety and avoid Syvester
 *
 * Description:           Board - This is similar to a game engine. It controls all the function of the game such as
 *                        assigning winning and loosing square, choosing what square should display what and setting
 *                        things up for a new game.
 *                        
 *                        Square - this is the individual square which will display itself when told to by the
 *                        controller class. 
 *                          
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FindTweety
{
    public partial class Form1 : Form
    {
        private Board board;
        private Graphics graphics;
        private Random rand;
        private int wins;
        private int lose;

        public Form1()//constructor
        {
            InitializeComponent();
            rand = new Random();
            graphics = panel1.CreateGraphics();
            board = new Board(graphics, rand);
            wins = 0;
            lose = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)//when mouse is clicked inside the panel
        {
            Status result = board.PlaySquare(e.Location);

            switch (result)
            {
                case Status.win:
                    {
                        MessageBox.Show("You win!");
                        wins++;
                        textBox1.Text = wins.ToString();
                        textBox2.Text = lose.ToString();
                        board.SetupNewGame();
                        break;
                    }
                case Status.lose:
                    {
                        MessageBox.Show("You lose");
                        lose++;
                        textBox2.Text = lose.ToString();
                        textBox1.Text = wins.ToString();
                        board.SetupNewGame();
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)//when the play agian button is clicked
        {
            board.SetupNewGame();
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            board.SetupNewGame();
        }
    }
}
