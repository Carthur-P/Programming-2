/*
 * The Animal class
 *contains the fields, contructor and methods that define an animal
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProject
{
    public class Animal
    {
        //private data members
        private string type;
        private string name;
        private int legs;


        //this is the contructor (This should be the same name as the class), used to assign initial values to the field, no return type
        public Animal(string type, string name, int legs)
        {
            this.type = type;
            this.name = name;
            this.legs = legs;
        }

        //method
        public string ListDetails()
        {
            return ("I am an " + type + ". my name is " + name + " and i have " + legs + " legs."); //this will return/give the following statement
        }
    }

}
