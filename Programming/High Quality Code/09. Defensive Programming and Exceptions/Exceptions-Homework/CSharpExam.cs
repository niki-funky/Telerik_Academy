//-----------------------------------------------------------------------
// <copyright file="CSharpExam.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
using System;

public class CSharpExam : Exam
{
    public const int HighestScore = 10;

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("Score must be zero or greater than zero.");
        }

        if (score > HighestScore)
        {
            throw new ArgumentOutOfRangeException("Score must be less than the highest score");
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, HighestScore, "Exam results calculated by score.");
    }
}
