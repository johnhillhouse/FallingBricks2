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
    }
}
