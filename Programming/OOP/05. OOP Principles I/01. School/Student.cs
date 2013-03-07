using System;
using System.Linq;

namespace School
{
    public class Student : Person
    {
        //fields
        private int classNumber;
        private string comments;

        //properties
        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number is not valid!");
                }
                this.classNumber = value;
            }
        }
        public string Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        //constuctors
        public Student(string name, int number)
            : base(name)
        {
            this.ClassNumber = number;
        }
        public Student(string name, int number, string comments)
            : this(name, number)
        {
            this.Comments = comments;
        }
    }
}
