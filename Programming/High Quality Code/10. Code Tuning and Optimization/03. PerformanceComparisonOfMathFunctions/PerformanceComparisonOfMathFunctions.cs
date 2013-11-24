//-----------------------------------------------------------------------
// <copyright file="PerformanceComparisonOfMathFunctions.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace PerformanceComparisonOfMathFunctions
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class PerformanceComparisonOfMathFunctions
    {
        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + "\n");
        }

        private static void SquareRootComparison()
        {
            var fixedValue = 3.0;
            var endValue = 100000000;
            double doubleValue = 0;

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    doubleValue = Math.Sqrt(fixedValue);
                }
            });
        }

        private static void NaturalLogarithmComparison()
        {
            var fixedValue = 3.0;
            var endValue = 100000000;
            double doubleValue = 0;

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    doubleValue = Math.Log(fixedValue);
                }
            });
        }

        private static void SineFunctionPerformance()
        {
            var fixedValue = 3.0;
            var endValue = 100000000;
            double doubleValue = 0;

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    doubleValue = Math.Sin(fixedValue);
                }
            });
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Performance comparison Of square root:");
            SquareRootComparison();
            Console.WriteLine("Performance comparison Of natural logarithm:");
            NaturalLogarithmComparison();
            Console.WriteLine("Performance comparison Of sine function:");
            SineFunctionPerformance();
        }
    }
}
