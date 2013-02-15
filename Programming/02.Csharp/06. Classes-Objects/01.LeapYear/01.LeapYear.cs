using System;

class LeapYear
{
    // Write a program that reads a year from 
    // the console and checks whether it is a leap.
    // Use DateTime.

    static void Main()
    {
        //variables
        int leapYear = IntFromConsole();
        Console.WriteLine("Year {0} is {1}a leap year.",
            leapYear, DateTime.IsLeapYear(leapYear)?"":"NOT ");
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
            Console.Write("Enter some year : ");
            if (int.TryParse(Console.ReadLine(), out value) && value > 0 && value < 10000)
            {
                break;
            }
            RedLine("Wrong Input!");
        }
        return value;
    }
}
