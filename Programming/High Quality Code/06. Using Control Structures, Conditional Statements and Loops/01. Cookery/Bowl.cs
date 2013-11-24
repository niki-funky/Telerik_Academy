//-----------------------------------------------------------------------
// <copyright file="Bowl.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Cookery
{
    using System;
    using System.Collections.Generic;

    public class Bowl
    {
        private List<Vegetable> listOfVegetables = new List<Vegetable>();

        public void Add(Vegetable vegetable)
        {
            this.listOfVegetables.Add(vegetable);
            Console.WriteLine("One {0} put in the bowl.", vegetable.GetType().Name);
        }
    }
}
