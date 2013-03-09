using System;
using System.Linq;
using System.Text;

namespace Substring
{
    // 01.Implement an extension method Substring(int index, int length)
    // for the class StringBuilder that returns new StringBuilder and
    // has the same functionality as Substring in the class String.

    class Program
    {
        static void Main(string[] args)
        {
            //test
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Implement an extension method Substring(int index, int length)");
            Console.WriteLine(sb.Substring(5,4).ToString());
        }
    }
}
