using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FallingBricks2.UnitTests
{
    [TestClass]
    public class LineFixture
    {
        private Point StartingPoint = new Point(100, 100);

        [TestMethod]
        public void TestNewLineCoordinatesAreCorrect()
        {
            var line = new Line();

            var width = line.Tiles[0].Width;
            
            Assert.AreEqual(line.Tiles[0].TopLeftPoint.X, StartingPoint.X);
            Assert.AreEqual(line.Tiles[0].TopLeftPoint.Y, StartingPoint.Y);

            Assert.AreEqual(line.Tiles[1].TopLeftPoint.X, StartingPoint.X + width);
            Assert.AreEqual(line.Tiles[1].TopLeftPoint.Y, StartingPoint.Y);

            Assert.AreEqual(line.Tiles[2].TopLeftPoint.X, StartingPoint.X + (width * 2));
            Assert.AreEqual(line.Tiles[2].TopLeftPoint.Y, StartingPoint.Y);

            Assert.AreEqual(line.Tiles[3].TopLeftPoint.X, StartingPoint.X + (width * 3));
            Assert.AreEqual(line.Tiles[3].TopLeftPoint.Y, StartingPoint.Y);
        }

        [TestMethod]
        public void TestRotateClockWise()
        {
            var line = new Line();
            var height = line.Tiles[0].Height;

            line.RotateClockWise();

            Assert.AreEqual(line.Tiles[0].TopLeftPoint.X, StartingPoint.X);
            Assert.AreEqual(line.Tiles[0].TopLeftPoint.Y, StartingPoint.Y - height);

            Assert.AreEqual(line.Tiles[1].TopLeftPoint.X, StartingPoint.X);
            Assert.AreEqual(line.Tiles[1].TopLeftPoint.Y, StartingPoint.Y);

            Assert.AreEqual(line.Tiles[2].TopLeftPoint.X, StartingPoint.X);
            Assert.AreEqual(line.Tiles[2].TopLeftPoint.Y, StartingPoint.Y + height);

            Assert.AreEqual(line.Tiles[3].TopLeftPoint.X, StartingPoint.X);
            Assert.AreEqual(line.Tiles[3].TopLeftPoint.Y, StartingPoint.Y + (height * 2));
        }

        [TestMethod]
        public void TestRotateClockWiseTwice()
        {
            var line = new Line();
            var width = line.Tiles[0].Width;

            line.RotateClockWise();
            line.RotateClockWise();

            Assert.AreEqual(line.Tiles[0].TopLeftPoint.X, StartingPoint.X);
            Assert.AreEqual(line.Tiles[0].TopLeftPoint.Y, StartingPoint.Y);

            Assert.AreEqual(line.Tiles[1].TopLeftPoint.X, StartingPoint.X - width);
            Assert.AreEqual(line.Tiles[1].TopLeftPoint.Y, StartingPoint.Y);

            Assert.AreEqual(line.Tiles[2].TopLeftPoint.X, StartingPoint.X - (width * 2));
            Assert.AreEqual(line.Tiles[2].TopLeftPoint.Y, StartingPoint.Y);

            Assert.AreEqual(line.Tiles[3].TopLeftPoint.X, StartingPoint.X - (width * 3));
            Assert.AreEqual(line.Tiles[3].TopLeftPoint.Y, StartingPoint.Y);
        }
    }
}
