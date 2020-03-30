/* Clown class
 * This contains the fields, contructor and the method
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus
{
    public class Clown
    {
        //this is the feild (private date members)
        private string name;
        private int height;
        private int age;

       public Clown(string name, int height, int age) //this is the constructor
        {
            this.name = name;
            this.height = height;
            this.age = age;
        }

        public string TalkAboutYourself()
        {
            return ("My name is " + name + "\nI am " + height + " cm tall \nI am " + age + "years old"); 
              
        }
    }
}
