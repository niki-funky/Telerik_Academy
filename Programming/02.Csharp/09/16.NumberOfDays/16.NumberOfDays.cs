using System;
using System.Globalization;
using System.Linq;

class NumberOfDays
{
    // Write a program that reads two dates
    // in the format: day.month.year and calculates
    // the number of days between them.

    static void Main()
    {
        //variables        
        TimeSpan span;
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        if (firstDate > secondDate)
        {
            span = firstDate - secondDate;
        }
        else
        {
            span = secondDate - firstDate;
        }

        Console.WriteLine(span.Days);
    }
}