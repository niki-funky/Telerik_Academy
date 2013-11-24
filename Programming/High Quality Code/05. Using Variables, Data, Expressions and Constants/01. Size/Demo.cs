//-----------------------------------------------------------------------
// <copyright file="Demo.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Figures
{
    using System;

    /// <summary>
    /// Tests program functionality.
    /// </summary>
    public class Demo
    {
        public static void Main()
        {
            Point point = new Point(5, -5);
            double angle = Math.PI / 2;
            Point rotatedPoint = Utilities.RotatePoint(point, angle);

            Console.WriteLine(rotatedPoint.Xcoordinate.ToString());
            Console.WriteLine(rotatedPoint.Ycoordinate.ToString());
        }
    }
}
