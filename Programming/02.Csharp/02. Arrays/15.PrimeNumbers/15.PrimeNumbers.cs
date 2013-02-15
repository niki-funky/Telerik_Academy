using System;

class PrimeNumbers
{
    //Write a program that finds all prime numbers 
    //in the range [1...10 000 000]. Use the sieve 
    //of Eratosthenes algorithm (find it in Wikipedia).

    static void Main()
    {
        //variables
        int[] array = new int[10000000];
        int temp = 0;

        //find all prime numbers using
        //sieve of Eratosthenes algorithm
        for (int i = 2; i <= Math.Sqrt(array.Length); i++)
        {
            if (array[i] != 1)
            {
                for (int k = 2; k < array.Length; k++)
                {
                    if (array[i] != 1 && k * i > 0 && k * i < array.Length)
                    {
                        array[k * i] = 1;
                    }
                }
            }
        }

        #region print all Prime numbers
        Console.Write("{ ");
        for (int i = 2; i < array.Length; i++)
        {
            if (array[i] == 0)
            {
                Console.Write(i);
                temp++;
                if (i != array.Length - 1)
                {
                    Console.Write(',' + " ");
                }
            }
        }
        Console.WriteLine(" }} {0}", temp);
        #endregion
    }
}