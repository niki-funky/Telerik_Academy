using System;

namespace Loops
{
    class TrailingZeroes
    {
        //* Write a program that calculates for given N how many 
        //trailing zeros present at the end of the number N!. Examples:
        //N = 10 -> N! = 3628800 -> 2
        //N = 20 -> N! = 2432902008176640000 -> 4
        //Does your program work for N = 50 000?
        //Hint: The trailing zeros in N! are equal to the number 
        //of its prime divisors of value 5. Think why!

        static void Main()
        {
            //variables
            int number;
            do
            {
                Console.Write("Enter a number : ");
            }
            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);
            Console.WriteLine();
            int numberOfZeroes = 0;
            int result = number;

            //expressions
            for (int i = 1; 1 <= number / Math.Pow(5, i); i++)
            {
                result = result / 5;
                numberOfZeroes += result;
            }

            Console.WriteLine("There are ({0}) trailing zeroes in number {1}", numberOfZeroes, number + "!");
        }
    }
}
