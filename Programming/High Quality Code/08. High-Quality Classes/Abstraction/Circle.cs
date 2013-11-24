//-----------------------------------------------------------------------
// <copyright file="Circle.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Abstraction
{
    using System;

    /// <summary>
    /// Creates circle by given radius and
    /// performs some calculations on it
    /// </summary>
    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius must be positive number.");
                }
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
