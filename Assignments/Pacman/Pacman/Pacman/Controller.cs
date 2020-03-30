//This will control the gameplay and game functions of the program

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Pacman
{
    public class Controller
    {
        private const int PACSTARTX = 10;
        private const int PACSTARTY = 9;
        private const int THREE = 3;
        private const int SEVENTEEN = 17;
        private const int NKIBBLE = 151;
        private const int SLEEP = 2000;

        private Maze maze;
        private Pacman pacman;
        private List<Ghoul> ghouls;
        private Label scoreLabel;
        private bool gameEnd;
        private bool gameWin;
        private SoundPlayer pacmanDeath;
        private Bitmap pacmanMouthOpen;
        private Bitmap pacmanMouthClose;

        public Controller(Random rand, Maze maze, Label scoreLabel)//constructor
        {
            this.maze = maze;
            this.scoreLabel = scoreLabel;
            pacmanMouthOpen = new Bitmap(Properties.Resources.PacmanUp);
            pacmanMouthClose = new Bitmap(Properties.Resources.PacmanUp2);
            pacman = new Pacman(pacmanMouthOpen, maze);
            ghouls = new List<Ghoul>();
            ghouls.Add(new Ghoul(Properties.Resources.Ghoul_Red, new Point(THREE, THREE), rand, maze));
            ghouls.Add(new Ghoul(Properties.Resources.Ghoul_Pink, new Point(THREE, SEVENTEEN), rand, maze));
            ghouls.Add(new Ghoul(Properties.Resources.Ghoul_Blue, new Point(SEVENTEEN, THREE), rand, maze));
            ghouls.Add(new Ghoul(Properties.Resources.Ghoul_Green, new Point(SEVENTEEN, SEVENTEEN), rand, maze));
            pacmanDeath = new SoundPlayer(Properties.Resources.PacmanDeath);
            gameEnd = true;
            gameWin = false;
        }

        public void StartNewGame()//setting up for a new game
        {
            pacman.Position = new Point(PACSTARTX, PACSTARTY);
            ghouls[0].Position = new Point(THREE, THREE);
            ghouls[1].Position = new Point(THREE, SEVENTEEN);
            ghouls[2].Position = new Point(SEVENTEEN, THREE);
            ghouls[3].Position = new Point(SEVENTEEN, SEVENTEEN); 
            maze.NKibbles = NKIBBLE;
            pacman.Score = 0;
            pacman.Life = THREE;
            maze.Map = "bwwwwwwwwwwwwwwwwwwwb" +
                       "bwkkkkkkkkwkkkkkkkkwb" +
                       "bwkwwkwwwkwkwwwkwwkwb" +
                       "bwkkkkkkkkkkkkkkkkkwb" +
                       "bwkwwkwkwwwwwkwkwwkwb" +
                       "bwkkkkwkkkwkkkwkkkkwb" +
                       "bwwwwkwwwbwbwwwkwwwwb" +
                       "bbbbwkwbbbbbbbwkwbbbb" +
                       "wwwwwkwbwwbwwbwkwwwww" +
                       "bbbbbkbbwbbbwbbkbbbbb" +
                       "wwwwwkwbwwwwwbwkwwwww" +
                       "bbbbwkwbbbbbbbwkwbbbb" +
                       "bwwwwkwbwwwwwbwkwwwwb" +
                       "bwkkkkkkkkwkkkkkkkkwb" +
                       "bwkwwkwwwkwkwwwkwwkwb" +
                       "bwkkwkkkkkkkkkkkwkkwb" +
                       "bwwkwkwkwwwwwkwkwkwwb" +
                       "bwkkkkwkkkwkkkwkkkkwb" +
                       "bwkwwwwwwkwkwwwwwwkwb" +
                       "bwkkkkkkkkkkkkkkkkkwb" +
                       "bwwwwwwwwwwwwwwwwwwwb";
            gameEnd = false;
            gameWin = false;
        }

        private void StartNewLife()//setting for a new round once pacman has died
        {
            Thread.Sleep(SLEEP);
            pacman.Position = new Point(PACSTARTX, PACSTARTY);
            ghouls[0].Position = new Point(THREE, THREE);
            ghouls[1].Position = new Point(THREE, SEVENTEEN);
            ghouls[2].Position = new Point(SEVENTEEN, THREE);
            ghouls[3].Position = new Point(SEVENTEEN, SEVENTEEN);
        }

        public void GamePlay()//the event that occurs every timer tick, this is when the game is running
        {
            scoreLabel.Text = "Score: " + pacman.Score.ToString();
            maze.Draw();
            PacmanAnimation();
            pacman.Draw();
            ChasePacman();
            MoveGhouls();
            CheckNumberOfKibble();
            CheckForPacmanGhouls();
            DrawGhouls();

            foreach (Ghoul ghoul in ghouls)
            {
                if (ghoul.FoundPacman == true)
                {
                    pacmanDeath.Play();
                    pacman.Life--;

                    if (pacman.Life == 0)
                    {
                        gameEnd = true;
                    }
                    else if (pacman.Life > 0)
                    {
                        StartNewLife();
                    }
                }
            }
        }

        public void MovePacman(Direction direction)//moving and setting pacman's direction according to the arrow key press
        {
            pacman.Direction = direction;

            //this will set the pacman's image roatation so that the mouth is always facing forward, depending on which directional arrow key is press
            switch (direction)
            {
                case Direction.up:
                    {
                        pacmanMouthOpen = Properties.Resources.PacmanUp;
                        pacmanMouthClose = Properties.Resources.PacmanUp2;
                        break;
                    }

                case Direction.down:
                    {
                        pacmanMouthOpen = Properties.Resources.PacmanDown;
                        pacmanMouthClose = Properties.Resources.PacmanDown2;
                        break;
                    }

                case Direction.left:
                    {
                        pacmanMouthOpen = Properties.Resources.PacmanLeft;
                        pacmanMouthClose = Properties.Resources.PacmanLeft2;
                        break;
                    }

                case Direction.right:
                    {
                        pacmanMouthOpen = Properties.Resources.PacmanRight;
                        pacmanMouthClose = Properties.Resources.PacmanRight2;
                        break;
                    }
            }
            pacman.Move();
        }

        private void PacmanAnimation()//changing the pacman's image between mouth open and close to create an animation
        {
            if (pacman.CharacterImage == pacmanMouthOpen)
            {
                pacman.CharacterImage = pacmanMouthClose;
            }
            else 
            {
                pacman.CharacterImage = pacmanMouthOpen;
            }
        }

        public void SetLives(PictureBox live1, PictureBox live2, PictureBox live3)//setting the visibility of the three pictureboxes according to how many lives pacman has left
        {
            switch (pacman.Life)
            {
                case 0:
                    {
                        live1.Visible = false;
                        live2.Visible = false;
                        live3.Visible = false;
                        break;
                    }
                case 1:
                    {
                        live1.Visible = false;
                        live2.Visible = false;
                        live3.Visible = true;
                        break;
                    }
                case 2:
                    {
                        live1.Visible = false;
                        live2.Visible = true;
                        live3.Visible = true;
                        break;
                    }
                case 3:
                    {
                        live1.Visible = true;
                        live2.Visible = true;
                        live3.Visible = true;
                        break;
                    }
            }
        }

        private void DrawGhouls()//drawing all four ghouls onto the maze
        {
            foreach (Ghoul ghoul in ghouls)
            {
                ghoul.Draw();
            }
        }

        private void MoveGhouls()//moving all four ghouls around the maze
        {
            foreach (Ghoul ghoul in ghouls)
            {
                ghoul.Move();
            }
        }

        private void CheckForPacmanGhouls()//getting all four ghouls to check if its position is the same as pacman's position
        {
            foreach (Ghoul ghoul in ghouls)
            {
                ghoul.CheckForPacman(pacman.Position);
            }
        }

        private void ChasePacman()//getting all four ghouls to chase after pacman
        {
            foreach (Ghoul ghoul in ghouls)
            {
                ghoul.ChasePacman(pacman.Position);
            }
        }

        private void CheckNumberOfKibble()//checking to see if all the kibbles are gone, if all the kibbles are gone the player wins
        {
            if (maze.NKibbles == 0)
            {
                gameWin = true;
            }
        }

        public bool GameEnd
        {
            get
            {
                return gameEnd;
            }
            set
            {
                gameEnd = value;
            }
        }

        public bool GameWin
        {
            get
            {
                return gameWin;
            }

            set
            {
                gameWin = value;
            }
        }
    }
}
