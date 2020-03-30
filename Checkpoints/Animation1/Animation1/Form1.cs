/* Program name:          Animation1
 * Project file name:     Animation1
 * Author:                Carthur Pongpatimet
 * Date:                  28/07/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To do a simple animation using the a class 
 * 
 * Description:           When 'hello' button is clicked, the pictureBox will cycle through a series of 
 *                        images creating an illusion of the person in the imagame waving.
 *                        
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Windows.Forms;

namespace Animation1
{
    public partial class Form1 : Form
    {
        private Animator animator;
        public Form1()//constructor
        {
            InitializeComponent();

            animator = new Animator(pictureBox1);
            //initializing the object 'animator' of class 'Animator'
        }

        private void button1_Click(object sender, EventArgs e)//when button1 is click, start the animation
        {
            animator.OutputImage();
            //calling the method from class 'Animator'
        }
    }
}
