using System;
using System.Linq;
using System.Text;

namespace ThreeDspace
{
    struct Point3D
    {
        //fields
        private static readonly Point3D zero = new Point3D(0, 0, 0);

        public double X
        {
            get;
            set;
        }
        public double Y
        {
            get;
            set;
        }
        public double Z
        {
            get;
            set;
        }

        //defining properties for these fields
        public static Point3D Zero
        {
            get
            {
                return zero;
            }
        }

        //defining constructors
        //constructor with all fields
        public Point3D(double x, double y, double z):this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        //overriding method ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.X.ToString() + ",");
            sb.Append(this.Y.ToString() + ",");
            sb.Append(this.Z.ToString());
            return sb.ToString();
        }
    }
}
