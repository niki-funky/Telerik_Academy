using System;

class MostFrequentNumber
{
    //Write a program that finds the most 
    //frequent number in an array. Example:
    //{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

    static void Main()
    {
        //variables
        int[] array = new int[10];
        int[] arrayForPrint = new int[10];
        Random rand = new Random();
        int maxIndex;
        int currentIndex;
        int currentSum = 1;
        int maxSum = 1;
        int value;

        //expressions
        //fill the array with random values 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(9);
        }

        Array.Copy(array, arrayForPrint, 10);

        //sort the array from smallest to biggest
        //I variant
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
        //II variant
        //Array.Sort(array);

        currentIndex = array[0];
        value = array[0];
        //find the most frequent number
        for (int i = 1; i < array.Length; i++)
        {
            if (currentIndex == array[i])
            {
                currentSum++;
            }
            else
            {
                currentIndex = array[i];
                currentSum = 1;
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                value = array[i - 1];
            }
        }

        #region print result
        Console.Write("{");
        for (int i = 0; i < arrayForPrint.Length; i++)
        {
            Console.Write(arrayForPrint[i]);
            if (i != arrayForPrint.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine("}} -> {0} ({1} times)", value, maxSum);
        #endregion
    }
}
