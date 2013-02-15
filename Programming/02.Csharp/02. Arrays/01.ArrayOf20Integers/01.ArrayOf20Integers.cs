using System;

class ArrayOf20Integers
{
    //Write a program that allocates array of 20 integers 
    //and initializes each element by its index multiplied by 5.
    //Print the obtained array on the console.

    static void Main()
    {
        //variables
        int[] array = new int[20];

        //expressions
        for (int i = 0; i < 20; i++)
        {
            array[i] = i * 5;
            Console.WriteLine(array[i]);
        }
    }
}

