//-----------------------------------------------------------------------
// <copyright file="OffsiteCourse.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents an offsite course.
    /// </summary>
    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName)
            : this(courseName, null, null, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, null, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public string Town { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
