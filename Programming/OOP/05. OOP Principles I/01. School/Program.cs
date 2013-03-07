using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace School
{
    //01. We are given a school. In the school there are classes
    // of students. Each class has a set of teachers. Each teacher
    // teaches a set of disciplines. Students have name and unique
    // class number. Classes have unique text identifier. Teachers
    // have name. Disciplines have name, number of lectures and 
    // number of exercises. Both teachers and students are people. 
    // Students, classes, teachers and disciplines could have optional
    // comments (free text block).
	// Your task is to identify the classes (in terms of  OOP) and 
    // their attributes and operations, encapsulate their fields, 
    // define the class hierarchy and create a class diagram with 
    // Visual Studio.

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //test
                School.Number = 50;
                School.Name = "СОУ Драган Драганов";
                //add 2 classes
                Class class1 = new Class("012");
                Class class2 = new Class("035");
                School.NewClass(class1);
                School.NewClass(class2);
                //some Disciplines
                List<Discipline> disciplines1 = new List<Discipline>
                    {new Discipline("Nuclear Physics", 1, -1),      //will throw error
                     new Discipline("Astrophysics", 1, 2)};
                List<Discipline> disciplines2 = new List<Discipline>
                    {new Discipline("Analysis", 2, 1),
                     new Discipline("Applied mathematics", 2, 1)};
                List<Discipline> disciplines3 = new List<Discipline>
                    {new Discipline("Painting", 1, 3),
                     new Discipline("Photography", 1, 3)};
                //some Teachers
                List<Teacher> teachers = new List<Teacher>
                    {new Teacher("M. Petrov"),
                     new Teacher("L. Borisova"),
                     new Teacher("K. Nakov")};
                //some students
                List<Student> students = new List<Student>
                    {new Student("Gosho P.", 10),
                     new Student("Pesho B.", 10),
                     new Student("Sasho K.", 10)};
                List<Student> students2 = new List<Student>
                    {new Student("Misho P.", 10),
                     new Student("Tosho B.", 10),
                     new Student("Rasho K.", 10)};
                //add teachers and students to each class
                class1.AddTeachers(teachers);
                class1.AddStudents(students);
                class2.AddTeachers(teachers);
                class2.AddStudents(students2);
                //add disciplines for each Teacher
                class1.SetOfTeachers[0].AddDisciplines(disciplines1);
                class1.SetOfTeachers[1].AddDisciplines(disciplines2);
                class1.SetOfTeachers[2].AddDisciplines(disciplines3);
                class2.SetOfTeachers[0].AddDisciplines(disciplines1);
                class2.SetOfTeachers[1].AddDisciplines(disciplines2);
                class2.SetOfTeachers[2].AddDisciplines(disciplines3);
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var stack = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = stack.GetFrame(0);
                // Get the line number from the stack frame
                //var lineNumber = frame.GetFileLineNumber();
                Console.WriteLine(ex.Message + "\n" + frame);
            }
        }
    }
}
