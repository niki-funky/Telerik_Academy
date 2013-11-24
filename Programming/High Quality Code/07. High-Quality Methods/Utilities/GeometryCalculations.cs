//-----------------------------------------------------------------------
// <copyright file="GeometryCalculations.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Utilities
{
    using System;

    /// <summary>
    /// Methods performing geometric calculations.
    /// </summary>
    public class GeometryCalculations
    {
        /// <summary>
        /// Calculates the area of a triangle.
        /// </summary>
        /// <param name="a">Side a length.</param>
        /// <param name="b">Side b length.</param>
        /// <param name="c">Side c length.</param>
        /// <returns>The area of the triangle.</returns>
        /// <remarks>Calculation of the Triangle area is using Heron's formula.</remarks>
        /// <see cref="http://en.wikipedia.org/wiki/Heron%27s_formula"/>
        public static double TriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Triangle sides must be positive numbers.");
            }

            if (!TriangleInequality(a, b, c))
            {
                throw new ArgumentException("Line segments does not form a triangle.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        public static double DistanceBetweenTwoPoints(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            var coordinateX = secondPointX - firstPointX;
            var coordinateY = secondPointY - firstPointY;
            double distance = Math.Sqrt((coordinateX * coordinateX) + (coordinateY * coordinateY));

            return distance;
        }

        public static bool IsHorizontal(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            if (firstPointX != secondPointX)
            {
                if (firstPointY == secondPointY)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsVertical(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            if (firstPointY != secondPointY)
            {
                if (firstPointX == secondPointX)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Triangle inequality theorem. <see cref="http://en.wikipedia.org/wiki/Triangle_inequality"/>
        /// </summary>
        /// <param name="a">Side a length.</param>
        /// <param name="b">Side b length.</param>
        /// <param name="c">Side c length.</param>
        /// <returns>Line segments can construct triangle if true, else they can not form a triangle.</returns>
        private static bool TriangleInequality(double a, double b, double c)
        {
            bool result = a + b > c && a + c > b && b + c > a;

            return result;
        }
    }
}
