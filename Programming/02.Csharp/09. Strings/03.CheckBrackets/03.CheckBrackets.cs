using System;

class CheckBrackets
{
    // Write a program to check if in a given expression
    // the brackets are put correctly.
    // Example of correct expression: ((a+b)/5-d).
    // Example of incorrect expression: )(a+b)).

    static void Main()
    {
        //variables
        Console.Write("Enter expression to check: ");
        string word = Console.ReadLine();

        //print result
        Console.WriteLine(CheckAllBrackets(word)?
            "Expression is correct.":
            "Expression is Incorrect!");
    }

    static bool CheckAllBrackets(string expression)
    {
        int count = 0;

        foreach (var symbol in expression)
        {
            if (symbol == '(')
            {
                count++;
            }
            else if (symbol == ')')
            {
                count--;
            }
            if (count < 0)
            {
                return false;
            }
        }
        if (count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
