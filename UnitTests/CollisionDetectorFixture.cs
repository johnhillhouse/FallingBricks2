using FallingBricks2;
using FallingBricks2.Controller;
using FallingBricks2.View.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class CollisionDetectorFixture
    {
        private ICollisionDetector _detector;

        public CollisionDetectorFixture()
        {
            GridDimensions.MaxYValue = 10;
            GridDimensions.MinXValue = 1;
            GridDimensions.MaxXValue = 10;
            _detector = (ICollisionDetector)new CollisionDetector();
        }

        [TestMethod]
        public void DetectCollisionRotatingClockwiseBlankGrid()
        {
            var line = new Line(new Point(5, 6));
            line.RotateClockWise();
            line.MoveRight();
            line.MoveRight();
            line.MoveRight();

            Assert.IsTrue(_detector.CollisionRotatingClockwise(line, new Dictionary<int, Tile>()), "Collision detection with right side of grid failed");

            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();

            Assert.IsTrue(_detector.CollisionRotatingClockwise(line, new Dictionary<int, Tile>()), "Collision detection with left side of grid failed");

            line.MoveRight();
            line.MoveRight();
            line.RotateClockWise();
            line.MoveDown();
            line.MoveDown();
            line.MoveDown();

            Assert.IsTrue(_detector.CollisionRotatingClockwise(line, new Dictionary<int, Tile>()), "Collision detection with bottom of grid failed");
        }

        [TestMethod]
        public void DetectCollisionRotatingAntiClockwiseBlankGrid()
        {
            var line = new Line(new Point(5, 6));
            line.RotateClockWise();
            line.MoveRight();
            line.MoveRight();
            line.MoveRight();

            Assert.IsTrue(_detector.CollisionRotatingAntiClockwise(line, new Dictionary<int, Tile>()), "Collision detection with right side of grid failed");

            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();
            line.MoveLeft();

            Assert.IsTrue(_detector.CollisionRotatingAntiClockwise(line, new Dictionary<int, Tile>()), "Collision detection with left side of grid failed");

            line.MoveRight();
            line.MoveRight();
            line.RotateClockWise();
            line.MoveDown();
            line.MoveDown();
            line.MoveDown();

            Assert.IsTrue(_detector.CollisionRotatingAntiClockwise(line, new Dictionary<int, Tile>()), "Collision detection with bottom of grid failed");
        }

        [TestMethod]
        public void DetectCollisionRotatingClockwiseFallenTiles()
        {
            Assert.IsTrue(_detector.CollisionRotatingClockwise(new Line(new Point(5, 6)), GetFallenTiles(5, 7)));
        }

        [TestMethod]
        public void DetectCollisionRotatingAntiClockwiseFallenTiles()
        {
            Assert.IsTrue(_detector.CollisionRotatingAntiClockwise(new Line(new Point(5, 6)), GetFallenTiles(5, 7)));
        }

        [TestMethod]
        public void DetectDownNonCollisionBlankGrid()
        {
            Assert.IsFalse(_detector.CollisionMovingDown(new Line(new Point(1, 8)), new Dictionary<int, Tile>()));
        }

        [TestMethod]
        public void DetectDownCollisionBlankGrid()
        {
            Assert.IsTrue(_detector.CollisionMovingDown(new Line(new Point(1, 9)), new Dictionary<int, Tile>()));
        }

        [TestMethod]
        public void DetectDownCollisionFallenTiles()
        {
            var line = new Line(new Point(1, 6));
            Assert.IsTrue(_detector.CollisionMovingDown(line, GetFallenTiles(3,7)));
        }

        [TestMethod]
        public void DetectDownNonCollisionFallenTiles()
        {
            var line = new Line(new Point(1, 3));
            Assert.IsFalse(_detector.CollisionMovingDown(line, GetFallenTiles(3,7)));
        }

        [TestMethod]
        public void DetectLeftCollisionBlankGrid()
        {
            Assert.IsTrue(_detector.CollisionMovingLeft(new Line(new Point(1,9)), new Dictionary<int, Tile>()));
        }

        [TestMethod]
        public void DetectRightCollisionBlankGrid()
        {
            Assert.IsTrue(_detector.CollisionMovingRight(new Line(new Point(10, 9)), new Dictionary<int, Tile>()));
        }

        [TestMethod]
        public void DetectLeftCollisionFallenTiles()
        {
            Assert.IsTrue(_detector.CollisionMovingLeft(new Line(new Point(7, 7)), GetFallenTiles(3,7)));
        }

        [TestMethod]
        public void DetectRightCollisionFallenTiles()
        {
            Assert.IsTrue(_detector.CollisionMovingRight(new Line(new Point(3, 7)), GetFallenTiles(7,7)));
        }

        private Dictionary<int, Tile> GetFallenTiles(int x, int y)
        {
            var fallenLine = new Line(new Point(x, y));
            var fallenTiles = new Dictionary<int, Tile>();
            foreach (var tile in fallenLine.Tiles)
            {
                fallenTiles.Add(tile.Position.Index, tile);
            }
            return fallenTiles;
        }
    }
}
