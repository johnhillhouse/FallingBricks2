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
            Position = new Point(0, 0);
        }

        public Point Position { get; set;}
        public Colour Colour { get; set; }
    }    
}
