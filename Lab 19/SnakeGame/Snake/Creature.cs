//base class for all creatures in the game

using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public abstract class Creature
    {
        protected Bitmap head;
        protected Grid grid;

        public Creature(Bitmap head, Grid grid)//constructor
        {
            this.head = head;
            this.grid = grid;
        }

        public DataGridViewCell GetGridCellForPosition(Point point)//setting the point as a grid reference
        {
            return grid.Rows[point.Y].Cells[point.X];
        }

        public abstract void Draw();//base class for drawing creatures
    }
}
