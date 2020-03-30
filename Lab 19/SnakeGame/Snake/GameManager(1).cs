using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    public class GameManager
    {
        private Grid grid;
        private Random rand;
        private Snake snake;

        public GameManager(Grid grid, Random rand)
        {

            this.grid = grid;
            this.rand = rand;
            snake = new Snake(Properties.Resources.snakeEyes, Properties.Resources.snakeSkin, grid);
        }

        public void StartNewGame()
        {
            

        }
        
        public ErrorMessage PlayGame()
        {
            grid.Draw();
            snake.Draw();
            snake.Move();
            
            ErrorMessage message = ErrorMessage.noError;

            //if (snake.HitWall() == true)
            {
               // message = ErrorMessage.snakeHitWall;
            }

            return message; 
        }

        private Point FindFreeCell()
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

        public void SetSnakeDirection(Direction direction)
        {
            snake.Direction = direction;
        }
  }
}
