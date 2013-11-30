using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedSubsets
{
    // 05. Write a recursive program for generating and printing all ordered 
    // k-element subsets from n-element set (variations Vkn).
    // Example: n=3, k=2, set = {hi, a, b} =>
    // (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

    public class SubsetGenerator
    {
        readonly string[] stringSet;

        public SubsetGenerator(string[] stringSet)
        {
            this.stringSet = stringSet;
        }

        private List<string[]> currentList;

        public List<string[]> GetAllVariations(int size)
        {
            currentList = new List<string[]>();
            GenerateCombinationsRecursively(new string[size], 0, 0);

            return currentList;
        }

        private void GenerateCombinationsRecursively(
            string[] subset, int currentIndex, int currentValueFrom)
        {
            if (currentIndex == subset.Length)
            {
                var newArray = new string[subset.Length];
                subset.CopyTo(newArray, 0);
                currentList.Add(newArray);
                return;
            }

            for (int i = currentValueFrom; i < stringSet.Length; i++)
            {
                subset[currentIndex] = stringSet[i];
                GenerateCombinationsRecursively(
                    subset, currentIndex + 1, currentValueFrom);
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("string set of {0} elements = ", n);
            string[] arr = Console.ReadLine().Split(',');

            SubsetGenerator generator = new SubsetGenerator(arr);
            var result = generator.GetAllVariations(k);
            foreach (var set in result)
            {
                Console.WriteLine("(" + String.Join(" ", set) + ")");
            }
        }
    }
}
