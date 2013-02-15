using System;

namespace Loops
{
    class SequenceOfIntegerNumbers
    {
        //Write a program that reads from the console 
        //a sequence of N integer numbers and returns the minimal and maximal of them.

        static void Main()
        {
            //variables
            Console.Write("How many numbers in the sequence? ");
            int lastNumber = int.Parse(Console.ReadLine());
            int currentNumber, min, max;
            Console.Write("Enter the 1 number: ");
            currentNumber = int.Parse(Console.ReadLine());
            min = max = currentNumber;

            //expression
            for (int i = 1; i < lastNumber; i++)
            {
                Console.Write("Enter the {0} number: ", i + 1);
                currentNumber = int.Parse(Console.ReadLine());
                if (max < currentNumber)
                {
                    max = currentNumber;
                }
                if (min > currentNumber)
                {
                    min = currentNumber;
                }
            }
            Console.WriteLine("The smallest number is {0}", min);
            Console.WriteLine("The biggest number is {0}", max);
        }
    }
}
