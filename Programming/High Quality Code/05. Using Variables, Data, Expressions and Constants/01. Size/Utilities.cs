//-----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Figures
{
    using System;

    /// <summary>
    /// Utilities to transform geometric objects.
    /// </summary>
    /// <remarks><see cref="http://en.wikipedia.org/wiki/Rotation_(geometry)"/></remarks>
    public class Utilities
    {
        public static Point RotatePoint(Point point, double angleOfRotation)
        {
            var newXcoordinate = (Math.Abs(Math.Cos(angleOfRotation)) * point.Xcoordinate) -
                (Math.Abs(Math.Sin(angleOfRotation)) * point.Ycoordinate);
            var newYcoordinate = (Math.Abs(Math.Sin(angleOfRotation)) * point.Xcoordinate) +
                (Math.Abs(Math.Cos(angleOfRotation)) * point.Ycoordinate);

            return new Point(newXcoordinate, newYcoordinate);
        }
    }
}
