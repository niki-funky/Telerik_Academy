using System;

namespace OperatorsExpressions
{
    class AreaOfRectangle
    {
        static void Main()
        {
            //Write an expression that calculates 
            //rectangle’s area by given width and height.

            //variables
            int width = 0;
            int height = 0;
            int rectangleArea;

            while (true)
            {
                Console.Write("Enter the width of Rectangle: ");
                if (int.TryParse(Console.ReadLine(), out width))
                {
                    break;
                }
                ColoredLine("wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter the height of rectangle: ");
                if (int.TryParse(Console.ReadLine(), out height))
                {
                    break;
                }
                ColoredLine("wrong Input!");
            }

            //expression
            rectangleArea = width * height;
            Console.Write("Area of rectangle is: {0}" + "\n" + "\n", rectangleArea);
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
