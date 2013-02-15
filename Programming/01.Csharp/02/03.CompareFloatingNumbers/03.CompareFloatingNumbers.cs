using System;

namespace PrimitiveDataTypes
{
    class CompareFloatingNumbers
    {
        //Write a program that safely compares floating-point numbers
        //with precision of 0.000001. Examples:(5.3 ; 6.01) -> false;  (5.00000001 ; 5.00000003) -> true

        static void Main()
        {
            #region variables

            double floatFirst, floatSecond;
            Console.WriteLine("//Comparison of two floating-point numbers//" +"\n");
            while (true)
            {
                Console.Write("Please enter 1st floating-point number:  ");
                if(double.TryParse(Console.ReadLine(), out floatFirst))
                {
                    break;
                }
                ColoredLine("Wrong input!");
            }

            while (true)
            {
                Console.Write("Please enter 2nd floating-point number:  ");
                if(double.TryParse(Console.ReadLine(), out floatSecond))
                {
                    break;
                }
                ColoredLine("Wrong input!");
            }
            #endregion

            const double precision = 0.000001;
 
                if (((floatFirst - precision) < floatSecond)
                    && ((floatFirst + precision) > floatSecond))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
        }
        static void ColoredLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value);

            // Reset the color
            Console.ResetColor();
        }
    }
}
