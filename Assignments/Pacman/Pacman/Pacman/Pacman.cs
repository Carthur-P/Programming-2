//This class will control the behavior specific to the character Pacman. This class will also inherits from the character class.

using System.Drawing;
using System.Media;

namespace Pacman
{
    public class Pacman : Character
    {
        private const int STARTX = 10;
        private const int STARTY = 9;
        private const int LIVES = 3;
        private const int MAZECOLUMN = 21;

        private int score;
        private int life;
        private SoundPlayer eatKibble;

        public Pacman(Bitmap characterImage, Maze maze)//constructor
            : base(characterImage, maze)
        {
            this.maze = maze;
            position = new Point(STARTX, STARTY);
            eatKibble = new SoundPlayer(Properties.Resources.EatKibble);
            score = 0;
            life = LIVES;
        }

        public override void Move()//moving pacman by one maze grid 
        {
            SetNextPosition();
            MoveOutsideMaze();

            if (CheckForWall() == false)//pacman can move
            {
                position = nextPosition;
                EatKibble();
            }
        }

        private void EatKibble()//making the kibble disappear when Pacman moves over it
        {
            int index = position.X + (position.Y * MAZECOLUMN);//equation to find the string positioning base on the gird location

            if (maze.Map.Substring(index, 1) == "k")//checking to see if the position pacman is on is a kibble
            {
                eatKibble.Play();
                string newMap = maze.Map.Substring(0, index) + "b" + maze.Map.Substring(index + 1);//setting the new updated string
                maze.Map = newMap;//updating the map
                score++;
                maze.NKibbles--;
            }
        }

        public override void Draw()//drawing the pacman onto the maze
        {
            GetGridCellForPosition(position).Value = characterImage;          
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
            }
        }
    }
}
