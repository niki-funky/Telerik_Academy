using System;
using System.Linq;

namespace Shapes
{
    // 01. Define abstract class Shape with only one abstract
    // method CalculateSurface() and fields width and height. 
    // Define two new classes Triangle and Rectangle that 
    // implement the virtual method and return the surface of
    // the figure (height*width for rectangle and height*width/2
    // for triangle). Define class Circle and suitable constructor
    // so that at initialization height must be kept equal to 
    // width and implement the CalculateSurface() method. Write
    // a program that tests the behavior of  the CalculateSurface()
    // method for different shapes (Circle, Rectangle, Triangle)
    // stored in an array.

    class Program
    {
        static void Main(string[] args)
        {
            //test
            Shape[] shapes = { 
                             new Circle(3),
                             new Rectangle(4,3),
                             new Triangle(3.5,2)};

            foreach (var item in shapes)
            {
                Console.WriteLine(item.CalculateSurface());
            }
        }
    }
}
