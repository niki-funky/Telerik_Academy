//-----------------------------------------------------------------------
// <copyright file="MatrixTest.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace MatrixTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Matrix;

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrixSize1()
        {
            MatrixGyration matrix = new MatrixGyration(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrixSize2()
        {
            MatrixGyration matrix = new MatrixGyration(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrixSize3()
        {
            MatrixGyration matrix = new MatrixGyration(1000);
        }

        [TestMethod]
        public void TestMatrixOfSize1()
        {
            MatrixGyration matrix = new MatrixGyration(1);

            Assert.IsTrue(matrix.ToString() == string.Format(
                "   1" +
                Environment.NewLine));
        }

        [TestMethod]
        public void TestMatrixOfSize3()
        {
            MatrixGyration matrix = new MatrixGyration(3);

            Assert.IsTrue(matrix.ToString() == string.Format(
                "   1   7   8" +
                Environment.NewLine +
                "   6   2   9" +
                Environment.NewLine +
                "   5   4   3" +
                Environment.NewLine));
        }

        [TestMethod]
        public void TestMatrixOfSize7()
        {
            MatrixGyration matrix = new MatrixGyration(7);

            Assert.IsTrue(matrix.ToString() == string.Format(
                "   1  19  20  21  22  23  24" +
                Environment.NewLine +
                "  18   2  33  34  35  36  25" +
                Environment.NewLine +
                "  17  40   3  32  39  37  26" +
                Environment.NewLine +
                "  16  48  41   4  31  38  27" +
                Environment.NewLine +
                "  15  47  49  42   5  30  28" +
                Environment.NewLine +
                "  14  46  45  44  43   6  29" +
                Environment.NewLine +
                "  13  12  11  10   9   8   7" +
                Environment.NewLine));
        }
    }
}
