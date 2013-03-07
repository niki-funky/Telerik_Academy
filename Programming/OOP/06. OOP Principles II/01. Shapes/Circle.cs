using System;
using System.Linq;

namespace Shapes
{
    class Circle : Shape
    {
        //constructor
        public Circle(double width)
            : base()
        {
            base.Height = width;
            base.Width = width;
        }

        //method
        public override double CalculateSurface()
        {
            return Math.PI*(base.Height) * (base.Width);
        }
    }
}
