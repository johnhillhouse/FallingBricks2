using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FallingBricks2.UnitTests
{
    [TestClass]
    public class SquareFixture
    {
        [TestMethod]
        public void TestMoveDown()
        {
            var square = new Square(new Point (2,3));
            square.MoveDown();

            Assert.AreEqual(4, square.Tiles[0].Position.Y);
            Assert.AreEqual(4, square.Tiles[1].Position.Y);
            Assert.AreEqual(5, square.Tiles[2].Position.Y);
            Assert.AreEqual(5, square.Tiles[3].Position.Y);
        }

        [TestMethod]
        public void TestMoveRight()
        {
            var square = new Square(new Point(2, 3));
            square.MoveRight();

            Assert.AreEqual(3, square.Tiles[0].Position.X);
            Assert.AreEqual(4, square.Tiles[1].Position.X);
            Assert.AreEqual(3, square.Tiles[2].Position.X);
            Assert.AreEqual(4, square.Tiles[3].Position.X);
        }

        [TestMethod]
        public void TestMoveLeft()
        {
            var square = new Square(new Point(2, 3));
            square.MoveLeft();

            Assert.AreEqual(1, square.Tiles[0].Position.X);
            Assert.AreEqual(2, square.Tiles[1].Position.X);
            Assert.AreEqual(1, square.Tiles[2].Position.X);
            Assert.AreEqual(2, square.Tiles[3].Position.X);
        }
    }
}
