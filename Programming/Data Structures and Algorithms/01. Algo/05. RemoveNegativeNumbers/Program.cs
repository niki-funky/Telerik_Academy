
namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 05. Write a program that removes from given sequence all negative numbers.

    class RemoveNegativeNumbers
    {
        private static List<int> sequence =
            new List<int> { 1, 0, -2, -2, 3, 3, 3, -4, -4, -4, -4, 5, 5, 5, 5, 5 };

        public static void Print(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("List is empty!");
            }

            Console.WriteLine("{ " + string.Join(", ", collection) + " }");
        }

        public static void Main(string[] args)
        {
            sequence.RemoveAll(x => x < 0);
            Print(sequence);
        }
    }
}
