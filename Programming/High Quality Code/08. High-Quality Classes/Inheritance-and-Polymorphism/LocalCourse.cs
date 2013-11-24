//-----------------------------------------------------------------------
// <copyright file="LocalCourse.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a local course.
    /// </summary>
    public class LocalCourse : Course
    {
        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName)
            : this(courseName, null, null, null)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, null, null)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
