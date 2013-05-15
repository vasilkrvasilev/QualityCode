using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace MatrixTest
{
    [TestClass]
    public class PrintMatrixTeat
    {
        [TestMethod]
        public void TestPrintEmptyMatrix()
        {
            int[,] matrix = new int[3, 3];
            string matrixString = ConsoleIO.PrintMatrix(matrix);
            StringBuilder result = new StringBuilder();
            result.AppendLine("  0  0  0");
            result.AppendLine("  0  0  0");
            result.AppendLine("  0  0  0");

            Assert.AreEqual(result.ToString(), matrixString);
        }

        [TestMethod]
        public void TestPrintFullMatrix()
        {
            int[,] matrix = new int[2, 2];
            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[1, 0] = 1;
            matrix[1, 1] = 1;
            string matrixString = ConsoleIO.PrintMatrix(matrix);
            StringBuilder result = new StringBuilder();
            result.AppendLine("  1  1");
            result.AppendLine("  1  1");

            Assert.AreEqual(result.ToString(), matrixString);
        }

        [TestMethod]
        public void TestFindEmptyCell()
        {
            int[,] matrix = new int[2, 2];
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            string matrixString = ConsoleIO.PrintMatrix(matrix);
            StringBuilder result = new StringBuilder();
            result.AppendLine("  1  0");
            result.AppendLine("  0  1");

            Assert.AreEqual(result.ToString(), matrixString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindEmptyCellNullMatrix()
        {
            int[,] matrix = null;
            ConsoleIO.PrintMatrix(matrix);
        }
    }
}
