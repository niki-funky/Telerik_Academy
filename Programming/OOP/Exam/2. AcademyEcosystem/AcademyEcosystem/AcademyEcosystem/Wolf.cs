using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {

        public Wolf(string name, Point location)
            : base(name, location, 4)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.Size <= this.Size)
            {
                var result = animal.GetMeatFromKillQuantity();
                return result;
            }
            if (animal != null && animal.State == AnimalState.Sleeping)
            {
                var result = animal.GetMeatFromKillQuantity();
                return result;
            }
            return 0;
        }
    }
}
