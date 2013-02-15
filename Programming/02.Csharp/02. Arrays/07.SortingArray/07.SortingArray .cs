using System;

class SortingArray
{
    //Sorting an array means to arrange its elements in
    //increasing order. Write a program to sort an array. 
    //Use the "selection sort" algorithm: Find the smallest
    //element, move it at the first position, find the smallest
    //from the rest, move it at the second position, etc.

    static void Main()
    {
        //variables
        int[] array = new int[10];
        Random rand = new Random();
        int max;

        //expressions
        //fill the array with random values 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(9);
        }

        //sort the array from smallest to biggest
        //I variant
        for (int i = array.Length - 1; i > 0; i--)
        {
            max = i;
            for (int m = i - 1; m >= 0; m--)
            {
                if (array[m] > array[max])
                {
                    max = m;
                }
            }
            //swap current element with smallest element
            if (i != max)
            {
                array[i] = array[i] ^ array[max];
                array[max] = array[max] ^ array[i];
                array[i] = array[i] ^ array[max];
            }
        }
        //II variant
        //Array.Sort(array);

        #region print result
        //print array
        Console.Write("{");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
            if (i != array.Length - 1)
            {
                Console.Write(',');
            }
        }
        Console.WriteLine("}");
        #endregion
    }
}
