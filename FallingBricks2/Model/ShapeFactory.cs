using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;

namespace FallingBricks2.Model
{
    public static class ShapeFactory
    {
        public static Shape GetRandomShape()
        {
            var startingPosition = new Point(5, 6);
            var random = new Random();
            switch (random.Next(1, 8))
            {
                case 1: return new ShapeO(startingPosition);
                case 2: return new ShapeI(startingPosition);
                case 3: return new ShapeJ(startingPosition);
                case 4: return new ShapeL(startingPosition);
                case 5: return new ShapeT(startingPosition);
                case 6: return new ShapeS(startingPosition);
                case 7: return new ShapeZ(startingPosition);
                default: throw new Exception("You really shouldn't get this exception!");
            }
        }
    }
}
