//-----------------------------------------------------------------------
// <copyright file="Point.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Figures
{
    using System;

    /// <summary>
    /// Creates Point object with x and y coordinates.
    /// </summary>
    public class Point
    {
        public Point(double x, double y)
        {
            this.Xcoordinate = x;
            this.Ycoordinate = y;
        }

        public double Xcoordinate { get; set; }

        public double Ycoordinate { get; set; }
    }
}
