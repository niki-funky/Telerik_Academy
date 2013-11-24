using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        public Lion(string name, Point location)
            : base(name, location, 6)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.Size <= this.Size*2)
            {
                var result = animal.GetMeatFromKillQuantity();
                this.Size++;
                return result;
            }
            return 0;
        }
    }
}
