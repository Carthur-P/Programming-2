//creates the polygon and draw the polygon, this is the program manager

using System;
using System.Drawing;

namespace ScreenSaver
{
    public class Controller
    {
        private const int SHAPE = 3;
        private const int MAXSIZE = 200;
        private const int MINSIZE = 20;
        private const int POSITION = 50;
        private const int MAXCOLOR = 256;

        private Graphics graphics;
        private Random rand;
        private Polygon polygon;
        private Point position;

        public Controller(Graphics graphics, Random rand)//constructor
        {
            this.graphics = graphics;
            this.rand = rand;
            polygon = null; //this is because the class is an abstract class
        }

        public void CreatePolygon(int width, int height)//creating the polygon base on a random number
        {
            int random = rand.Next(3);
            int size = rand.Next(MINSIZE, MAXSIZE);
            position.X = rand.Next(-POSITION, width);
            position.Y = rand.Next(-POSITION, height);
            
            switch (random)
            {
                case 0:
                    polygon = new Square(graphics, new Point(position.X, position.Y), Color.FromArgb(rand.Next(MAXCOLOR), rand.Next(MAXCOLOR), rand.Next(MAXCOLOR)), size);
                    break;

                case 1:
                    polygon = new Circle(graphics, new Point(position.X, position.Y), Color.FromArgb(rand.Next(MAXCOLOR), rand.Next(MAXCOLOR), rand.Next(MAXCOLOR)), size);
                    break;

                case 2:
                    polygon = new Triangle(graphics, new Point(position.X, position.Y), Color.FromArgb(rand.Next(MAXCOLOR), rand.Next(MAXCOLOR), rand.Next(MAXCOLOR)), size);
                    break;
            }
        }

        public void Draw()//drawing the polygon
        {
            polygon.Draw();
            polygon = null;//getting rid of the created polygon
        }
    }
}
