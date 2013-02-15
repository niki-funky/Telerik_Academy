using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractAllDates
{
    // Write a program that extracts from a given 
    // text all dates that match the format DD.MM.YYYY.
    // Display them in the standard date format for Canada.

    static void Main()
    {
        //variables        
        string text = "On 12.04.1961 Soviet Union's Yuri A. Gagarin (1934-1968) became the first man to complete an orbit of Earth. The first American to orbit the Earth was John Glenn on 20.02.1962.";
        var pattern = @"\d{2}.\d{2}.\d{4}";
        DateTime canadianDate;

        foreach (Match item in Regex.Matches(text, pattern))
        {
            canadianDate = DateTime.Parse(item.Value);
            Console.WriteLine(canadianDate.Date.ToString(new CultureInfo("fr-CA").DateTimeFormat.ShortDatePattern));
        }
    }
}