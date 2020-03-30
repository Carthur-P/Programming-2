//creating a snake creature that inherits feilds and methods from the creature class

using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame
{
    public class Snake : Creature
    {
        private const int SNAKESTART = 15;
        private const int LENGTH = 8;
        private const int NCELLS = 30;

        private Bitmap body;
        private Direction direction;
        private List<Point> position;

        public Snake(Bitmap head, Bitmap body, Grid grid)
            : base(head, grid)//constructor
        {
            this.body = body;
            position = new List<Point>();
            direction = Direction.Right;

            for (int i = 0; i < LENGTH; i++)
            {
                position.Add(new Point((SNAKESTART - i), SNAKESTART));
            }
        }

        public override void Draw()//drawing the snake onto the grid
        {
            foreach (Point position in position)
            {
                GetGridCellForPosition(position).Value = body;
            }
            GetGridCellForPosition(position[0]).Value = head;
        }

        public void Move()//moving the snake
        {
            for (int i = position.Count - 1; i > 0; i--)
            {
                position[i] = position[i - 1];
            }

            switch (direction)
            {
                case Direction.Right:
                    {
                        position[0] = new Point((position[0].X + 1), position[0].Y);
                        break;
                    }

                case Direction.Left:
                    {
                        position[0] = new Point((position[0].X - 1), position[0].Y);
                        break;
                    }

                case Direction.Up:
                    {
                        position[0] = new Point((position[0].X), position[0].Y - 1);
                        break;
                    }

                case Direction.Down:
                    {
                        position[0] = new Point((position[0].X), position[0].Y + 1);
                        break;
                    }
            }
        }

        public void Grow()//growing the snake by one gid of body
        {
            position.Add(position[position.Count - 1]);
        }

        public bool EatFrog(Point frogPosition)//checking to see if the snake's head position is the smae as frog position
        {
            bool eaten = false;

            if (position[0] == frogPosition)
            {
                eaten = true;
            }

            return eaten;
        }

        public bool CheckWall()//check to see if the snake's head has gone pass the grid walls
        {
            bool hitWall = false;

            if ((position[0].X < 0) || (position[0].X > (NCELLS - 1)) || (position[0].Y < 0) || (position[0].Y > (NCELLS - 1)))
            {
                hitWall = true;
            }

            return hitWall;
        }

        public bool CheckSelf()//checking to see if the snake's head is the same position as its body
        {
            bool hitSelf = false;

            for (int i = 1; i < position.Count; i++)
            {
                if (position[0] == position[i])
                {
                    hitSelf = true;
                }
            }
 
            return hitSelf;
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

        public List<Point> Position
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
