using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WcfServiceString.Lib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceString : IServiceString
    {
        public int NumberOfOccurences(string first, string second)
        {
            return Regex.Matches(second, first).Count;
        }
    }
}
