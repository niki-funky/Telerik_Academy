using System;
using System.Linq;
using System.Text;

namespace Person
{
    class Person
    {
        //properties
        public string Name { get; set; }
        public int? Age { get; set; }

        //constructors
        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name)
            : this(name, null)
        {
        }

        //overriding methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);
            if (!this.Age.HasValue)
            {
                sb.AppendLine("Person doesn't have age!");
            }
            else
            {
                sb.AppendLine(this.Age.ToString());
            }
            return sb.ToString();
        }
    }
}
