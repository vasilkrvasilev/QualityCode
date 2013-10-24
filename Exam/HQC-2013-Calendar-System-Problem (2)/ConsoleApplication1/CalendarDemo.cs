using System;
using System.Linq;

namespace Calendar
{
    public class CalendarDemo
    {
        public static void Main()
        {
            // Second bottleneck
            // In the original code is used EM (EventManagerWithList)
            // It uses List<CalendarEvent> instead of 
            // MultiDictionary<string, CalendarEvent> and
            // OrderedMultiDictionary<DateTime, CalendarEvent>, which are faster
            // Solution: use EventManager (EventManagerFast) instead of EM
            EventManager eventManager = new EventManager();
            var commandExecutor = new CommandExecutor(eventManager);

            while (true)
            {
                string commandText = Console.ReadLine();
                if (commandText == "End" || commandText == null)
                {
                    break;
                }

                try
                {
                    Command command = Command.Parse(commandText);
                    string result = commandExecutor.ProcessCommand(command);
                    Console.WriteLine(result);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
