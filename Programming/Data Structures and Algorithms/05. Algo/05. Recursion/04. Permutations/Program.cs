using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    // 04. Write a recursive program for generating and printing 
    // all permutations of the numbers 1, 2, ..., n for given integer
    // number n. Example:
    // n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}

    class Permutations
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            List<int> array = new List<int>();

            for (int i = 0; i < n; i++)
            {
                array.Add(i + 1);
            }

            PrintAllPermutations(array, 0);
        }

        static void PrintAllPermutations(List<int> array, int start)
        {
            #region print all permutations
            if (start == array.Count)
            {
                Console.Write("{ ");
                Console.Write(string.Join(", ",array));
                Console.Write(" }");
                Console.WriteLine();
                return;
            }
            #endregion

            for (int j = start; j < array.Count; j++)
            {
                //swap current element with j 
                if (j != start)
                {
                    array[j] = array[j] ^ array[start];
                    array[start] = array[start] ^ array[j];
                    array[j] = array[j] ^ array[start];
                }

                PrintAllPermutations(array, start + 1);
                if (j < array.Count - 1)
                {
                    array.Reverse(start + 1, array.Count - start - 1);
                }
            }
        }
    }
}
