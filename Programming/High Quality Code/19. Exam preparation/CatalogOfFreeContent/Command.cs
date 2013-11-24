//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace CatalogOfFreeContent
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the commands to manipulate a catalog.
    /// </summary>
    internal class Command : ICommand
    {
        private const string AddBook = "Add book";
        private const string AddMovie = "Add movie";
        private const string AddSong = "Add song";
        private const string AddApplication = "Add application";
        private const string Update = "Update";
        private const string Find = "Find";

        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        public Commands Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public Commands ParseCommandType(string commandName)
        {
            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("Invalid command.Command can not contain ':' or ';'.");
            }

            switch (commandName.Trim())
            {
                case AddBook:
                    return Commands.AddBook;
                case AddMovie:
                    return Commands.AddMovie;
                case AddSong:
                    return Commands.AddSong;
                case AddApplication:
                    return Commands.AddApplication;
                case Update:
                    return Commands.Update;
                case Find:
                    return Commands.Find;
                default:
                    throw new ArgumentException("Invalid command name!");
            }
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.commandEnd) - 1;

            return endIndex;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Empty + this.Name + " ");

            foreach (string param in this.Parameters)
            {
                result.Append(param + " ");
            }

            return result.ToString();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();
            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();
            this.Type = this.ParseCommandType(this.Name);
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }
    }
}
