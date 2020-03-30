using System;
using System.Collections.Generic;
using System.Drawing;

namespace MoleculeSimulation
{
    public class Controller
    {
        private const int FIFTY = 50;
        private const int BLACKXPOINT = 200;
        private const int BLACKYPOINT = 100;
        private const int REDXPOINT = 300;
        private const int REDYPOINT = 150;
        private const int BLUEXPOINT = 400;
        private const int BLUEYPOINT = 200;

        private Random rand;
        private Graphics graphics;  
        private List<Molecule> molecules;

        public Controller(Random rand, Graphics graphics)
        {
            molecules = new List<Molecule>();
            this.rand = rand;
            this.graphics = graphics;

            for (int i = 0; i < FIFTY; i++)
            {
                molecules.Add(new Molecule(rand, graphics, Color.Black, new Point(BLACKXPOINT, BLACKYPOINT)));
                molecules.Add(new Molecule(rand, graphics, Color.Red, new Point(REDXPOINT, REDYPOINT)));
                molecules.Add(new Molecule(rand, graphics, Color.Blue, new Point(BLUEXPOINT, BLUEYPOINT)));
                //adding a new molecule object into the molecules list
            }  
            //this will be done 50 times making the total item count in the list equals to 150
        }

        public void Run()
        {
            foreach (Molecule molecule in molecules)
            {
                molecule.Move();
                molecule.Draw();
            }
            //for each molecues object in the list molecues, call the 'move' and 'draw' method
        }    
    }
}
