using System;
using System.Linq;

namespace Shapes
{
    class Triangle : Shape
    {
        //constructor
        public Triangle(double width, double height)
            : base()
        {
            base.Width = width;
            base.Height = height;
        }

        //method
        public override double CalculateSurface()
        {
            return (base.Height * base.Width)/2;
        }
    }
}
