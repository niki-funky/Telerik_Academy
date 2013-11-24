//-----------------------------------------------------------------------
// <copyright file="Student.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace School
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a student in course.
    /// </summary>
    public class Student
    {
        private const int MaxValue = 99999;
        private const int MinValue = 10000;
        private string name;
        private int number;

        public Student(string name)
        {
            this.Name = name;
            this.Number = Utilities.GetUN();
        }

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

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (value < MinValue || MaxValue < value)
                {
                    throw new ArgumentOutOfRangeException("Number should be in in range[10000...99999]!");
                }

                this.number = value;
            }
        }

        public override string ToString()
        {
            return string.Format("(Name = {0}, UN = {1})", this.Name, this.Number);
        }
    }
}
