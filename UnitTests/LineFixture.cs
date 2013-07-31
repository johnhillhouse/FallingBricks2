﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FallingBricks2.UnitTests
{
    [TestClass]
    public class LineFixture
    {
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

        private void AssertFacingNorth(Line line)
        {
            Assert.AreEqual(3, line.Tiles[0].TopLeftPoint.X);
            Assert.AreEqual(4, line.Tiles[0].TopLeftPoint.Y);

            Assert.AreEqual(3, line.Tiles[1].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[1].TopLeftPoint.Y);

            Assert.AreEqual(3, line.Tiles[2].TopLeftPoint.X);
            Assert.AreEqual(2, line.Tiles[2].TopLeftPoint.Y);

            Assert.AreEqual(3, line.Tiles[3].TopLeftPoint.X);
            Assert.AreEqual(1, line.Tiles[3].TopLeftPoint.Y);
        }

        private void AssertFacingEast(Line line)
        {
            Assert.AreEqual(2, line.Tiles[0].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[0].TopLeftPoint.Y);

            Assert.AreEqual(3, line.Tiles[1].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[1].TopLeftPoint.Y);

            Assert.AreEqual(4, line.Tiles[2].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[2].TopLeftPoint.Y);

            Assert.AreEqual(5, line.Tiles[3].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[3].TopLeftPoint.Y);
        }

        private void AssertFacingSouth(Line line)
        {
            Assert.AreEqual(3, line.Tiles[0].TopLeftPoint.X);
            Assert.AreEqual(2, line.Tiles[0].TopLeftPoint.Y);

            Assert.AreEqual(3, line.Tiles[1].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[1].TopLeftPoint.Y);

            Assert.AreEqual(3, line.Tiles[2].TopLeftPoint.X);
            Assert.AreEqual(4, line.Tiles[2].TopLeftPoint.Y);

            Assert.AreEqual(3, line.Tiles[3].TopLeftPoint.X);
            Assert.AreEqual(5, line.Tiles[3].TopLeftPoint.Y);
        }

        private void AssertFacingWest(Line line)
        {
            Assert.AreEqual(4, line.Tiles[0].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[0].TopLeftPoint.Y);

            Assert.AreEqual(3, line.Tiles[1].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[1].TopLeftPoint.Y);

            Assert.AreEqual(2, line.Tiles[2].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[2].TopLeftPoint.Y);

            Assert.AreEqual(1, line.Tiles[3].TopLeftPoint.X);
            Assert.AreEqual(3, line.Tiles[3].TopLeftPoint.Y);
        }

        private Line GetLine(int startingPointX, int startingPointY)
        {
            return new Line(new Point(startingPointX, startingPointY), 1, 1);
        }
    }
}