using System;
using System.Linq;
using System.Text;

namespace StudentsNames
{
    // 03. Write a method that from a given array of students 
    // finds all students whose first name is before its 
    // last name alphabetically. Use LINQ query operators.

    // 04. Write a LINQ query that finds the first name 
    // and last name of all students with age between 18 and 24.

    // 05. Using the extension methods OrderBy() and ThenBy()
    // with lambda expressions sort the students by first name
    // and last name in descending order. Rewrite the same with LINQ.

    class Program
    {
        static void Main(string[] args)
        {
            //anonymous type
            var arr = new Students[]
            {
                new Students {FirstName = "Gosho", LastName = "Petrov", Age = 15},
                new Students {FirstName = "Pesho", LastName = "Cvetkov", Age = 19},
                new Students {FirstName = "Misho", LastName = "Ivanov", Age = 24}
            };

            Console.WriteLine(ToString(SortStudentsByName(arr)));
            Console.WriteLine(ToString(SortStudentsByAge(arr)));
            Console.WriteLine(ToString(SortStudentsUsingLambda(arr)));
            Console.WriteLine(ToString(SortStudentsUsingLINQ(arr))); 
        }

        public static Students[] SortStudentsByName(Students[] arr)
        {
            var result = from x in arr
                         where x.FirstName.CompareTo(x.LastName) < 0
                         select x;
            return result.ToArray();
        }

        public static Students[] SortStudentsByAge(Students[] arr)
        {
            var result = from x in arr
                         where x.Age <= 24 && x.Age >= 18
                         select x;
            return result.ToArray();
        }

        public static Students[] SortStudentsUsingLambda(Students[] arr)
        {
            var result = arr.OrderByDescending(x => x.FirstName).
                        ThenByDescending(x => x.LastName).ToArray();
            return result.ToArray();
        }

        public static Students[] SortStudentsUsingLINQ(Students[] arr)
        {
            var result = from x in arr
                         orderby x.FirstName descending, x.LastName descending
                         select x;
            return result.ToArray();
        }

        //method to print Students[] array
        public static string ToString(Students[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in arr)
            {
                sb.AppendLine(item.FirstName
                    + ", " 
                    + item.LastName 
                    + ", " 
                    + item.Age);
            }
            return sb.ToString();
        }
    }
}
