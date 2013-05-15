using System;
using Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixTest
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void TestValidCell()
        {
            Cell cell = new Cell(3, 3);
            Assert.AreEqual(3, cell.Row);
            Assert.AreEqual(3, cell.Column);
        }

        [TestMethod]
        public void TestCellZero()
        {
            Cell cell = new Cell(0, 0);
            Assert.AreEqual(0, cell.Row);
            Assert.AreEqual(0, cell.Column);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCellNegativeRow()
        {
            Cell cell = new Cell(-3, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCellNegativeColumn()
        {
            Cell cell = new Cell(3, -1);
        }
    }
}
