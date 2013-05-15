using System;
using System.Linq;
using System.Text;

namespace Matrix
{
    /// <summary>
    /// Read the input and print the output on the console
    /// </summary>
    public class ConsoleIO
    {
        private const int MIN_SIZE = 1;
        private const int MAX_SIZE = 26;

        /// <summary>
        /// Read and verify the input from the console
        /// </summary>
        /// <remarks>Ask for a number till a valid one is entered</remarks>
        /// <returns>Number in the interval [MIN_SIZE, MAX_SIZE]</returns>
        public static int ReadInput()
        {
            Console.WriteLine(
                "Enter a positive number in the interval [{0}, {1}]", MIN_SIZE, MAX_SIZE);
            int size = 0;
            string input = Console.ReadLine();
            bool inputIsNumber = int.TryParse(input, out size);
            while (!inputIsNumber || size < MIN_SIZE || size > MAX_SIZE)
            {
                Console.WriteLine("You entered a incorrect number");
                input = Console.ReadLine();
                inputIsNumber = int.TryParse(input, out size);
            }

            return size;
        }

        /// <summary>
        /// Print on the console string representation of a matrix
        /// </summary>
        /// <param name="matrix">Matrix to be print</param>
        /// <exception cref="ArgumentNullException">
        /// If the matrix to be print is not initialized</exception>
        /// <returns>String representation of the matrix</returns>
        public static string PrintMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! You cannot print empty matrix.");
            }

            StringBuilder matrixString = new StringBuilder();
            int size = matrix.GetLength(0);
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    matrixString.Append(string.Format("{0,3}", matrix[row, column]));
                }

                matrixString.AppendLine();
            }

            Console.WriteLine(matrixString.ToString());
            return matrixString.ToString();
        }
    }
}