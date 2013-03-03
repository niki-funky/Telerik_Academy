using System;
using System.IO;
using System.Linq;

namespace ThreeDspace
{
    static class PathStorage
    {
        //fields
        private static readonly string path1 = ".../.../input.txt";
        private static readonly string path2 = ".../.../output.txt";
        public static readonly Path path = new Path();

        //methods
        //read path of 3D points
        public static void LoadPointsFromFile()
        {
            using (StreamReader sr = new StreamReader(path1))
            {
                string line = sr.ReadLine();                

                while (line != null)
                {
                    //using Linq to split and parse as double
                    double[] coordinates = line.Split(',').Select(double.Parse).ToArray();
                    path.New3Dpoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
                    line = sr.ReadLine();
                }
            }
        }

        //write path of 3D points
        public static void WritePointsToFile()
        {
            using (StreamWriter sw = new StreamWriter(path2))
            {
                foreach (var item in path.ListOf3Dpoints)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }
    }
}
