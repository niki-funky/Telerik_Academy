using System;

namespace OperatorsExpressions
{
    class CheckIfPointIsWithinCircle
    {
        static void Main()
        {
            //Write an expression that checks 
            //if given point (x,  y) is within a circle K(O, 5).

            //variables
            int radius = 5;
            int pointX = 0;
            int pointY = 0;
            bool checkCoordinates;

            while (true)
            {
                Console.Write("Enter X coordinate: ");
                if (int.TryParse(Console.ReadLine(), out pointX))
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter Y coordinate: ");
                if (int.TryParse(Console.ReadLine(), out pointY))
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }

            //expression
            checkCoordinates = (pointX*pointX + pointY*pointY) < (radius*radius);
            Console.WriteLine(checkCoordinates
                ? "Point is within the circle(0,5)" + "\n"
                : "Point is Not within the circle(0,5)" + "\n");
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
