using System;

class RandomValues
{
    // Write a program that generates and prints
    // to the console 10 random values in the range [100, 200].

    static void Main()
    {
        //variables
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(random.Next(100, 200));
        }
    }
}
