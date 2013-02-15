using System;
using System.Text.RegularExpressions;

class HTMLtitleAndBodyText
{
    // Write a program that extracts from given HTML file
    // its title (if available), and its body text without
    // the HTML tags. 

    static void Main()
    {
        //variables        
        string text = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">TelerikAcademy</a>aims to provide free real-world practicaltraining for young people who want to turn into skillful .NET software engineers.</p></body></html>";

        //print title of HTML file (using Regular Expressions)
        Console.WriteLine(Regex.Match(text, @"(?<=<title>)(.*?)(?=</title>)"));

        //take only the body of HTML file (using Regular Expressions)
        string body = Regex.Replace(text, "^.*?(?=body.*?>)", "");
        foreach (Match item in Regex.Matches(body, @"(?<=>)[^>]*(?=<)"))
        {
            if (item.Length != 0)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}