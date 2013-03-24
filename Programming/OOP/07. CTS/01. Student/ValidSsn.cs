using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Student
{
    class ValidSsn
    {
        public bool IsValidSsn(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;

            string pattern = @"^\d{9}$|^\d{3}-\d{2}-\d{4}$";

            return Regex.IsMatch(strIn, pattern, RegexOptions.IgnoreCase);
        }
    }
}
