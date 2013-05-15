using System;
using System.Linq;

namespace Matrix
{
    /// <summary>
    /// Represent a cell from two dimentional matrix
    /// </summary>
    public class Cell
    {
        private int row;
        private int column;

        /// <summary>
        /// Create a cell
        /// </summary>
        /// <param name="row">Cell's row in the matrix</param>
        /// <param name="column">Cell's column in the matrix</param>
        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        /// <summary>
        /// Represent the cell's row in the matrix
        /// </summary>
        /// <exception cref="ArgumentException">
        /// If the value of the row is negative</exception>
        public int Row 
        {
            get 
            { 
                return this.row; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "Invalid input! Cannot create cell with negative row.");
                }

                this.row = value;
            }
        }

        /// <summary>
        /// Represent the cell's column in the matrix
        /// </summary>
        /// /// <exception cref="ArgumentException">
        /// If the value of the column is negative</exception>
        public int Column
        {
            get 
            { 
                return this.column; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "Invalid input! Cannot create cell with negative column.");
                }

                this.column = value;
            }
        }
    }
}