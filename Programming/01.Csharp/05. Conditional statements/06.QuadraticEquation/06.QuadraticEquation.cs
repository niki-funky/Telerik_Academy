using System;

namespace ConditionalStatements
{
    class QuadraticEquation
    {
        //Write a program that enters the coefficients a, b and c of a quadratic equation
		//a*x^2 + b*x + c = 0
		//and calculates and prints its real roots. 
        //Note that quadratic equations may have 0, 1 or 2 real roots.

        static void Main()
        {
            //variables
            double a = DoubleFromConsole();
            double b = DoubleFromConsole();
            double c = DoubleFromConsole();
            double x, x1, x2;

            //expressions
            //first find the Discriminant D
            double D = Math.Pow(b, 2) - 4 * a * c;

            //check if a=0
            if (a == 0)
            {
                x = -c / b;
                Console.WriteLine("x={0}", x);
            }
            else
            {
                //we have then 3 cases for D
                //1. If the discriminant is negative, then there are no real roots
                if (D < 0)
                {
                    Console.WriteLine("No real roots.");
                }
                //2. If the discriminant is zero, then there is exactly one distinct real root,
                //sometimes called a double root
                if (D == 0)
                {
                    x = -b / 2 * a;
                    Console.WriteLine("x={0}", x);
                }
                //3. If the discriminant is positive, 
                //then there are two distinct roots, both of which are real numbers
                if (D > 0)
                {
                    x1 = (-b + Math.Sqrt(D)) / 2 * a;
                    x2 = (-b - Math.Sqrt(D)) / 2 * a;
                    Console.WriteLine("x1 = {0}" + "\n" + "x2 = {1}", x1, x2);

                }
            }
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
                Console.Write("Enter a number : ");
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
