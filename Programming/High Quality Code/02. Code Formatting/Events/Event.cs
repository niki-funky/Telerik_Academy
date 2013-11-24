namespace Events
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class that specifies an event
    /// </summary>
    public class Event : IComparable
    {
        /// <summary>
        /// Gets or sets Time of the event
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Name of the event
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Location of the event
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event" /> class.
        /// </summary>
        /// <param name="date">Time of the event</param>
        /// <param name="title">Name of the event</param>
        /// <param name="location">Location of the event</param>
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        /// <summary>
        /// Overrides the <see cref="System.IComparable"/> method.
        /// </summary>
        /// <param name="obj">The object to be compared to this instance.</param>
        /// <returns>A value that shows if this instance is before or after the object</returns>
        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            if (other == null)
            {
                throw new ArgumentException("Object is not an Event!");
            }

            int byDate = this.Date.CompareTo(other.Date);
            int byTitle = this.Title.CompareTo(other.Title);
            int byLocation = this.Location.CompareTo(other.Location);

            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }
            else
            {
                return byDate;
            }
        }

        /// <summary>
        /// Formats Event output as:
        /// {Date and Time} | {Title} | {Location}
        /// </summary>
        /// <returns>Event output as string</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            stringBuilder.Append(" | " + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                stringBuilder.Append(" | " + this.Location);
            }

            return stringBuilder.ToString();
        }
    }
}