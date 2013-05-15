using System;
using Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixTest
{
    [TestClass]
    public class DirectionTest
    {
        [TestMethod]
        public void TestDirection()
        {
            Direction direction = new Direction(-3, 3);
            Assert.AreEqual(-3, direction.X);
            Assert.AreEqual(3, direction.Y);
        }

        [TestMethod]
        public void TestDirectionZero()
        {
            Direction direction = new Direction(0, 0);
            Assert.AreEqual(0, direction.X);
            Assert.AreEqual(0, direction.Y);
        }

        [TestMethod]
        public void TestPossibleDirectionGenerate()
        {
            Direction[] directions = PossibleDirections.Generate();
            Assert.AreEqual(1, directions[0].X);
            Assert.AreEqual(1, directions[0].Y);
            Assert.AreEqual(1, directions[1].X);
            Assert.AreEqual(0, directions[1].Y);
            Assert.AreEqual(1, directions[2].X);
            Assert.AreEqual(-1, directions[2].Y);
            Assert.AreEqual(0, directions[3].X);
            Assert.AreEqual(-1, directions[3].Y);
            Assert.AreEqual(-1, directions[4].X);
            Assert.AreEqual(-1, directions[4].Y);
            Assert.AreEqual(-1, directions[5].X);
            Assert.AreEqual(0, directions[5].Y);
            Assert.AreEqual(-1, directions[6].X);
            Assert.AreEqual(1, directions[6].Y);
            Assert.AreEqual(0, directions[7].X);
            Assert.AreEqual(1, directions[7].Y);
        }

        [TestMethod]
        public void TestPossibleDirectionGetNewDirection()
        {
            Direction current = new Direction(1, 1);
            Direction next = PossibleDirections.GetNextPossibleDirection(current);
            Assert.AreEqual(1, next.X);
            Assert.AreEqual(0, next.Y);
        }

        [TestMethod]
        public void TestPossibleDirectionGetNewDirectionLast()
        {
            Direction[] directions = PossibleDirections.Generate();
            Direction current = directions[7];
            Direction next = PossibleDirections.GetNextPossibleDirection(current);
            Assert.AreEqual(1, next.X);
            Assert.AreEqual(1, next.Y);
        }
    }
}
