//-----------------------------------------------------------------------
// <copyright file="Geometry3DUtilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Performs geometry calculations in 3D space.
    /// </summary>
    public class Geometry3DUtilities
    {
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
            return distance;
        }

        public static double CalcVolumeOfRectangularParallelepiped(double width, double height, double depth)
        {
            if (width < 0 || height < 0 || depth < 0)
            {
                throw new ArgumentException("All lengths must be positive numbers.");
            }

            double volume = width * height * depth;
            return volume;
        }

        public static double CalcDistanceToBase3D(double x, double y, double z)
        {
            double distance = CalcDistance3D(0, 0, 0, x, y, z);
            return distance;
        }
    }
}
