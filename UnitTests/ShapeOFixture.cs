using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FallingBricks2.UnitTests
{
    [TestClass]
    public class ShapeOFixture
    {
        [TestMethod]
        public void TestMoveDown()
        {
            var shape = new ShapeO(new Point (2,3));
            shape.MoveDown();

            Assert.AreEqual(4, shape.Tiles[0].Position.Y);
            Assert.AreEqual(4, shape.Tiles[1].Position.Y);
            Assert.AreEqual(5, shape.Tiles[2].Position.Y);
            Assert.AreEqual(5, shape.Tiles[3].Position.Y);
        }

        [TestMethod]
        public void TestMoveRight()
        {
            var shape = new ShapeO(new Point(2, 3));
            shape.MoveRight();

            Assert.AreEqual(3, shape.Tiles[0].Position.X);
            Assert.AreEqual(4, shape.Tiles[1].Position.X);
            Assert.AreEqual(3, shape.Tiles[2].Position.X);
            Assert.AreEqual(4, shape.Tiles[3].Position.X);
        }

        [TestMethod]
        public void TestMoveLeft()
        {
            var shape = new ShapeO(new Point(2, 3));
            shape.MoveLeft();

            Assert.AreEqual(1, shape.Tiles[0].Position.X);
            Assert.AreEqual(2, shape.Tiles[1].Position.X);
            Assert.AreEqual(1, shape.Tiles[2].Position.X);
            Assert.AreEqual(2, shape.Tiles[3].Position.X);
        }
    }
}
