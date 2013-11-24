//-----------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Abstraction
{
    using System;

    /// <summary>
    /// Creates rectangle by given width and height and
    /// performs some calculations on it
    /// </summary>
    public class Rectangle : Figure
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width must be positive number.");
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height must be positive number.");
                }
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
