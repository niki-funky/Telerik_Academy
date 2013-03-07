using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class Class
    {
        //fields
        private string identifier;
        private string comments;

        //properties
        public List<Teacher> SetOfTeachers {get; private set;}
        public List<Student> SetOfStudents { get; private set; }

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
        public string Identifier
        {
            get
            {
                return this.identifier;
            }
            set
            {
                this.identifier = value;
            }
        }

        //constructors
        public Class(string uid)
        {
            this.SetOfTeachers = new List<Teacher>();
            this.SetOfStudents = new List<Student>();
            this.Identifier = uid;
        }
        public Class(string uid,string comment)
            :this(uid)
        {
            this.Comments = comment;
        }

        //methods
        //add teacher
        public void AddTeacher(Teacher teacher)
        {
            SetOfTeachers.Add(teacher);
        }
        public void AddTeachers(List<Teacher> teachers)
        {
            SetOfTeachers.AddRange(teachers);
        }
        //add student
        public void AddStudent(Student student)
        {
            SetOfStudents.Add(student);
        }
        public void AddStudents(List<Student> students)
        {
            SetOfStudents.AddRange(students);
        }
    }
}
