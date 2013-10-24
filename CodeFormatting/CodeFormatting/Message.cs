using System;
using System.Text;

// Extract the class in a separate file and rename it to Message - Message.cs
// Rename methods to AddMessageForAddedEvent(), AddMessageForDeletedEvent(), AddMessageForNoEventsFound(), AddMessageForEvent()
// Add input parameter StringBuilder output to all methods in the class
// Use Environment.NewLine instead of "\n"

public static class Message
{
    public static void AddMessageForAddedEvent(StringBuilder output)
    {
        output.Append("Event added" + Environment.NewLine);
    }

    public static void AddMessageForDeletedEvent(int number, StringBuilder output)
    {
        if (number == 0)
        {
            AddMessageForNoEventsFound(output);
        }
        else
        {
            output.AppendFormat("{0} events deleted{1}", number, Environment.NewLine);
        }
    }

    public static void AddMessageForNoEventsFound(StringBuilder output)
    {
        output.Append("No events found" + Environment.NewLine);
    }

    public static void AddMessageForEvent(Event eventToPrint, StringBuilder output)
    {
        if (eventToPrint != null)
        {
            output.Append(eventToPrint.ToString() + Environment.NewLine);
        }
    }
}