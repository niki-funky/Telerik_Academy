using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace StudentCourses
{
    // 01. A text file students.txt holds information about students and 
    // their courses in the following format: 
    // Kiril  | Ivanov   | C#
    // Stefka | Nikolova | SQL
    // Stela  | Mineva   | Java
    // Milena | Petrova  | C#
    // Ivan   | Grigorov | C#
    // Ivan   | Kolev    | SQL

    // Using SortedDictionary<K,T> print the courses in alphabetical order 
    // and for each of them prints the students ordered by family and then by name:
    // C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
    // Java: Stela Mineva
    // SQL: Ivan Kolev, Stefka Nikolova

    public class Program
    {
        public static void Main(string[] args)
        {
            var fileName = @"..\..\students.txt";
            SortedDictionary<string, OrderedBag<Student>> listOfCourses =
                new SortedDictionary<string, OrderedBag<Student>>();
            GetData(ref listOfCourses, fileName);
            PrintData(listOfCourses);
        }

        private static void GetData(
            ref SortedDictionary<string, OrderedBag<Student>> listOfCourses,
            string fileName)
        {
            string line;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var entry = line.Split('|');

                    var fName = entry[0].Trim();
                    var lName = entry[1].Trim();
                    var course = entry[2].Trim();

                    Student student = new Student(fName, lName, course);

                    if (!listOfCourses.ContainsKey(course))
                    {
                        OrderedBag<Student> listOfStudents = new OrderedBag<Student>();
                        listOfStudents.Add(student);
                        listOfCourses.Add(course, listOfStudents);
                    }
                    else
                    {
                        listOfCourses[course].Add(student);
                    }
                }
            }
        }

        private static void PrintData(
            SortedDictionary<string, OrderedBag<Student>> collection)
        {
            foreach (var item in collection)
            {
                Console.Write("{0}: ", item.Key);
                Console.WriteLine(item.Value.ToString());
                Console.WriteLine();
            }
        }
    }
}
