namespace NamingIdentifiers
{
    using System;
    using System.Linq;

    public class Humans
    {
        public enum Sex
        {
            Male,
            Female
        }

        public void CreateHuman(int magicNumber)
        {
            Human newHuman = new Human();
            newHuman.Age = magicNumber;

            if (magicNumber % 2 == 0)
            {
                newHuman.Name = "Dandy";
                newHuman.Sex = Sex.Male;
            }
            else
            {
                newHuman.Name = "Goddess";
                newHuman.Sex = Sex.Female;
            }
        }

        public class Human
        {
            public Sex Sex { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
