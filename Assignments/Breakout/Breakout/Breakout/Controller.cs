/* This will control the gameplay of the program. Aspect such as organizing the bricks at the top of the form, 
 * moving the paddle and ball, keeping track of scores and lives
 */

using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Breakout
{
    public class Controller
    {
        private const int PADDLEY = 430;
        private const int FONTSIZE1 = 40;
        private const int FONTSIZE2 = 25;
        private const int LIVES = 3;
        private const int BALLX = 220;
        private const int BALLY = 150;
        private const int TEXT1X = 70;
        private const int TEXT1Y = 200;
        private const int TEXT2X = 110;
        private const int TEXT2Y = 180;
        private const int TEXT3X = 95;
        private const int TEXT3Y = 70;
        private const int TEXT4X = 130;
        private const int TEXT4Y = 200;
        private const int TEXT5X = 50;
        private const int TEXT5Y = 240;
        private const int TEXT6X = 100;
        private const int TEXT6Y = 250;
        private const int TEXT7X = 130;
        private const int TEXT7Y = 70;

        private Graphics graphics;
        private Brush brush;
        private Paddle paddle;
        private Ball ball;
        private Brick brick;
        private Label livesLabel;
        private Label scoreLabel;
        private Timer timer1;
        private SoundPlayer bouncingSound;
        private SoundPlayer gameOver;
        private Font font1;
        private Font font2;
        private int width;
        private int height;
        private int lives;
        private int score;
        private int bounce;
        private int highscore;

        public Controller(Graphics graphics, int width, int height, Label livesLabel, Label scoreLabel, Timer timer1, SoundPlayer bouncingSound, SoundPlayer gameOver)//contructor
        {
            this.graphics = graphics;
            this.livesLabel = livesLabel;
            this.scoreLabel = scoreLabel;
            this.timer1 = timer1;
            this.width = width;
            this.height = height;
            this.bouncingSound = bouncingSound;
            this.gameOver = gameOver;
            brush = new SolidBrush(Color.White);
            paddle = new Paddle(graphics, Color.White, new Point(0, PADDLEY));
            brick = new Brick(graphics, Color.White, new Point(0, 0), width);
            font1 = new Font("Microsoft Sans Serif", FONTSIZE1, FontStyle.Bold);
            font2 = new Font("Microsoft Sans Serif", FONTSIZE2, FontStyle.Bold);
            highscore = 0;
        }

        public void MovePaddle(int mousePointX)//moving the paddle to mouse loaction
        {
            paddle.Move(mousePointX);
        }

        private void MoveBall()//moving the ball around the form
        {
            score = ball.BounceOffBrick(brick, score, bounce);
            bounce = ball.BounceOffpaddle(paddle, bounce);
            ball.BounceOffBottom();
            ball.Draw();
            ball.Move();
        }

        public void GameRun()//this is what happens everytime the timer ticks, the gameplay of the game
        {
            paddle.Draw();
            brick.Draw(bounce);
            MoveBall();
            SettingHighscore();
            GameLose();
            GameEnd();
            livesLabel.Text = lives.ToString();
            scoreLabel.Text = score.ToString();
        }

        public void GameStart()//setting everything up for a new game
        {
            lives = LIVES;
            score = 0;
            bounce = 0;
            brick.BrickManger();
            ball = new Ball(graphics, Color.White, new Point(BALLX, BALLY), width, height, bouncingSound);
        }

        private void GameEnd()//checking to see if the game have ended
        {
            if (lives == 0)//loosing all 3 lives
            {
                graphics.DrawString("Game over", font1, brush, TEXT1X, TEXT1Y);
                timer1.Enabled = false;
                gameOver.Play();
            }

            if (brick.BrickPositions.Count == 0)//bricks has all benn destroyed
            {
                graphics.DrawString("You win!", font1, brush, TEXT2X, TEXT2Y);
                graphics.DrawString("Score x " + lives, font1, brush, TEXT6X, TEXT6Y);
                score = score * lives;
                SettingHighscore();
                scoreLabel.Text = score.ToString();
                timer1.Enabled = false;
            }
        }

        public void PauseMenu()//showing the text for pause menu 
        {
            graphics.FillRectangle(Brushes.Black, 0, 0, width, height);
            graphics.DrawString("Pause", font1, brush, TEXT7X, TEXT7Y);
        }

        public void StartMenu()//showing the text for start menu
        {
            graphics.FillRectangle(Brushes.Black, 0, 0, width, height);
            graphics.DrawString("Breakout", font1, brush, TEXT3X, TEXT3Y);
        }

        private void GameLose()//subtracting a live and displaying this information to the user
        {
            if (ball.BallPosition.Y > height)
            {
                lives = lives - 1;
                bounce = 0;
                if (lives > 0)
                {
                    graphics.DrawString(lives + " lives left", font2, brush, TEXT4X, TEXT4Y);
                    graphics.DrawString("Press 'C' to continue", font2, brush, TEXT5X, TEXT5Y);
                    timer1.Enabled = false;
                }
            }
        }

        public void SettingHighscore()//setting the highscore
        {
            if (score > highscore)//if the current score is larger than the score in highscore, replace it with the current score
            {
                highscore = score;
            }
        }

        public int Lives
        {
            get
            {
                return lives;
            }
        }

        public int BrickCount
        {
            get
            {
                return brick.BrickPositions.Count;
            }
        }

        public int Highscore
        {
            get
            {
                return highscore;
            }
        }
    }
}
