using System;

class MaxIncreasingSequence
{
    //Write a program that finds the maximal 
    //increasing sequence in an array. 
    //Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.


    static void Main()
    {
        //variables
        int[] array = new int[10];
        Random rand = new Random();
        int current;
        int next;
        int consecutiveElements = 1;
        int maxElements = 1;
        int value;

        //fill the array with random values 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(5);
        }

        #region print array
        //print array
        Console.Write("{");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.Write("} -> { ");
        #endregion

        current = array[0];
        value = array[0];
        //find the maximal sequence of equal elements
        for (int i = 1; i < array.Length; i++)
        {
            next = array[i];
            if (next == current + consecutiveElements)
            {
                consecutiveElements++;
            }
            else
            {
                current = next;
                if (consecutiveElements > maxElements)
                {
                    maxElements = consecutiveElements;
                    value = array[i - consecutiveElements];
                }
                consecutiveElements = 1;
            }
            //case when max sequence includes last index
            if (i == array.Length - 1)
            {
                if (consecutiveElements > maxElements)
                {
                    maxElements = consecutiveElements;
                    value = array[i - consecutiveElements + 1];
                }
            }
        }

        #region print result
        //print result to the Console
        if (maxElements == 1)
        {
            Console.Write("No consecutive elements ");
        }
        else
        {
            for (int i = 0; i < maxElements; i++)
            {
                Console.Write((value + i));
                if (i != maxElements - 1)
                {
                    Console.Write(',' + " ");
                }
            }
        }
        Console.WriteLine(" }");
        #endregion
    }
}

