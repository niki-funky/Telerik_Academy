using System;
using System.Globalization;
using System.Linq;
using System.Threading;

class DateAndTime
{
    // Write a program that reads a date and time
    // given in the format: day.month.year 
    // hour:minute:second and prints the date and
    // time after 6 hours and 30 minutes 
    // (in the same format) along with the day of 
    // week in Bulgarian.

    static void Main()
    {
        //variables        
        DateTime date = DateTime.Parse(Console.ReadLine()).AddHours(6).AddMinutes(30);

        Console.WriteLine("{0} {1}", date, date.ToString("dddd", new CultureInfo("bg-BG")));
    }
}