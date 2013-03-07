using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public static class School
    {
        private static int number;
        private static string name;

        public static List<Class> Classes { get; private set; }
        public static string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public static int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        static School()
        {
            Classes = new List<Class>();
            Number = number;
            Name = name;
        }

        public static void NewClass(Class newClass)
        {
            Classes.Add(newClass);
        }
    }
}
