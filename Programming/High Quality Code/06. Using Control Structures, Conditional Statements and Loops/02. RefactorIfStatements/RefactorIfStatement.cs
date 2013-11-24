//-----------------------------------------------------------------------
// <copyright file="RefactorIfStatement.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//---------------------------------------------------------------------
namespace RefactorIfStatements
{
    using System;

    public class RefactorIfStatement
    {
        public static void Main(string[] args)
        {
            int x = 1;
            int minX = -100;
            int maxX = 100;
            int y = 1;
            int minY = -100;
            int maxY = 100;
            bool shouldVisitCell = true;
            if (shouldVisitCell && IsInRange(x, minX, maxX) && IsInRange(y, minY, maxY))
            {
                VisitCell();
            }
        }

        public static bool IsInRange(int number, int startOfRange, int endOfRange)
        {
            bool isInRange = false;
            if (startOfRange >= number && number <= endOfRange)
            {
                isInRange = true;
            }

            return isInRange;
        }

        public static void VisitCell()
        {
            // TODO implement method
        }
    }
}
