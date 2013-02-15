using System;
using System.Collections.Generic;

namespace ConditionalStatements
{
    class SignOfProduct
    {
        //Write a program that shows the sign (+ or -) of the product
        //of three real numbers without calculating it. Use a sequence of if statements.

        static void Main()
        {
            //variables
            double firstNumber = DoubleFromConsole();
            double secondNumber = DoubleFromConsole();
            double thirdNumber = DoubleFromConsole();
            string sign = "+";
            int negative = 0;

            //expressions
            #region I variant
            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                Console.WriteLine("The product is zero");
            }
            if (firstNumber < 0)
            {
                if (secondNumber < 0)
                {
                    if (thirdNumber < 0)
                    {
                        sign = "-";
                    }
                    else
                    {
                        sign = "+";
                    }
                }
                else
                {
                    if (thirdNumber < 0)
                    {
                        sign = "+";
                    }
                    else
                    {
                        sign = "-";
                    }
                }
            }
            else
            {
                if (secondNumber < 0)
                {
                    if (thirdNumber < 0)
                    {
                        sign = "+";
                    }
                    else
                    {
                        sign = "-";
                    }
                }
                else
                {
                    if (thirdNumber < 0)
                    {
                        sign = "-";
                    }
                    else
                    {
                        sign = "+";
                    }
                }
            }
            Console.WriteLine("Sign (+ or -) of the product of the three real numbers is: {0}", sign);
            #endregion

            #region II variant
            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                Console.WriteLine("The product is zero");
            }
            if (firstNumber < 0)
            {
                negative++;
            }
            if (secondNumber < 0)
            {
                negative++;
            }
            if (thirdNumber < 0)
            {
                negative++;
            }
            Console.WriteLine("Sign (+ or -) of the product of the three real numbers is: {0}",negative==2?"+":"-");
            #endregion

            #region III variant
            List<double> listOfNumbers = new List<double>();
            listOfNumbers.Add(firstNumber);
            listOfNumbers.Add(secondNumber);
            listOfNumbers.Add(thirdNumber);
            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                Console.WriteLine("The product is zero");
            }
            if (listOfNumbers.FindAll(x => x < 0).Count == 2)
            {
                sign = "+";
            }
            else
            {
                sign = "-";
            }
            #endregion

            Console.WriteLine("Sign (+ or -) of the product of the three real numbers is: {0}",sign);
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

        //parse console input to double
        static double DoubleFromConsole()
        {
            double value;
            while (true)
            {
                Console.Write("Enter a real number : ");
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            return value;
        }
    }
}
