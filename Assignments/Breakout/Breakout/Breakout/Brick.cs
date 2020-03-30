//This will draw a stationary rectangular shape object onto the form which will disappear when the ball bounce of it.

using System.Collections.Generic;
using System.Drawing;

namespace Breakout
{
    public class Brick
    {
        private const int BRICKWIDTH = 50;
        private const int BRICKHEIGHT = 20;
        private const int FONTSIZE = 10;
        private const int LOOP = 6;
        private const int BOUNCELIMIT = 8;
        private const int BOUNCELIMIT2 = 16;
        private const int ADJUSTX = 18;
        private const int ADJUSTY = 3;

        private Graphics graphics;
        private Brush brush;
        private Point brickPosition;
        private List<Point> brickPositions;
        private int width;

        public Brick(Graphics graphics, Color color, Point brickPosition, int width)//contructor
        {
            this.graphics = graphics;
            this.width = width;
            this.brickPosition = brickPosition;
            brush = new SolidBrush(color);
            brickPositions = new List<Point>();
        }

        public void Explode(int i)//this will make the brick disappear from the form
        {
            brickPositions.Remove(BrickPositions[i]);//removing the brick that the ball hit from the list of all the bricks
        }

        public void BrickManger()//organizing the bricks across the screen in multiple rows
        {
            BrickPositions.Clear();//making sure that when the method is call, the list is empty
            brickPosition.Y = 0;
            for (int i = 0; i < LOOP; i++)//control how many rows of bricks there is
            {
                brickPositions.Add(brickPosition);
                do
                {
                    brickPosition.X = brickPosition.X + BRICKWIDTH;
                    brickPositions.Add(new Point(brickPosition.X, brickPosition.Y));//adding the brick into the list of bricks

                } while (brickPosition.X + BRICKWIDTH < width);//keep adding bricks accross the screen till it reaches the width of the form

                brickPosition.Y = brickPosition.Y + BRICKHEIGHT;
                brickPosition.X = 0;
            }
        }

        public void Draw(int bounce)//drawing the brick onto the screen
        {
            Pen pen = new Pen(Brushes.Black, 1F);
            Font font = new Font("Microsoft Sans Serif", FONTSIZE);

            if (bounce <= BOUNCELIMIT)//ball bouncing of the paddle is less thatn 8 times
            {
                foreach (Point point in brickPositions)//drawing all the bricks in the list onto the form
                {
                    graphics.FillRectangle(brush, point.X, point.Y, BRICKWIDTH, BRICKHEIGHT);
                    graphics.DrawRectangle(pen, point.X, point.Y, BRICKWIDTH, BRICKHEIGHT);
                }
            }

            if ((bounce > BOUNCELIMIT) && (bounce <= BOUNCELIMIT2))//ball bouncing of the paddle is more than 8 times but less than 16 times
            {
                foreach (Point point in brickPositions)//drawing all the bricks in the list onto the form
                {
                    graphics.FillRectangle(brush, point.X, point.Y, BRICKWIDTH, BRICKHEIGHT);
                    graphics.DrawString("x2", font, Brushes.Black, point.X + ADJUSTX, point.Y + ADJUSTY);//this will add the text "x2" to the bricks
                    graphics.DrawRectangle(pen, point.X, point.Y, BRICKWIDTH, BRICKHEIGHT);
                }
            }

            if (bounce > BOUNCELIMIT2)//ball bouncing of the paddle is more than 16 times
            {
                foreach (Point point in brickPositions)//drawing all the bricks in the list onto the form
                {
                    graphics.FillRectangle(brush, point.X, point.Y, BRICKWIDTH, BRICKHEIGHT);
                    graphics.DrawString("x4", font, Brushes.Black, point.X + ADJUSTX, point.Y + ADJUSTY);//this will add the text "x4" to the bricks
                    graphics.DrawRectangle(pen, point.X, point.Y, BRICKWIDTH, BRICKHEIGHT);
                }
            }
        }

        public List<Point> BrickPositions
        {
            get
            {
                return brickPositions;
            }
        }
    }
}
