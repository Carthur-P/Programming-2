//Acts as the game engine and controls the behaviour such as drawing the cells and setting the colours of the cells

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Conways
{
    public class World
    {
        private const int NCELLS = 2500;
        private const int NCOLS = 50; 
        private const int NROWS = 50;
        private const int RANDFILL = 40;
        private const int CHANCE = 101;

        private Random random;
        private Grid grid;
        private List <Cell> worldCells;
            
        public World(Random random, Grid grid)//constructor
        {
            this.random = random;
            this.grid = grid;
            worldCells = new List <Cell>();

            for (int i = 0; i < NCELLS; i++)
            {
                worldCells.Add(new Cell());   
            }         

            //assign neighbours 
            int LeftColumn, RightColumn, TopRow, BottomRow;

            for (int i = 0; i < NCELLS; i++)
            {     
                int column = i % NCOLS;
                int row = i / NROWS;
              
                if (column == 0)
                {
                    LeftColumn = (NCOLS-1); 
                }
                else
                {
                    LeftColumn = column - 1;
                }

                if (column == (NCOLS -1))
                {
                    RightColumn = 0;
                }
                else
                {
                    RightColumn = column + 1;
                }

                if (row == 0)
                {
                    TopRow = (NROWS-1);
                }
                else
                {
                    TopRow = row - 1;
                }

                if (row == (NROWS  - 1))
                {
                    BottomRow = 0;
                }
                else
                {
                    BottomRow = row + 1;
                }

                worldCells[column * NCOLS + row].Neighbour(worldCells[LeftColumn * NCOLS + TopRow]);

                worldCells[column * NCOLS + row].Neighbour(worldCells[LeftColumn * NCOLS + row]);

                worldCells[column * NCOLS + row].Neighbour(worldCells[LeftColumn * NCOLS + BottomRow]);

                worldCells[column * NCOLS + row].Neighbour(worldCells[RightColumn * NCOLS + TopRow]);

                worldCells[column * NCOLS + row].Neighbour(worldCells[RightColumn * NCOLS + row]);

                worldCells[column * NCOLS + row].Neighbour(worldCells[RightColumn * NCOLS + BottomRow]);

                worldCells[column * NCOLS + row].Neighbour(worldCells[column * NCOLS + TopRow]);

                worldCells[column * NCOLS + row].Neighbour(worldCells[column * NCOLS + BottomRow]);
            }
        }

        public void Clear()//clearing all the cell to set up for a new simulation
        {
            foreach (Cell worldCell in worldCells)      
            {
                worldCell.CurrentState = false;
                worldCell.Generation = 0;
            }
        }

        public void Fill()//setting cells to be alive with a 40% chance
        { 
            foreach (Cell worldCell in worldCells)
            {
                int chance = random.Next(1, CHANCE);

                if (chance >= RANDFILL)
                {
                    worldCell.CurrentState = true;
                    worldCell.Generation = 0;
                }
            }
        }

        public void Draw()//drawing all the cells onto the form
        {
            foreach (Cell worldCell in worldCells)
            {
                grid.SetCellColour(worldCells.IndexOf(worldCell), Color.White); 
                
                if (worldCell.CurrentState)
                {
                    switch (worldCell.Generation)
                    {
                        case 0:
                            grid.SetCellColour(worldCells.IndexOf(worldCell), Color.Aqua);
                            break;
                        case 1:
                            grid.SetCellColour(worldCells.IndexOf(worldCell), Color.Aqua);
                            break;
                        case 2:
                            grid.SetCellColour(worldCells.IndexOf(worldCell), Color.Teal);
                            break;
                        case 3:
                            grid.SetCellColour(worldCells.IndexOf(worldCell), Color.Blue);
                            break;
                        case 4:
                            grid.SetCellColour(worldCells.IndexOf(worldCell), Color.Navy);
                            break;
                        default:
                            grid.SetCellColour(worldCells.IndexOf(worldCell), Color.Purple);
                            break;
                    }
                }
                else
                {
                    grid.SetCellColour(worldCells.IndexOf(worldCell), Color.White);
                }
            }
        }

        public void UpdateWorld()//checking the next state of the cell and updating it
        {
            foreach (Cell worldCell in worldCells)
            {
                worldCell.CalculateNextState();
            }

            foreach (Cell worldCell in worldCells)
            {
                worldCell.UpdateToNextState();
            }
        }
    }
}
