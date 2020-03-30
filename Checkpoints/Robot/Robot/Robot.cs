//This class will move the picturebox to the list of points from the class Path

using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Robot
{
    public class Robot
    {
        private const int SLEEP = 50;
        private const int TWO = 2;

        private PictureBox pictureBox;

        public Robot(PictureBox pictureBox)//constructor
        {
            this.pictureBox = pictureBox;
        }

        public void WalkPath(Path path)//the picturebox will follow the path that was drawn
        {
            foreach (Point point in path.Points)
            { 
                pictureBox.Left = point.X - (pictureBox.Width/TWO);
                //minusing the point by half of the width will move the pictureBox slighly to the left, centering it             
                pictureBox.Top = point.Y - (pictureBox.Height/TWO);
                //minusing the point by half of the height will move the pictureBox slighly higher than the line, centering it  
                Application.DoEvents();
                Thread.Sleep(SLEEP); 
                //Pausing the program so the pictureBox does not jump to the end
            }
        }
    }
}
