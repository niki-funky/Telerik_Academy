using System;
using System.Linq;

namespace Animals
{
    class Tomcat : Cat
    {
        //constructor
        public Tomcat(int age, string name)
            : base(age, name, Sex.male)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("purr purr!");
        }
    }
}
