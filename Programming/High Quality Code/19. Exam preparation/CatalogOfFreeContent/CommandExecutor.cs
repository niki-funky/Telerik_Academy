//-----------------------------------------------------------------------
// <copyright file="CommandExecutor.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a command executor.
    /// </summary>
    internal class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder sb)
        {
            switch (command.Type)
            {
                case Commands.AddBook:
                    catalog.Add(new CatalogContent(ContentTypes.Book, command.Parameters));
                    sb.AppendLine("Book added");
                    break;
                case Commands.AddMovie:
                    catalog.Add(new CatalogContent(ContentTypes.Movie, command.Parameters));
                    sb.AppendLine("Movie added");
                    break;
                case Commands.AddSong:
                    catalog.Add(new CatalogContent(ContentTypes.Song, command.Parameters));
                    sb.AppendLine("Song added");
                    break;
                case Commands.AddApplication:
                    catalog.Add(new CatalogContent(ContentTypes.Application, command.Parameters));
                    sb.AppendLine("Application added");
                    break;
                case Commands.Update:
                    UpdateCommand(catalog, command, sb);
                    break;
                case Commands.Find:
                    FindCommand(command, catalog, sb);
                    break;
                default:
                    throw new InvalidOperationException("Unknown command!");
            }
        }

        private static void UpdateCommand(ICatalog catalog, ICommand command, StringBuilder sb)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int updatedItems = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            sb.AppendLine(string.Format("{0} items updated", updatedItems));
        }

        private void FindCommand(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);
            IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                sb.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    sb.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}
