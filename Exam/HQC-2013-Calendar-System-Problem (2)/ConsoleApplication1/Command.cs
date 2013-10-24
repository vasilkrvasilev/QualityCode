using System;
using System.Linq;

namespace Calendar
{
    public class Command
    {
        public string Name { get; private set; }
        public string[] Parameters { get; private set; }

        public static Command Parse(string commandText)
        {
            int endOfCommandInex = commandText.IndexOf(' ');
            if (endOfCommandInex == -1)
            {
                throw new FormatException(string.Format(
                    "Invalid input! The program cannot find entered command: {0}", 
                    commandText));
            }

            string name = commandText.Substring(0, endOfCommandInex);

            string parametersText = commandText.Substring(endOfCommandInex + 1);
            string[] commandParameters = parametersText.Split('|');
            string[] parameters = new string[commandParameters.Length];

            for (int count = 0; count < commandParameters.Length; count++)
            {
                parameters[count] = commandParameters[count].Trim();
            }

            return new Command { Name = name, Parameters = parameters };
        }
    }
}
