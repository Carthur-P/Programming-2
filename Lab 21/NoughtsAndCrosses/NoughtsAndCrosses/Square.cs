//individual squares that can display itself

using System.Drawing;

namespace NoughtsAndCrosses
{
    class Square
    {
        private Graphics graphics;
        private Rectangle bounds;
        private Image image;
        private bool filled;

        public Square(Graphics graphics, Rectangle bounds)//constuctor
        {
            this.graphics = graphics;
            this.bounds = bounds;
            filled = false;
        }

        public bool FindActiveSquare(Point mouseLocation)//see if the mouse position is in the bondry of the square
        {
            bool foundSquare = false;

            if (bounds.Contains(mouseLocation) == true)
            {
                foundSquare = true;
            }

            return foundSquare;
        }

        private void Draw()//displaying the image onto the form
        {
            graphics.DrawImage(image, bounds.Left, bounds.Top);
        }

        public void Play(bool playerX)//seeing which image should be display
        {
            if (filled == false)
            {
                if (playerX == true)
                {
                    image = Properties.Resources.X;
                }

                else if (playerX == false)
                {
                    image = Properties.Resources.O;
                }
                filled = true;
                Draw();
            }
        }

        public void NewGame()//setting up for a new game
        {
            image = Properties.Resources.solid;
            Draw();
            filled = false;
        }
    }
}
