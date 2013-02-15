using System;
using System.Linq;

class CheckElementInArray2
{
    // Write a method that returns the index of the first
    // element in array that is bigger than its neighbors,
    // or -1, if there’s no such element.
    // Use the method from the previous exercise.


    static void Main()
    {
        //variables
        int[] array = new int[10];
        Random rand = new Random();

        //fill the array with Random numbers
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(9);
        }

        #region print array
        Console.Write("{");
        Console.Write(String.Join(", ", array));
        Console.WriteLine("} -> ");
        #endregion

        //print result
        for (int i = 1; i < array.Length - 1; i++)
        {
            if (Methods.CheckElementInArray.CompareNumbers(array, i))
            {
                Console.WriteLine("Element at index {0} is bigger than its neighbours", i);
                return;
            }
        }
        Console.WriteLine("-1");
    }

    //public static bool CompareNumbers(int[] array, int index)
    //{
    //    bool biggest = false;
    //    if (index != 0 && index != array.Length - 1)
    //    {
    //        if (array[index] > array[index - 1] && array[index] > array[index + 1])
    //        {
    //            biggest = true;
    //        }
    //    }

    //    return biggest;
    //}
}