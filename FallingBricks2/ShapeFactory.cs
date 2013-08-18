using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.Controls;

namespace FallingBricks2
{
    public static class ShapeFactory
    {
        public static Shape GetRandomShape(GameGrid gameGrid)
        {
            var startingPosition = new Point(3, 3);
            var random = new Random();
            switch (random.Next(1, 3))
            {
                case 1: return new Line(gameGrid, startingPosition);
                case 2: return new Line(gameGrid, startingPosition);
                default: return new Square(gameGrid);
            }
        }
    }
}
