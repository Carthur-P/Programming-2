/* Program name:          Slot Machine
 * Project file name:     SlotMachine
 * Author:                Carthur Pongpatimet
 * Date:                  08/08/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To create a functioning slot machine.
 * 
 * Description:           The user will enter the amount of balance they want and click the 'load money' button, this
 *                        cannot exceed $200. The 'spin' button will then be enabled for the user to click. When this
 *                        is clicked the three picturebox will cycle through random images. If there is two slots of 
 *                        images that are the same, the user wins $30. If all three slots of images are the same, then
 *                        the user wins $100. When the 'claim' button is clicked, a message box will pop up displaying
 *                        the amount of money the user has in their balance. The program will end after the message box 
 *                        is closed.
 *                        
 * Known bugs:            If the user enter in a number that exceed the limits of variable type 'double' into the balance
 *                        section, then the program will crash. If the user enter characters into the balance section 
 *                        instead of numbers, then the program will crash.
 *  
 * Additional features:   The function for the user to enter the amount of starting balance that does not exceed $200.
 *                        More than three pictures that can be cycled through in each slots.
 *                        More ways of winning, if the user match two images, then they win $30. If the user matches
 *                        all three images, then they win $100.
 *                        The function for the user to claim their balance whenever they want to end the game.                        
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

namespace SlotMachine
{  
    public partial class Form1 : Form
    {
        private const int TEN = 10;
        private const int BIGWIN = 100;
        private const int SMALLWIN = 30;
        private const int LIMIT = 200;

        private Random rand;
        private Spinner slot1;
        private Spinner slot2;
        private Spinner slot3;
        private double balance;

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            slot1 = new Spinner(rand, pictureBox1);
            slot2 = new Spinner(rand, pictureBox2);
            slot3 = new Spinner(rand, pictureBox3);
            //creating the three slot items for each slots in the slot machine
        }

        private void button1_Click(object sender, EventArgs e)
        {
            balance = balance - TEN;
            //minusing the balance by the bet of ten before the game runs
            if (balance >= 0)
            //checking if the balance has money in it to play
            {
                textBox2.Text = Convert.ToString(balance);
                button1.Enabled = false;
                button3.Enabled = false;
                slot1.Spin();
                slot2.Spin();
                slot3.Spin();
                //spinning the three slots in the machine and unabling the spin and claim button so the user can't click it
                //while the slots are spinning

                if ((slot1.ImageNumber == slot2.ImageNumber) && (slot2.ImageNumber == slot3.ImageNumber))
                //checking if all three images are the same
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    label8.Text = "Result: You won $100!";
                    balance = balance + BIGWIN;
                    textBox2.Text = Convert.ToString(balance);
                    //displaying the result and updated balance on the form
                }
                else if ((slot1.ImageNumber == slot2.ImageNumber) || (slot2.ImageNumber == slot3.ImageNumber)
                        || (slot1.ImageNumber == slot3.ImageNumber))
                //checking if two images are the same
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    label8.Text = "Result: You won $30";
                    balance = balance + SMALLWIN;
                    textBox2.Text = Convert.ToString(balance);
                    //displaying the result and updated balance on the form
                }
                else
                //if no images are the same
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    label8.Text = "Result: You loss";
                    //display result 
                }
            }
            else 
            //if the balance is lower than $0 then display a message telling the user that they have no money in the balance
            {
                MessageBox.Show("You don't have enough money");
                textBox1.Enabled = true;
                button2.Enabled = true;
            } 
        }
        //this will spin the three slots and check if the user have won anything and update the balance

        private void button2_Click(object sender, EventArgs e)
        {
            balance = Convert.ToDouble(textBox1.Text);
            //setting the variable balance to the number that the user have input
            if (balance < TEN)
            {
                MessageBox.Show("The amount you have entered is below the minimum bet");
            }
            //if the number the user have input is lower than the bet of ten
            else if (balance > LIMIT)
            {
                MessageBox.Show("You can only load a maximum of $200 at a time");
            }
            //if the number the user input have entered is more than 200
            else
            {
                textBox2.Text = Convert.ToString(balance);
                textBox1.Enabled = false;
                button2.Enabled = false;
            }
            //everything is fine and the balance will be shown on a textbox, the function to load miney will not be unabled
        }
        //this will set the balance to the amount of money the user have input

        private void button3_Click(object sender, EventArgs e)
        {
            if (balance > 0)
            {
                MessageBox.Show("You have claim $" + balance);
            }
            else
            {
                MessageBox.Show("You have claim $" + (balance + TEN));
            }
            //this if function will stop the messagebox showings a negative balance as the balance is subtracted by
            //ten before the game is run
            Application.Exit();
        }
        //this will close the application and show how much money the user have claim
    }
}
