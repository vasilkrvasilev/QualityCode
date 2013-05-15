using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace MatrixTest
{
    [TestClass]
    public class FillMatrixTest
    {
        [TestMethod]
        public void TestFillMatrix()
        {
            int[,] matrix = new int[3, 3];
            int currentValue = 1;
            Cell cell = new Cell(0, 0);
            Direction direction = PossibleDirections.GetInitialDirection();
            MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
            int[,] result = {
                            {1,7,8},
                            {6,2,9},
                            {5,4,3},
                            };
            Assert.AreEqual(result[0, 0], matrix[0, 0]);
            Assert.AreEqual(result[0, 1], matrix[0, 1]);
            Assert.AreEqual(result[0, 2], matrix[0, 2]);
            Assert.AreEqual(result[1, 0], matrix[1, 0]);
            Assert.AreEqual(result[1, 1], matrix[1, 1]);
            Assert.AreEqual(result[1, 2], matrix[1, 2]);
            Assert.AreEqual(result[2, 0], matrix[2, 0]);
            Assert.AreEqual(result[2, 1], matrix[2, 1]);
            Assert.AreEqual(result[2, 2], matrix[2, 2]);
        }

        [TestMethod]
        public void TestFillMatrixHalf()
        {
            int[,] matrix = new int[5, 5];
            int currentValue = 1;
            Cell cell = new Cell(0, 0);
            Direction direction = PossibleDirections.GetInitialDirection();
            MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
            int[,] result = {
                            {1,13,14,15,16},
                            {12,2,21,22,17},
                            {11,0,3,20,18},
                            {10,0,0,4,19},
                            {9,8,7,6,5}
                            };
            Assert.AreEqual(result[2, 3], matrix[2, 3]);
            Assert.AreEqual(result[0, 4], matrix[0, 4]);
            Assert.AreEqual(result[2, 1], matrix[2, 1]);
            Assert.AreEqual(result[3, 1], matrix[3, 1]);
            Assert.AreEqual(result[3, 2], matrix[3, 2]);
        }

        [TestMethod]
        public void TestFindMatrixSecondHalf()
        {
            int[,] matrix = {
                            {1,13,14,15,16},
                            {12,2,21,22,17},
                            {11,0,3,20,18},
                            {10,0,0,4,19},
                            {9,8,7,6,5}
                            };
            Cell cell = MatrixTraversal.FindEmptyCell(matrix);
            int currentValue = 23;
            Direction direction = PossibleDirections.GetInitialDirection();
            MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
            int[,] result = {
                            {1,13,14,15,16},
                            {12,2,21,21,17},
                            {11,23,3,20,18},
                            {10,25,24,4,19},
                            {9,8,7,6,5}
                            };
            Assert.AreEqual(result[2, 1], matrix[2, 1]);
            Assert.AreEqual(result[3, 1], matrix[3, 1]);
            Assert.AreEqual(result[3, 2], matrix[3, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFillNullMatrix()
        {
            int[,] matrix = null;
            int currentValue = 1;
            Cell cell = new Cell(0, 0);
            Direction direction = PossibleDirections.GetInitialDirection();
            MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFillMatrixNullCell()
        {
            int[,] matrix = new int[3, 3];
            int currentValue = 1;
            Cell cell = null;
            Direction direction = PossibleDirections.GetInitialDirection();
            MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFillMatrixNegativeValue()
        {
            int[,] matrix = new int[3, 3];
            int currentValue = -1;
            Cell cell = new Cell(0, 0);
            Direction direction = PossibleDirections.GetInitialDirection();
            MatrixTraversal.FillMatrix(matrix, currentValue, cell, direction);
        }
    }
}
