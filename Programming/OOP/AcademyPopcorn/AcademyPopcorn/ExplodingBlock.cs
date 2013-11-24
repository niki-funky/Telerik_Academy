using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "explodingBlock";

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = 'O';
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> destroyed = new List<GameObject>();
            if (this.IsDestroyed)
            {
                destroyed.Add(new DestroyedObject(this.topLeft, new char[,] { { 'x' } }, new MatrixCoords(-1, 0)));
                destroyed.Add(new DestroyedObject(this.topLeft, new char[,] { { 'x' } }, new MatrixCoords(-1, -1)));
                destroyed.Add(new DestroyedObject(this.topLeft, new char[,] { { 'x' } }, new MatrixCoords(-1, 1)));
                destroyed.Add(new DestroyedObject(this.topLeft, new char[,] { { 'x' } }, new MatrixCoords(0, 1)));
                destroyed.Add(new DestroyedObject(this.topLeft, new char[,] { { 'x' } }, new MatrixCoords(0, -1)));
                destroyed.Add(new DestroyedObject(this.topLeft, new char[,] { { 'x' } }, new MatrixCoords(1, -1)));
                destroyed.Add(new DestroyedObject(this.topLeft, new char[,] { { 'x' } }, new MatrixCoords(1, 0)));
                destroyed.Add(new DestroyedObject(this.topLeft, new char[,] { { 'x' } }, new MatrixCoords(1, 1)));
            }
            return destroyed;
        }

        //public override string GetCollisionGroupString()
        //{
        //    return ExplodingBlock.CollisionGroupString;
        //}
    }
}
