//-----------------------------------------------------------------------
// <copyright file="ArithmethicCalculations.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Utilities
{
    using System;

    /// <summary>
    /// Performs some common arithmetic calculations. 
    /// </summary>
    public class ArithmethicCalculations
    {
        public static int FindMaxValue(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Invalid sequence");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Sequence is empty.");
            }

            int maxValue = int.MinValue;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }
    }
}
