using System;
using System.Linq;

namespace Matrix
{
    /// <summary>
    /// Represent all possible directions to traverse
    /// </summary>
    public class PossibleDirections
    {
        private readonly Direction downRight = new Direction(1, 1);
        private readonly Direction down = new Direction(1, 0);
        private readonly Direction downLeft = new Direction(1, -1);
        private readonly Direction left = new Direction(0, -1);
        private readonly Direction upLeft = new Direction(-1, -1);
        private readonly Direction up = new Direction(-1, 0);
        private readonly Direction upRight = new Direction(-1, 1);
        private readonly Direction right = new Direction(0, 1);

        /// <summary>
        /// Generate all possible directions to traverse
        /// </summary>
        /// <returns>Array with all possible directions to traverse</returns>
        public static Direction[] Generate()
        {
            PossibleDirections current = new PossibleDirections();
            Direction[] possibleDirections = 
            { 
                current.downRight, current.down, current.downLeft, current.left, 
                current.upLeft, current.up, current.upRight, current.right 
            };
            return possibleDirections;
        }

        /// <summary>
        /// Generate initial (start) direction to traverse
        /// </summary>
        /// <returns>Initial (start) direction to traverse</returns>
        public static Direction GetInitialDirection()
        {
            PossibleDirections current = new PossibleDirections();
            Direction initialDirection = current.downRight;
            return initialDirection;
        }

        /// <summary>
        /// Generate next possible direction to traverse
        /// </summary>
        /// <param name="direction">Current direction to traverse</param>
        /// <returns>Next possible direction to traverse</returns>
        public static Direction GetNextPossibleDirection(Direction direction)
        {
            Direction[] possibleDirections = Generate();
            int index = 0;
            for (int count = 0; count < possibleDirections.Length; count++)
            {
                bool foundDirection =
                    possibleDirections[count].X == direction.X && 
                    possibleDirections[count].Y == direction.Y;
                if (foundDirection && count < possibleDirections.Length - 1)
                {
                    index = count + 1;
                    break;
                }
                else if (foundDirection && count == possibleDirections.Length - 1)
                {
                    index = 0;
                }
            }

            return possibleDirections[index];
        }
    }
}