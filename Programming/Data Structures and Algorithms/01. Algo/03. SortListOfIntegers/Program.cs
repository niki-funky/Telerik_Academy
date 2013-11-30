
namespace SortListOfIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 03. Write a program that reads a sequence of integers (List<int>) 
    // ending with an empty line and sorts them in an increasing order.

    class SortListOfIntegers
    {
        private static List<int> sequence;

        private static void ReadUserInput()
        {
            sequence = new List<int>();
            var inputLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(inputLine))
            {
                int number = int.Parse(inputLine);
                if (number > 0)
                {
                    sequence.Add(number);
                }
                inputLine = Console.ReadLine();
            }
        }

        private static void Sort()
        {
            sequence.Sort();
        }

        public static void Print(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("List is empty!");
            }

            Console.WriteLine("{ " + string.Join(", ", collection) + " }");
        }

        public static void Main()
        {
            Console.WriteLine("Enter some numbers: ");
            ReadUserInput();

            Console.WriteLine("List before sorting:");
            Print(sequence);

            Sort();

            Console.WriteLine("List after sorting:");
            Print(sequence);
        }
    }
}
