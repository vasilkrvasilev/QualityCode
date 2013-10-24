using System;
using System.Collections.Generic;

// Create static class MinesweeperEngine and extract static methods from class Minesweeper in it
// Rename the methods and variables
// Extract GenerateRandomNumbers() and AddBombs() methods to reduce size of GenerateBombs() method
// Extract CheckForBomb() methods to reduce size of CountBombs() method
// Delete smetki() method because it is never used

namespace Minesweeper
{
    public static class MinesweeperEngine
    {
        public static void PrintResults(List<Player> champions)
        {
            Console.WriteLine(Environment.NewLine + "Results:");
            if (champions.Count > 0)
            {
                for (int position = 0; position < champions.Count; position++)
                {
                    Console.WriteLine("{0}. {1} --> {2} scores",
                        position + 1, champions[position].Name, champions[position].Scores);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There are no saved results!" + Environment.NewLine);
            }
        }

        public static void Move(char[,] gamefield, char[,] bombs, int row, int column)
        {
            int bombsAround = CountBombsAround(bombs, row, column);
            bombs[row, column] = char.Parse(bombsAround.ToString());
            gamefield[row, column] = char.Parse(bombsAround.ToString());
        }

        public static void PrintGamefield(char[,] gamefield)
        {
            int rows = gamefield.GetLength(0);
            int columns = gamefield.GetLength(1);
            Console.WriteLine(Environment.NewLine + Minesweeper.INITIAL_ROW);
            Console.WriteLine(Minesweeper.GAMEFIELD_BORDER);
            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                Console.Write("{0} {1} ", currentRow, Minesweeper.BORDER_SYMBOL);
                for (int currentColumn = 0; currentColumn < columns; currentColumn++)
                {
                    Console.Write(string.Format("{0} ", gamefield[currentRow, currentColumn]));
                }

                Console.WriteLine(Minesweeper.BORDER_SYMBOL);
            }

            Console.WriteLine(Minesweeper.GAMEFIELD_BORDER + Environment.NewLine);
        }

        public static char[,] CreateGamefield()
        {
            char[,] gamefield = new char[Minesweeper.GAMEFIELD_ROWS, Minesweeper.GAMEFIELD_COLUMNS];
            for (int currentRow = 0; currentRow < Minesweeper.GAMEFIELD_ROWS; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < Minesweeper.GAMEFIELD_COLUMNS; currentColumn++)
                {
                    gamefield[currentRow, currentColumn] = Minesweeper.CELL_SYMBOL;
                }
            }

            return gamefield;
        }

        public static char[,] GenerateBombs()
        {
            char[,] bombs = new char[Minesweeper.GAMEFIELD_ROWS, Minesweeper.GAMEFIELD_COLUMNS];
            for (int currentRow = 0; currentRow < Minesweeper.GAMEFIELD_ROWS; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < Minesweeper.GAMEFIELD_COLUMNS; currentColumn++)
                {
                    bombs[currentRow, currentColumn] = Minesweeper.NOT_BOMB_SYMBOL;
                }
            }

            List<int> randomNumbers = GenerateRandomNumbers();
            bombs = AddBombs(bombs, randomNumbers);
            return bombs;
        }

        private static List<int> GenerateRandomNumbers()
        {
            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < Minesweeper.BOMBS_NUMBER)
            {
                Random randomGenerator = new Random();
                int random = randomGenerator.Next(Minesweeper.BOMBS_NUMBER + Minesweeper.NOT_BOMBS_NUMBER);
                if (!randomNumbers.Contains(random))
                {
                    randomNumbers.Add(random);
                }
            }

            return randomNumbers;
        }

        private static char[,] AddBombs(char[,] bombs, List<int> randomNumbers)
        {
            foreach (int element in randomNumbers)
            {
                int row = (element / Minesweeper.GAMEFIELD_COLUMNS);
                int column = (element % Minesweeper.GAMEFIELD_COLUMNS);
                if (column == 0 && element != 0)
                {
                    row--;
                    column = Minesweeper.GAMEFIELD_COLUMNS;
                }
                else
                {
                    column++;
                }

                bombs[row, column - 1] = Minesweeper.BOMB_SYMBOL;
            }

            return bombs;
        }

        private static int CountBombsAround(char[,] bombs, int row, int column)
        {
            int numberBombs = 0;
            int rows = bombs.GetLength(0);
            int columns = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                numberBombs = CheckForBomb(bombs, row - 1, column, numberBombs);
            }
            if (row + 1 < rows)
            {
                numberBombs = CheckForBomb(bombs, row + 1, column, numberBombs);
            }
            if (column - 1 >= 0)
            {
                numberBombs = CheckForBomb(bombs, row, column - 1, numberBombs);
            }
            if (column + 1 < columns)
            {
                numberBombs = CheckForBomb(bombs, row, column + 1, numberBombs);
            }
            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                numberBombs = CheckForBomb(bombs, row - 1, column - 1, numberBombs);
            }
            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                numberBombs = CheckForBomb(bombs, row - 1, column + 1, numberBombs);
            }
            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                numberBombs = CheckForBomb(bombs, row + 1, column - 1, numberBombs);
            }
            if ((row + 1 < rows) && (column + 1 < columns))
            {
                numberBombs = CheckForBomb(bombs, row + 1, column + 1, numberBombs);
            }

            return numberBombs;
        }

        private static int CheckForBomb(char[,] bombs, int row, int column, int numberBombs)
        {
            if (bombs[row, column] == Minesweeper.BOMB_SYMBOL)
            {
                numberBombs++;
            }

            return numberBombs;
        }
    }
}