//this contains the list of squares and control what the squares should do

using System;
using System.Collections.Generic;
using System.Drawing;

namespace FindTweety
{
    class Board
    {
        private const int NCOLS = 4;
        private const int NROWS = 2;
        private const int SQUARESIZE = 110;
        private const int NSQUARE = 7;

        private Random rand;
        private List<Square> squares;

        public Board(Graphics graphics, Random rand)//constructor
        {
            this.rand = rand;
            squares = new List<Square>();

            for (int i = 0; i < NCOLS; i++)
            {
                for (int j = 0; j < NROWS; j++)
                {
                    int left = i * SQUARESIZE;
                    int top = j * SQUARESIZE;

                    Rectangle bounds = new Rectangle(left, top, SQUARESIZE, SQUARESIZE);
                    squares.Add(new Square(graphics, Properties.Resources.blue, bounds));
                }
            }
        }

        public void SetupNewGame()//setting up for a new game
        {
            foreach (Square square in squares)
            {
                square.NewGame();
                square.Type = Status.blank;
            }
            AssignCharacters();
        }

        private void AssignCharacters()//assign the square that will have the winning and loosing image
        {
            int winIndex = rand.Next(NSQUARE);
            int loseIndex = rand.Next(NSQUARE);

            while (winIndex == loseIndex)
            {
                loseIndex = rand.Next(NSQUARE);
            }

            squares[winIndex].Type = Status.win;
            squares[loseIndex].Type = Status.lose;
        }

        public Status PlaySquare(Point mouseLocation)//making the sqaure show its content 
        {
            Status type = Status.blank;
            foreach (Square square in squares)
            {
                bool activeSquare = square.FindActiveSquare(mouseLocation);

                if (activeSquare == true)
                {
                    square.Play();
                    type = square.Type;
                    break;
                }
            }
            return type;
        }
    }
}
