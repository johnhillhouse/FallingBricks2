﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;

namespace FallingBricks2
{
    public class Square : Shape
    {
        public Square()
        {
        }
        
        public Square(Point startingPoint)
        {
            BuildSquare(startingPoint);
        }

        private void BuildSquare(Point startingPoint)
        {
            Colour = Colour.Red;

            Tiles = new Tile[4];
            Tiles[0] = new Tile { Position = startingPoint, Colour = Colour };
            Tiles[1] = new Tile { Position = new Point(startingPoint.X + 1, startingPoint.Y), Colour = Colour };
            Tiles[2] = new Tile { Position = new Point(startingPoint.X, startingPoint.Y + 1), Colour = Colour };
            Tiles[3] = new Tile { Position = new Point(startingPoint.X + 1, startingPoint.Y + 1), Colour = Colour };
        }
    }
}
