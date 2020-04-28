/* Program name:          Animal Project
 * Project file name:     AnimalProject
 * Author:                Carthur Pongpatimet
 * Date:                  25/07/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * Purpose:               First application in defining a class, creating an object that belongs to the class,
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

namespace AnimalProject
{
    public partial class Form1 : Form
    {
        private Animal dog; //declaration 
        private Animal cat;
        private Animal frog;

        public Form1()
        {
            InitializeComponent();

            dog = new Animal("deefer dog", "Max", 4); //creating the object
            cat = new Animal("Kitty cat", "Fluffy", 4);
            frog = new Animal("Tadpole", "Fido", 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dog.ListDetails()); //use an object to call upon a method
            MessageBox.Show(cat.ListDetails());
            MessageBox.Show(frog.ListDetails());
        }
    }
}
