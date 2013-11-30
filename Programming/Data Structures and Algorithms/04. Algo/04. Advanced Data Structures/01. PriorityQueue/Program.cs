using System;
using System.Collections.Generic;
using System.Linq;

namespace PriorityQueue
{
    class Program
    {
        public static void Main()
        {
            IComparer<int> comparer = null;

            Console.WriteLine("PriorityQueue sample application.");
            Console.WriteLine();
            Console.WriteLine("Please enter the initial elements of the priority queue as a list of integer");
            Console.WriteLine("numbers, separated by spaces.");
            Console.Write("> ");

            string initialElements = Console.ReadLine().Trim();

            // Initializing the priority queue from an existing list of elements is an O(n) operation,
            // and thus faster than calling Enqueue for each element, which would be O(n log n).
            PriorityQueue<int> queue = new PriorityQueue<int>(GetNumbers(initialElements), comparer);

            PrintQueueInfo(queue);

            Console.WriteLine("Please enter a list of integer numbers, separated by spaces, to add to the");
            Console.WriteLine("priority queue; enter \"remove\" to remove an element, or \"exit\" to exit.");
            while (true)
            {
                Console.Write("> ");

                string command = Console.ReadLine().Trim();

                switch (command)
                {
                    case "remove":
                        if (queue.Count > 0)
                        {
                            int n = queue.Dequeue();
                            Console.WriteLine("Removed {0} from the queue.", n);
                        }
                        break;
                    case "exit":
                        return;
                    default:
                        foreach (int n in GetNumbers(command))
                        {
                            queue.Enqueue(n);
                        }
                        break;
                }

                PrintQueueInfo(queue);
            }
        }

        private static void PrintQueueInfo(PriorityQueue<int> queue)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("The priority queue is empty.");
            }
            else
            {
                Console.WriteLine("The priority queue has {0} elements; the first element has value {1}.",
                    queue.Count, queue.Peek());
            }

            Console.WriteLine();
        }

        private static IEnumerable<int> GetNumbers(string numbers)
        {
            string[] elements = numbers.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string element in elements)
            {
                int number;
                if (int.TryParse(element, out number))
                {
                    yield return number;
                }
                else
                {
                    Console.WriteLine("{0} is not a valid number.", element);
                }
            }
        }
    }
}
