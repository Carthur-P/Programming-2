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
        //setting the feilds and constant
        private Image[] image;
        private PictureBox pictureBox;
        private int ARRAY = 11;
        private int SLEEP = 100;

        public Animator(PictureBox pictureBox)
        {
            image = new Image[ARRAY]; //setting the image array numbers

            //adding the image into the array
            for (int i = 0; i < image.Length; i++)
            {
                image[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject("T" + i.ToString());
            }

            this.pictureBox = pictureBox; //setting the feild pictureBox to the properties that is goign to get pass in, also called pictureBox

        }

         public void OutputImage()
         {
            //loading the image from the array into the picture box
            for (int i = 0; i < image.Length; i++)
            {
                pictureBox.Image = image[i];
                Application.DoEvents();
                Thread.Sleep(SLEEP);
            }

           
         }
     }
 
}
