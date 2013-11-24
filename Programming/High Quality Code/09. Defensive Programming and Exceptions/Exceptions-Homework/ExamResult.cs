//-----------------------------------------------------------------------
// <copyright file="ExamResult.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("The grade cannot be negative!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("The minimum grade cannot be negative!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("The minimum grade must be less than the maximum grade.");
        }

        if (string.IsNullOrWhiteSpace(comments))
        {
            throw new ArgumentNullException("Comments should not be empty or null.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
