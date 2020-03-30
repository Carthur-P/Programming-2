//the base class for the polygon shapes

using System.Drawing;

namespace ScreenSaver
{
    public abstract class Polygon
    {
        protected Graphics graphics;
        protected Point position;
        protected Color color;
        protected int size;

        public Polygon(Graphics graphics, Point position, Color color, int size)//constructor
        {
            this.graphics = graphics;
            this.position = position;
            this.color = color;
            this.size = size;
        }

        public abstract void Draw();//these are abstract methods which will never be use, it excists to create a structure
    }
}
