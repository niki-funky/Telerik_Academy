﻿namespace Events
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Container for <see cref="Event"/> objects.
    /// </summary>
    public class EventHolder
    {
        private readonly MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        private readonly OrderedBag<Event> byDate = new OrderedBag<Event>();

        /// <summary>
        /// Adds event to the EventHolder
        /// </summary>
        /// <param name="date">Time of the event</param>
        /// <param name="title">Name of the event</param>
        /// <param name="location">Location of the event</param>
        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(newEvent);
            Messages.EventAdded();
        }

        /// <summary>
        /// Deletes event from the EventHolder
        /// Operation is logged
        /// </summary>
        /// <param name="titleToDelete">Name of event to be deleted</param>
        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.byTitle[title])
            {
                removed++;
                this.byDate.Remove(eventToRemove);
            }

            this.byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        /// <summary>
        /// Add to the log all Events that have the specified date
        /// If no such Events then logs "No events found"
        /// </summary>
        /// <param name="date">Time of the events</param>
        /// <param name="count">The number of events to be added</param>
        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow =
                this.byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);

            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
