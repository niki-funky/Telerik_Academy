using System;
using System.Globalization;

class DayOfWeek
{
    // Write a program that prints to the console which
    // day of the week is today. Use System.DateTime.

    static void Main()
    {
        Console.WriteLine(DateTime.Today.ToString("dddd",
                          new CultureInfo("bg-BG")));
    }
}
