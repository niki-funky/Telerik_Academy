//-----------------------------------------------------------------------
// <copyright file="Demo.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace SchoolDemo
{
    using System;
    using System.Linq;
    using School;

    /// <summary>
    /// Demo for the program.
    /// </summary>
    internal class Demo
    {
        private static void Main()
        {
            try
            {
                Student pesho = new Student("Pesho Georgiev");
                Student gosho = new Student("Gosho Ivanov");
                Student misho = new Student("Misho Cekov");
                Student sasho = new Student("Sasho Kostov");

                Course telerikAcademy = new Course("Telerik Academy");
                Course webProgramming = new Course("Web Programming");

                webProgramming.AddStudent(sasho);

                telerikAcademy.AddStudent(pesho);
                telerikAcademy.AddStudent(gosho);
                telerikAcademy.AddStudent(misho);

                telerikAcademy.RemoveStudent(gosho);
                Console.WriteLine(gosho.ToString() + " was removed from course.");

                Console.WriteLine("Courses:");
                Console.WriteLine(telerikAcademy);

                School freeSchool = new School("School of Computer Sciences");
                freeSchool.AddCourse(webProgramming);
                freeSchool.AddCourse(telerikAcademy);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
