using System;
using log4net;
using log4net.Config;

// Format the code
// Rename the variables nad methods
// Remove useless code
// Fix bugs (the matrix is printed twice, if the size is less than 5 the matrix is filled incorrect)
// Create classes Cell with fields and properties row and column,
// Class Direction with fields and properties x and y,
// PossibleDirections which holds all possible directions, with methods Generate(),
// GetInitialDirection() and GetNextPossibleDirection()
// Class MatrixTraversal with public methods FindEmptyCell() and FillMatrix() and private
// IsPath(), UpdatePossibleDirections() and FindDirection()
// Class ConsoleIO with methods ReadInput() and PrintMatrix()
// Check input parameters of public methods
// Create test classes CellTest, DirectionTest, FillMatrixTest, FindEmptyCellTest and PrintMatrixTest
// Create 23 test methods
// Add Log4Net messages and T4Template to create file T4Matrix.cs
// Add xml documentation and CHM book made with Sandcastle
namespace Matrix
{
    /// <summary>
    /// Traverse a matrix
    /// </summary>
    public class MatrixTraversalDemo 
    {
        private static readonly ILog exceptionError =
          LogManager.GetLogger("Exception");

        /// <summary>
        /// Traverse a matrix using console for input/output
        /// </summary>
        /// <remarks>Use Log4Net to show the exeption messages. 
        /// The method Log4Net.ShowExceptions is designed to cause 
        /// ArgumentNullException for demonstration</remarks>
        public static void Main()
        {
            BasicConfigurator.Configure();
            try
            {
                int size = ConsoleIO.ReadInput();
                int[,] matrix = new int[size, size];
                int currentValue = 1;
                Cell cell = new Cell(0, 0);
                Direction direction = PossibleDirections.GetInitialDirection();
                currentValue = MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
                cell = MatrixTraversal.FindEmptyCell(matrix);
                if (currentValue < size * size)
                {
                    currentValue++;
                    direction = PossibleDirections.GetInitialDirection();
                    MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
                }

                ConsoleIO.PrintMatrix(matrix);
            }
            catch (ArgumentNullException ane)
            {
                exceptionError.Error(ane.Message, ane);
            }
            catch (ArgumentException ae)
            {
                exceptionError.Error(ae.Message, ae);
            }

            // Designed to couse ArgumentNullException for demonstration
            // This method throws the ERROR messages on the console 
            Log4Net.ShowExceptions();
        }
    }
}