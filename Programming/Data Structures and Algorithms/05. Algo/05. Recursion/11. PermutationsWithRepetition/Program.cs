using System;
using System.Linq;

namespace PermutationsWithRepetition
{
    //11. * Write a program to generate all permutations with repetitions 
    // of given multi-set. For example the multi-set {1, 3, 5, 5} has the 
    // following 12 unique permutations:
    // { 1, 3, 5, 5 }	{ 1, 5, 3, 5 }
    // { 1, 5, 5, 3 }	{ 3, 1, 5, 5 }
    // { 3, 5, 1, 5 }	{ 3, 5, 5, 1 }
    // { 5, 1, 3, 5 }	{ 5, 1, 5, 3 }
    // { 5, 3, 1, 5 }	{ 5, 3, 5, 1 }
    // { 5, 5, 1, 3 }	{ 5, 5, 3, 1 }
    // Ensure your program efficiently avoids duplicated permutations. 
    // Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Set of integers : ");
            string[] arr = Console.ReadLine().Split(',');
            int[] setOfIntegers = Array.ConvertAll(arr, int.Parse);

            Array.Sort(setOfIntegers);
            Permute(setOfIntegers, 0, setOfIntegers.Length);
        }

        public static void Permute(int[] setOfIntegers, int start, int n)
        {
            Print(setOfIntegers);
            int tmp = 0;

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (setOfIntegers[i] != setOfIntegers[j])
                        {
                            // swap numbers
                            setOfIntegers[j] = setOfIntegers[j] ^ setOfIntegers[i];
                            setOfIntegers[i] = setOfIntegers[i] ^ setOfIntegers[j];
                            setOfIntegers[j] = setOfIntegers[j] ^ setOfIntegers[i];

                            Permute(setOfIntegers, i + 1, n);
                        }
                    }

                    // Undo all modifications done by
                    // recursive calls and swapping
                    tmp = setOfIntegers[i];
                    for (int k = i; k < n - 1; )
                    {
                        setOfIntegers[k] = setOfIntegers[++k];
                    }

                    setOfIntegers[n - 1] = tmp;
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine("{"+string.Join(", ",arr)+"}");
        }
    }
}