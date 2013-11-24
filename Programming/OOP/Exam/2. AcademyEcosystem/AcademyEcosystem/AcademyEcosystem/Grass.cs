using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        public Grass(Point location)
            : base(location, 2)
        {

        }

        public override void Update(int timeElapsed)
        {
            if (this.IsAlive)
            {
                for (int i = 0; i < timeElapsed; i++)
                {
                    this.Size += 1;
                }
            }
            base.Update(timeElapsed);
        }
    }
}
