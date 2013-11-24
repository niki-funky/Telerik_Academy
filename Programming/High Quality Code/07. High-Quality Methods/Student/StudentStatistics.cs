//-----------------------------------------------------------------------
// <copyright file="StudentStatistics.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Student
{
    using System;
    using System.Text.RegularExpressions;

    public static class StudentStatistics
    {
        public static bool IsOlderThan(this Student student, Student otherStudent)
        {
            var firstStudentDate = ParseStudentDate(student.OtherInfo);
            var secondStudentDate = ParseStudentDate(otherStudent.OtherInfo);

            return firstStudentDate > secondStudentDate;
        }

        private static DateTime ParseStudentDate(string otherInfo)
        {
            var pattern = @"[0-3]{0,1}[0-9]\.[0-1]{0,1}[0-9]\.[0-9]{2,4}";
            var regEx = new Regex(pattern, RegexOptions.IgnoreCase);
            var dateMatch = regEx.Match(otherInfo);

            return DateTime.Parse(dateMatch.Value);
        }
    }
}
