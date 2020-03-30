//the application engine, controls what what happens when the program is running

using System.Collections.Generic;
using System.Drawing;

namespace BouncingShapes
{
    public class Controller
    {
        private const int GREENX = 160;
        private const int GREENY = 150;
        private const int REDX = 300;
        private const int REDY = 75;
        private const int BLUEX = 540;
        private const int BLUEY = 100;
        private const int TWO = 2;


        private List<Ball> balls;

        public Controller(Graphics graphics, int width, int height)//constuctor
        {
            balls = new List<Ball>();
            balls.Add(new Ball(graphics, Color.Green, new Point(GREENX, GREENY), width, height));
            balls.Add(new Ball(graphics, Color.Red, new Point(REDX, REDY), width, height));
            balls.Add(new Ball(graphics, Color.Blue, new Point(BLUEX, BLUEY), width, height));
        }

        public void Run()//the event that occurs each timer tick
        {
            foreach (Ball ball in balls)
            {
                ball.Move();
                ball.Draw();
            }
        }

        public void ChangeVelocity (int index, Point velocity)//changing the velocity of the green ball by the value from the trackbar
        {
            balls[index].Velocity = velocity;
        }
    }
}
