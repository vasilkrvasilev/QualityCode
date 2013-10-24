using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public interface IEventManager
    {
        void AddEvent(CalendarEvent calendarEvent);
        int DeleteEventsByTitle(string title);
        IEnumerable<CalendarEvent> ListEvents(DateTime date, int numberEvents);
    }
}
