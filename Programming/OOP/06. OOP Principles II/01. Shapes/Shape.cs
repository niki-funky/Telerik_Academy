using System;
using System.Linq;

namespace Shapes
{
    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        //method
        public abstract double CalculateSurface();
    }
}
