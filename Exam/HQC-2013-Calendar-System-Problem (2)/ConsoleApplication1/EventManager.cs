using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Calendar
{
    public class EventManager : IEventManager
    {
        private readonly MultiDictionary<string, CalendarEvent> calendarByTitle = 
            new MultiDictionary<string, CalendarEvent>(true);
        private readonly OrderedMultiDictionary<DateTime, CalendarEvent> calendarByDate = 
            new OrderedMultiDictionary<DateTime, CalendarEvent>(true);

        /// <summary>
        /// Events in the calendar ordered by title
        /// </summary>
        /// <remarks>Read-only property used for testing</remarks>
        public MultiDictionary<string, CalendarEvent> CalendarByTitle 
        {
            get { return this.calendarByTitle; }
        }

        /// <summary>
        /// Events in the calendar ordered by date
        /// </summary>
        /// <remarks>Read-only property used for testing</remarks>
        public OrderedMultiDictionary<DateTime, CalendarEvent> CalendarByDate
        {
            get { return this.calendarByDate; }
        }

        /// <summary>
        /// Add event to calendar by title and date
        /// </summary>
        /// <param name="calendarEvent">Event to add</param>
        /// <remarks>Can be added events 
        /// with duplicating title or date (or location)</remarks>
        public void AddEvent(CalendarEvent calendarEvent)
        {
            string titleToLower = calendarEvent.Title.ToLowerInvariant();
            this.calendarByTitle.Add(titleToLower, calendarEvent);
            this.calendarByDate.Add(calendarEvent.Date, calendarEvent);
        }

        /// <summary>
        /// Find and delete from the calendar all events with given title
        /// </summary>
        /// <param name="title">Title of the event</param>
        /// <returns>Number of deleted from the calendar events</returns>
        public int DeleteEventsByTitle(string title)
        {
            string titleToLower = title.ToLowerInvariant();
            var eventsToDelete = this.calendarByTitle[titleToLower];
            int numberEventsToDelete = eventsToDelete.Count;

            foreach (var item in eventsToDelete)
            {
                this.calendarByDate.Remove(item.Date, item);
            }

            this.calendarByTitle.Remove(titleToLower);

            return numberEventsToDelete;
        }
        
        // First bottleneck
        // Is in the IEventManager.ListEvents() method. 
        // The method may produce too large amount of output and this is slow. 
        // It could also lead to OutOfMemoryException (memory bottleneck).
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
            var listOfEvents =
                from item in this.calendarByDate.RangeFrom(date, true).Values
                where item.Date >= date
                orderby item.Date, item.Title, item.Location
                select item;
            var eventsToList = listOfEvents.Take(numberEvents);
            return eventsToList;
        }
    }
}