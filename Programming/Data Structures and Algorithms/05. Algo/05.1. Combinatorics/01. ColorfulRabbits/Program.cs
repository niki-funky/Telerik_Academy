using System;
using System.Linq;

namespace ColorfulRabbits
{
    class Program
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] answers = new int[count];
            for (int i = 0; i < count; i++)
            {
                answers[i] = int.Parse(Console.ReadLine());
            }

            int answer = GetMinimum(answers);
            Console.WriteLine(answer);
        }

        private static int GetMinimum(int[] replies)
        {
            int[] cache = new int[1000002];
            for (int i = 0; i < replies.Length; i++)
            {
                cache[replies[i] + 1]++;
            }
            int minCount = 0;
            for (int i = 0; i < cache.Length; i++)
            {
                if (cache[i] == 0)
                {
                    continue;
                }
                if (cache[i] <= i)
                {
                    minCount += i;
                }
                else
                {
                    minCount += (int)Math.Ceiling((double)cache[i] / i) * i;
                }
            }
            return minCount;
        }
    }
}
