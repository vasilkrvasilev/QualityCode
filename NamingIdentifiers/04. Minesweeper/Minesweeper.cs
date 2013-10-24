using System;
using System.Collections.Generic;

// Rename the class as Minesweeper
// Extract constanstants from the code
// Leave only Main() method in the class
// Extract ReadCommand() and UpdateResults() methods to reduce size of Main() method
// Remane the variables

namespace Minesweeper
{
    public class Minesweeper
    {
        // Initialize the constansts which define the interface appearance
        public const string INITIAL_ROW = "    0 1 2 3 4 5 6 7 8 9";
        public const string GAMEFIELD_BORDER = "   ---------------------";
        public const char BORDER_SYMBOL = '|';
        public const char CELL_SYMBOL = '?';
        public const char BOMB_SYMBOL = '*';
        public const char NOT_BOMB_SYMBOL = '-';
        public const int GAMEFIELD_ROWS = 5;
        public const int GAMEFIELD_COLUMNS = 10;
        public const int BOMBS_NUMBER = 15;
        public const int NOT_BOMBS_NUMBER = 35;
        public const int CHAMPIONS_LIST_SIZE = 6;

        static void Main()
        {
            // Initialize the variables which rule the game
            string command = string.Empty;
            char[,] gamefield = MinesweeperEngine.CreateGamefield();
            char[,] bombs = MinesweeperEngine.GenerateBombs();
            List<Player> champions = new List<Player>(CHAMPIONS_LIST_SIZE);
            int row = 0;
            int column = 0;
            int moveCounter = 0;
            bool isBomb = false;
            bool isNewGame = true;
            bool isEndGame = false;

            // Run the game
            do
            {
                if (isNewGame)
                {
                    Console.WriteLine(
                        "Lets play Minesweeper. Try your luck. Find fields without bombs." +
                        "To show the results enter - \"top\", to start new game enter - \"restart\"," +
                        "to make move enter row and column separated by space, to exit enter - \"exit\"");
                    MinesweeperEngine.PrintGamefield(gamefield);
                    isNewGame = false;
                }

                command = ReadCommand(command, gamefield, ref row, ref column);

                switch (command)
                {
                    case "top":
                        MinesweeperEngine.PrintResults(champions);
                        break;
                    case "restart":
                        gamefield = MinesweeperEngine.CreateGamefield();
                        bombs = MinesweeperEngine.GenerateBombs();
                        MinesweeperEngine.PrintGamefield(gamefield);
                        isBomb = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye, Bye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != BOMB_SYMBOL)
                        {
                            MinesweeperEngine.Move(gamefield, bombs, row, column);
                            moveCounter++;
                            if (NOT_BOMBS_NUMBER == moveCounter)
                            {
                                isEndGame = true;
                            }
                            else
                            {
                                MinesweeperEngine.PrintGamefield(gamefield);
                            }
                        }
                        else
                        {
                            isBomb = true;
                        }
                        break;
                    default:
                        Console.WriteLine(Environment.NewLine +
                            "Invalid input! You should enter valid command - top, restart, valid row and column or exit" +
                            Environment.NewLine);
                        break;
                }

                // End current game and start new one if there is a bomb
                if (isBomb)
                {
                    MinesweeperEngine.PrintGamefield(bombs);
                    Console.Write(Environment.NewLine +
                        "Game over! Your scores are {0}. Enter username: ", moveCounter);
                    string name = Console.ReadLine();
                    Player player = new Player(name, moveCounter);
                    champions = UpdateResults(champions, player);
                    MinesweeperEngine.PrintResults(champions);
                    gamefield = MinesweeperEngine.CreateGamefield();
                    bombs = MinesweeperEngine.GenerateBombs();
                    moveCounter = 0;
                    isBomb = false;
                    isNewGame = true;
                }

                // End current game and start new one if all bomb are descovered
                if (isEndGame)
                {
                    Console.WriteLine(Environment.NewLine + "Congratulations! You win this game.");
                    MinesweeperEngine.PrintGamefield(bombs);
                    Console.WriteLine("Enter username: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, moveCounter);
                    champions.Add(player);
                    MinesweeperEngine.PrintResults(champions);
                    gamefield = MinesweeperEngine.CreateGamefield();
                    bombs = MinesweeperEngine.GenerateBombs();
                    moveCounter = 0;
                    isEndGame = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria");
            Console.WriteLine("Press any key to exit the program.");
            Console.Read();
        }

        private static string ReadCommand(string command, char[,] gamefield, ref int row, ref int column)
        {
            Console.Write("Enter command: ");
            command = Console.ReadLine().Trim();
            string[] commandWords = command.Split(' ');
            if (commandWords.Length != 1)
            {
                bool rowIsNumber = int.TryParse(commandWords[0], out row);
                bool columnIsNumber = int.TryParse(commandWords[1], out column);
                bool isValidRow = rowIsNumber && (row >= 0) && (row <= gamefield.GetLength(0));
                bool isValidColumn = columnIsNumber && (column >= 0) && (column <= gamefield.GetLength(1));
                if (isValidRow && isValidColumn)
                {
                    command = "turn";
                }
            }
            return command;
        }

        public static List<Player> UpdateResults(List<Player> champions, Player player)
        {
            if (champions.Count < CHAMPIONS_LIST_SIZE - 1)
            {
                champions.Add(player);
            }
            else
            {
                for (int position = 0; position < champions.Count; position++)
                {
                    if (champions[position].Scores < player.Scores)
                    {
                        champions.Insert(position, player);
                        champions.RemoveAt(champions.Count - 1);
                        break;
                    }
                }
            }

            champions.Sort((Player first, Player second) => second.Name.CompareTo(first.Name));
            champions.Sort((Player first, Player second) => second.Scores.CompareTo(first.Scores));
            return champions;
        }
    }
}