using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class Teacher : Person
    {
        //field
        private string comments;

        //property
        public List<Discipline> SetOfDisciplines{ get; private set; }
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

        //constructor
        public Teacher(string name)
            : base(name)
        {
            this.SetOfDisciplines = new List<Discipline>();
        }
        public Teacher(string name, string comments)
            : this(name)
        {
            this.Comments = comments;
        }

        //methods
        //add discipline
        public void AddDiscipline(Discipline discipline)
        {
            SetOfDisciplines.Add(discipline);
        }
        public void AddDisciplines(List<Discipline> disciplines)
        {
            SetOfDisciplines.AddRange(disciplines);
        }
    }
}
