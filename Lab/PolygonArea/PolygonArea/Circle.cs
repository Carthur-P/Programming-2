using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonArea
{
    public class Circle: Polygon
    {
        public Circle(Graphics graphics, Point position, Color color, int size)
            : base(graphics, position, color, size)
        {

        }

        public override void Draw()
        {
            Brush brush = new SolidBrush(color);
            graphics.FillEllipse(brush, new Rectangle(position.X, position.Y, size, size));
        }

        public override double CalculateArea()
        {
            double area = 0;
            area = ((size/2)^2) * Math.PI;
            return area;
        }
    }
}
