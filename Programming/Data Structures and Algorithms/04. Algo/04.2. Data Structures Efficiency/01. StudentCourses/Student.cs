using System;
using System.Linq;

namespace StudentCourses
{
    public class Student : IComparable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Course { get; set; }

        public Student(string fName, string lName,string course)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Course = course;
        }

        public int CompareTo(object obj)
        {
            Student other = obj as Student;
            var result = this.LastName.CompareTo(other.LastName);

            return result;
        }

        public override string ToString()
        {
            string result = this.FirstName + " " + this.LastName;
            return result;
        }
    }
}
