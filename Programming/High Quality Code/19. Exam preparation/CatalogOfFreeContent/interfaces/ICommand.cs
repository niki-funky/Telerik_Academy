//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Linq;

    public interface ICommand
    {
        Commands Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        Commands ParseCommandType(string commandName);

        string ParseName();

        string[] ParseParameters();
    }
}
