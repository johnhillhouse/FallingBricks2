using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;

namespace FallingBricks2
{
    public class Square : Shape
    {
        public Square()
        {
        }
        
        public Square(Point startingPoint)
        {
            BuildSquare(startingPoint);
        }

        public override Shape Clone()
        {
            var tiles = new Tile[4];
            var i = 0;
            foreach (var tile in this.Tiles)
            {
                tiles[i] = new Tile { Position = new Point(tile.Position.X, tile.Position.Y) };
                i++;
            }

            return new Square { Tiles = tiles, Colour = this.Colour };
        }

        private void BuildSquare(Point startingPoint)
        {
            Colour = Colour.Red;

            Tiles = new Tile[4];
            Tiles[0] = new Tile { Position = startingPoint };
            Tiles[1] = new Tile { Position = new Point(startingPoint.X + 1, startingPoint.Y) };
            Tiles[2] = new Tile { Position = new Point(startingPoint.X, startingPoint.Y + 1) };
            Tiles[3] = new Tile { Position = new Point(startingPoint.X + 1, startingPoint.Y + 1) };
        }
    }
}
