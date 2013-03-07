using System;
using System.Linq;

namespace Exceptions
{
    // 03. Define a class InvalidRangeException<T> that holds 
    // information about an error condition related to invalid
    // range. It should hold error message and a range definition
    // [start … end].
    // Write a sample application that demonstrates the 
    // InvalidRangeException<int> and InvalidRangeException<DateTime> 
    // by entering numbers in the range [1..100] and dates in the range
    // [1.1.1980 … 31.12.2013].

    class Program
    {
        static void Main(string[] args)
        {
            //test1
            const int min = 0;
            const int max = 100;

            try
            {
                Console.Write("Enter a number b/n [1...100]: ");
                int number = int.Parse(Console.ReadLine());
                if (number < min || number > max)
                {
                    throw new InvalidRangeException<int>("Number out of range!", min, max);
                }
            }
            catch (InvalidRangeException<int> iex)
            {
                Console.WriteLine(iex.Message + "[" + iex.Min + "..." + iex.Max + "]" + "\n");
            }

            //test2
            DateTime minDate = new DateTime(1980, 1, 1);
            DateTime maxDate = new DateTime(2013, 12, 31);

            try
            {
                Console.Write("Enter a date b/n [{0}...{1}]: ",
                                minDate.ToShortDateString(), 
                                maxDate.Date.ToShortDateString());
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date < minDate || date > maxDate)
                {
                    throw new InvalidRangeException<DateTime>("Date out of range!",
                        minDate, maxDate.Date);
                }
            }
            catch (InvalidRangeException<DateTime> iex)
            {
                Console.WriteLine(iex.Message + "["
                    + iex.Min.ToShortDateString() + "..."
                    + iex.Max.ToShortDateString() + "]");
            }
        }
    }
}
