using System;
using System.Linq;
using StringConsumer.Console.ServiceReferenceString;

namespace StringConsumer.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceStringClient client = new ServiceStringClient();
            int result = client.NumberOfOccurences("a", "banica");
            System.Console.WriteLine("The result returned by the WCF service is: " + result);
        }
    }
}
