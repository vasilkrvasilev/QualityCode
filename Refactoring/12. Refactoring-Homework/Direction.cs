using System;
using System.Linq;

namespace Matrix
{
    /// <summary>
    /// Represent the direction of traversal
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// Create direction to move
        /// </summary>
        /// <param name="x">Move on x (rows)</param>
        /// <param name="y">Move on y (columns)</param>
        public Direction(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Represent direction of traversal on x (row)
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Represent direction of traversal on y (column)
        /// </summary>
        public int Y { get; set; }
    }
}