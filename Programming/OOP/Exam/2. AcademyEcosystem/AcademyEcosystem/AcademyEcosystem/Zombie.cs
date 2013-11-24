using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        public Zombie(string name, Point location)
            : base(name, location, 0)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
        //public override void RespondTo(IOrganism organism)
        //{
        //    if (organism is ICarnivore)
        //    {
        //        ((Animal)organism).GetMeatFromKillQuantity = 10;
        //    }
        //}
    }
}
