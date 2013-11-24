//-----------------------------------------------------------------------
// <copyright file="NumericConversions.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Utilities
{
    using System;

    public class NumericConversions
    {
        public static string DigitToString(int number)
        {
            string digitAsString = string.Empty;

            switch (number)
            {
                case 0:
                    digitAsString = "zero";
                    break;
                case 1:
                    digitAsString = "one";
                    break;
                case 2:
                    digitAsString = "two";
                    break;
                case 3:
                    digitAsString = "three";
                    break;
                case 4:
                    digitAsString = "four";
                    break;
                case 5:
                    digitAsString = "five";
                    break;
                case 6:
                    digitAsString = "six";
                    break;
                case 7:
                    digitAsString = "seven";
                    break;
                case 8:
                    digitAsString = "eight";
                    break;
                case 9:
                    digitAsString = "nine";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Digit is not in the range (0...9).");
            }
            return digitAsString;
        }
    }
}
