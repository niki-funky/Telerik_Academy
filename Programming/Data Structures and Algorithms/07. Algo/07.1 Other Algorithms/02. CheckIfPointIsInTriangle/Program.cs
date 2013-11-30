using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CheckIfPointIsInTriangle
{
    // 02. You are given 3 points A, B and C, forming triangle, and a point P. 
    // Check if the point P is in the triangle or not.
    class Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Program
    {
        // Barycentric Technique
        private static bool CheckPoint(Point p, Point p0, Point p1, Point p2)
        {
            double area = 1.0 / 2.0 * (-p1.Y * p2.X + p0.Y *
                (-p1.X + p2.X) + p0.X * (p1.Y - p2.Y) + p1.X * p2.Y);

            double s = 1.0 / (2.0 * area) *
                (p0.Y * p2.X - p0.X * p2.Y + (p2.Y - p0.Y) *
                p.X + (p0.X - p2.X) * p.Y);
            double t = 1.0 / (2.0 * area) *
                (p0.X * p1.Y - p0.Y * p1.X + (p0.Y - p1.Y) *
                p.X + (p1.X - p0.X) * p.Y);

            if (s > 0 && t > 0 && 1 - s - t > 0)
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            Point p = new Point(1, 10);
            Point p0 = new Point(10, 0);
            Point p1 = new Point(0, 10);
            Point p2 = new Point(0, 0);

            bool isInside = CheckPoint(p, p0, p1, p2);

            Console.WriteLine(
                "Point " + 
                (isInside ? "is" : "is NOT") + 
                " inside the Triangle!");
        }
    }
}
