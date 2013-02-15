using System;
using System.Text.RegularExpressions;

class SubstringRepetition
{
    // Write a program that finds how many times 
    // a substring is contained in a given text 
    // (perform case insensitive search).
    // Example: The target substring is "in".
    // The text is as follows:

    // We are living in an yellow submarine. 
    // We don't have anything else. Inside the 
    // submarine is very tight. So we are drinking 
    // all the day. We will move out of it in 5 days.

    // The result is: 9.

    static void Main()
    {
        //variables
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string pattern = "in";

        try
        {
            //using Regex to match multiple instances of a pattern
            MatchCollection match = Regex.Matches(
                text, pattern, RegexOptions.IgnoreCase);

            Console.WriteLine("The result is: {0}", match.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ooops something went wrong!" + ex);
        }
    }
}
