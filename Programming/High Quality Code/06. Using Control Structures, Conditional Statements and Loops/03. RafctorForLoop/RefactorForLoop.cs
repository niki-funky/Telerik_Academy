//-----------------------------------------------------------------------
// <copyright file="RefactorForLoop.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace RefactorForLoops
{
    using System;

    public class RefactorForLoop
    {
        private static void PrintOnConsoleUntillvalueFound(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    if (array[i] == value)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
                else
                {
                    // Ignore all content once the value is found
                }
            }
        }

        private static void Main(string[] args)
        {
        }
    }
}
