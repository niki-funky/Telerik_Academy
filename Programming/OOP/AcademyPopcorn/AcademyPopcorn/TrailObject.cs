using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        //field
        private int lifetime;

        //constructor
        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.lifetime = lifetime - 1;
        }

        //method
        public override void Update()
        {
            if (this.lifetime == 0)
            {
                IsDestroyed = true;
            }
            else
            {
                this.lifetime--;
            }
        }
    }
}
