using System;

class FindingIndexOfElement
{
    //Write a program that finds the index
    //of given element in a sorted array of 
    //integers by using the binary search 
    //algorithm (find it in Wikipedia).

    static void Main()
    {
        //variables
        int[] array = { 9, 5, 9, 4, 8, 3, 7, 2, 1, 6 };
        Random rand = new Random();
        int e = rand.Next(9);
        int maxIndex;
        int lowIndex = 0;
        int highIndex = array.Length - 1;
        int result = -1;

        //sort the array from smallest to biggest
        #region I variant
        for (int i = array.Length - 1; i > 0; i--)
        {
            maxIndex = i;
            for (int m = i - 1; m >= 0; m--)
            {
                if (array[m] > array[maxIndex])
                {
                    maxIndex = m;
                }
            }
            //swap current element with smallest element
            if (i != maxIndex)
            {
                array[i] = array[i] ^ array[maxIndex];
                array[maxIndex] = array[maxIndex] ^ array[i];
                array[i] = array[i] ^ array[maxIndex];
            }
        }
        #endregion

        //II variant
        //Array.Sort(array);

        #region print array
        Console.Write("{");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.Write("} -> ");
        #endregion

        //find the index of element by using the binary search 
        //I variant
        while (lowIndex <= highIndex)
        {
            int midIndex = lowIndex + (highIndex - lowIndex) / 2;
            if (array[midIndex] == e)
            {
                result = midIndex;
                break;
            }
            else if (array[midIndex] < e)
            {
                lowIndex = midIndex + 1;
            }
            else
            {
                highIndex = midIndex - 1;
            }
        }
        //II variant
        //result = Array.BinarySearch(array, e);

        #region print result
        if (result == -1)
        {
            Console.WriteLine("Number {0} is not in the array.", e, result);
        }
        else
        {
            Console.WriteLine("Index of number {0} is ({1}).", e, result);
        }
        #endregion
    }
}
