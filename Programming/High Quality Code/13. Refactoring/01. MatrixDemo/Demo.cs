//-----------------------------------------------------------------------
// <copyright file="MatrixDemo.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace MatrixDemo
{
    using System;
    using System.Linq;
    using Matrix;

    class Demo
    {
        static void Main(string[] args)
        {
            int matrixSize = ReadFromConsole();
            MatrixGyration matrix = new MatrixGyration(matrixSize);
            Console.Write(matrix.ToString());
        }

        private static int ReadFromConsole()
        {
            Console.WriteLine("Enter a number in the range [0...100]: ");
            string input = Console.ReadLine();
            int number = 0;
            var result = int.TryParse(input, out number);

            return number;
        }
    }
}
