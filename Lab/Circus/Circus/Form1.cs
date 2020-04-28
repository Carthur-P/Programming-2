/* Program name:          Circus
 * Project file name:     Circus
 * Author:                Carthur Pongpatimet
 * Date:                  25/07/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * Purpose:               Second application in defining a class, creating an object that belongs to the class,
 *                        and using method which belong to the class
 * Description:           
 * Known bugs:            None
 * Additional features:
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circus
{
    public partial class Form1 : Form
    {
        private Clown [] clown; //initulizing the array
        public Form1()
        {
            InitializeComponent();

            clown = new Clown[3]; //there is going to be 3 spaces in the array

            //putting information into the array
            clown[0] = new Clown("Crusty", 160, 45);
            clown[1] = new Clown("Charlie", 100, 18);
            clown[2] = new Clown("Clary", 180, 67);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clown.Length; i++)
            {
                pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("clown" + (i + 1).ToString());
                MessageBox.Show(clown[i].TalkAboutYourself());  
            }
        }
           
            
    }
}
