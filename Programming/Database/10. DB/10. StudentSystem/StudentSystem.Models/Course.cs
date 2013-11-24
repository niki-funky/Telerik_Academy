using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;
        private ICollection<Material> materials;

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
            this.materials = new HashSet<Material>();
        }

        public virtual ICollection<Student> Student
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public virtual ICollection<Material> Materials
        {
            get { return this.materials; }
            set { this.materials = value; }
        }
    }
}
