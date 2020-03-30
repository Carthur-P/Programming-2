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
    class Spinner
    {
        Random rand;

        private int imageNumber;
        private Image[] image;
        public int[] pictureArrayNums;
        private PictureBox pictureBox;

        private const int ARRAY = 8;
        private const int SLEEP = 50;
        private const int LOOP = 20;    

        public Spinner(Random rand, PictureBox pictureBox)
        {
            this.rand = rand;
            this.pictureBox = pictureBox;
            pictureArrayNums = new int[ARRAY];
            image = new Image[ARRAY];
            LoadImage();
        }//end of contructor

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
        }//end of LoadImage method

        public void Spin()
        {

            for (int i = 0; i < LOOP; i++)
            {
                imageNumber = rand.Next(ARRAY);
                pictureBox.Image = image[imageNumber];
                Application.DoEvents();
                Thread.Sleep(SLEEP);

            }//end of for loop

        }//end of spin method

        public int ImageNumber
        {
            get
            {
                return imageNumber;
            }

            set
            {
                imageNumber = value;
            }
        }
    }
}
