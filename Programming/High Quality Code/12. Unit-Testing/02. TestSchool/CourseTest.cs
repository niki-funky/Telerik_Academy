//-----------------------------------------------------------------------
// <copyright file="CourseTest.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourseConstructorName1()
        {
            Course course = new Course("Telerik Academy");
            Assert.AreEqual("Telerik Academy", course.Name, "Course name not set correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructorName2()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructorName3()
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructorName4()
        {
            Course course = new Course(" ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddStudent1()
        {
            Course course = new Course("Telerik Academy");
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddStudent2()
        {
            Course course = new Course("Telerik Academy");
            Student misho = new Student("Misho Ivanov");
            Student pesho = new Student("Pesho Ivanov");
            pesho.Number = misho.Number;
            course.AddStudent(misho);
            course.AddStudent(pesho);
        }

        [TestMethod]
        public void TestAddStudent3()
        {
            Course course = new Course("Telerik Academy");
            Student misho = new Student("Misho Ivanov");
            course.AddStudent(misho);

            Assert.AreEqual(1, course.ListOfStudents.Count, "Student was not added successfully.");
        }

        [TestMethod]
        public void TestAddStudent4()
        {
            Course course = new Course("Telerik Academy");
            Student misho = new Student("Misho Ivanov");
            Student pesho = new Student("Pesho Ivanov");
            course.AddStudent(misho);
            course.AddStudent(pesho);
            Assert.IsTrue(course.ListOfStudents.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddStudent5()
        {
            Course course = new Course("Telerik Academy");
            for (int i = 0; i < Course.MaxValue + 1; i++)
            {
                course.AddStudent(new Student("Misho Ivanov"));
            }
        }

        [TestMethod]
        public void TestRemoveStudent1()
        {
            Course course = new Course("Telerik Academy");
            Student misho = new Student("Misho Ivanov");
            course.AddStudent(misho);
            course.RemoveStudent(misho);

            Assert.AreEqual(0, course.ListOfStudents.Count, "Student was not removed successfully.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveStudent2()
        {
            Course course = new Course("Telerik Academy");
            Student misho = new Student("Misho Ivanov");
            course.AddStudent(misho);
            course.RemoveStudent(new Student("Pesho Ivanov"));

            Assert.AreEqual(1, course.ListOfStudents.Count, "Non-existent student was removed.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveStudent3()
        {
            Course course = new Course("Telerik Academy");

            course.RemoveStudent(null);
        }

        [TestMethod]
        public void TestCourseToString1()
        {
            Course course = new Course("Telerik Academy");
            Student misho = new Student("Misho Ivanov");
            Student pesho = new Student("Pesho Ivanov");
            course.AddStudent(misho);
            course.AddStudent(pesho);

            Assert.AreEqual(
                string.Format(
                "Course name -> Telerik Academy; Course students -> {{ {0}, \n{1} }}",
                misho,
                pesho),
                course.ToString(),
                "Course.ToString() is not correct.");
        }

        [TestMethod]
        public void TestCourseToString2()
        {
            Course course = new Course("Telerik Academy");

            Assert.AreEqual(
                "Course name -> Telerik Academy; Course students -> { No students }",
                course.ToString(),
                "Course.ToString() is not correct.");
        }
    }
}
