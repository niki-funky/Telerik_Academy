using System;
using System.Collections.Generic;

class Permutations
{
    //* Write a program that reads a number N
    //and generates and prints all the permutations
    //of the numbers [1 … N]. Example: n = 3 ->
    //{1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, 
    //{3, 1, 2}, {3, 2, 1}

    static void Main()
    {
        //variables
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        List<int> array = new List<int>();

        //fill the List with consecutive numbers
        for (int i = 0; i < n; i++)
        {
            array.Add(i + 1);
        }

        PrintAllPermutations(array, 0);
    }

    //find All permutations
    static void PrintAllPermutations(List<int> array, int start)
    {
        #region print all permutations
        if (start == array.Count)
        {
            Console.Write("{ ");
            for (int i = 0; i < array.Count; i++)
            {
                if (i != array.Count - 1)
                {
                    Console.Write(array[i] + ", ");
                }
                else
                {
                    Console.Write(array[i]);
                }

            }
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
