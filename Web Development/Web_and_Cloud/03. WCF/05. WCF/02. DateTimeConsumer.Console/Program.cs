using System;
using System.Linq;
using DateTimeConsumer.Console.ServiceReferenceDateTime;

namespace DateTimeConsumer.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceDateTimeClient dateTimeClient = new ServiceDateTimeClient();
            string result = dateTimeClient.GetDayOfWeek(new DateTime(2013,07,29));
            System.Console.WriteLine("The result returned by the WCF service is: " + result);
        }
    }
}
