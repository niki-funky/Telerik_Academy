using System;
using System.Linq;

namespace Human
{
    class Student : Human
    {
        public int Grade { get; set; }

        //constructor
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }
    }
}
