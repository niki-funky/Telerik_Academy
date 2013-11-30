
namespace FindNumberOfOccurences
{
    using System;
    using System.Linq;

    // 07. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    // Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    // 2 -> 2 times
    // 3 -> 4 times
    // 4 -> 3 times

    class FindNumberOfOccurences
    {
        private static int[] sequence =
            new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        public static void Main(string[] args)
        {
            var listOfOccurences = from x in sequence
                                   group x by x into g
                                   let count = g.Count()
                                   orderby g.Key
                                   select new { Value = g.Key, Count = count };

            foreach (var item in listOfOccurences)
            {
                Console.WriteLine(item.Value + " -> " + item.Count + " times");
            }
        }
    }
}
