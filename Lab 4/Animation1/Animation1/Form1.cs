/* Program name:          Animation1
 * Project file name:     Animation1
 * Author:                Carthur Pongpatimet
 * Date:                  28/07/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * Purpose:               To do a simple animation using the class 
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

namespace Animation1
{
    public partial class Form1 : Form
    {
        private Animator animator;
        public Form1()
        {
            InitializeComponent();
            animator = new Animator(pictureBox1);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            animator.OutputImage();
        }
    }
}
