using System;
using System.Linq;

namespace IEnumerable
{
    class Program
    {
        // 02. Implement a set of extension methods for IEnumerable<T> that
        // implement the following group functions: sum, product, min, max, average.

        static void Main(string[] args)
        {
            //test
            int[] array = new int[3];
            array[0] = -10;
            array[1] = 2;
            array[2] = 10;

            Console.WriteLine(array.Sum());
            Console.WriteLine(array.Product());
            Console.WriteLine(array.Min());
            Console.WriteLine(array.Max());
            Console.WriteLine(array.Average());
        }
    }
}
