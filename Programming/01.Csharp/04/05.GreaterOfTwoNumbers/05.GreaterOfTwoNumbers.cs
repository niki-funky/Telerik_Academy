using System;

namespace ConsoleInputOutput
{
    class GreaterOfTwoNumbers
    {
        //Write a program that gets two numbers from the console 
        //and prints the greater of them. Don’t use if statements.

        static void Main()
        {
            //variables
            int firstNumber = IntFromConsole();
            int secondNumber = IntFromConsole();

            //1 variant(alternative syntax to if-else)
            //Console.WriteLine("The bigger number is : {0}",firstNumber>secondNumber?firstNumber:secondNumber);

            //2 variant
            Console.WriteLine("1v. The bigger number is : {0}", Math.Max(firstNumber, secondNumber));

            //3 variant
            while (firstNumber > secondNumber)
            {
                Console.WriteLine("2v. The bigger number is : {0}", firstNumber);
                break;
            }
            while (secondNumber > firstNumber)
            {
                Console.WriteLine("2v. The bigger number is : {0}", secondNumber);
                break;
            }

            //4 variant
            int biggerNumber = firstNumber - ((firstNumber - secondNumber) & ((firstNumber - secondNumber) >> 31));
            Console.WriteLine("3v. The bigger number is : {0}", biggerNumber);
        }

        //make console red if wrong input
        static void RedLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value);

            // Reset the color
            Console.ResetColor();
        }

        //parse console input to integer
        static int IntFromConsole()
        {
            int value;
            while (true)
            {
                Console.Write("Enter a number : ");
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            return value;
        }
    }
}
