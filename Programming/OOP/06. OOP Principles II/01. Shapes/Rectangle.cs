using System;
using System.Linq;

namespace Shapes
{
    class Rectangle : Shape
    {
        //constructor
        public Rectangle(double width, double height)
            : base()
        {
            base.Width = width;
            base.Height = height;
        }

        //method
        public override double CalculateSurface()
        {
            return base.Height * base.Width;
        }
    }
}
