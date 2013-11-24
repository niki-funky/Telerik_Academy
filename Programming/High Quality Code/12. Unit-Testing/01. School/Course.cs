//-----------------------------------------------------------------------
// <copyright file="Course.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a course in school.
    /// </summary>
    public class Course
    {
        public const int MaxValue = 30;

        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.ListOfStudents = new List<Student>();
        }

        public List<Student> ListOfStudents { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be empty!");
                }

                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student should not be null!");
            }

            bool isSignedInCourse = this.CheckIfStudentIsSignedIn(student);

            if (isSignedInCourse)
            {
                throw new ArgumentException("The student is already signed in this course!");
            }

            if (this.ListOfStudents.Count + 1 < MaxValue)
            {
                this.ListOfStudents.Add(student);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The course is full!");
            }
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student should not be null!");
            }

            bool isSignedInCourse = this.CheckIfStudentIsSignedIn(student);

            if (!isSignedInCourse)
            {
                throw new ArgumentException("The student is not signed in this course!");
            }

            this.ListOfStudents.Remove(student);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Course name -> {0}; ", this.Name);
            result.AppendFormat("Course students -> {0}", this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.ListOfStudents.Count == 0)
            {
                return "{ No students }";
            }
            else
            {
                return "{ " + string.Join(", " + "\n", this.ListOfStudents) + " }";
            }
        }

        private bool CheckIfStudentIsSignedIn(Student student)
        {
            var found = this.ListOfStudents.Any(x => x.Number == student.Number);
            return found;
        }
    }
}
