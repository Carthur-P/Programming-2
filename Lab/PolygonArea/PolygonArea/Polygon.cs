using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonArea
{
    public abstract class Polygon
    {
        protected Graphics graphics;
        protected Point position;
        protected Color color;
        protected int size;

        public Polygon(Graphics graphics, Point position, Color color, int size)
        {
            this.graphics = graphics;
            this.position = position;
            this.color = color;
            this.size = size; 
        }

        public abstract void Draw();//these are abstract methods which will never be use, it excists to create a structure

        public abstract double CalculateArea();//use 'virtual' for the method to be accessable by its own class
    }
}
