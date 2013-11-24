//-----------------------------------------------------------------------
// <copyright file="Demo.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Demo
{
    using System;
    using Utilities;
    using Student;

    class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GeometryCalculations.TriangleArea(3, 4, 5));

            Console.WriteLine(NumericConversions.DigitToString(5));

            Console.WriteLine(ArithmethicCalculations.FindMaxValue(5, -1, 3, 2, 14, 2, 3));

            ConsoleMethods.PrintNumberWithPrecision(1.3, 2);
            ConsoleMethods.PrintNumberAsPercentWithPrecision(0.75, 0);
            ConsoleMethods.PrintObjectAsPaddedString(2.30, 8);

            Console.WriteLine(GeometryCalculations.DistanceBetweenTwoPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + GeometryCalculations.IsHorizontal(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + GeometryCalculations.IsVertical(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
