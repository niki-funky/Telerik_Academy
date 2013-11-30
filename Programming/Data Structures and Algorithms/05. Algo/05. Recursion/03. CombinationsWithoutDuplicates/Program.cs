using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithoutDuplicates
{
    // 03. Modify the previous program to skip duplicates:
    // n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)


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

        private void GenerateCombinationsRecursively(
            int[] vector, int currentIndex, int currentValueFrom)
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
                    vector, currentIndex + 1, i + 1);
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
