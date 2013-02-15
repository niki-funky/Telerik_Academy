using System;

class MaximalSum2
{
    //Write a program that finds the sequence 
    //of maximal sum in given array. 
    //Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}

    static void Main()
    {
        //variables
        int[] array = new int[10];
        Random rand = new Random();
        int currentSum;
        int maxSum;
        int currentIndex = 0;
        int startIndex = 0;
        int currentSequence = 1;
        int finalSequence = 1;

        //fill the array with random values 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(-9,9);
        }

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
        Console.Write("} -> { "); 
        #endregion

        currentSum = array[0];
        maxSum = array[0];
        //find the sequence of maximal sum
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] + currentSum > array[i])
            {
                currentSum = currentSum + array[i];
                currentSequence++;
            }
            else
            {
                currentSum = array[i];
                currentIndex = i;
                currentSequence = 1;
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                finalSequence = currentSequence;
                startIndex = currentIndex;
            }
        }

        #region print result
        //print sequence
        for (int i = startIndex; i < startIndex + finalSequence; i++)
        {
            Console.Write(array[i]);
            if (i != startIndex + finalSequence - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine(" }");
    } 
        #endregion
}
