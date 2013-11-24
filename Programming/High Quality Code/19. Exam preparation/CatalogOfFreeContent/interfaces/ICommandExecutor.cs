//-----------------------------------------------------------------------
// <copyright file="ICommandExecutor.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Linq;
    using System.Text;

    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}
