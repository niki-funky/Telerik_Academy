namespace PrintFirst50Members
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 09. We are given the following sequence:
    // S1 = N;
    // S2 = S1 + 1;
    // S3 = 2*S1 + 1;
    // S4 = S1 + 2;
    // S5 = S2 + 1;
    // S6 = 2*S2 + 1;
    // S7 = S2 + 2;
    // ...
    // Using the Queue<T> class write a program to print its first 50 members for given N.
    // Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

    class PrintFirst50Members
    {
        private const int LastIndex = 50;
        private static int number;
        private static Queue<int> queue = new Queue<int>();

        private static void FillTheQueue(int inputNumber)
        {
            queue.Enqueue(inputNumber);
            for (int i = 0; i < LastIndex / 3; i++)
            {
                queue.Enqueue(queue.ElementAt(i) + 1);
                queue.Enqueue(2 * queue.ElementAt(i) + 1);
                queue.Enqueue(queue.ElementAt(i) + 2);
            }
            queue.Enqueue(queue.ElementAt(LastIndex / 3) + 1);
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter some number: ");
            number = int.Parse(Console.ReadLine());

            FillTheQueue(number);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
