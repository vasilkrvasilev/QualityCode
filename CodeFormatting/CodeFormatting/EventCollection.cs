using System;
using System.Text;
using Wintellect.PowerCollections;

// Rename the class from Program to EventCollection
// Extract the commandSeparator as a static field
// Group it with static field events
// Use string.Empty instead of ""
// Create a boolean variable to hold the thesult of the method ExecuteNextCommand()
// Split the command by commandSeparator
// Use if-else-if statements to find the commandType and execute it (could be used also switch)
// Add commandType to the parameters of ListEvents(), DeleteEvent(), AddEvent()
// Rename them to ParseEventToDelete(), ParseEventToAdd(), ParseEventsToList()

public class EventCollection
{
    private static EventHolder events = new EventHolder();
    private static char commandSeparator = ' ';

    public static void Main()
    {
        bool continueLoop = true;
        while (continueLoop)
        {
            continueLoop = ExecuteNextCommand();
        }

        Console.WriteLine(events.Output);
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();
        string[] commandData = command.Split(commandSeparator);
        string commandType = commandData[0];
        if (commandType == "AddEvent")
        {
            ParseEventToAdd(command, commandType);
            return true;
        }
        else if (commandType == "DeleteEvents")
        {
            ParseEventToDelete(command, commandType);
            return true;
        }
        else if (commandType == "ListEvents")
        {
            ParseEventsToList(command, commandType);
            return true;
        }
        else if (commandType == "End")
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    private static void ParseEventsToList(string command, string commandType)
    {
        int pipeIndex = command.IndexOf(Event.SEPARATOR);
        DateTime date = GetDate(command, commandType);
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);
        events.ListEvents(date, count);
    }

    private static void ParseEventToDelete(string command, string commandType)
    {
        string title = command.Substring(commandType.Length + 1);
        events.DeleteEvents(title);
    }

    private static void ParseEventToAdd(string command, string commandType)
    {
        DateTime date;
        string title;
        string location;
        GetParameters(command, commandType, out date, out title, out location);
        events.AddEvent(date, title, location);
    }

    private static void GetParameters(string commandForExecution, string commandType,
        out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);
        int firstPipeIndex = commandForExecution.IndexOf(Event.SEPARATOR);
        int lastPipeIndex = commandForExecution.LastIndexOf(Event.SEPARATOR);
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

    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, Event.DATE_FORMAT.Length));
        return date;
    }
}