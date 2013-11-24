//-----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace School
{
    using System;
    using System.Linq;
    using Properties;

    /// <summary>
    /// Performs operations on students data.
    /// </summary>
    public static class Utilities
    {
        private const int MinValue = 10000;
        private const int MaxValue = 99999;

        /// <summary>
        /// Generates unique number.
        /// Number is saved in Settings.
        /// <see cref=http://msdn.microsoft.com/en-us/library/aa730869(v=vs.80).aspx /> 
        /// </summary>
        /// <returns>Unique student number(UN).</returns>
        public static int GetUN()
        {
            int uniqueNumber = Settings.Default.UniqueNumber;
            if (uniqueNumber < MinValue || uniqueNumber > MaxValue)
            {
                Settings.Default.UniqueNumber = MinValue;
            }

            Settings.Default.UniqueNumber++;
            Settings.Default.Save();

            return uniqueNumber;
        }
    }
}
