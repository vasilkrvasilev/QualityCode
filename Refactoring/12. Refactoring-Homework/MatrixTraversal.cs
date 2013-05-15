using System;
using System.Linq;

namespace Matrix
{
    /// <summary>
    /// Traverse a matrix and assign its cells
    /// </summary>
    public class MatrixTraversal
    {
        /// <summary>
        /// Search for unassigned cell
        /// </summary>
        /// <param name="matrix">Matrix, where the cell is searched</param>
        /// <exception cref="ArgumentNullException">
        /// If we try to search in matrix, which is not initialized</exception>
        /// <returns>The first unassigned cell or null if thre is no such</returns>
        public static Cell FindEmptyCell(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! You cannot search in empty matrix.");
            }

            Cell cell = new Cell(0, 0);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(0); column++)
                {
                    if (matrix[row, column] == 0)
                    {
                        cell.Row = row;
                        cell.Column = column;
                        return cell;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Assign cells in a matrix
        /// </summary>
        /// <param name="matrix">Matrix, which cells are going to be assigned</param>
        /// <param name="currentValue">Initial value to assign the first unassigned cell</param>
        /// <param name="cell">Initial cell from which start the assigning</param>
        /// <param name="direction">Initial direction to traverse the matrix</param>
        /// <exception cref="ArgumentNullException">
        /// If there is not initialized input parameter</exception>
        /// <exception cref="ArgumentException">
        /// If we try to assign a cell with non-positive value</exception>
        /// <returns>Value of last assigned cell</returns>
        public static int FillMatrix(int[,] matrix, int currentValue, Cell cell, Direction direction)
        {
            if (matrix == null || cell == null || direction == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! You cannot fill matrix using empty (null) parameter.");
            }

            if (currentValue < 1)
            {
                throw new ArgumentException(
                    "Invalid input! You cannot fill matrix with non-positive number.");
            }

            matrix[cell.Row, cell.Column] = currentValue;
            while (IsPath(matrix, cell))
            {
                direction = FindDirection(matrix, cell, direction);
                cell.Row += direction.X;
                cell.Column += direction.Y;
                currentValue++;
                matrix[cell.Row, cell.Column] = currentValue;
            }

            return currentValue;
        }

        /// <summary>
        /// Find if there is unassigned cell around current cell
        /// </summary>
        /// <param name="matrix">Matrix, where the cell is searched</param>
        /// <param name="cell">Cell around which is searching</param>
        /// <returns>Is or is not such cell</returns>
        private static bool IsPath(int[,] matrix, Cell cell)
        {
            var isPath = false;
            Direction[] possibleDirections = PossibleDirections.Generate();
            UpdatePossibleDirections(possibleDirections, matrix, cell);

            for (int count = 0; count < possibleDirections.Length; count++)
            {
                int changedRow = cell.Row + possibleDirections[count].X;
                int changedColumn = cell.Column + possibleDirections[count].Y;
                if (matrix[changedRow, changedColumn] == 0)
                {
                    isPath = true;
                }
            }

            return isPath;
        }

        /// <summary>
        /// Change all directions which are leading outside the matrix
        /// </summary>
        /// <param name="possibleDirections">Current possible directions</param>
        /// <param name="matrix">Matrix to be traversed</param>
        /// <param name="cell">Cell from which is searching direction</param>
        private static void UpdatePossibleDirections(Direction[] possibleDirections, int[,] matrix, Cell cell)
        {
            for (int count = 0; count < possibleDirections.Length; count++)
            {
                int changedRow = cell.Row + possibleDirections[count].X;
                if (changedRow >= matrix.GetLength(0) || changedRow < 0)
                {
                    possibleDirections[count].X = 0;
                }

                int changedColumn = cell.Column + possibleDirections[count].Y;
                if (changedColumn >= matrix.GetLength(0) || changedColumn < 0)
                {
                    possibleDirections[count].Y = 0;
                }
            }
        }

        /// <summary>
        /// Find next possible direction to continue the traversal of a matrix
        /// </summary>
        /// <param name="matrix">Matrix to be traversed</param>
        /// <param name="cell">Cell from which is searching direction</param>
        /// <param name="direction">Current direction which could be changed</param>
        /// <returns>Next direction to traverse the matrix</returns>
        private static Direction FindDirection(int[,] matrix, Cell cell, Direction direction)
        {
            int size = matrix.GetLength(0);
            bool isOuterRow = cell.Row + direction.X >= size || cell.Row + direction.X < 0;
            bool isOuterColumn = cell.Column + direction.Y >= size || cell.Column + direction.Y < 0;
            while (isOuterRow || isOuterColumn || 
                matrix[cell.Row + direction.X, cell.Column + direction.Y] != 0)
            {
                direction = PossibleDirections.GetNextPossibleDirection(direction);
                isOuterRow = cell.Row + direction.X >= size || cell.Row + direction.X < 0;
                isOuterColumn = cell.Column + direction.Y >= size || cell.Column + direction.Y < 0;
            }

            return direction;
        }
    }
}