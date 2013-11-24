//-----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Statistics
{
    using System;

    /// <summary>
    /// Contains methods for Basic Statistical Calculations
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Calculates the minimum in an array of numbers.
        /// </summary>
        /// <param name="array">An array of numbers used for the calculation.</param>
        /// <returns>The minimum value of the numbers in the array.</returns>
        public static double Min(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            var min = double.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Calculates the maximum in an array of numbers.
        /// </summary>
        /// <param name="array">An array of numbers used for the calculation.</param>
        /// <returns>The maximum value of the numbers in the array.</returns>
        public static double Max(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            var max = double.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Calculates the average in an array of numbers.
        /// </summary>
        /// <param name="array">An array of numbers used for the calculation.</param>
        /// <returns>The average value of the numbers in the array.</returns>
        public static double Average(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            int arrayLength = array.Length;

            if (arrayLength == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            var sum = 0;

            for (int i = 0; i < arrayLength; i++)
            {
                sum += array[i];
            }

            double average = sum / arrayLength;
            return average;
        }
    }
}
