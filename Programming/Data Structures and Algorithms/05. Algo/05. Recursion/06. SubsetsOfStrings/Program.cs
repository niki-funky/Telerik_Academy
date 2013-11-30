using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetsOfStrings
{
    // 06. Write a program for generating and printing all 
    // subsets of k strings from given set of strings.
    // Example: s = {test, rock, fun}, k=2
    // (test rock),  (test fun),  (rock fun)

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
            GenerateVariationsRecursively(new string[size], 0, 0);

            return currentList;
        }

        private void GenerateVariationsRecursively(
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
                GenerateVariationsRecursively(
                    subset, currentIndex + 1, i + 1);
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.Write("string set = ");
            string[] arr = Console.ReadLine().Split(',');

            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            SubsetGenerator generator = new SubsetGenerator(arr);
            var result = generator.GetAllVariations(k);
            foreach (var set in result)
            {
                Console.WriteLine("(" + String.Join(" ", set) + ")");
            }
        }
    }
}
