
namespace MajorantOfArray
{
    using System;
    using System.Linq;

    // 08. * The majorant of an array of size N is a value that occurs in it 
    // at least N/2 + 1 times. Write a program to find the majorant of given array (if exists). Example:
    // {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3

    class MajorantOfArray
    {
        private static int[] sequence =
            new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

        public static void Main(string[] args)
        {
            var listOfMajorants = sequence
                                 .GroupBy(x => x)
                                 .Where(g => g.Count() >= sequence.Length / 2 + 1)
                                 .Select(g => new { Value = g.Key });

            if (listOfMajorants.Count() == 0)
            {
                Console.WriteLine("No majorant for this array.");
            }
            foreach (var item in listOfMajorants)
            {
                Console.WriteLine("Majorant of the array is: " + item.Value);
            }
        }
    }
}
