using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlock : Block
    {
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = '@';
        }

        //public override bool CanCollideWith(string otherCollisionGroupString)
        //{
        //    return otherCollisionGroupString == "unstoppableBall";
        //}

        public override void RespondToCollision(CollisionData collisionData)
        {
            //this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}
