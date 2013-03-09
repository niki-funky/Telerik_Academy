using System;
using System.Linq;
using System.Text;

namespace Substring
{
    // 01.Implement an extension method Substring(int index, int length)
    // for the class StringBuilder that returns new StringBuilder and
    // has the same functionality as Substring in the class String.

    public static class SubString
    {
        //extension method Substring for Stringbuilder class
        public static StringBuilder Substring(
            this StringBuilder sb, int index, int length)
        {
            if (index > sb.Length || index + length > sb.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            StringBuilder result = new StringBuilder();
            int size = index + length;

            for (int i = index; i <= size; i++)
            {
                result.Append(sb[i]);
            }
            return result;
        }
    }
}
