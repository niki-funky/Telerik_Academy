using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace StringExtension
{
    public static class Extension
    {
        public static string Capitalize(this String str)
        {
            // Creates a TextInfo based on current culture.
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(str);
        }
    }
}
