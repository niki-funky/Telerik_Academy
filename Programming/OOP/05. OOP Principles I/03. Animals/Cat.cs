using System;
using System.Linq;

namespace Animals
{
    class Cat : Animal
    {
        //constructor
        public Cat(int age, string name, Sex sex)
            : base(age, name, sex)
        {

        }

        //method
        public override void MakeSound()
        {
            Console.WriteLine("meow meow!");
        }
    }
}
