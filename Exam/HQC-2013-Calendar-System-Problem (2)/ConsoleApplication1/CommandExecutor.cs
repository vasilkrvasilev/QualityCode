using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Calendar
{
    public class CommandExecutor
    {
        private const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss";

        public CommandExecutor(IEventManager eventManager)
        {
            this.EventManager = eventManager;
        }

        public IEventManager EventManager { get; private set; }

        public string ProcessCommand(Command command)
        {
            string result = string.Empty;

            result = ProccessAddEventCommand(command, result);
            result = ProcessDeleteEventsCommand(command, result);
            result = ProcessListEventsCommand(command, result);

            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                throw new FormatException(
                        "Invalid input! The program cannot find entered command");
            }
        }

        private string ProcessListEventsCommand(Command command, string result)
        {
            if ((command.Name == "ListEvents") && (command.Parameters.Length == 2))
            {
                DateTime date = DateTime.ParseExact(
                    command.Parameters[0], DATE_FORMAT, CultureInfo.InvariantCulture);
                int numberEvents = int.Parse(command.Parameters[1]);
                List<CalendarEvent> listOfEvents =
                    this.EventManager.ListEvents(date, numberEvents).ToList();
                var sb = new StringBuilder();

                if (!listOfEvents.Any())
                {
                    result = "No events found";
                }
                else
                {
                    foreach (var item in listOfEvents)
                    {
                        sb.AppendLine(item.ToString());
                    }

                    result = sb.ToString().Trim();
                }
            }

            return result;
        }

        private string ProcessDeleteEventsCommand(Command command, string result)
        {
            if ((command.Name == "DeleteEvents") && (command.Parameters.Length == 1))
            {
                int deletedEvents =
                    this.EventManager.DeleteEventsByTitle(command.Parameters[0]);

                if (deletedEvents == 0)
                {
                    result = "No events found.";
                }
                else
                {
                    result = string.Format("{0} events deleted", deletedEvents);
                }
            }

            return result;
        }

        private string ProccessAddEventCommand(Command command, string result)
        {
            if ((command.Name == "AddEvent"))
            {
                if (command.Parameters.Length == 2)
                {
                    DateTime date = DateTime.ParseExact(
                        command.Parameters[0], DATE_FORMAT, CultureInfo.InvariantCulture);
                    CalendarEvent calendarEvent =
                        new CalendarEvent(date, command.Parameters[1], null);
                    this.EventManager.AddEvent(calendarEvent);
                    result = "Event added";
                }
                else if (command.Parameters.Length == 3)
                {
                    DateTime date = DateTime.ParseExact(
                        command.Parameters[0], DATE_FORMAT, CultureInfo.InvariantCulture);
                    CalendarEvent calendarEvent =
                        new CalendarEvent(date, command.Parameters[1], command.Parameters[2]);
                    this.EventManager.AddEvent(calendarEvent);
                    result = "Event added";
                }
            }

            return result;
        }
    }
}
