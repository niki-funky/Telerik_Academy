//-----------------------------------------------------------------------
// <copyright file="Chef.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Cookery
{
    using System;

    /// <summary>
    /// Represents the chef in a kitchen.
    /// </summary>
    public class Chef
    {
        public void Cook()
        {
            Bowl bowl = this.GetBowl();
            Potato potato = this.GetPotato();
            if (potato.IsRotten)
            {
                Console.WriteLine("This potato is rotten!");
                return;
            }
            if (!potato.IsPeeled)
            {
                this.Peel(potato);
            }

            Carrot carrot = this.GetCarrot();
            if (!potato.IsPeeled)
            {
                this.Peel(carrot);
            }

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);

            Console.WriteLine("Supper is ready!");
        }

        private void Cut(Vegetable vegetable)
        {
            Console.WriteLine("One {0} cut.", vegetable.GetType().Name);
        }

        private void Peel(Vegetable vegetable)
        {
            Console.WriteLine("One {0} peeled.", vegetable.GetType().Name);
        }

        private Bowl GetBowl()
        {
            Bowl bowl = new Bowl();
            Console.WriteLine("One big bowl.");

            return bowl;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();
            Console.WriteLine("One more potato.");

            return potato;
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();
            Console.WriteLine("One more carrot.");

            return carrot;
        }
    }
}
