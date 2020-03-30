//creating the cell for the simulation

using System.Collections.Generic;

namespace Conways
{
    public class Cell
    {
        private List<Cell> neighbours;
        private bool currentState;
        private bool nextState;
        private int generation;

        public Cell()//constructor
        {
            neighbours = new List <Cell>(); 
            currentState = false;
            nextState = false;
            generation = 0;
        }

        public void CalculateNextState()//calculating to see how many neighbours are alive
        {
            int aliveCount = 0;

            foreach (Cell neighbours in neighbours)
            {
                if (neighbours.currentState == true)
                {
                    aliveCount = aliveCount + 1;
                }
            }

            nextState = false;//setting eveyone to dead to then be change by the rules

            if (currentState == true)
            {
                if ((aliveCount == 2) || (aliveCount == 3))
                {
                    nextState = true;
                    generation = generation + 1;
                }
            }
            else if (currentState == false)
            {
                if (aliveCount == 3)
                {
                    nextState = true;
                    generation = generation + 1;
                }
            }
        }

        public void UpdateToNextState()//updating the currentState to nextState
        {
            currentState = nextState;

            if (nextState == false)
            {
                generation = 0;
            }
        }

        public void Neighbour(Cell neighbour)
        {
            neighbours.Add(neighbour);
        }

        public bool CurrentState
        {
            get
            {
                return currentState;
            }

            set
            {
                currentState = value;
            }
        }

        public int Generation
        {
            get
            {
                return generation;
            }

            set
            {
                generation = value;
            }
        }
    }
}
