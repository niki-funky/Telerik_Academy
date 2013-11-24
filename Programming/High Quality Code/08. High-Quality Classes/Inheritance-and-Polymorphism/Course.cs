//-----------------------------------------------------------------------
// <copyright file="Course.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a course.
    /// </summary>
    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course must have name.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value != null)
                {
                    this.students = new List<string>();

                    foreach (var student in value)
                    {
                        this.students.Add(student);
                    }
                }
                else
                {
                    this.students = null;
                }
            }
        }

        public void AddStudent(string student)
        {
            if (this.students == null)
            {
                this.students = new List<string>();
            }

            this.students.Add(student);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
