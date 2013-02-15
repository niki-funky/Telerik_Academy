using System;

namespace ConsoleInputOutput
{
    class PrintAllNumsInInterval
    {
        //Write a program that reads an integer number n 
        //from the console and prints all the numbers 
        //in the interval [1..n], each on a single line.

        static void Main()
        {
            //variables
            int number;
            //parse console input to integer
            while (true)
            {
                Console.Write("Enter a number : ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }
            }

            //expressions
            Console.WriteLine("All numbers in the interval [1...{0}] are : ", number);
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i + " ");
            }
            Console.WriteLine();
        }
    }
}
