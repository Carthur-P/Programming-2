/* Program name:          Hero vs Monster Game
 * Project file name:     HeroVsMonster
 * Author:                Carthur Pongpatimet
 * Date:                  25/09/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To create a textbase game where the two players attack each other until their health reaches
 *                        zero 
 * 
 * Description:           Button - when the button is clicked, the game will start and will continue until one of the 
 *                        player's health reaches zero. Each player will take turn at attacking each other with some 
 *                        attacks being successful and some being blocked
 *                        
 *                        Player - The player has a name, strength, health and can attack. The chances of a successful
 *                        attack depends on the player's strength, the higher the strenght, the higher the chances.
 *                        If the attack was successful, the other player looses one health and if the player's health
 *                        reaches zero, the other player wins
 *                        
 *                        Hero - A hero does everything that a player does, however it has a chance to recover two 
 *                        health
 *                        
 * Known bugs:            None
 * 
 * Additional features:   The game runs on a timer instead of clicking each turns individually.
 */

using System;
using System.Windows.Forms;

namespace HeroVsMonster
{
    public partial class Form1 : Form
    {
        private Controller controller;
        private Random rand;

        public Form1()//constructor
        {
            InitializeComponent();
            rand = new Random();
            controller = new Controller(rand, label1, label2, label3, label4, label5, label6);
        }

        private void timer1_Tick(object sender, EventArgs e)//everytime the timer clicks, the game runs
        {
            if (controller.EndGame() == true)
            {
                controller.GameRun();
            }

            else if (controller.EndGame() == false)
            {
                timer1.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)//when button is click, the game starts
        {
            controller.NewGame();
            timer1.Enabled = true;
            button1.Enabled = false; 
        }
    }
}
