using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.Controls;

namespace FallingBricks2
{
    public class T: Shape
    {
        public T(GameGrid gameGrid): base(gameGrid)
        {
            Colour = Colour.Yellow;
        }
    }
}
