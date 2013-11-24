namespace Events
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Keeps log with Event's operations
    /// </summary>
    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        /// <summary>
        /// Gets all messages
        /// </summary>
        public static string Output
        {
            get
            {
                return output.ToString();
            }
        }

        /// <summary>
        /// Logs "Event added" message
        /// </summary>
        public static void EventAdded()
        {
            output.Append("Event added" + Environment.NewLine);
        }

        /// <summary>
        /// Logs "x events deleted" message
        /// </summary>
        /// <param name="x">Number of deleted events</param>
        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted" + Environment.NewLine, x);
            }
        }

        /// <summary>
        /// Logs "No events found" message
        /// </summary>
        public static void NoEventsFound()
        {
            output.Append("No events found" + Environment.NewLine);
        }

        /// <summary>
        /// Logs the event as message
        /// </summary>
        /// <param name="eventToPrint">Event to print</param>
        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + Environment.NewLine);
            }
        }
    }
}
