using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLoops
{
    // 01. Write a recursive program that simulates the execution
    // of n nested loops from 1 to n. Examples:
    //                            1 1 1
    //                            1 1 2
    //                            1 1 3
    //          1 1               1 2 1
    // n=2  ->  1 2      n=3  ->  ...
    //          2 1               3 2 3
    //          2 2               3 3 1
    //                            3 3 2
    //                            3 3 3

    public class VectorsGenerator
    {
        private readonly int vectortype;
        private List<int[]> currentList;

        public VectorsGenerator(int vectorType)
        {
            this.vectortype = vectorType;
        }

        public List<int[]> GetAllVectors(int size)
        {
            currentList = new List<int[]>();
            GenerateVectorsRecursively(new int[size], 0);

            return currentList;
        }

        private void GenerateVectorsRecursively(
            int[] vector, int currentIndex)
        {
            if (currentIndex == vector.Length)
            {
                var newArray = new int[vector.Length];
                vector.CopyTo(newArray, 0);
                currentList.Add(newArray);
                return;
            }

            for (int i = 1; i <= vectortype; i++)
            {
                vector[currentIndex] = i;
                GenerateVectorsRecursively(vector, currentIndex + 1);
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            VectorsGenerator generator = new VectorsGenerator(n);
            var result = generator.GetAllVectors(n);
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
