using System;
using System.Linq;

namespace Animals
{
    class Dog : Animal
    {
        //constructor
        public Dog(int age, string name, Sex sex)
            : base(age, name, sex)
        {

        }

        //method
        public override void MakeSound()
        {
            Console.WriteLine("bark bark!");
        }
    }
}
