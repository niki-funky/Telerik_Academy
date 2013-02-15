using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SolveTasks
{
    //Write a program that can solve these tasks:
    //      - Reverses the digits of a number
    //      - Calculates the average of a sequence of integers
    //      - Solves a linear equation a * x + b = 0
    // Create appropriate methods.
    // Provide a simple text-based menu for the user 
    // to choose which task to solve.
    // Validate the input data:
    //      - The decimal number should be non-negative
    //      - The sequence should not be empty
    //      - a should not be equal to 0

    static void Main()
    {
        Console.WriteLine("1. Reverse the digits of a number");
        Console.WriteLine("2. Calculate the average of a sequence of integers");
        Console.WriteLine("3. Solves a linear equation a * x + b = 0");
        int choice = IntFromConsole("Enter your choice : ", 1, 3);

        switch (choice)
        {
            case 1:
                Console.WriteLine(ReverseDigit());
                break;
            case 2:
                Console.WriteLine(AverageOfSequence());
                break;
            case 3:
                Console.WriteLine(LinearEquation());
                break;
        }
    }

    public static string ReverseDigit()
    {
        decimal number = DecimalFromConsole("Enter a number : ");
        //I variant
        var reversed = string.Join("", number.ToString().Reverse());

        //II variant
        StringBuilder sb = new StringBuilder();
        int index = 0;
        while (number > 0)
        {
            decimal d = number % 10;
            number = (number - d) / 10;
            sb.Insert(index, (char)('0' + d));
            index++;
        }

        return reversed;
        //return sb.ToString();
    }

    public static double AverageOfSequence()
    {
        double average;

        Console.WriteLine("Enter sequence of integers separated by space : ");
        //parse console input to List<int> using Linq\
        //no check here for correct input !!!
        List<int> sequence = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();
        //find average using Linq
        average = sequence.Average();

        return average;
    }

    public static double LinearEquation()
    {
        double solution;

        int a = IntFromConsole2("Enter value for 'a' : ");
        int b = IntFromConsole("Enter value for 'b' : ", Int32.MinValue, Int32.MaxValue);
        solution = -(b / a);
        return solution;
    }

    //parse console input to integer
    static int IntFromConsole(string str, int min, int max)
    {
        int value;
        while (true)
        {
            Console.WriteLine();
            Console.Write("{0}", str);
            if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
            {
                break;
            }
            RedLine("Wrong Input!");
        }
        return value;
    }

    //parse console input to integer
    static int IntFromConsole2(string str)
    {
        int value;
        while (true)
        {
            Console.WriteLine();
            Console.Write("{0}", str);
            if (int.TryParse(Console.ReadLine(), out value) && value != 0)
            {
                break;
            }
            RedLine("Wrong Input!");
        }
        return value;
    }

    //parse console input to decimal
    static decimal DecimalFromConsole(string str)
    {
        decimal value;
        while (true)
        {
            Console.WriteLine();
            Console.Write("{0}", str);
            if (decimal.TryParse(Console.ReadLine(), out value) && value > 0)
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