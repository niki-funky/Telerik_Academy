using System;
using System.Linq;

namespace Animals
{
    class Kitten : Cat
    {
        //constructor
        public Kitten(int age, string name)
            : base(age, name, Sex.female)
        {

        }

        //method
        public override void MakeSound()
        {
            Console.WriteLine("mew mew!");
        }
    }
}
