//This will draw a rectangular shape object at the bottom of the form which will be able to move horizontally relative to mouse position

using System.Drawing;

namespace Breakout
{
    public class Paddle
    {
        private const int PADDLEWIDTH = 100;
        private const int PADDLEHEIGHT = 10;
        private const int TWO = 2;

        private Graphics graphics;
        private Brush brush;
        private Point paddlePoint;

        public Paddle(Graphics graphics, Color color, Point paddlePoint)//contructor
        {
            this.graphics = graphics;
            this.paddlePoint = paddlePoint;
            brush = new SolidBrush(color);
        }

        public void Draw()//draw the paddle to form
        {
            graphics.FillRectangle(brush, paddlePoint.X, paddlePoint.Y, PADDLEWIDTH, PADDLEHEIGHT);
        }

        public void Move(int mousePointX)//set the position of the paddle the position of the mouse
        {
            paddlePoint.X = mousePointX - (PADDLEWIDTH / TWO);//mouse position will be in the middle of the paddle
        }

        public Point PaddlePoint
        {
            get
            {
                return paddlePoint;
            }
        }
    }
}
