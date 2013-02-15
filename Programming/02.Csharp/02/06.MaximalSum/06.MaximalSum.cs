using System;

class MaximalSum
{
    //Write a program that reads two integer 
    //numbers N and K and an array of N elements
    //from the console. Find in the array those K 
    //elements that have maximal sum.
    //Example: K=2 ->{3, 2, 3, 4, 2, 2, 4} => {4, 4}.

    static void Main()
    {
        //variables
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        int max;

        //fill the array with numbers from console
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        //sort the array from biggest to smallest
        //I variant
        for (int i = 0; i < n - 1; i++)
        {
            max = i;
            for (int m = i + 1; m < n; m++)
            {
                if (array[m] > array[max])
                {
                    max = m;
                }
            }
            //swap current element with Biggest element
            if (i != max)
            {
                array[i] = array[i] ^ array[max];
                array[max] = array[max] ^ array[i];
                array[i] = array[i] ^ array[max];
            }
        }
        //II variant
        //Array.Sort(array);
        //Array.Reverse(array);

        #region print result
        //print those K elements with max sum
        Console.Write("The {0} elements with max sum are {{", k);
        for (int i = 0; i < k; i++)
        {
            Console.Write(array[i]);
            if (i != k - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine("}"); 
        #endregion
    }
}
