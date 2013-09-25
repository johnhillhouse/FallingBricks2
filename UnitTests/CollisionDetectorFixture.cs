using FallingBricks2;
using FallingBricks2.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class CollisionDetectorFixture
    {
        private ICollisionDetector _detector;

        public CollisionDetectorFixture()
        {
            _detector = (ICollisionDetector)new CollisionDetector(10);
        }

        [TestMethod]
        public void DetectNonCollisionBlankGrid()
        {
            Assert.IsFalse(_detector.CollisionDown(new Line(new Point(1, 8)), new Dictionary<int, Tile>()));
        }

        [TestMethod]
        public void DetectCollisionBlankGrid()
        {
            Assert.IsTrue(_detector.CollisionDown(new Line(new Point(1, 9)), new Dictionary<int, Tile>()));
        }

        [TestMethod]
        public void DetectCollisionFallenShapes()
        {
            var line = new Line(new Point(1, 6));
            var fallenLine = new Line(new Point(1, 7));
            var fallenTiles = new Dictionary<int, Tile>();
            foreach (var tile in fallenLine.Tiles)
            {
                fallenTiles.Add(tile.Position.Index, tile);
            }

            Assert.IsTrue(_detector.CollisionDown(line, fallenTiles));
        }

        [TestMethod]
        public void DetectNonCollisionFallenShapes()
        {
            var line = new Line(new Point(1, 3));
            var fallenLine = new Line(new Point(1, 7));
            var fallenTiles = new Dictionary<int, Tile>();
            foreach (var tile in fallenLine.Tiles)
            {
                fallenTiles.Add(tile.Position.Index, tile);
            }

            Assert.IsFalse(_detector.CollisionDown(line, fallenTiles));
        }
    }
}
