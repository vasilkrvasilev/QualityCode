using System;
using System.Text;
using Wintellect.PowerCollections;

// Extract the class in a separate file - EventHolder.cs
// Add reference to Wintellect.PowerCollections libriry - http://powercollections.codeplex.com/
// Or to PowerCollection.dll from the homework
// Add private access modificator and rename the fields to eventsByTitle and eventsByDate
// Add private field output of type StringBuilder with readonly public property
// Use this.field instead of field and string.Empty instead of ""

public class EventHolder
{
    private StringBuilder output;
    private MultiDictionary<string, Event> eventsByTitle;
    private OrderedBag<Event> eventsByDate;

    public EventHolder()
    {
        this.output = new StringBuilder();
        this.eventsByTitle = new MultiDictionary<string, Event>(true);
        this.eventsByDate = new OrderedBag<Event>();
    }

    public StringBuilder Output
    {
        get { return this.output; }
    }

    public void AddEvent(DateTime date, string title, string location)
    {
        Event newEvent = new Event(date, title, location);
        this.eventsByTitle.Add(title.ToLower(), newEvent);
        this.eventsByDate.Add(newEvent);
        Message.AddMessageForAddedEvent(this.output);
    }

    public void DeleteEvents(string titleToDelete)
    {
        string title = titleToDelete.ToLower();
        int removed = 0;
        foreach (var eventToRemove in this.eventsByTitle[title])
        {
            removed++;
            this.eventsByDate.Remove(eventToRemove);
        }

        this.eventsByTitle.Remove(title);
        Message.AddMessageForDeletedEvent(removed, this.output);
    }

    public void ListEvents(DateTime date, int count)
    {
        OrderedBag<Event>.View eventsToShow =
            this.eventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
        int shown = 0;
        foreach (var eventToShow in eventsToShow)
        {
            if (shown == count)
            {
                break;
            }

            Message.AddMessageForEvent(eventToShow, this.output);
            shown++;
        }

        if (shown == 0)
        {
            Message.AddMessageForNoEventsFound(this.output);
        }
    }
}