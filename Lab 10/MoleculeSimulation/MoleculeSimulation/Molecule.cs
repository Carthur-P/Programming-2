using System;
using System.Drawing;

namespace MoleculeSimulation
{
    public class Molecule
    {
        private const int TEN = 10;

        private Random rand;
        private Point position;
        private Graphics graphics;
        private Brush brush;
        private Pen pen;

        public Molecule(Random rand, Graphics graphics, Color color, Point position)
        {
            this.rand = rand;
            this.graphics = graphics;
            this.position = position;
            brush = new SolidBrush(color); 
            //this is setting the color of the brush to the color past from the controller class
            pen = new Pen(Brushes.Black);
        }

        public void Move ()
        {
            position.X = position.X + rand.Next(-TEN, TEN);
            position.Y = position.Y + rand.Next(-TEN, TEN);
            //this will add to the value of the points, both x and y by a random number between -10 and 10
        }

        public void Draw()
        {
            graphics.DrawEllipse(pen, position.X, position.Y, TEN, TEN);
            graphics.FillEllipse(brush, position.X, position.Y, TEN, TEN);
            //drawing the dots onto the form at the position of the point value in the feild position
        }
    }
}
