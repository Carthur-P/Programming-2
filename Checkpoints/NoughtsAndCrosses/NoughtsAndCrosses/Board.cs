//this will holds a list of squares and contols when and what the square will show

using System.Collections.Generic;
using System.Drawing;

namespace NoughtsAndCrosses
{
    class Board
    {
        private const int NCOLS = 3;
        private const int NROWS = 3;
        private const int SQUARESIZE = 100;

        private bool playerX;
        private List<Square> squares;

        public Board(Graphics graphics)//constuctor
        {
            playerX = false;
            squares = new List<Square>();

            for (int i = 0; i < NCOLS; i++)
            {
                for (int j = 0; j < NROWS; j++)
                {
                    int left = i * SQUARESIZE;
                    int top = j * SQUARESIZE;

                    Rectangle bounds = new Rectangle(left, top, SQUARESIZE, SQUARESIZE);
                    squares.Add(new Square(graphics, bounds)); 
                }
            }
        }
        
        public void SetupNewGame()//setting up for a new game
        {
            foreach (Square square in squares)
            {
                square.NewGame();
            }
        }

        public void PlaceSquare(Point mouseLocation)//event that occur when the mouse is clicked
        {
            if (playerX == true)
            {
                playerX = false;
            }

            else if (playerX == false)
            {
                playerX = true;
            }

            foreach (Square square in squares)
            {
                bool activeSquare = square.FindActiveSquare(mouseLocation);

                if (activeSquare == true)
                {
                    square.Play(playerX);
                }
            }
        }
    }
}
