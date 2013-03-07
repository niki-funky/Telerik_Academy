using System;
using System.Linq;

namespace School
{
    public class Discipline
    {
        //field
        private string name;
        private int numberOfLectures;
        private int numberOfExersises;
        private string comments;

        //properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number is not valid!");
                }
                this.numberOfLectures = value;
            }
        }
        public int NumberOfExersises
        {
            get
            {
                return this.numberOfExersises;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number is not valid!");
                }
                this.numberOfExersises = value;
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

        //constructor
        public Discipline(string name, int lectures, int exersizes)
        {
            this.Name = name;
            this.NumberOfLectures = lectures;
            this.NumberOfExersises = exersizes;
        }
        public Discipline(string name, int lectures, int exersizes, string comments)
            :this(name,lectures,exersizes)
        {
            this.Comments = comments;
        }
    }
}
