using System;

namespace OperatorsExpressions
{
    class AreaOfTrapezoid
    {
        static void Main()
        {
            //Write an expression that calculates 
            //trapezoid's area by given sides a and b and height h.

            //variables
            int sideA = 0;
            int sideB = 0;
            int height = 0;
            int areaOfTrapezoid;

            #region Console Input
            while (true)
            {
                Console.Write("Enter number for side a: ");
                if (int.TryParse(Console.ReadLine(), out sideA) && sideA > 0)
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter number for side b: ");
                if (int.TryParse(Console.ReadLine(), out sideB) && sideB > 0)
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter number for height h: ");
                if (int.TryParse(Console.ReadLine(), out height) && height > 0)
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }
            #endregion

            //expression
            areaOfTrapezoid = (sideA + sideB) * height / 2;
            Console.WriteLine("Trapezoid area is: {0}" + "\n", areaOfTrapezoid);
        }

        //make console red if wrong input
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
