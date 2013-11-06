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
            var line = new ShapeI(new Point(5, 1));
            var fallenTiles = new FallenTiles();

            foreach (var tile in line.Tiles)
                fallenTiles.Add(tile);
            foreach (var tile in new ShapeI(new Point(1, 2)).Tiles)
                fallenTiles.Add(tile);
            foreach (var tile in new ShapeI(new Point(1, 1)).Tiles)
                fallenTiles.Add(tile);

            int numberOfRowsRemoved;
            fallenTiles.RemoveCompletedRowIfRequired(line, 8, out numberOfRowsRemoved);

            // Assert 4 tiles remain i.e. 4 tiles have been removed (a row)
            Assert.AreEqual(4, fallenTiles.Tiles.Count);
            Assert.AreEqual(1, numberOfRowsRemoved);
            
            // Make sure the remaining tiles have shifted down
            Assert.IsTrue(fallenTiles.Tiles.ContainsKey(21));
            Assert.IsTrue(fallenTiles.Tiles.ContainsKey(22));
            Assert.IsTrue(fallenTiles.Tiles.ContainsKey(23));
            Assert.IsTrue(fallenTiles.Tiles.ContainsKey(24));
        }
    }
}
