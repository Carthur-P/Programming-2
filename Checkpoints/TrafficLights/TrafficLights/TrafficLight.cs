using System;
using System.Collections.Generic;
using System.Drawing;
//the programs engine which will set the colours and flash interval

namespace TrafficLights
{
    public class TrafficLight
    {
        private const int SLEEPINTERVAL = 1000;
        private const int POINTX = 60;
        private const int POINTY = 50;
        private const int GAP = 60;
        private const int GAP2 = 120;
        private const int COLORMAX = 255;

        private Graphics graphics;
        private List<Light> lights;
        private Random rand;

        public TrafficLight(Graphics graphics, Random rand)//contructor
        {
            lights = new List<Light>();
            this.rand = rand;
            this.graphics = graphics;

            lights.Add(new Light(graphics, Color.Black, new Point(POINTX, POINTY), SLEEPINTERVAL));
            lights.Add(new Light(graphics, Color.Black, new Point(POINTX, POINTY + GAP), SLEEPINTERVAL));
            lights.Add(new Light(graphics, Color.Black, new Point(POINTX, POINTY + GAP2), SLEEPINTERVAL));
        }

        public void Draw()//drawing each lights in the list to the form
        {
            foreach (Light light in lights)
            {
                light.Draw(Color.Black);
            }
        }

        public void Flash()//flashing each lights in the list 
        {
            foreach (Light light in lights)
            {
                light.Flash();
            }
        }

        public void SetSleepInterval(int sleepInterval)//setting how long the colour is change for (sleepinterval)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                lights[i].SleepInterval = sleepInterval;
            }
        }

        public void SetTraditionalColor()//setting the colour of the three lights to traditional traffic light colours (green, yellow, red)
        {
            lights[0].Color = Color.Green;
            lights[1].Color = Color.Yellow;
            lights[2].Color = Color.Red;
        }

        public void SetMixedColor()//setting the colour of the three lights to mixed traditional traffic light colours
        {
            lights[0].Color = Color.Yellow;
            lights[1].Color = Color.Red;
            lights[2].Color = Color.Green;
        }

        public void SetRandomColor()//setting the colour of the three lights to random colours
        {
            foreach (Light light in lights)
            {
                light.Color = Color.FromArgb(rand.Next(COLORMAX), rand.Next(COLORMAX), rand.Next(COLORMAX));
            }
        }
    }
}
