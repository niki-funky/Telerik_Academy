using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        //fields
        List<GameObject> trail;

        //constructor
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        //methods
        public override IEnumerable<GameObject> ProduceObjects()
        {
            trail = new List<GameObject>();
            trail.Add(new TrailObject(this.topLeft, new char[,] { { '*' } }, 3));
            return this.trail;
        }
    }
}
