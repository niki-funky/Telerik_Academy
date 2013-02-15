using System;

class FirTree
{
    //write a program that prints a fir tree to the console

    static void Main()
    {
        //variables
        int number = int.Parse(Console.ReadLine());
        int dots = number - 2;
        int asteriks = 1;

        //expressions
        for (int i = 1; i < number; i++)
        {
            Console.WriteLine(new String('.', dots) + new String('*', asteriks) + new String('.', dots));
            dots--;
            asteriks = asteriks+2;
        }
        Console.WriteLine(new String('.', number - 2) + new String('*', 1) + new String('.', number - 2));
    }
}
