using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2
{
    public class Square : Shape
    {
        public Point TopLeftPosition { get; set; }
        
        public Square()
        {
            //Point[] coordinates = new Point[4];
            //coordinates[0] = new Point(left, top);

            Tile[] square = new Tile[4];
            tile1 = new Tile { TopLeftPoint = new Point(100, 100) };
            tile2 = new Tile { TopLeftPoint = new Point(100, tile1.TopLeftPoint.X + tile1.Width) };
            square[0] = tile1;
            square[1] = tile2;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        private Tile tile1;
        private Tile tile2;
    }
}
