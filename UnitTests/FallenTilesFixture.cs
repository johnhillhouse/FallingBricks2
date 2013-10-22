using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FallingBricks2.Controller;
using FallingBricks2;

namespace UnitTests
{
    [TestClass]
    public class FallenTilesFixture
    {
        [TestMethod]
        public void RemoveCompletedRowIfRequired()
        {
            var line = new Line(new Point(5, 1));
            var fallenTiles = new FallenTiles();

            foreach (var tile in line.Tiles)
                fallenTiles.Add(tile);
            foreach (var tile in new Line(new Point(1, 2)).Tiles)
                fallenTiles.Add(tile);
            foreach (var tile in new Line(new Point(1, 1)).Tiles)
                fallenTiles.Add(tile);

            fallenTiles.RemoveCompletedRowIfRequired(line, 8);

            // Assert 8 tiles remain i.e. 4 tiles have been removed (a row)
            Assert.AreEqual(4, fallenTiles.Tiles.Count);
            
            // Make sure the remaining tiles have shifted down
            Assert.IsTrue(fallenTiles.Tiles.ContainsKey(21));
            Assert.IsTrue(fallenTiles.Tiles.ContainsKey(22));
            Assert.IsTrue(fallenTiles.Tiles.ContainsKey(23));
            Assert.IsTrue(fallenTiles.Tiles.ContainsKey(24));
        }
    }
}
