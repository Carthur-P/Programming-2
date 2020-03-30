using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot
{
    public class Robot
    {
        private const int SLEEP = 50;

        private PictureBox pictureBox;

        public Robot(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        public void WalkPath(Path path)
        {

            foreach (Point point in path.Points)
            { 
                pictureBox.Left = point.X - pictureBox.Width/2;
                //minusing the point by half of the width will move the pictureBox slighly to the left, centering it             
                pictureBox.Top = point.Y - pictureBox.Height/2;
                //minusing the point by half of the height will move the pictureBox slighly higher than the line, centering it    
                Thread.Sleep(SLEEP); 
                //Pausing the program so the pictureBox does not jump to the end
            }
        }
    }
}
