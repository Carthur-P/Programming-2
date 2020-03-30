/* Program name:          Libary
 * Project file name:     Libary
 * Author:                Carthur Pongpatimet
 * Date:                  19/09/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To create a libary database using datagridview where the user can see if the book they 
 *                        want is issued or not and to who
 * 
 * Description:           Book - Book contains all the information about the book such as its ID, title, if it is
 *                        issued or not and to who
 *                        
 *                        Controller - The controller is the libary and will show the user using the datagridview
 *                        what books are avaliable, the books ID, and whether is has been issued or not. It will
 *                        also controll what happens when the user wants to borrow a book and clicks the button. 
 *                        It is essentially the programs engine.
 *                        
 * Known bugs:            None
 * 
 * Additional features:   Adding a function where a messagebox will pop up informing the user that the book have 
 *                        already been issued if the book that the user is trying to get have already been issued. 
 *                        Adding another function where if the book ID that was entered is not valid, a messagebox
 *                        will pop up informing the user that the ID inputted is invalid.
 */

using System;
using System.Windows.Forms;

namespace Libary
{
    public partial class Form1 : Form
    {
        private Controller controller;

        public Form1()//constructor
        {
            InitializeComponent();
            controller = new Controller(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)//issuring the book
        {
            if ((Convert.ToInt32(textBox1.Text) > (controller.Books.Count)) || (Convert.ToInt32(textBox1.Text) < 1))
            {
                MessageBox.Show("The ID number that you have entered is invalid");
                textBox1.Clear();
            }

            else
            {
                controller.LibaryIssued(Convert.ToInt32(textBox1.Text), textBox2.Text);
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)//returning the book
        {
            controller.LibaryReturn(Convert.ToInt32(textBox1.Text));
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)//exiting the program
        {
            Application.Exit();
        }
    }
}
