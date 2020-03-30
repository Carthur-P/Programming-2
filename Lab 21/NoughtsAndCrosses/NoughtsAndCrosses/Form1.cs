/* Program name:          NoughtsAndCrosses
 * Project file name:     Noughts and Crosses
 * Author:                Carthur Pongpatimet
 * Date:                  31/10/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 *
 * Purpose:               To make a clickable area on the form which you can play a game of noughts and crosses
 *
 * Description:           Board - Acts similar to a game engine. This will contain a list of all the squares on the
 *                        form and controls which square will display what
 *                        
 *                        Square - This is the individual sqaure which will display itself when it is told to by the 
 *                        board class
 *                          
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace NoughtsAndCrosses
{
    public partial class Form1 : Form
    {
        private Board board;
        private Graphics graphics;

        public Form1()//constuctor
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            board = new Board(graphics);
        }

        private void panel10_MouseDown_1(object sender, MouseEventArgs e)//when mouse is clicked inside the panel
        {
            board.PlaceSquare(e.Location);
        }

        private void button1_Click(object sender, EventArgs e)//button 1 is clicked
        {
            board.SetupNewGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)//when the form first load
        {
            board.SetupNewGame();
        }
    }
}
