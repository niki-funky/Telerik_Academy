using System;
using System.Linq;

namespace Animals
{
    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private Sex sex;

        //properties
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be zero or greater!");
                }
                this.age = value;
            }
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
                    throw new ArgumentException("Animal must have name!");
                }
                this.name = value;
            }
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        //constructor
        public Animal(int age, string name, Sex sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        //method
        public virtual void MakeSound()
        {

        }
    }
}
