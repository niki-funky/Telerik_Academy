using System;

class MaxSequence
{
    //Write a program that finds the maximal sequence 
    //of equal elements in an array.
    //Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

    static void Main()
    {
        //variables
        int[] array = new int[10];
        Random rand = new Random();
        int current;
        int next;
        int equalElements = 1;
        int maxElements = 1;
        int value;

        //fill the array with random values 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(4);
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
            if (next == current)
            {
                equalElements++;
            }
            else
            {
                current = next;
                if (equalElements > maxElements)
                {
                    maxElements = equalElements;
                    value = array[i - 1];
                }
                equalElements = 1;
            }
            //case when max sequence includes last index
            if (i == array.Length - 1)
            {
                if (equalElements > maxElements)
                {
                    maxElements = equalElements;
                    value = array[i];
                }
            }
        }

        #region print result
        //print sequence
        if (maxElements == 1)
        {
            Console.Write("No equal elements ");
        }
        else
        {
            for (int i = 0; i < maxElements; i++)
            {
                Console.Write(value);
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

