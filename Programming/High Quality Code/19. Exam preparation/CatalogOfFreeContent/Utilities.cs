//-----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents additional utilities.
    /// </summary>
    public class Utilities
    {
        public static List<ICommand> ListOfCommands()
        {
            List<ICommand> listOfCommands = new List<ICommand>();
            string commandEnd = "End";
            bool isCommandEnd = false;

            do
            {
                string input = Console.ReadLine();
                isCommandEnd = (input.Trim() == commandEnd);
                if (!isCommandEnd)
                {
                    listOfCommands.Add(new Command(input));
                }
            }
            while (!isCommandEnd);

            return listOfCommands;
        }
    }
}
