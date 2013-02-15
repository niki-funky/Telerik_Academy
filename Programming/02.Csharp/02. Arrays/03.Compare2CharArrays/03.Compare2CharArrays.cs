using System;

class Compare2CharArrays
{
    //Write a program that compares two char 
    //arrays lexicographically (letter by letter).

    static void Main()
    {
        //variables
        char[] array1 = { 'a', 'b', 'c', 'd' };
        char[] array2 = { 'a', 'n', 'o', 'd', 'e', 'a', 'g' };
        int equalElements = 0;
        int result = 0;

        //expressions
        for (int i = 0; i < (array1.Length >= array2.Length ? array2.Length : array1.Length); i++)
        {
            result = array1[i].CompareTo(array2[i]);
            if (result < 0)
            {
                Console.WriteLine("{0} is before {1}", array1[i], array2[i]);
            }
            if (result == 0)
            {
                Console.WriteLine("{0} is equal to {1}", array1[i], array2[i]);
                equalElements++;
            }
            if (result > 0)
            {
                Console.WriteLine("{0} is after {1}", array1[i], array2[i]);
            }
            //check if arrays are identical
            if (array1.Length == array2.Length && equalElements == array2.Length)
            {
                Console.WriteLine("Arrays are identical.");
            }
        }
        if (array1.Length != array2.Length)
        {
            Console.WriteLine("Arrays are Not identical.");
        }

    }
}

