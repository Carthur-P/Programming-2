using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    public class Snake : Creature
    {
        private const int SNAKESTART = 15;
        private const int LENGTH = 8;

        private Bitmap body;
        private Direction direction;
        private List<Point> position;

       

        public Snake(Bitmap head, Bitmap body, Grid grid)
            : base(head, grid)
        {
            this.body = body;
            position = new List<Point>();
            direction = Direction.Right;

            for (int i = 0; i < LENGTH; i++)
            {
                position.Add(new Point((SNAKESTART - i), SNAKESTART));
            }
        }

        public override void Draw()
        {
            foreach (Point position in position)
            {
                GetGridCellForPosition(position).Value = body;
            }
            GetGridCellForPosition(position[0]).Value = head;
        }

        public override void Move()
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

        public Direction Direction
        {
            get
            {
                return direction;
            }

            set
            {
                if ((direction == Direction.Right) && (direction == ))
                direction = value;
            }
        }
    }
        

}
