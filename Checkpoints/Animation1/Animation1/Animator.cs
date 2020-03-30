using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation1
{
    public class Animator
    {
        private const int ARRAY = 11;
        private const int SLEEP = 100;

        private Image[] image;
        private PictureBox pictureBox;

        public Animator(PictureBox pictureBox)
        {
            image = new Image[ARRAY]; //initializing the image array

            for (int i = 0; i < image.Length; i++)
            {
                image[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject("T" + i.ToString());
            }
            //this will add all the images into the array

            this.pictureBox = pictureBox; 
            //initializing the feild pictureBox with the parameter past in from the form
        }

         public void OutputImage()
         {
            for (int i = 0; i < image.Length; i++)
            {
                pictureBox.Image = image[i];
                Application.DoEvents();
                Thread.Sleep(SLEEP);
                //pausing the program so each images can be seen
            }
            //loading the image from the array into the pictureBox
        }
    }
}
