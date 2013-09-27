using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FallingBricks2.UnitTests
{
    [TestClass]
    public class LineFixture
    {
        [TestMethod]
        public void TestMoveDown()
        {
            var line = GetLine(2, 3);
            line.MoveDown();

            Assert.AreEqual(4, line.Tiles[0].Position.Y);
            Assert.AreEqual(4, line.Tiles[1].Position.Y);
            Assert.AreEqual(4, line.Tiles[2].Position.Y);
            Assert.AreEqual(4, line.Tiles[3].Position.Y);
        }

        [TestMethod]
        public void TestMoveRight()
        {
            var line = new Line(new Point(2, 3));
            line.MoveRight();

            Assert.AreEqual(3, line.Tiles[0].Position.X);
            Assert.AreEqual(4, line.Tiles[1].Position.X);
            Assert.AreEqual(5, line.Tiles[2].Position.X);
            Assert.AreEqual(6, line.Tiles[3].Position.X);
        }

        [TestMethod]
        public void TestMoveLeft()
        {
            var line = new Line(new Point(2, 3));
            line.MoveLeft();

            Assert.AreEqual(1, line.Tiles[0].Position.X);
            Assert.AreEqual(2, line.Tiles[1].Position.X);
            Assert.AreEqual(3, line.Tiles[2].Position.X);
            Assert.AreEqual(4, line.Tiles[3].Position.X);
        }

        [TestMethod]
        public void TestRotateClockWise()
        {
            var line = GetLine(2, 3);
            AssertFacingEast(line);

            line.RotateClockWise();
            AssertFacingSouth(line);
            
            line.RotateClockWise();
            AssertFacingWest(line);

            line.RotateClockWise();
            AssertFacingNorth(line);

            line.RotateClockWise();
            AssertFacingEast(line);
        }

        [TestMethod]
        public void TestRotateAntiClockWise()
        {
            var line = GetLine(2, 3);
            AssertFacingEast(line);

            line.RotateAntiClockWise();
            AssertFacingNorth(line);

            line.RotateAntiClockWise();
            AssertFacingWest(line);

            line.RotateAntiClockWise();
            AssertFacingSouth(line);

            line.RotateAntiClockWise();
            AssertFacingEast(line);
        }

        private void AssertFacingNorth(Line line)
        {
            Assert.AreEqual(3, line.Tiles[0].Position.X);
            Assert.AreEqual(4, line.Tiles[0].Position.Y);

            Assert.AreEqual(3, line.Tiles[1].Position.X);
            Assert.AreEqual(3, line.Tiles[1].Position.Y);

            Assert.AreEqual(3, line.Tiles[2].Position.X);
            Assert.AreEqual(2, line.Tiles[2].Position.Y);

            Assert.AreEqual(3, line.Tiles[3].Position.X);
            Assert.AreEqual(1, line.Tiles[3].Position.Y);
        }

        private void AssertFacingEast(Line line)
        {
            Assert.AreEqual(2, line.Tiles[0].Position.X);
            Assert.AreEqual(3, line.Tiles[0].Position.Y);

            Assert.AreEqual(3, line.Tiles[1].Position.X);
            Assert.AreEqual(3, line.Tiles[1].Position.Y);

            Assert.AreEqual(4, line.Tiles[2].Position.X);
            Assert.AreEqual(3, line.Tiles[2].Position.Y);

            Assert.AreEqual(5, line.Tiles[3].Position.X);
            Assert.AreEqual(3, line.Tiles[3].Position.Y);
        }

        private void AssertFacingSouth(Line line)
        {
            Assert.AreEqual(3, line.Tiles[0].Position.X);
            Assert.AreEqual(2, line.Tiles[0].Position.Y);

            Assert.AreEqual(3, line.Tiles[1].Position.X);
            Assert.AreEqual(3, line.Tiles[1].Position.Y);

            Assert.AreEqual(3, line.Tiles[2].Position.X);
            Assert.AreEqual(4, line.Tiles[2].Position.Y);

            Assert.AreEqual(3, line.Tiles[3].Position.X);
            Assert.AreEqual(5, line.Tiles[3].Position.Y);
        }

        private void AssertFacingWest(Line line)
        {
            Assert.AreEqual(4, line.Tiles[0].Position.X);
            Assert.AreEqual(3, line.Tiles[0].Position.Y);

            Assert.AreEqual(3, line.Tiles[1].Position.X);
            Assert.AreEqual(3, line.Tiles[1].Position.Y);

            Assert.AreEqual(2, line.Tiles[2].Position.X);
            Assert.AreEqual(3, line.Tiles[2].Position.Y);

            Assert.AreEqual(1, line.Tiles[3].Position.X);
            Assert.AreEqual(3, line.Tiles[3].Position.Y);
        }

        private Line GetLine(int startingPointX, int startingPointY)
        {
            return new Line(new Point(startingPointX, startingPointY));
        }
    }
}
