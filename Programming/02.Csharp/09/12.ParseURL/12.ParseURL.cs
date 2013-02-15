using System;
using System.Linq;
using System.Text.RegularExpressions;

class ParseURL
{
    // Write a program that parses an URL address given in the format:
    // and extracts from it the [protocol], [server] and [resource] elements.
    // For example from the URL http://www.devbg.org/forum/index.php 
    // the following information should be extracted:
    // [protocol] = "http"
    // [server] = "www.devbg.org"
    // [resource] = "/forum/index.php"

    static void Main()
    {
        try
        {
            //variables
            Console.WriteLine("Write some url in the following format: ");
            Console.WriteLine("[protocol]://[server]/[resource]" + "\n");
            string url = "http://www.devbg.org/forum/index.php";
            var uri = new Uri(url);

            //I variant
            string[] separator = new string[] { "://" };
            string[] string1 = url.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("[protocol] = " + string1[0]);
            string[] string2 = string1[1].Split('/');
            Console.WriteLine("[server] = " + string2[0]);
            Console.WriteLine("[resource] = "
                + '/'
                + string.Join("/", string2, 1, string2.Length - 1));

            //II variant using regular expressions
            Console.WriteLine();

            Console.WriteLine("[protocol] = " + Regex.Match(url, @"^.*?(?=://)"));
            Console.WriteLine("[server] = " + Regex.Match(url, @"(?<=//)[\w\.]+"));
            Console.WriteLine("[resource] = " + '/' + Regex.Match(url, @"(?<=\w/)(.*)"));

            //III variant
            Console.WriteLine();

            Console.WriteLine("[protocol] = " + uri.Scheme);
            Console.WriteLine("[server] = " + uri.Host);
            Console.WriteLine("[resource] = " + uri.AbsolutePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops something went wrong!" + "\n" + ex.Message);
        }
    }
}