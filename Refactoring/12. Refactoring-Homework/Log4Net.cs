using System;
using System.Linq;
using log4net;
using log4net.Config;

namespace Matrix
{
    /// <summary>
    /// Show exception messages using Log4Net
    /// </summary>
    public class Log4Net
    {
        private static readonly ILog exceptionError =
          LogManager.GetLogger("Exception");

        /// <summary>
        /// Show ArgumentNullException and ArgumentException messages using Log4Net.
        /// </summary>
        public static void ShowExceptions()
        {
            BasicConfigurator.Configure();
            try
            {
                int size = 3;
                int[,] matrix = new int[size, size];
                int currentValue = 1;
                Cell cell = new Cell(0, 0);
                Direction direction = PossibleDirections.GetInitialDirection();
                currentValue = MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
                cell = MatrixTraversal.FindEmptyCell(matrix);

                currentValue++;
                direction = PossibleDirections.GetInitialDirection();
                MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
            }
            catch (ArgumentNullException ane)
            {
                exceptionError.Error(
                    "This message is thrown by method Log4Net.ShowExceptions() \r\n" +
                    ane.Message);
            }
            catch (ArgumentException ae)
            {
                exceptionError.Error(
                    "This message is thrown by method Log4Net.ShowExceptions() \r\n" + 
                    ae.Message);
            }
        }
    }
}