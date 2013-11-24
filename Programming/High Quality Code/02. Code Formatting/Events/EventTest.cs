namespace Events
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class that executes the program 
    /// and tests its functionality
    /// </summary>
    public class EventTest
    {
        private static EventHolder events = new EventHolder();

        public static void Main(string[] args)
        {
            while (ExecuteNextCommand())
            {
                // user input
            }

            Console.WriteLine(Messages.Output);
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            switch (command[0])
            {
                case 'A':
                    {
                        AddEvent(command);
                        return true;
                    }
                case 'D':
                    {
                        DeleteEvents(command);
                        return true;
                    }
                case 'L':
                    {
                        ListEvents(command);
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);

            events.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);

            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            GetParameters(command, "AddEvent", out date, out title, out location);

            events.AddEvent(date, title, location);
        }

        /// <summary>
        /// Method which excerpts the Events' name and location from given command.
        /// </summary>
        /// <param name="commandForExecution">The command text</param>
        /// <param name="commandType">The command type</param>
        /// <param name="dateAndTime">Date and time</param>
        /// <param name="eventTitle">Name of event</param>
        /// <param name="eventLocation">Location of event</param>
        private static void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);

            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(
                    firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        /// <summary>
        /// Method which excerpts the date from given command.
        /// </summary>
        /// <param name="command">The command which contains the info.</param>
        /// <param name="commandType">The command type.</param>
        /// <returns>The date and time</returns>
        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

            return date;
        }
    }
}
