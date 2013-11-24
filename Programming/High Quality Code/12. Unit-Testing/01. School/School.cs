//-----------------------------------------------------------------------
// <copyright file="School.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a school.
    /// </summary>
    public class School
    {
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.Courses = new List<Course>();
        }

        public List<Course> Courses { get; set; }

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

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course should not be null!");
            }

            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course should not be null!");
            }

            bool courseFound = this.Courses.Any(x => x.Name == course.Name);
            if (courseFound)
            {
                this.Courses.Remove(course);
            }
            else
            {
                throw new ArgumentException("The course does not exist.");
            }
        }
    }
}
