//-----------------------------------------------------------------------
// <copyright file="StudentTest.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestStudentConstructorName1()
        {
            string name = "Pesho Ivanov";
            Student student = new Student(name);
            Assert.AreEqual(student.Name, "Pesho Ivanov");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructorName2()
        {
            Student incognito = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructorName3()
        {
            Student incognito = new Student(string.Empty);
        }

        [TestMethod]
        public void TestStudentConstructorName4()
        {
            Student misho = new Student("Misho Ivanov");

            string message = string.Format(
                "Student's unique number is not within the expected range [10000 ... 99999].");

            Assert.IsTrue(10000 < misho.Number && misho.Number < 99999, message);
        }

        [TestMethod]
        public void TestStudentConstructorNumber()
        {
            Student misho = new Student("Misho Ivanov");
            Student pesho = new Student("Pesho Ivanov");

            Assert.IsTrue(misho.Number == (pesho.Number - 1), "Students' unique numbers are consecutive values.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentUniqueNumber1()
        {
            Student misho = new Student("Misho Ivanov");
            misho.Number = 500000;

            string message = string.Format(
                "Student's unique number is not within the expected range [10000 ... 99999].");

            Assert.IsTrue(10000 < misho.Number && misho.Number < 99999, message, message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentUniqueNumber2()
        {
            Student misho = new Student("Misho Ivanov");
            misho.Number = 0;

            string message = string.Format(
                "Student's unique number is not within the expected range [10000 ... 99999].");

            Assert.IsTrue(10000 < misho.Number && misho.Number < 99999, message);
        }

        [TestMethod]
        public void TestStudentToString()
        {
            Student misho = new Student("Misho Ivanov");

            Assert.AreEqual(
                string.Format("(Name = Misho Ivanov, UN = {0})", misho.Number),
                misho.ToString(),
                "Student.ToString() does not work correctly.");
        }
    }
}
