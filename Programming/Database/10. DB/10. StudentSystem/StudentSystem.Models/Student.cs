using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSystem.Models
{
    public class Student
    {
        private ICollection<Course> cources;
        private ICollection<Homework> homeworks;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public Student()
        {
            this.cources = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public virtual ICollection<Course> Cources
        {
            get { return this.cources; }
            set { this.cources = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

    }
}
