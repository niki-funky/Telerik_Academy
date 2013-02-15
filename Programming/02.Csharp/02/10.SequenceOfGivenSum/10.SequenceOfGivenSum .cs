using System;

class SequenceOfGivenSum
{
    //Write a program that finds in given array
    //of integers a sequence of given sum S (if present).
    //Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

    static void Main()
    {
        //variables
        int s = int.Parse(Console.ReadLine());
        int[] array = new int[10];
        Random rand = new Random();
        int startIndex = 0;
        int currentIndex = 0;
        int sum = 0;

        //expressions
        //fill the array with random values 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(9);
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

        //sum = array[0];
        //find in the array a sequence of the sum S
        for (int i = 0; i < array.Length - 1; i++)
        {
            sum = array[i];
            startIndex = i;

            for (int k = i + 1; k < array.Length; k++)
            {
                sum = sum + array[k];
                if (sum == s)
                {
                    currentIndex = k;
                    i = array.Length;   //dirty hack to exit outer loop :)
                    break;
                }
            }
        }

        #region print result
        //print sequence
        if (sum != s)
        {
            Console.Write("No sequence of sum {0}", s);
        }
        else
        {
            for (int i = startIndex; i <= currentIndex; i++)
            {
                Console.Write(array[i]);
                if (i != currentIndex)
                {
                    Console.Write(',' + " ");
                }
            }
        }
        Console.WriteLine(" }"); 
        #endregion
    }
}
