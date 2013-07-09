using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2
{
    public static class ShapeFactory
    {
        public static Shape GetRandomShape()
        {
            var random = new Random();
            switch (random.Next(1, 3))
            {
                case 1: return new Square { Colour = GetRandomColour() };
                case 2: return new Line { Colour = GetRandomColour() };
                default: return new Square { Colour = GetRandomColour() };
            }
        }

        private static Colour GetRandomColour()
        {
            var random = new Random();
            switch (random.Next(1, 6))
            {
                case 1: return Colour.Blue;
                case 2: return Colour.Green;
                case 3: return Colour.Orange;
                case 4: return Colour.Red;
                case 5: return Colour.Yellow;
            }
            return Colour.Blue;
        }
    }
}
