using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRace
{
    class Controller
    {
        private const int ARRAY = 4;
        private const int STARTPOSITION = 12;

        private Horse[] horse;
        private PictureBox[] pictureBox;
        private int finishLine;
        private Random rand;
        private bool gameOn;

        public Controller(PictureBox[] pictureBox, Random rand, int finishLine)
        {
            this.rand = rand;
            this.pictureBox = pictureBox;
            this.finishLine = finishLine;

            gameOn = true;

            horse = new Horse[ARRAY];
            horse[0] = new Horse("Red horse", pictureBox[0], rand);
            horse[1] = new Horse("Green horse", pictureBox[1], rand);
            horse[2] = new Horse("Yellow horse", pictureBox[2], rand);
            horse[3] = new Horse("Blue horse", pictureBox[3], rand);
        }

        public void StartRace()
        {
            gameOn = true;
            for (int i = 0; i < ARRAY; i++)
            { 
                if (pictureBox[i].Right < finishLine)
                {
                    horse[i].Move();
                }
                else if (pictureBox[i].Right >= finishLine)
                {
                    gameOn = false;
                    MessageBox.Show(horse[i].Name + " has won!");
                    break;//This will force the program to jump out of the loop
                }
             }             
        }

        public void Reset()
        {
            for (int i = 0; i < ARRAY; i++)
            {
                pictureBox[i].Left = STARTPOSITION;
            }
        }
        public bool GameOn
        {
            get
            {
                return gameOn;
            }
            set
            {
                gameOn = value;
            }
        }


    }
}
