//-----------------------------------------------------------------------
// <copyright file="ConsoleMethods.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Utilities
{
    using System;

    /// <summary>
    /// Methods which format an input value and print it on the console.
    /// </summary>
    public class ConsoleMethods
    {
        public static void PrintNumberWithPrecision(double number, int digits)
        {
            string format = "{0:F" + digits + "}";
            Console.WriteLine(format, number);
        }

        public static void PrintNumberAsPercentWithPrecision(double number, int digits)
        {
            string format = "{0:P" + digits + "}";
            Console.WriteLine(format, number);
        }

        public static void PrintObjectAsPaddedString(object value, int length)
        {
            string format = "{0," + length + "}";
            Console.WriteLine(format, value);
        }
    }
}
