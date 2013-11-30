using StudentsDB.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsDB.Server.Controllers
{
    public class StudentsController : ApiController
    {
        private IEnumerable<Student> students;
        static Random rand = new Random();

        public StudentsController()
        {
            var students = new List<Student>();
            for (int i = 0; i < 15; i++)
            {
                var marks = new List<Mark>();
                for (int j = 0; j < 10; j++)
                {
                    marks.Add(new Mark()
                    {
                        Subject = "Subject #" + j,
                        Score = rand.Next(1,6)
                    });
                }
                students.Add(new Student()
                {
                    Id = i + 1,
                    Name = "Student #" + i,
                    Grade = i + 1,
                    Marks = marks
                });
            }
            this.students = students;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return this.students;
        }

        [ActionName("marks")]
        public IEnumerable<Mark> GetStudentMarks(int studentId)
        {
            return this.students.FirstOrDefault(st => st.Id == studentId).Marks;
        }
    }
}