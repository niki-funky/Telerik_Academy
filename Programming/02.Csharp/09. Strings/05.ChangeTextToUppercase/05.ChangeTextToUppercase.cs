using System;
using System.Text.RegularExpressions;

class ChangeTextToUppercase
{
    // You are given a text. Write a program that changes 
    // the text in all regions surrounded by the tags <upcase>
    // and </upcase> to uppercase. The tags cannot be nested. 

    static void Main()
    {
        //variables
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string pattern = @"<upcase>(.*?)</upcase>";
        string pattern2 = @"(?<=<upcase>)(.*?)(?=</upcase>)";   //only the text b/n tags

        try
        {
            //using Regex to match multiple instances of a pattern
            foreach (Match match in Regex.Matches(text, pattern))
            {
                text = text.Replace(match.Value, Regex.Match(text, pattern2).Value.ToUpper());
            }

            Console.WriteLine(text);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ooops something went wrong!" + ex);
        }
    }
}
