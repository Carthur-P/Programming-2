using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonArea
{
    public class Triangle: Polygon
    {
        private const double HALF = 0.5;

        public Triangle(Graphics graphics, Point position, Color color, int size)
            :base (graphics, position, color, size) 
        {

        }

        public override void Draw()
        {
            Brush brush = new SolidBrush(color);
            graphics.FillPolygon(brush, new Point[] { new Point(position.X, position.Y), new Point(position.X + size, position.Y + size), new Point(position.X - size, position.Y + size) });
        }

        public override double CalculateArea()
        {
            double area = 0;
            area = (HALF * (size * 2) * size);
            return area;
        }
    }
}
