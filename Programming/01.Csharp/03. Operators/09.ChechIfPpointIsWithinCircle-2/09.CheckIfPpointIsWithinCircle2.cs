using System;

namespace OperatorsExpressions
{
    class ChechIfPpointIsWithinCircle2
    {
        static void Main()
        {
            //Write an expression that checks 
            //for given point (x, y) if it is within the circle K( (1,1), 3)
            //and out of the rectangle R(top=1, left=-1, width=6, height=2).

            //variables
            int radius = 3;
            int circleX = 1;
            int circleY = 1;
            float pointX = 0;
            float pointY = 0;
            bool checkCirclelimits;
            bool checkRectLimmits;
            int rectTop = 1;
            int rectLeft = -1;
            int rectBottom = -1;

            while (true)
            {
                Console.Write("Enter X coordinate: ");
                if (float.TryParse(Console.ReadLine(), out pointX))
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter Y coordinate: ");
                if (float.TryParse(Console.ReadLine(), out pointY))
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }

            //expression
            checkCirclelimits = (Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2)) < Math.Pow(radius,2);
            checkRectLimmits = ((pointX < rectLeft) || (pointY > rectTop) || (pointY < rectBottom));
            Console.WriteLine(checkCirclelimits && checkRectLimmits
                ? "\n" + "Point is at the Right place." + "\n"
                : "\n" + "Point is at Wrong place!" + "\n");
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
