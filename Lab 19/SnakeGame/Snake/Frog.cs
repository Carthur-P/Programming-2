//creating the frog creature that inherit feilds and methods from the creature class

using System.Drawing;

namespace SnakeGame
{
    class Frog : Creature
    {
        private Point position;
        private bool alive;

        public Frog(Bitmap head, Grid grid)//constructor
            : base(head, grid)
        {
            position = new Point(0, 0);
            alive = false;
        }

        public override void Draw()//drawing the frog onto the grid
        {
            GetGridCellForPosition(position).Value = head;
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

        public bool Alive
        {
            get
            {
                return alive;
            }

            set
            {
                alive = value;
            }
        }
    }
}
