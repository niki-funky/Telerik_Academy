//-----------------------------------------------------------------------
// <copyright file="SchoolTest.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolConstructorName1()
        {
            School school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolConstructorName2()
        {
            School school = new School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolConstructorName3()
        {
            School school = new School(" ");
        }

        [TestMethod]
        public void TestSchoolConstructorName4()
        {
            School school = new School("Telerik");

            Assert.AreEqual("Telerik", school.Name, "School name not set correctly.");
        }

        [TestMethod]
        public void TestAddCourse1()
        {
            School school = new School("Telerik");
            Course course = new Course("JavaScript");

            school.AddCourse(course);
            Assert.AreEqual(1, school.Courses.Count, "Course was not added successfully.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddCourse2()
        {
            School school = new School("Telerik");
            school.AddCourse(null);
        }

        [TestMethod]
        public void TestRemoveCourse1()
        {
            School school = new School("Telerik");
            Course course = new Course("JavaScript");

            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(0, school.Courses.Count, "Course was not removed successfully.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveCourse2()
        {
            School school = new School("Telerik");
            Course course = new Course("JavaScript");

            school.AddCourse(course);
            school.RemoveCourse(new Course("Web"));
            Assert.AreEqual(0, school.Courses.Count, "Course was not removed successfully.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveCourse3()
        {
            School school = new School("Telerik");
            Course course = new Course("JavaScript");

            school.AddCourse(course);
            school.RemoveCourse(null);
            Assert.AreEqual(0, school.Courses.Count, "Course was not removed successfully.");
        }
    }
}
