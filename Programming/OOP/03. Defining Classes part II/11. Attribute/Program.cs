using System;
using System.Linq;

namespace Attribute
{
    [Version(2.11)]

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Program);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine(
                    "Major version: {0} ", attr.Major);
                Console.WriteLine(
                    "Minor version: {0} ", attr.Minor);
            }

        }
    }
}
