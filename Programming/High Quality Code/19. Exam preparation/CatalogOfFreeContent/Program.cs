//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Text;

    /// <summary>
    /// Demo of the program.
    /// Contains Main method.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor ce = new CommandExecutor();

            foreach (ICommand command in Utilities.ListOfCommands())
            {
                ce.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }
    }
}