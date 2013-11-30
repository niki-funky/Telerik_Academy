using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithDuplicates
{
    // 02. Write a recursive program for generating and printing 
    // all the combinations with duplicates of k elements from 
    // n-element set. Example:
    // n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

    public class VectorsGenerator
    {
        readonly int vectortype;

        public VectorsGenerator(int vectorType)
        {
            this.vectortype = vectorType;
        }

        private List<int[]> currentList;

        public List<int[]> GetAllCombinations(int size)
        {
            currentList = new List<int[]>();
            GenerateCombinationsRecursively(new int[size], 0, 1);

            return currentList;
        }

        private void GenerateCombinationsRecursively(int[] vector,
            int currentIndex, int currentValueFrom)
        {
            if (currentIndex == vector.Length)
            {
                var newArray = new int[vector.Length];
                vector.CopyTo(newArray, 0);
                currentList.Add(newArray);
                return;
            }

            for (int i = currentValueFrom; i <= vectortype; i++)
            {
                vector[currentIndex] = i;
                GenerateCombinationsRecursively(
                    vector, currentIndex + 1, i);
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

            VectorsGenerator generator = new VectorsGenerator(n);
            var result = generator.GetAllCombinations(k);
            foreach (var vector in result)
            {
                foreach (var num in vector)
                {
                    Console.Write(num);
                }
                Console.WriteLine();
            }
        }
    }
}
