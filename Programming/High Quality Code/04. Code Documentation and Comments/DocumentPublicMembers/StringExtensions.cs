//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class that extends the String type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Encodes a given string using MD5 hash algorithm.
        /// </summary>
        /// <param name="input">A string to be encoded.</param>
        /// <returns>The hexadecimal representation of the input string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            var hashData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var stringBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < hashData.Length; i++)
            {
                stringBuilder.Append(hashData[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Determines whether a sequence contains a given string.
        /// </summary>
        /// <param name="input">A string to be checked.</param>
        /// <returns>True if the sequence contains the input string, otherwise false.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts string to 16-bit signed integer
        /// </summary>
        /// <param name="input">String to be converted</param>
        /// <returns>Short value if successful, else returns zero.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts string to 32-bit signed integer.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Integer value if successful, else returns zero.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts string to 64-bit signed integer.
        /// </summary>
        /// <param name="input">String to be converted</param>
        /// <returns>Long value if successful, else returns zero.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts string to DateTime object.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Value equivalent to the date and time contained in the input string 
        /// if successful, else returns System.DateTime.MinValue.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes first Letter of a given string.
        /// </summary>
        /// <param name="input">String to be capitalized.</param>
        /// <returns>Capitalized string.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string capitalizedString = input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);

            return capitalizedString;
        }

        /// <summary>
        /// Gets the string between two other strings.
        /// </summary>
        /// <param name="input">String to be searched.</param>
        /// <param name="startString">String as a start position.</param>
        /// <param name="endString">String as an end position.</param>
        /// <param name="startFrom">Starting index.</param>
        /// <returns>The string between startString and endString is successful, else returns empty string</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts cyrillic letters to latin letters.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted to Latin string.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts latin keyboard to cyrillic keyboard.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted to Latin keyboard.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts given string to valid user name.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Valid user name as string.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            string validUserName = Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);

            return validUserName;
        }

        /// <summary>
        /// Converts given string to valid latin filename.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Valid latin filename as string.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            string validLatinFileName = Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);

            return validLatinFileName;
        }

        /// <summary>
        /// Gets the first characters of a given string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="charsCount">Number of characters.</param>
        /// <returns>The first characters as string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            string firstCharacters = input.Substring(0, Math.Min(input.Length, charsCount));

            return firstCharacters;
        }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The file extension as string if successful, else returns empty string.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets the content type of given file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns>The content type as string if successful, else returns "application/octet-stream"</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a given string to byte array.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);

            return bytesArray;
        }
    }
}
