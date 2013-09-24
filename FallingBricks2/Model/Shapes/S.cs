using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;

namespace FallingBricks2
{
    public class S: Shape
    {
        public S(): base()
        {
            Colour = Colour.Orange;
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

            return new S { Tiles = tiles, Colour = this.Colour };
        }
    }
}
