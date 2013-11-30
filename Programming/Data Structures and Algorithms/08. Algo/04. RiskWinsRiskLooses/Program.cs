using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RiskWinsRiskLooses
{

    static class Program
    {
        const int MaxDigit = 10;
        const int WheelsCount = 5;

        static int GetNextConfiguration(int currentConfiguration, int i, int step)
        {
            int powerOf10 = (int)Math.Pow(10, i);

            int digit = (currentConfiguration / powerOf10) % 10;
            int nextDigit = (digit + step + MaxDigit) % MaxDigit;

            int nextConfiguration = currentConfiguration;
            nextConfiguration -= digit * powerOf10;
            nextConfiguration += nextDigit * powerOf10;

            return nextConfiguration;
        }

        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            int combinations = (int)Math.Pow(MaxDigit, WheelsCount);
            bool[] visited = new bool[combinations];
            bool[] forbidden = new bool[combinations];

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
                forbidden[int.Parse(Console.ReadLine())] = true;

            IEnumerable<int> steps = new int[] { 1, -1 };

            var queue = new Queue<int>();
            visited[start] = true;
            queue.Enqueue(start);

            int buttonPresses = 0;

            // using BFS
            while (queue.Count != 0)
            {
                buttonPresses++;

                var nextLevelNodes = new Queue<int>();

                while (queue.Count != 0)
                {
                    int node = queue.Dequeue();

                    for (int i = 0; i < WheelsCount; i++)
                    {
                        foreach (int step in steps)
                        {
                            int nextConfiguration = GetNextConfiguration(node, i, step);

                            if (nextConfiguration == end)
                            {
                                Console.WriteLine(buttonPresses);
                                return;
                            }

                            if (!forbidden[nextConfiguration] && !visited[nextConfiguration])
                            {
                                visited[nextConfiguration] = true;
                                nextLevelNodes.Enqueue(nextConfiguration);
                            }
                        }
                    }
                }

                queue = nextLevelNodes;
            }

            Console.WriteLine(-1);
        }
    }
}