using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2
{
    public class Tile
    {
        public Tile(int width, int height)
        {
            TopLeftPoint = new Point(0, 0);
            Width = width;
            Height = height;
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public Point TopLeftPoint { get; set;}
    }    
}
