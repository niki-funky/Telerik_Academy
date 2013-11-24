using System;
using System.Data.Entity;
using System.Linq;
using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Models;

namespace StudentSystem.Client
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            using (var db = new StudentSystemContext())
            {
                var material = new Material
                {
                    Content = "za sega njama"
                };
                db.Materials.Add(material);

                var course = new Course
                {
                    Name = "Algorihms",
                    Description = "gadno"
                };
                course.Materials.Add(material);
                db.Courses.Add(course);

                var student = new Student
                {
                    Name = "Pesho",
                    Number = 10000
                };
                student.Cources.Add(course);
                db.Students.Add(student);

                db.SaveChanges();
            }
        }
    }
}
