
namespace RemoveNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 06. Write a program that removes from given sequence all numbers that occur odd number of times. Example:
    // 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}

    class RemoveNumbers
    {
        private static List<int> sequence =
            new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

        private static void Remove(List<int> collection)
        {
            var listOfItemsToBeRemoved = collection
                                        .ToLookup(x => x)
                                        .Where(g => g.Count() % 2 != 0)
                                        .SelectMany(g => g);

            collection.RemoveAll(listOfItemsToBeRemoved.Contains);
        }

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
            Remove(sequence);
            Print(sequence);
        }
    }
}
