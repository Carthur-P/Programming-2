/* Program name:          Breakout
 * Project file name:     Breakout
 * Author:                Carthur Pongpatimet
 * Date:                  05/09/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 *
 * Purpose:               To make a ‘breakout’ game where the ball bounces around the form, controlled by a paddle at the bottom of the form, 
 *                        destroying bricks at the top of the form. 
 *
 * Description:           Ball - The ball will move around the form and bounce of the two sides and the top of the form. If the ball goes pass
 *                        the bottom of the form the player will loose a life. The ball will also bounce of the paddle object at the bottom of 
 *                        the form and the brick objects at the top of the form which will cause the brick to disappear.
 *  
 *                        Paddle - The paddle will be controlled by the user with the mouse. This will only move horizontally at the bottom of 
 *                        the form and is use to prevent the ball from reaching the bottom of the form.
 *                        
 *                        Bricks - There will be multiple bricks across the width of the form in six rows. These bricks will get disappear when
 *                        the ball bounces of it earning the player scores. 
 *                     
 * Known bugs:            Ball sometimes gets stuck in paddle
 *  
 * Additional features:   Menu – there are two menus, start menu and in game menu that also acts as a pause screen in game. The start menu will allow
 *                        the player to start a new game, exit and check high score once a game have been played. The in game menu acts as a pause 
 *                        screen and allows the user to resume game, start a new game and exit. 
 *                        
 *                        Lives – lives acts as the number of attempts the player has to win the game. When the ball reaches the bottom of the form,
 *                        the player looses a life. The player starts off with 3 lives and if the player wins the game, the score is multiplied by the 
 *                        amount of lives left. If the player looses all three lives then the game is over.
 *                        
 *                        Score – every brick the player destroys gives 10 points. If the player can keep the ball up by consecutive bouncing the ball
 *                        of the paddle 8 times, the score per brick destroyed will increase to 20 points. If the player can continue keeping the ball
 *                        up by consecutive bouncing the ball of the paddle 16 times in total, the score per brick destroyed will increase to 40 points.  
 *                        
 *                        High score – The player can check the high score in the start menu once a game have been played. The high score will update
 *                        automatically once a new high score have been achieve. 
 *                        
 *                        Sounds – Adding game sounds such as ball bouncing and a game over sound
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Breakout
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Graphics bufferGraphics;
        private Image bufferImage;
        private Controller controller;
        private SoundPlayer bouncingSound;
        private SoundPlayer gameOver;
        private int width;
        private int height;
        private bool menu;
        
        public Form1()//constructor
        {
            InitializeComponent();
            KeyPreview = true;
            menu = false;
            width = ClientSize.Width;
            height = ClientSize.Height;
            bufferImage = new Bitmap(width, height);
            bufferGraphics = Graphics.FromImage(bufferImage);
            graphics = CreateGraphics();
            bouncingSound = new SoundPlayer(Properties.Resources.BounceSound);//instruction from https://stackoverflow.com/questions/4125698/how-to-play-wav-audio-file-from-resources
            gameOver = new SoundPlayer(Properties.Resources.GameOver);
            controller = new Controller(bufferGraphics, width, height, label3, label4, timer1, bouncingSound, gameOver);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)//move paddle to the mouse location everytime mouse move in form
        {
            controller.MovePaddle(e.X);
        }

        private void timer1_Tick(object sender, EventArgs e)//everytime the timer tick the game runs
        {
            bufferGraphics.FillRectangle(Brushes.Black, 0, 0, width, height); //acts like the refresh method drawing a blank screen
            controller.GameRun();
            graphics.DrawImage(bufferImage, 0, 0); //drawing from the image that was created
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//showing the game's menu or continuing the game
        {
            if (e.KeyCode == Keys.C)//pressing the 'C' key will start the timer again
            {
                if ((controller.Lives > 0) && (controller.BrickCount > 0) && (menu == false))
                {
                    timer1.Enabled = true;
                }
            }

            if (e.KeyCode == Keys.M)//pressing 'M' key will show start menu/pause screen
            {
                Cursor.Show();
                if ((controller.BrickCount == 0) || (controller.Lives == 0))//if game is over, start screen
                {
                    timer1.Enabled = false;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    controller.StartMenu();
                    graphics.DrawImage(bufferImage, 0, 0);
                }

                else//if game is still going, pause screen
                {
                    timer1.Enabled = false;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    controller.PauseMenu();
                    graphics.DrawImage(bufferImage, 0, 0);
                    menu = true;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)//when form shows, show the start menu
        {
            controller.StartMenu();
            graphics.DrawImage(bufferImage, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)//resuming the game that was paused
        {
            timer1.Enabled = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            Cursor.Hide();
            menu = false;
        }

        private void button3_Click(object sender, EventArgs e)//starting a new game 
        {
            controller.GameStart();
            timer1.Enabled = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            Cursor.Hide();
            menu = false;
        }

        private void button4_Click(object sender, EventArgs e)//closing the program
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)//showing the high score to the player
        {
            MessageBox.Show("Your highscore is " + controller.Highscore.ToString());
        }
    }
}
