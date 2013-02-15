using System;
using System.Globalization;

class AreaOfTriangle
{
    // Write methods that calculate the surface of a triangle by given:
    // Side and an altitude to it; Three sides; Two sides and an angle
    // between them. Use System.Math.

    static void Main()
    {
        Console.WriteLine("Program to calculate the surface of a triangle.");
        Console.WriteLine("1. Side and altitude to it.");
        Console.WriteLine("2. Three sides");
        Console.WriteLine("3. Two sides and an angle between them");
        int choice = (int)IntFromConsole("Enter your choice : ", 1.0, 3.0);

        switch (choice)
        {
            case 1:
                Console.WriteLine(SideAndAltitude());
                break;
            case 2:
                Console.WriteLine(ThreeSides());
                break;
            case 3:
                Console.WriteLine(TwoSidesAndAngle());
                break;
        }
    }
    //Side and altitude to it
    public static double SideAndAltitude()
    {
        double area;
        double side = IntFromConsole("Enter length of a side : ", 1, 1000000);
        double altitude = IntFromConsole("Enter length of altitude : ", 1, 1000000);
        area = (side * altitude) / 2;
        return area;
    }

    //Area by three sides - Heron's formula
    public static double ThreeSides()
    {
        double area;
        double p;
        double sideA = IntFromConsole("Enter length of a side A : ", 1.0, 1000000.0);
        double sideB = IntFromConsole("Enter length of a side B : ", 1.0, 1000000.0);
        double sideC = IntFromConsole("Enter length of a side C : ", 1.0, 1000000.0);
        p = (sideA + sideB + sideC) / 2;
        area = Math.Sqrt(p*(p-sideA)*(p-sideB)*(p-sideC));
        if (area <= 0)
        {
            Console.WriteLine("Sum of every 2 sides of a triangle, must be greater then the third side");
            return 0;
        }
        return area;
    }

    //Two sides and an angle between them
    public static double TwoSidesAndAngle()
    {
        double area;
        double sideA = IntFromConsole("Enter length of a side A : ", 1, 1000000);
        double sideB = IntFromConsole("Enter length of a side B : ", 1, 1000000);
        double angle = IntFromConsole("Enter the angle between them :", 1, 1000000);
        area = (sideA * sideB * Math.Sin(angle * Math.PI / 180)) / 2;
        return area;
    }

    //parse console input to integer
    static double IntFromConsole(string str, double min, double max)
    {
        double value;
        while (true)
        {
            Console.WriteLine();
            Console.Write("{0}", str);
            if (double.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
            {
                break;
            }
            RedLine("Wrong Input!");
        }
        return value;
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
}
