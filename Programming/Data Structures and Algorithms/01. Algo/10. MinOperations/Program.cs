namespace MinOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 10. * We are given numbers N and M and the following operations:
    // N = N+1
    // N = N+2
    // N = N*2
    // Write a program that finds the shortest sequence of operations 
    // from the list above that starts from N and finishes in M. Hint: use a queue.
    // Example: N = 5, M = 16
    // Sequence: 5 -> 7 -> 8 -> 16

    class MinOperations
    {
        private static int N;
        private static int M;
        private static readonly Queue<int> queue = new Queue<int>();
        // stores all passed sequences
        private static readonly Queue<List<int>> queueAllSequences = new Queue<List<int>>();
        private static List<int> lastSequence = new List<int>();

        private static void FindMinStepsFromNtoM()
        {
            if (M > N)
            {
                int current = 0;
                queue.Enqueue(N);
                lastSequence.Add(N);
                queueAllSequences.Enqueue(lastSequence);

                while (true)
                {
                    current = queue.Dequeue();
                    lastSequence = queueAllSequences.Dequeue();
                    // creates new sequence from the last sequence
                    // and new numbers are added to it for each operation
                    List<int> currentSequence = new List<int>(lastSequence);

                    currentSequence.Add(current + 1);
                    queue.Enqueue(current + 1);
                    queueAllSequences.Enqueue(new List<int>(currentSequence));
                    if (current + 1 == M)
                    {
                        PrintSequence(currentSequence);
                        return;
                    }

                    currentSequence.RemoveAt(currentSequence.Count - 1);
                    currentSequence.Add(current + 2);
                    queue.Enqueue(current + 2);
                    queueAllSequences.Enqueue(new List<int>(currentSequence));
                    if (current + 2 == M)
                    {
                        PrintSequence(currentSequence);
                        return;
                    }

                    currentSequence.RemoveAt(currentSequence.Count - 1);
                    currentSequence.Add(current * 2);
                    queue.Enqueue(current * 2);
                    queueAllSequences.Enqueue(new List<int>(currentSequence));
                    if (current * 2 == M)
                    {
                        PrintSequence(currentSequence);
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("M must be bigger than N!");
            }
        }

        private static void ReadInput()
        {
            bool isNvalid = false;
            bool isMvalid = false;
            while (!isNvalid)
            {
                Console.Write("Enter N number: ");
                isNvalid = int.TryParse(Console.ReadLine(), out N) && N > 0;
            }
            while (!isMvalid)
            {
                Console.Write("Enter M number: ");
                isMvalid = int.TryParse(Console.ReadLine(), out M) && M > 0;
            }
        }

        static void PrintSequence(List<int> sequence)
        {
            Console.WriteLine("Shortest sequence is: ");
            Console.WriteLine(string.Join(" -> ", sequence));
        }

        public static void Main(string[] args)
        {
            ReadInput();

            FindMinStepsFromNtoM();
        }
    }
}
