using System;

namespace ConsoleInputOutput
{
    class SumOfNnumbers
    {
        //Write a program that gets a number n and after that 
        //gets more n numbers and calculates and prints their sum. 

        static void Main()
        {
            //variables
            int number1;
            //parse console input to integer
            while (true)
            {
                Console.Write("Enter a number : ");
                if (int.TryParse(Console.ReadLine(), out number1))
                {
                    break;
                }
            }
            int sum = 0;

            //expressions
            for (int i = 0; i < number1; i++)
            {
                int number2 = int.Parse(Console.ReadLine());
                sum = number2 + sum;
            }
            Console.WriteLine("Sum of all numbers is : {0}", sum);
        }
    }
}
