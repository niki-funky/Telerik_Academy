using System;
using System.Linq;

namespace ThreeDspace
{
    static class Distance
    {
        //method to calculate distance b/n two 3D points
        public static double Distance3D(Point3D p1, Point3D p2)
        {
            double dist = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X)
                           + (p1.Y - p2.Y) * (p1.Y - p2.Y)
                           + (p1.Z - p2.Z) * (p1.Z - p2.Z));
            return dist;
        }
    }
}
