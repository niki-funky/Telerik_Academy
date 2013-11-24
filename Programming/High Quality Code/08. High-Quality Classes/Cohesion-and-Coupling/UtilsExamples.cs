//-----------------------------------------------------------------------
// <copyright file="UtilsExamples.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtilities.GetFileExtension("example"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Geometry2DUtilities.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Geometry3DUtilities.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine("Volume = {0:f2}", Geometry3DUtilities.CalcVolumeOfRectangularParallelepiped(3, 4, 5));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3DUtilities.CalcDistanceToBase3D(3, 4, 5));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry2DUtilities.CalcDistanceToBase2D(3, 4));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry2DUtilities.CalcDistanceToBase2D(3, 5));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry2DUtilities.CalcDistanceToBase2D(4, 5));
        }
    }
}
