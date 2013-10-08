using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;

namespace FallingBricks2
{
    public class Line : Shape
    {
        private Point _pivotPoint { get { return Tiles[1].Position; } }
        
        public Line(Point startingPoint)
        {
            BuildLine(startingPoint);
        }

        private void BuildLine(Point startingPoint)
        {
            Colour = Colour.Green;

            Tiles = new Tile[4];
            Tiles[0] = new Tile { Colour = Colour };
            Tiles[1] = new Tile { Position = new Point(startingPoint.X + 1, startingPoint.Y), Colour = Colour };
            Tiles[2] = new Tile { Colour = Colour };
            Tiles[3] = new Tile { Colour = Colour };
            RotateEast();
        }

        protected override void RotateEast() 
        {
            base.RotateEast();
            for(var i = 0; i <= 3; i++)
                Tiles[i].Position = EastCoordinates()[i];
        }

        protected override void RotateSouth() 
        {
            base.RotateSouth();
            for (var i = 0; i <= 3; i++)
                Tiles[i].Position = SouthCoordinates()[i];
        }

        protected override void RotateWest()
        {
            base.RotateWest();
            for (var i = 0; i <= 3; i++)
                Tiles[i].Position = WestCoordinates()[i];
        }

        protected override void RotateNorth()
        {
            base.RotateNorth();
            for (var i = 0; i <= 3; i++)
                Tiles[i].Position = NorthCoordinates()[i];
        }

        protected override List<Point> SouthCoordinates()
        {
            return new List<Point> { 
                new Point(_pivotPoint.X, _pivotPoint.Y - 1),
                _pivotPoint,
                new Point(_pivotPoint.X, _pivotPoint.Y + 1),
                new Point(_pivotPoint.X, _pivotPoint.Y + 2)
            };
        }

        protected override List<Point> EastCoordinates()
        {
            return new List<Point> { 
                new Point(_pivotPoint.X - 1, _pivotPoint.Y),
                _pivotPoint,
                new Point(_pivotPoint.X + 1, _pivotPoint.Y),
                new Point(_pivotPoint.X + 2, _pivotPoint.Y)
            };
        }

        protected override List<Point> WestCoordinates()
        {
            return new List<Point> { 
                new Point(_pivotPoint.X + 1, _pivotPoint.Y),
                _pivotPoint,
                new Point(_pivotPoint.X - 1, _pivotPoint.Y),
                new Point(_pivotPoint.X - 2, _pivotPoint.Y)
            };
        }
        protected override List<Point> NorthCoordinates()
        {
            return new List<Point> { 
                new Point(_pivotPoint.X, _pivotPoint.Y + 1),
                _pivotPoint,
                new Point(_pivotPoint.X, _pivotPoint.Y - 1),
                new Point(_pivotPoint.X, _pivotPoint.Y - 2)
            };
        }
    }
}
