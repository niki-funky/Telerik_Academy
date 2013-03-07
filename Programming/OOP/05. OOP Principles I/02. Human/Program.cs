using System;
using System.Collections.Generic;
using System.Linq;

namespace Human
{
    //02. Define abstract class Human with first name and last name.
    // Define new class Student which is derived from Human and has
    // new field – grade. Define class Worker derived from Human with
    // new property WeekSalary and WorkHoursPerDay and method MoneyPerHour()
    // that returns money earned by hour by the worker. Define the proper
    // constructors and properties for this hierarchy. Initialize a list
    // of 10 students and sort them by grade in ascending order (use LINQ
    // or OrderBy() extension method). Initialize a list of 10 workers 
    // and sort them by money per hour in descending order. Merge the 
    // lists and sort them by first name and last name.

    class Program
    {
        static void Main(string[] args)
        {
            //list of 10 students
            List<Student> listOfStudents = new List<Student>{
                new Student("Gosho","Petrov",1),
                new Student("Pesho","Ivanov",3),
                new Student("Misho","Marinov",2),
                new Student("Sasho","Nakov",3),
                new Student("Tosho","Naidenov",1),
                new Student("Asho","Vasilev",1),
                new Student("Jet","Li",2),
                new Student("Bruce","Lee",1),
                new Student("Hon","GilDon",2),
                new Student("Jackie","Chan",3)};

            //list of 10 workers
            List<Worker> listOfWorkers = new List<Worker>{
                new Worker("Bai","Ivan",100,2),
                new Worker("Bai","Gencho",200,4),
                new Worker("Bai","Stefan",150,4),
                new Worker("Bai","Nedko",150,6),
                new Worker("Bai","Peter",400,7),
                new Worker("Bai","Milcho",200,8),
                new Worker("Bai","Velcho",300,4),
                new Worker("Bai","Ljuben",200,5),
                new Worker("Bai","Mino",500,6),
                new Worker("Bash","Maistora",900,8)};

            //sort the Lists
            listOfStudents = listOfStudents.OrderBy(x => x.Grade).ToList();
            listOfWorkers = listOfWorkers.OrderByDescending(x => x.MoneyPerHour()).ToList();

            #region print sorted lists
            Console.WriteLine("----Sorted(students)----");
            foreach (var item in listOfStudents)
            {
                Console.WriteLine(String.Format("{0,-6}{1}", item.FirstName, " : "+ item.Grade));
            }
            Console.WriteLine();
            Console.WriteLine("----Sorted(workers)----");
            foreach (var item in listOfWorkers)
            {
                Console.WriteLine(String.Format("{0,-6}{1,-6}", item.FirstName, " : "+ item.MoneyPerHour()));
            }
            #endregion

            //merge the two lists and then sort by name
            var result = listOfStudents.Concat<Human>(listOfWorkers).
                OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            //print merged list
            Console.WriteLine();
            Console.WriteLine("----Merged----");
            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName +" "+ item.LastName);
            }
        }
    }
}
