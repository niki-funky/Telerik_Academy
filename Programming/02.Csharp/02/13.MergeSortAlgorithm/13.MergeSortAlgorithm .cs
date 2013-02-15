using System;

class MergeSortAlgorithm
{
    //* Write a program that sorts an array of 
    //integers using the merge sort algorithm 
    //(find it in Wikipedia).

    static void Main()
    {
        //variables
        int[] array = new int[10];
        int[] sortedArray;
        Random rand = new Random();

        //expressions
        //fill the array with random values 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(9);
        }

        //sort array using Merge Sort algorithm
        sortedArray = MergeSort(array);

        #region print result
        //print result to the Console
        Console.Write("{");
        //print array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.Write("} -> { ");
        //print sorted array
        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.Write(sortedArray[i]);
            if (i != sortedArray.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine(" }");
        #endregion
    }

    /// <summary>
    /// Implementation of Merge Sort algorithm
    /// </summary>
    /// <param name="array">Some Array</param>
    /// <returns>same array, but sorted</returns>
    static int[] MergeSort(int[] array)
    {
        if (array.Length == 1)
        {
            return array;
        }
        int middle = array.Length / 2;
        //numbers left from middle
        int[] left = new int[middle];
        for (int i = 0; i < middle; i++)
        {
            left[i] = array[i];
        }
        //numbers right from middle
        int[] right = new int[array.Length - middle];
        for (int i = 0; i < array.Length - middle; i++)
        {
            right[i] = array[i + middle];
        }
        //using recursion
        //call MergeSort until array.Length == 1
        left = MergeSort(left);
        right = MergeSort(right);

        int leftNumber = 0;
        int rightNumber = 0;

        int[] sorted = new int[array.Length];
        //sort the array
        for (int i = 0; i < array.Length; i++)
        {
            if (leftNumber < left.Length && rightNumber < right.Length)
            {
                if (left[leftNumber] < right[rightNumber])
                {
                    sorted[i] = left[leftNumber];
                    leftNumber++;
                }
                else
                {
                    sorted[i] = right[rightNumber];
                    rightNumber++;
                }
            }
            else
            {
                if (leftNumber < left.Length)
                {
                    sorted[i] = left[leftNumber];
                    leftNumber++;
                }
                else
                {
                    sorted[i] = right[rightNumber];
                    rightNumber++;
                }
            }
        }
        return sorted;
    }
}
