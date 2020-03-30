//creates a square shape polygon

using System.Drawing;

namespace ScreenSaver
{
    public class Square : Polygon
    {
        public Square(Graphics graphics, Point position, Color color, int size)
            : base(graphics, position, color, size)//constructor
        {

        }

        public override void Draw()//drawing the shape
        {
            Brush brush = new SolidBrush(color);
            graphics.FillRectangle(brush, new Rectangle(position.X, position.Y, size, size));
        }
    }
}
