using System;

class Sequence
{
    //Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

    static void Main()
    {
        Console.WriteLine("The first 10 members of the sequence are:"+"\r\n");
        Console.WriteLine("{0,-3}{1,6}", "even", "odd");
        Console.WriteLine("----------");

        for (int i = 2; i < 12; i=i+2)
        {
            Console.WriteLine(" {0,-3}{1,6}", i, -(i+1));
        }
    }
}
