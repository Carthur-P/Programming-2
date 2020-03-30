//creates a triangle shape polygon

using System.Drawing;

namespace ScreenSaver
{
    public class Triangle : Polygon
    {
        private const double HALF = 0.5;

        public Triangle(Graphics graphics, Point position, Color color, int size)
            : base(graphics, position, color, size)//constructor
        {

        }

        public override void Draw()//drawing the shape
        {
            Brush brush = new SolidBrush(color);
            graphics.FillPolygon(brush, new Point[] { new Point(position.X, position.Y), new Point(position.X + size, position.Y + size), new Point(position.X - size, position.Y + size) });
        }
    }
}
