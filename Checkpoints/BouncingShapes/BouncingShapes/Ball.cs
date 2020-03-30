//this controls the ball behavior such as moving, bouncing and drawing

using System.Drawing;

namespace BouncingShapes
{
    public class Ball
    {
        private const int SIZE = 80;
        private const int STARTVELOCITY = 10;

        private Graphics graphics;
        private Brush brush;
        private Point position;
        private Point velocity;
        private int width;
        private int height;

        public Ball(Graphics graphics, Color color, Point position, int width, int height)//constructor
        {
            this.graphics = graphics;
            this.position = position;
            this.width = width;
            this.height = height;
            velocity = new Point(STARTVELOCITY, STARTVELOCITY);
            brush = new SolidBrush(color);
        }

        public void Move()//move the balls by the velocity amount
        {
            position.X = position.X + velocity.X;
            position.Y = position.Y + velocity.Y;
            Bounce();
        }

        private void Bounce()//bounces the balls of the form
        {
            if ((position.X <= 0) || (position.X + SIZE >= width))
            {
                velocity.X = velocity.X * -1;
            }

            if ((position.Y <= 0) || (position.Y + SIZE >= height))
            {
                velocity.Y = velocity.Y * -1;
            }
        }

        public void Draw()//drawing the ball onto the form
        {
            graphics.FillEllipse(brush, position.X, position.Y, SIZE, SIZE);
        }

        public Point Velocity
        {
            get
            {
                return velocity;
            }

            set
            {
                if (velocity.X > 0)
                {
                    velocity.X = value.X;
                }
                else
                {
                    velocity.X = value.X * -1;
                }

                if (velocity.Y > 0)
                {
                    velocity.X = value.Y;
                }
                else
                {
                    velocity.Y = value.Y * -1;
                }

            }
        }
    }
}
