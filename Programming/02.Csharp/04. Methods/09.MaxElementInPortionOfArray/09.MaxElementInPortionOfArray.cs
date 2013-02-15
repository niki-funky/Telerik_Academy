using System;
using System.Linq;

class MaxElementInPortionOfArray
{
    // WWrite a method that return the maximal element in a 
    // portion of array of integers starting at given index. 
    // Using it write another method that sorts an array in 
    // ascending / descending order.

    static void Main()
    {
        //variables
        int[] array = new int[10];
        Random rand = new Random();
        int index = rand.Next(8);
        int maxIndex;

        //fill the array with Random numbers
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(9);
        }

        #region print array
        Console.Write("{");
        Console.Write(String.Join(", ", array));
        Console.Write("}} -> portion from index {0}",index);
        Console.WriteLine();
        #endregion

        //print result
        maxIndex = FindMaxElement(array, index, array.Length-1);
        Console.WriteLine("Element {0} at index {1} is max element in this portion \n",
                array[maxIndex], maxIndex);

        //print sorted array in ascending order
        Console.Write("{");
        Console.Write(String.Join(", ", SortArrayAscending(array)));
        Console.WriteLine("} \n");

        //print sorted array in descending order
        Console.Write("{");
        Console.Write(String.Join(", ", SortArrayDescending(array)));
        Console.WriteLine("}");
    }

    public static int FindMaxElement(int[] array, int startIndex,int endIndex)
    {
        int max = array[startIndex];
        int maxIndex = startIndex;
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    //sorting in ascending order
    public static int[] SortArrayAscending(int[] array)
    {
        int[] sorted = (int[])array.Clone();
        //sort the array from smallest to biggest
        for (int i = array.Length - 1; i > 0; i--)
        {
            int max = i;
            int maxIndex = FindMaxElement(sorted, 0, i);
            //for (int m = i - 1; m >= 0; m--)
            //{
            if (sorted[maxIndex] > sorted[max])
            {
                max = maxIndex;
            }
            //}

            //swap current element with smallest element
            if (i != max)
            {
                sorted[i] = sorted[i] ^ sorted[max];
                sorted[max] = sorted[max] ^ sorted[i];
                sorted[i] = sorted[i] ^ sorted[max];
            }
        }
        return sorted;
    }

    //sorting in descending order
    public static int[] SortArrayDescending(int[] array)
    {
        int[] sorted = (int[])array.Clone();
        //sort the array from smallest to biggest
        for (int i = 0; i < sorted.Length-1; i++)
        {
            int max = i;
            int maxIndex = FindMaxElement(sorted, i, sorted.Length-1);
            //for (int m = i - 1; m >= 0; m--)
            //{
            if (sorted[maxIndex] > sorted[max])
            {
                max = maxIndex;
            }
            //}

            //swap current element with smallest element
            if (i != max)
            {
                sorted[i] = sorted[i] ^ sorted[max];
                sorted[max] = sorted[max] ^ sorted[i];
                sorted[i] = sorted[i] ^ sorted[max];
            }
        }
        return sorted;
    }
}