using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public class EventManagerWithList : IEventManager
    {
        private readonly List<CalendarEvent> list = new List<CalendarEvent>();

        /// <summary>
        /// Add event to calendar by title and date
        /// </summary>
        /// <param name="calendarEvent">Event to add</param>
        /// <remarks>Can be added events 
        /// with duplicating title or date (or location)</remarks>
        public void AddEvent(CalendarEvent calendarEvent)
        {
            this.list.Add(calendarEvent);
        }

        /// <summary>
        /// Find and delete from the calendar all events with given title
        /// </summary>
        /// <param name="title">Title of the event</param>
        /// <returns>Number of deleted from the calendar events</returns>
        public int DeleteEventsByTitle(string title)
        {
            return this.list.RemoveAll(
                e => e.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        /// <summary>
        /// List events from the calendar after given date
        /// </summary>
        /// <param name="date">Date, after which start
        /// the search for events in the calendar</param>
        /// <param name="numberEvents">Number of events, 
        /// we want to list from the calendar</param>
        /// <remarks>If there are available more than asked number of events
        /// in the calender, will be printed as we asked.
        /// Otherwise if there are not enough event in the calendar,
        /// will be printed all found events.
        /// Events are ordered by date, title and location</remarks>
        /// <returns>List of found events</returns>
        public IEnumerable<CalendarEvent> ListEvents(DateTime date, int numberEvents)
        {
            return (from item in this.list
                    where item.Date >= date
                    orderby item.Date, item.Title, item.Location
                    select item).Take(numberEvents);
        }
    }
}
