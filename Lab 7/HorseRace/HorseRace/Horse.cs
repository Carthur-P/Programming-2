using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRace
{
    public class Horse
    {
        private const int MAXSPEED = 100;

        private string name;
        private PictureBox pictureBox;
        private int speed;
        private Random rand;

        public Horse (string name, PictureBox pictureBox, Random rand)
        {
            this.name = name;
            this.pictureBox = pictureBox;
            this.rand = rand;
        }

        public void Move ()
        {
            //this will move the picture box at a random amount
            speed = rand.Next(MAXSPEED);
            pictureBox.Left = pictureBox.Left + speed;
        }

        public string Name
        {
            get
            {
                return name;
            }

        }
    }
}
