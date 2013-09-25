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
            switch (random.Next(1, 3))
            {
                case 1: return new Square(startingPosition);
                case 2: return new Line(startingPosition);
                default: return new Square(startingPosition);
            }
        }
    }
}
