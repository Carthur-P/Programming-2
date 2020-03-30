//This class will draw a circle shape object onto the form which will move, bounce of the form, bounce of the bricks and bounce of the paddle

using System.Drawing;
using System.Media;

namespace Breakout
{
    public class Ball
    {
        private const int SIZE = 10;
        private const int VELOCITY = 5;
        private const int PADDLEWIDTH = 100;
        private const int PADDLEHEIGHT = 10;
        private const int BRICKWIDTH = 50;
        private const int BRICKHEIGHT = 20;
        private const int SCOREUP = 10;
        private const int SCOREUP2 = 20;
        private const int SCOREUP3 = 40;
        private const int BALLX = 220;
        private const int BALLY = 150;
        private const int BOUNCELIMIT = 8;
        private const int BOUNCELIMIT2 = 16;

        private Graphics graphics;
        private Brush brush;
        private Point velocity;
        private Point ballPosition;
        private SoundPlayer bouncingSound;
        private int width;
        private int height;

        public Ball(Graphics graphics, Color color, Point ballPosition, int width, int height, SoundPlayer bouncingSound)//contructor 
        {
            this.graphics = graphics;
            this.ballPosition = ballPosition;
            this.width = width;
            this.height = height;
            this.bouncingSound = bouncingSound;
            velocity = new Point(VELOCITY, VELOCITY);
            brush = new SolidBrush(color);
        }

        public void Move()//this will move the ball by the velocity value
        {
            ballPosition.X = ballPosition.X + velocity.X;
            ballPosition.Y = ballPosition.Y + velocity.Y;
            BounceOffForm();
        }

        public void Draw()//drawing the ball onto the form
        {
            graphics.FillEllipse(brush, ballPosition.X, ballPosition.Y, SIZE, SIZE);
        }

        private void BounceOffForm()//change the ball's direction (bounce) when it hits the top, left and right of the form
        {
            if ((ballPosition.X <= 0) || ((ballPosition.X + SIZE) >= width))//collision detection for ball against left and right of form
            {
                velocity.X = velocity.X * - 1;
                ballPosition.X = ballPosition.X + velocity.X;
                ballPosition.Y = ballPosition.Y + velocity.Y;
                bouncingSound.Play();
            }

            if (ballPosition.Y <= 0)//collision detection for ball against top of form
            {
                velocity.Y = velocity.Y * - 1;
                ballPosition.X = ballPosition.X + velocity.X;
                ballPosition.Y = ballPosition.Y + velocity.Y;
                bouncingSound.Play();
            }
        }

        public void BounceOffBottom()//this will move the ball back to its starting point when it reach the bottom of the form
        {
            if (ballPosition.Y > height)//collision detection for ball against bottom of the form
            {
                ballPosition.X = BALLX;
                ballPosition.Y = BALLY;
            }
        }

        public int BounceOffpaddle(Paddle paddle, int bounce)//change the direction of the ball (bounce) when it hits the paddle
        {
            if ((ballPosition.Y + SIZE >= paddle.PaddlePoint.Y) && (ballPosition.Y + SIZE <= paddle.PaddlePoint.Y + PADDLEHEIGHT)
                && (ballPosition.X >= paddle.PaddlePoint.X) && (ballPosition.X + SIZE <= paddle.PaddlePoint.X + PADDLEWIDTH))
                //collision detection for ball against paddle
            {
                velocity.Y = velocity.Y * - 1;
                bounce = bounce + 1;
                ballPosition.X = ballPosition.X + velocity.X;
                ballPosition.Y = ballPosition.Y + velocity.Y;
                bouncingSound.Play();
            }
            return bounce;
        }

        public int BounceOffBrick(Brick brick, int score, int bounce)//change the direction of the ball when it hits the brick causing the brick to disappear
        {
            for (int i = 0; i < brick.BrickPositions.Count; i++)
            {
                if ((ballPosition.Y <= brick.BrickPositions[i].Y + BRICKHEIGHT) && (ballPosition.Y + SIZE >= brick.BrickPositions[i].Y) 
                    && (ballPosition.X + SIZE >= brick.BrickPositions[i].X) && (ballPosition.X <= brick.BrickPositions[i].X + BRICKWIDTH))
                    //collison detection of the ball agaisnt brick
                {
                    brick.Explode(i);//making the brick that the ball collide with dissapear
                    velocity.Y = velocity.Y * - 1;
                    bouncingSound.Play();

                    if (bounce <= BOUNCELIMIT)//ball bouncing of the paddle is less thatn 8 times
                    {
                        score = score + SCOREUP;//score plus 10
                    }

                    if ((bounce > BOUNCELIMIT) && (bounce <= BOUNCELIMIT2))//ball bouncing of the paddle is more than 8 times but less than 16 times
                    {
                        score = score + SCOREUP2;//score plus 20
                    }

                    if (bounce > BOUNCELIMIT2)//ball bouncing of the paddle is more than 16 times
                    {
                        score = score + SCOREUP3;//score plus 40
                    }
                }
            }
            return score;
        }

        public Point BallPosition
        {
            get
            {
                return ballPosition;
            }
        }
    }
}
