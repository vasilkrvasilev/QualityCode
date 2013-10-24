using System;
using System.Linq;

namespace Calendar
{
    public class CalendarEvent : IComparable<CalendarEvent>
    {
        private const string EVENT_FORMAT_WITHOUT_LOCATION = 
            "{0:yyyy-MM-ddTH:mm:ss} | {1}";
        private const string EVENT_FORMAT_WITH_LOCATION = 
            "{0:yyyy-MM-ddTH:mm:ss} | {1} | {2}";

        public CalendarEvent(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; private set; }
        public string Title { get; private set; }
        public string Location { get; private set; }

        public override string ToString()
        {
            string eventAsString = string.Empty;
            if (this.Location != null)
            {
                eventAsString = 
                    string.Format(EVENT_FORMAT_WITH_LOCATION, 
                    this.Date, this.Title, this.Location);
            }
            else
            {
                eventAsString = 
                    string.Format(EVENT_FORMAT_WITHOUT_LOCATION, 
                    this.Date, this.Title, this.Location);
            }

            return eventAsString;
        }

        public int CompareTo(CalendarEvent other)
        {
            int result = DateTime.Compare(this.Date, other.Date);

            if (result == 0)
            {
                result = 
                    string.Compare(this.Title, other.Title, StringComparison.Ordinal);
            }

            if (result == 0)
            {
                result = 
                    string.Compare(this.Location, other.Location, StringComparison.Ordinal);
            }

            return result;
        }
    }
}
