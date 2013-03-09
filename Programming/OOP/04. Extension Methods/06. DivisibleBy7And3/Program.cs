using System;
using System.Linq;
using System.Text;

namespace DivisibleBy7And3
{
    // 06. Write a program that prints from given array
    // of integers all numbers that are divisible by 7 
    // and 3. Use the built-in extension methods and lambda
    // expressions. Rewrite the same with LINQ.

    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 1, 2, 3, 10, 15, 21, 84 };

            //using Lambda
            var resultLambda = arr.Where(x => x % 7 == 0 && x % 3 == 0).ToArray();
            //using LINQ
            var resultLINQ = (from x in arr
                              where x % 7 == 0 && x % 3 == 0
                              select x).ToArray();

            //print results
            Console.WriteLine(ToString(resultLambda));
            Console.WriteLine(ToString(resultLINQ));
        }

        //method to print int[] array
        public static string ToString(int[] arr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    sb.Append(arr[i] + ", ");
                }
                else
                {
                    sb.Append(arr[i]);
                }

            }
            return sb.ToString();
        }
    }
}
