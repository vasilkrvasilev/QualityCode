using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace MatrixTest
{
    [TestClass]
    public class FindEmptyCellTest
    {
        [TestMethod]
        public void TestFindEmptyCellEmptyMatrix()
        {
            int[,] matrix = new int[5,5];
            Cell cell = MatrixTraversal.FindEmptyCell(matrix);
            Assert.AreEqual(0, cell.Row);
            Assert.AreEqual(0, cell.Column);
        }

        [TestMethod]
        public void TestFindEmptyCellFullMatrix()
        {
            int[,] matrix = new int[2, 2];
            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[1, 0] = 1;
            matrix[1, 1] = 1;
            Cell cell = MatrixTraversal.FindEmptyCell(matrix);
            Assert.AreEqual(null, cell);
        }

        [TestMethod]
        public void TestFindEmptyCell()
        {
            int[,] matrix = new int[2, 2];
            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            Cell cell = MatrixTraversal.FindEmptyCell(matrix);
            Assert.AreEqual(1, cell.Row);
            Assert.AreEqual(0, cell.Column);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindEmptyCellNullMatrix()
        {
            int[,] matrix = null;
            MatrixTraversal.FindEmptyCell(matrix);
        }
    }
}
