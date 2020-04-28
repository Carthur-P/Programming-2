using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonArea
{
    public class Controller
    {
        private Graphics graphics;
        private Random rand;
        private Polygon polygon;

        public Controller(Graphics graphics, Random rand)
        {
            this.graphics = graphics;
            this.rand = rand;
            polygon = null; //this is because the class is an abstract class
        }

        public void CreatePolygon()
        {
            int random = rand.Next(3);

            switch (random)
            {
                case 0:
                    polygon = new Square(graphics, new Point(120,50), Color.Red, 200);
                    break;

                case 1:
                    polygon = new Circle(graphics, new Point(120, 50), Color.Green, 200);
                    break;

                case 2:
                    polygon = new Triangle(graphics, new Point(220, 50), Color.Yellow, 200);
                    break;
            }
        }

        public void Draw()
        {
            polygon.Draw();
        }

        public double Area()
        {
            return polygon.CalculateArea();
        }

    }
}
