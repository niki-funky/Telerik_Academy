using System;
using System.Linq;

namespace Human
{
    public abstract class Human
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        //constructor
        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }
    }
}
