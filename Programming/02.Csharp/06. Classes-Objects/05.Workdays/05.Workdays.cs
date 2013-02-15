using System;
using System.Linq;

class Workdays
{
    // Write a method that calculates the number
    // of workdays between today and given date,
    // passed as parameter. Consider that workdays 
    // are all days from Monday to Friday except a 
    // fixed list of public holidays specified preliminary as array.

    static void Main()
    {
        //variables
        Console.Write("Enter final date(YYYY/MM/DD): ");
        DateTime final = DateTime.Parse(Console.ReadLine());

        int workDays = WorkingDays(final);
        Console.WriteLine("The number of working days from {0} to {1} -> " + "\n" + " {2}",
                            DateTime.Today.ToString("dd.MM.yyyy"),
                            final.ToString("dd.MM.yyyy"),
                            workDays);
    }

    static DateTime[] holidays = 
        {
            new DateTime(2013, 5, 1),
            new DateTime(2013, 5, 2),                            
            new DateTime(2013, 5, 3),
            new DateTime(2013, 5, 6),
            new DateTime(2013, 5, 24),
                            
            new DateTime(2013, 9, 6),
                            
            new DateTime(2013, 12, 24),
            new DateTime(2013, 12, 25),
            new DateTime(2013, 12, 26),
            new DateTime(2013, 12, 31),
        };

    static int WorkingDays(DateTime final)
    {
        int result = 0;
        DateTime start = DateTime.Now;
        for (DateTime days = start; days <= final; days = days.AddDays(1.0))
        {
            if ((days.DayOfWeek == DayOfWeek.Saturday) || (days.DayOfWeek == DayOfWeek.Sunday))
            {
                continue;
            }
            else
            {
                if (holidays.Any(x => x.Date == days.Date))
                {
                    continue;
                }
                result++;
            }
        }
        return result;
    }
}
