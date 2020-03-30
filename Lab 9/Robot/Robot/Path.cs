using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class Path
    {
        private List<Point> points;
        private bool draw;

        public Path()
        {
            points = new List<Point>();
            draw = false;
        }

        public void StartPath(Point mousePosition)
        {
            points.Clear();
            //Clearing the list so there is no previous points from previous runs, starting new
            points.Add(mousePosition);
            //Adding the first point to the list, this will always be where the mouse is first clicked
            draw = true;
            //draw will only be true if mouse is down
        }

        public void DrawPath(Graphics graphics, Pen pen, Point mousePosition)
        {
            if (draw == true) 
            //this will ensure that line and point is drawn and recorded only when the mouse click is down
            {
                points.Add(mousePosition);
                int listPoint = points.Count - 1; 
                //this will convert it to zero base so you can call stuff from the list
                graphics.DrawLine(pen, points[listPoint], points[listPoint - 1]); 
                //drawing the line form current point to previous point 
            }
        }
        public void EndPath()
        {
            draw = false;
            //when  mouse is up, draw is set to false which will then stop the line from being draw in DrawPath method
        }

        public List<Point> Points
        {
            get
            {
                return points;
            }
        }//this will encapsulate the points in the list so it can be use in other classes
    }
}