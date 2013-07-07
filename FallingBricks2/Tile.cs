using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2
{
    public class Tile
    {
        public Tile()
        {
            Height = 20;
            Width = 20;
            Colour = Colour.Red;
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public Colour Colour { get; set; }
        public Point TopLeftPoint { get; set;}
    }    
}
