//Controlls the gameplay and action of the game

using System;
using System.Drawing;

namespace SnakeGame
{
    public class GameManager
    {
        private Grid grid;
        private Random rand;
        private Snake snake;
        private Frog frog;

        public GameManager(Grid grid, Random rand)//constructor
        {

            this.grid = grid;
            this.rand = rand;
            snake = new Snake(Properties.Resources.snakeEyes, Properties.Resources.snakeSkin, grid);
            frog = new Frog(Properties.Resources.frog, grid);
        }

        public void StartNewGame()//set up for a new game
        {
            snake.Position.Clear();
            snake = new Snake(Properties.Resources.snakeEyes, Properties.Resources.snakeSkin, grid);
        }
        
        public ErrorMessage PlayGame()//the actual gameplay of the game, the action that occur at each timer tick
        {
            grid.Draw();
            snake.Draw();

            if (frog.Alive == false)
            {
                frog.Position = FindFreeCell();
                frog.Alive = true;
            }

            frog.Draw();
            snake.Move();
            
            ErrorMessage message = ErrorMessage.noError;

            if (snake.CheckWall() == true)
            {
               message = ErrorMessage.snakeHitWall;
               frog.Alive = false;
            }

            if (snake.CheckSelf() == true)
            {
                message = ErrorMessage.snakeHitSelf;
                frog.Alive = false;
            }

            if (snake.EatFrog(frog.Position) == true)
            {
                frog.Alive = false;
                snake.Grow();
                message = ErrorMessage.snakeEatenFrog;
            }

            return message; 
        }

        private Point FindFreeCell()//finding a free cell in the grid and returning a point value
        {
            Point target = Point.Empty;

            while (target == Point.Empty)
            {
               int i = rand.Next(30);
               int j = rand.Next(30);

                if (grid.Rows[i].Cells[j].Value == grid.Blank)//checking if there is already something on the grid
                {
                   target = new Point(i, j);
                }
            }

            return target;
        }

        public void SetSnakeDirection(Direction direction)//setting the direction for the snake to move
        {
            snake.Direction = direction;
        }
  }
}
