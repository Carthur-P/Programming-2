//This class will control the behavior specific to the character ghoul. This class will also inherits from the character class. 

using System;
using System.Drawing;

namespace Pacman
{
    public class Ghoul : Character
    {
        private const int DIRECTION = 4;
        private const int CHASECHANCE = 2;
        private const int MAZECOLUMN = 21;

        private Random rand;
        private bool foundPacman;

        public Ghoul(Bitmap characterImage, Point position, Random rand, Maze maze)//constructor
            :base (characterImage, maze)
        {
            this.position = position;
            this.maze = maze;
            this.rand = rand;
            SetDirection();
        }

        private void SetDirection()//setting the direction that the ghoul will move in
        {
            int directionChoice = rand.Next(DIRECTION);

            switch (directionChoice)
            {
                case 0:
                    {
                        direction = Direction.up;
                        break;
                    }
                case 1:
                    {
                        direction = Direction.down;
                        break;
                    }
                case 2:
                    {
                        direction = Direction.left;
                        break;
                    }
                case 3:
                    {
                        direction = Direction.right;
                        break;
                    }
            }
        }

        public void ChasePacman(Point pacmanPosition)//changing the direction of the ghoul to chase after pacman if their vertical or horizontal position are the same
        {
            int chaseChance = rand.Next(CHASECHANCE);

            if (chaseChance == 1)//this means that sometimes the ghoul does not chase pacman
            {
                if ((pacmanPosition.X == position.X) && (position.Y < pacmanPosition.Y))
                {
                    int index = (position.X + ((position.Y + 1) * MAZECOLUMN));//pacman is below the ghoul
                    if (maze.Map.Substring(index, 1) != "w")//checking to see if there is a wall inbetween the ghoul and pacman
                    {
                        direction = Direction.down;
                    }
                }

                if ((pacmanPosition.X == position.X) && (position.Y > pacmanPosition.Y))//pacman is above the ghoul
                {
                    int index = (position.X + ((position.Y - 1) * MAZECOLUMN));
                    if (maze.Map.Substring(index, 1) != "w")
                    {
                        direction = Direction.up;
                    }
                }

                if ((pacmanPosition.Y == position.Y) && (position.X > pacmanPosition.X))//pacman is to the left the ghoul
                {
                    int index = ((position.X - 1) + ((position.Y) * MAZECOLUMN));
                    if (maze.Map.Substring(index, 1) != "w")
                    {
                        direction = Direction.left;
                    }
                }

                if ((pacmanPosition.Y == position.Y) && (position.X < pacmanPosition.X))//pacman is to the right the ghoul
                {
                    int index = ((position.X + 1) + ((position.Y) * MAZECOLUMN));
                    if (maze.Map.Substring(index, 1) != "w")
                    {
                        direction = Direction.right;
                    }
                }
            }
        }   

        public override void Move()//moving the ghoul by one maze cell
        {
            SetNextPosition();
            MoveOutsideMaze();

            if (CheckForWall() == false)
            {
                int index = position.X + (position.Y * MAZECOLUMN);

                if (maze.Map.Substring(index,1) == "k")//checking if the ghoul is on a kibble
                {
                    maze.Rows[position.Y].Cells[position.X].Value = maze.Kibble;
                }
                else if (maze.Map.Substring(index, 1) == "b")//checking if the ghoul is on a blank cell
                {
                    maze.Rows[position.Y].Cells[position.X].Value = maze.Blank;
                }
                position = nextPosition;
            }
            else if (CheckForWall() == true)
            {
                SetDirection();
            }
        }

        public void CheckForPacman(Point pacmanPosition)//checking to see if ghoul position is the same as pacman position
        {
            foundPacman = false;
            if (position == pacmanPosition)
            {
                foundPacman = true;
            }
        }

        public override void Draw()//displaying the ghoul image onto the maze
        {
            GetGridCellForPosition(position).Value = characterImage;
        }

        public bool FoundPacman
        {
            get
            {
                return foundPacman;
            }

            set
            {
                foundPacman = value;
            }
        }
    }
}
