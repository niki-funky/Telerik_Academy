using System;

namespace ConsoleInputOutput
{
    class CircleArea
    {
        //Write a program that reads the radius r of a circle
        //and prints its perimeter and area.

        static void Main()
        {
            //variables
            double radius;
            //parse console input to double
            while (true)
            {
                Console.Write("Enter the radius of circle : ");
                if (double.TryParse(Console.ReadLine(), out radius))
                {
                    break;
                }
            }
            double circlePerimeter = 0;
            double circleArea = 0;

            //expressions
            Console.WriteLine("Perimeter of the circle is : {0}", circlePerimeter = 2 * Math.PI * radius);
            Console.WriteLine("Area of the circle is : {0}", circleArea = Math.PI * Math.Pow(radius, 2));
        }
    }
}
