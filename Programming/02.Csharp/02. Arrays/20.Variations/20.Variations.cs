using System;

class Variations
{
    //Write a program that reads two numbers N
    //and K and generates all the variations of K
    //elements from the set [1..N]. Example:
    //N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, 
    //{2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}


    static void Main()
    {
        //variables
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];
        int index;

        //fill the array with 1-s
        for (int i = 0; i < k; i++)
        {
            array[i] = 1;
        }

        //find all variations
        while (true)
        {
            #region print current variation
            Console.Write("{ ");
            for (int i = 0; i < k; i++)
            {
                if (i != k - 1)
                {
                    Console.Write(array[i] + ", ");
                }
                else
                {
                    Console.Write(array[i]);
                }
            }
            Console.WriteLine(" }");
            #endregion

            index = k - 1;
            array[index] = array[index] + 1;

            //it's so beautiful
            while (array[index] > n)
            {
                array[index] = 1;
                index--;

                if (index < 0)
                {
                    return;
                }
                array[index] = array[index] + 1;
            }
        }
    }
}