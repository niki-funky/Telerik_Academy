//-----------------------------------------------------------------------
// <copyright file="SimpleMathExam.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
using System;

public class SimpleMathExam : Exam
{
    public const int MaxProblemsSolved = 10;

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("Problems solved must be zero or greater than zero.");
        }

        if (problemsSolved > MaxProblemsSolved)
        {
            throw new ArgumentOutOfRangeException("Problems solved must be less than the max problems solved");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: 1 problem solved.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Highest result: 2 problems solved.");
        }

        throw new ArgumentOutOfRangeException("The number of solved problems is invalid!");
    }
}
