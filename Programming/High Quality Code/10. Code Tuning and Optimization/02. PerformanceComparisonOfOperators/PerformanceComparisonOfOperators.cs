//-----------------------------------------------------------------------
// <copyright file="PerformanceComparisonOfOperators.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace PerformanceComparisonOfOperators
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class PerformanceComparisonOfOperators
    {
        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void AddComparison()
        {
            var fixedValue = 3;
            var endValue = 100000000;
            int intValue = 0;

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    intValue = intValue + fixedValue;
                }
            });

            var longValue = 0L;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    longValue = longValue + (long)fixedValue;
                }
            });

            var floatValue = 0f;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    floatValue = floatValue + (float)fixedValue;
                }
            });

            var doubleValue = 0.0;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    doubleValue = doubleValue + (double)fixedValue;
                }
            });

            var decimalValue = 0.0m;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    decimalValue = decimalValue + (decimal)fixedValue;
                }
            });
        }

        private static void SubtractComparison()
        {
            var fixedValue = 3;
            var endValue = 100000000;
            int intValue = 100000000;

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    intValue = intValue - fixedValue;
                }
            });

            var longValue = 100000000L;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    longValue = longValue - (long)fixedValue;
                }
            });

            var floatValue = 100000000f;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    floatValue = floatValue - (float)fixedValue;
                }
            });

            var doubleValue = 100000000.0;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    doubleValue = doubleValue - (double)fixedValue;
                }
            });

            var decimalValue = 100000000.0m;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    decimalValue = decimalValue - (decimal)fixedValue;
                }
            });
        }

        private static void IncrementComparison()
        {
            var endValue = 100000000;
            int intValue = 0;

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    intValue++;
                }
            });

            var longValue = 0L;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    longValue++;
                }
            });

            var floatValue = 0f;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    floatValue++;
                }
            });

            var doubleValue = 0.0;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    doubleValue++;
                }
            });

            var decimalValue = 0.0m;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    decimalValue++;
                }
            });
        }

        private static void MultiplyComparison()
        {
            var fixedValue = 3;
            var endValue = 100000000;
            int intValue = 0;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    intValue = fixedValue * fixedValue;
                }
            });

            var longValue = 0L;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    longValue = (long)fixedValue * (long)fixedValue;
                }
            });

            var floatValue = 0f;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    floatValue = (float)fixedValue * (float)fixedValue;
                }
            });

            var doubleValue = 0.0;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    doubleValue = (double)fixedValue * (double)fixedValue;
                }
            });

            var decimalValue = 0.0m;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    decimalValue = (decimal)fixedValue * (decimal)fixedValue;
                }
            });
        }

        private static void DivideComparison()
        {
            var fixedValue = 3;
            var endValue = 100000000;
            int intValue = 100000000;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    intValue = intValue / fixedValue;
                }
            });

            var longValue = 100000000L;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    longValue = longValue / (long)fixedValue;
                }
            });

            var floatValue = 100000000f;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    floatValue = floatValue / (float)fixedValue;
                }
            });

            var doubleValue = 100000000.0;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    doubleValue = doubleValue / (double)fixedValue;
                }
            });

            var decimalValue = 100000000.0m;
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < endValue; i++)
                {
                    decimalValue = decimalValue / (decimal)fixedValue;
                }
            });
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Performance comparison Of add operator:");
            AddComparison();
            Console.WriteLine("Performance comparison Of subtract operator:");
            SubtractComparison();
            Console.WriteLine("Performance comparison Of increment operator:");
            IncrementComparison();
            Console.WriteLine("Performance comparison Of multiply operator:");
            MultiplyComparison();
            Console.WriteLine("Performance comparison Of divide operator:");
            DivideComparison();
        }
    }
}
