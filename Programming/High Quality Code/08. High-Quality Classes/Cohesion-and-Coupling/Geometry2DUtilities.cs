//-----------------------------------------------------------------------
// <copyright file="Geometry2DUtilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Performs geometry calculations on single plane.
    /// </summary>
    public static class Geometry2DUtilities
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static double CalcDistanceToBase2D(double x, double y)
        {
            double distance = CalcDistance2D(0, 0, x, y);
            return distance;
        }
    }
}
