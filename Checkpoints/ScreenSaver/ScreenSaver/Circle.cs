//creates a circle shape polygon 

using System.Drawing;

namespace ScreenSaver
{
    public class Circle : Polygon
    {
        public Circle(Graphics graphics, Point position, Color color, int size)
            : base(graphics, position, color, size)//constructor
        {

        }

        public override void Draw()//drawing the shape
        {
            Brush brush = new SolidBrush(color);
            graphics.FillEllipse(brush, new Rectangle(position.X, position.Y, size, size));
        }
    }
}
