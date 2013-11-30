using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StudentsDatabase.Controllers
{
    public class StudentsController : ApiController
    {
        //GET api/student
        public IEnumerable<Student> Get()
        {
            var students = new List<Student>();
            var marks = new List<Mark>();
            marks.Add(new Mark()
            {
                Subject = "subject",
                Value = 1
            });
            marks.Add(new Mark()
            {
                Subject = "subject2",
                Value = 3
            });
            marks.Add(new Mark()
            {
                Subject = "subject3",
                Value = 3
            });
            students.Add(new Student()
            {
                Id = 0,
                FirstName = "Pesho",
                LastName = "Peshev",
                Grade = 2,
                Marks = marks
            });
            students.Add(new Student()
            {
                Id = 1,
                FirstName = "Gosho",
                LastName = "Goshev",
                Grade = 5,
                Marks = marks
            });
            students.Add(new Student()
            {
                Id = 2,
                FirstName = "Tosho",
                LastName = "Toshev",
                Grade = 3,
                Marks = marks
            });
            students.Add(new Student()
            {
                Id = 3,
                FirstName = "Losho",
                LastName = "Loshev",
                Grade = 10,
                Marks = marks
            });

            //return Serializer.GetEntities(students);
            return students;
        }
    }
}
