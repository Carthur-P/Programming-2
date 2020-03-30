using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine
{
    public class Spinner
    {
        private const int ARRAY = 8;
        private const int SLEEP = 50;
        private const int LOOP = 20;

        private Random rand;
        private int imageNumber;
        private Image[] image;
        public int[] pictureArrayNums;
        private PictureBox pictureBox;  

        public Spinner(Random rand, PictureBox pictureBox)
        {
            this.rand = rand;
            this.pictureBox = pictureBox;
            pictureArrayNums = new int[ARRAY];
            image = new Image[ARRAY];
            LoadImage();
        }

        public void LoadImage()
        {
            image[0] = Properties.Resources.cherry;
            image[1] = Properties.Resources.win;
            image[2] = Properties.Resources.melon;
            image[3] = Properties.Resources.grape;
            image[4] = Properties.Resources.seven;
            image[5] = Properties.Resources.orange;
            image[6] = Properties.Resources.bar;
            image[7] = Properties.Resources.lemon;
            //loading the images into the image array
        }

        public void Spin()
        {
            for (int i = 0; i < LOOP; i++)
            {
                imageNumber = rand.Next(ARRAY);
                pictureBox.Image = image[imageNumber];
                Application.DoEvents();
                Thread.Sleep(SLEEP);
                //showing a random image in the array and pausing it so the user can see
            }
            //this will cycle through the images in the image array twenty times
        }

        public int ImageNumber
        {
            get
            { return imageNumber; }
            //this is needed to find out what image is in the slots and check if the user have won
        }
    }
}
