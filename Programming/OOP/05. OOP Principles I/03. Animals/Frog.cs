using System;
using System.Linq;

namespace Animals
{
    class Frog : Animal
    {
        //constructor
        public Frog(int age, string name, Sex sex)
            : base(age, name, sex)
        {

        }

        //method
        public override void MakeSound()
        {
            Console.WriteLine("ribbit ribbit!");
        }
    }
}
