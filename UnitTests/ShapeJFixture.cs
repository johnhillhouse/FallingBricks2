using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FallingBricks2.UnitTests
{
    [TestClass]
    public class ShapeJFixture
    {
        [TestMethod]
        public void TestMoveDown()
        {
            var shape = GetShape(2, 3);
            shape.MoveDown();

            Assert.AreEqual(4, shape.Tiles[0].Position.Y);
            Assert.AreEqual(4, shape.Tiles[1].Position.Y);
            Assert.AreEqual(4, shape.Tiles[2].Position.Y);
            Assert.AreEqual(3, shape.Tiles[3].Position.Y);
        }

        [TestMethod]
        public void TestMoveRight()
        {
            var shape = new ShapeJ(new Point(2, 3));
            shape.MoveRight();

            Assert.AreEqual(5, shape.Tiles[0].Position.X);
            Assert.AreEqual(4, shape.Tiles[1].Position.X);
            Assert.AreEqual(3, shape.Tiles[2].Position.X);
            Assert.AreEqual(3, shape.Tiles[3].Position.X);
        }

        [TestMethod]
        public void TestMoveLeft()
        {
            var shape = new ShapeJ(new Point(2, 3));
            shape.MoveLeft();

            Assert.AreEqual(3, shape.Tiles[0].Position.X);
            Assert.AreEqual(2, shape.Tiles[1].Position.X);
            Assert.AreEqual(1, shape.Tiles[2].Position.X);
            Assert.AreEqual(1, shape.Tiles[3].Position.X);
        }

        [TestMethod]
        public void TestRotateClockWise()
        {
            var shape = GetShape(2, 3);
            AssertFacingEast(shape);

            shape.RotateClockWise();
            AssertFacingSouth(shape);
            
            shape.RotateClockWise();
            AssertFacingWest(shape);

            shape.RotateClockWise();
            AssertFacingNorth(shape);

            shape.RotateClockWise();
            AssertFacingEast(shape);
        }

        private void AssertFacingNorth(Shape shape)
        {
            Assert.AreEqual(3, shape.Tiles[0].Position.X);
            Assert.AreEqual(2, shape.Tiles[0].Position.Y);

            Assert.AreEqual(3, shape.Tiles[1].Position.X);
            Assert.AreEqual(3, shape.Tiles[1].Position.Y);

            Assert.AreEqual(3, shape.Tiles[2].Position.X);
            Assert.AreEqual(4, shape.Tiles[2].Position.Y);

            Assert.AreEqual(2, shape.Tiles[3].Position.X);
            Assert.AreEqual(4, shape.Tiles[3].Position.Y);
        }

        private void AssertFacingEast(Shape shape)
        {
            Assert.AreEqual(4, shape.Tiles[0].Position.X);
            Assert.AreEqual(3, shape.Tiles[0].Position.Y);

            Assert.AreEqual(3, shape.Tiles[1].Position.X);
            Assert.AreEqual(3, shape.Tiles[1].Position.Y);

            Assert.AreEqual(2, shape.Tiles[2].Position.X);
            Assert.AreEqual(3, shape.Tiles[2].Position.Y);

            Assert.AreEqual(2, shape.Tiles[3].Position.X);
            Assert.AreEqual(2, shape.Tiles[3].Position.Y);
        }

        private void AssertFacingSouth(Shape shape)
        {
            Assert.AreEqual(3, shape.Tiles[0].Position.X);
            Assert.AreEqual(4, shape.Tiles[0].Position.Y);

            Assert.AreEqual(3, shape.Tiles[1].Position.X);
            Assert.AreEqual(3, shape.Tiles[1].Position.Y);

            Assert.AreEqual(3, shape.Tiles[2].Position.X);
            Assert.AreEqual(2, shape.Tiles[2].Position.Y);

            Assert.AreEqual(4, shape.Tiles[3].Position.X);
            Assert.AreEqual(2, shape.Tiles[3].Position.Y);
        }

        private void AssertFacingWest(Shape shape)
        {
            Assert.AreEqual(2, shape.Tiles[0].Position.X);
            Assert.AreEqual(3, shape.Tiles[0].Position.Y);

            Assert.AreEqual(3, shape.Tiles[1].Position.X);
            Assert.AreEqual(3, shape.Tiles[1].Position.Y);

            Assert.AreEqual(4, shape.Tiles[2].Position.X);
            Assert.AreEqual(3, shape.Tiles[2].Position.Y);

            Assert.AreEqual(4, shape.Tiles[3].Position.X);
            Assert.AreEqual(4, shape.Tiles[3].Position.Y);
        }

        private ShapeJ GetShape(int startingPointX, int startingPointY)
        {
            return new ShapeJ(new Point(startingPointX, startingPointY));
        }
    }
}
