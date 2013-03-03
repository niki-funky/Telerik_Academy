using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeDspace
{
    class Path
    {
        //fields
        //private readonly List<Point3D> listOf3Dpoints;

        //defining properties for these fields
        public List<Point3D> ListOf3Dpoints { get; private set; }
        //{
        //    get
        //    {
        //        return this.listOf3Dpoints;
        //    }
        //}

        public Path()
        {
            ListOf3Dpoints = new List<Point3D>();
        }

        //methods
        //add new point in the list
        public void New3Dpoint(Point3D p)
        {
            ListOf3Dpoints.Add(p);
        }
    }
}
