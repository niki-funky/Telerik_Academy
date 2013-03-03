using System;
using System.Linq;

namespace ThreeDspace
{
    class Program
    {
        static void Main(string[] args)
        {
            //test classes
            //read points from file
            PathStorage.LoadPointsFromFile();
            Point3D fisrt = PathStorage.path.ListOf3Dpoints.First();
            Point3D last = PathStorage.path.ListOf3Dpoints.Last();

            //then calculate distance b/n first and last point
            //and print it
            double dist = Distance.Distance3D(fisrt, last);
            Console.WriteLine(dist);
            PathStorage.WritePointsToFile();
        }
    }
}
