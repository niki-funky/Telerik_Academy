//-----------------------------------------------------------------------
// <copyright file="UtilitiesTest.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class UtilitiesTest
    {
        [TestMethod]
        public void TestGetUN1()
        {
            int uniqueNumber = Utilities.GetUN();

            Assert.IsTrue(10000 < uniqueNumber && uniqueNumber < 99999, "Student unique number is not in range[10000...99999]!");
        }
    }
}
