//making each individual lights which will draw and change colour for a period of time

using System.Drawing;
using System.Threading;

namespace TrafficLights
{
    public class Light
    {
        private const int SIZE = 50;

        private Graphics graphics;
        private Color color;
        private Point position;
        private int sleepInterval;

        public Light(Graphics graphics, Color color, Point position, int sleepInterval)//constructor
        {
            this.graphics = graphics;
            this.color = color;
            this.position = position;
            this.sleepInterval = sleepInterval;
        }

        public void Draw(Color color)//drawing the light onto the form
        {
            Brush brush = new SolidBrush(color);
            graphics.FillEllipse(brush, position.X, position.Y, SIZE, SIZE);
        }

        public void Flash()//changing the colour of the light for a period of time then changing it back to default black
        {
            Draw(color);
            Thread.Sleep(sleepInterval);
            Draw(Color.Black);
        }

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public int SleepInterval
        {
            get
            {
                return sleepInterval;
            }

            set
            {
                sleepInterval = value;
            }
        }
    }
}
