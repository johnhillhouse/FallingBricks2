using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2
{
    public class Square : Shape
    {
        public Square()
        {
            Tiles = new Tile[4];
            Tiles[0] = new Tile { TopLeftPoint = new Point(100, 100) };
            Tiles[1] = new Tile { TopLeftPoint = new Point(100, Tiles[0].TopLeftPoint.X + Tiles[0].Width) };
            Tiles[2] = new Tile { TopLeftPoint = new Point(Tiles[0].TopLeftPoint.X + Tiles[0].Height, 100) };
            Tiles[3] = new Tile { TopLeftPoint = new Point(Tiles[0].TopLeftPoint.X + Tiles[0].Height, Tiles[0].TopLeftPoint.X + Tiles[0].Width) };
        }
    }
}
