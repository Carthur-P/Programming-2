//This class is the base class for all the characters in the game

using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    public abstract class Character
    {
        private const int EDGEOFMAZE = 20;

        protected Bitmap characterImage;
        protected Maze maze;
        protected Point position;
        protected Point nextPosition;
        protected Direction direction;

        public Character(Bitmap characterImage, Maze maze)//constructor
        {
            this.characterImage = characterImage;
            this.maze = maze;
        }

        protected void SetNextPosition()//setting the next position according to the direction set from the arrow keys 
        {
            switch (direction)
            {
                case Direction.up:
                    {
                        nextPosition = new Point(position.X, position.Y - 1);
                        break;
                    }

                case Direction.down:
                    {
                        nextPosition = new Point(position.X, position.Y + 1);
                        break;
                    }

                case Direction.left:
                    {
                        nextPosition = new Point(position.X - 1, position.Y);
                        break;
                    }

                case Direction.right:
                    {
                        nextPosition = new Point(position.X + 1, position.Y);
                        break;
                    }
            }
        }

        protected bool CheckForWall()//checking to see if the next position is a wall
        {
            bool wall;
            if (maze.Rows[nextPosition.Y].Cells[nextPosition.X].Value == maze.Wall)
            {
                wall = true;
            }
            else
            {
                wall = false;
            }
            return wall;
        }

        public abstract void Move();//abstract method that is never use but serves as a structure

        public abstract void Draw();//abstract method that is never use but serves as a structure

        public DataGridViewCell GetGridCellForPosition(Point point)//setting the point as a grid reference
        {
            return maze.Rows[point.Y].Cells[point.X];
        }

        protected void MoveOutsideMaze()//setting the next position to the furthest cell on the opposite side when any character reaches the edge of the maze
        {
            if (nextPosition.X < 0)
            {
                nextPosition.X = EDGEOFMAZE;
            }
             
            if (nextPosition.X > EDGEOFMAZE)
            {
                nextPosition.X = 0;
            }
        }

        public Direction Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public Bitmap CharacterImage
        {
            get
            {
                return characterImage;
            }

            set
            {
                characterImage = value;
            }
        }

        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }
    }
}
