using System;
using System.Linq;

namespace _02.AcademyTasks
{
    class AcademyTasks
    {
        static int[] arr;
        static int variety;
        static int maxIndex = -1;
        static int bestSolution;

        static void Main()
        {
            string input = Console.ReadLine();
            variety = int.Parse(Console.ReadLine());
            string[] arrAsString = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            arr = arrAsString.Select(x => int.Parse(x)).ToArray();
            bestSolution = arr.Length;
            int min = arr[0];
            int max = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                min = Math.Min(arr[i], min);
                max = Math.Max(arr[i], max);
                if (Math.Abs(max - min) >= variety)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine(arr.Length);
                return;
            }

            FindMinNumberOfProblems(0, arr[0], arr[0], 1);

            Console.WriteLine(bestSolution);
        }

        static void FindMinNumberOfProblems(int currentIndex, int min, int max, int result)
        {
            if (max - min >= variety)
            {
                bestSolution = Math.Min(bestSolution, result);
            }

            if (currentIndex >= maxIndex)
            {
                return;
            }

            for (int i = 2; i >= 1; i--)
            {
                if (currentIndex + i < arr.Length)
                {
                    FindMinNumberOfProblems(
                        currentIndex + i,
                        Math.Min(arr[currentIndex + i], min),
                        Math.Max(arr[currentIndex + i], max),
                        result + 1);

                    if (bestSolution != arr.Length)
                    {
                        return;
                    }
                }
            }
        }
    }
}
