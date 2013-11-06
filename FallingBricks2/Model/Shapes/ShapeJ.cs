using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;

namespace FallingBricks2
{
    public class ShapeJ : Shape
    {
        private Point _pivotPoint { get { return Tiles[1].Position; } }

        public ShapeJ(Point startingPoint)
        {
            BuildShape(startingPoint);
        }

        private void BuildShape(Point startingPoint)
        {
            Colour = Colour.Blue;

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
            SetShapeCoordinates(EastCoordinates());
        }

        protected override void RotateSouth()
        {
            base.RotateSouth();
            SetShapeCoordinates(SouthCoordinates());
        }

        protected override void RotateWest()
        {
            base.RotateWest();
            SetShapeCoordinates(WestCoordinates());
        }

        protected override void RotateNorth()
        {
            base.RotateNorth();
            SetShapeCoordinates(NorthCoordinates());
        }

        protected override List<Point> SouthCoordinates()
        {
            return new List<Point> { 
                new Point(_pivotPoint.X, _pivotPoint.Y + 1),
                _pivotPoint,
                new Point(_pivotPoint.X, _pivotPoint.Y - 1),
                new Point(_pivotPoint.X + 1, _pivotPoint.Y - 1)
            };
        }

        protected override List<Point> EastCoordinates()
        {
            return new List<Point> { 
                new Point(_pivotPoint.X + 1, _pivotPoint.Y),
                _pivotPoint,
                new Point(_pivotPoint.X - 1, _pivotPoint.Y),
                new Point(_pivotPoint.X - 1, _pivotPoint.Y - 1)
            };
        }

        protected override List<Point> WestCoordinates()
        {
            return new List<Point> { 
                new Point(_pivotPoint.X - 1, _pivotPoint.Y),
                _pivotPoint,
                new Point(_pivotPoint.X + 1, _pivotPoint.Y),
                new Point(_pivotPoint.X + 1, _pivotPoint.Y + 1)
            };
        }
        protected override List<Point> NorthCoordinates()
        {
            return new List<Point> { 
                new Point(_pivotPoint.X, _pivotPoint.Y - 1),
                _pivotPoint,
                new Point(_pivotPoint.X, _pivotPoint.Y + 1),
                new Point(_pivotPoint.X - 1, _pivotPoint.Y + 1)
            };
        }

        private void SetShapeCoordinates(List<Point> Coordinates)
        {
            for (var i = 0; i <= 3; i++)
                Tiles[i].Position = Coordinates[i];
        }
    }
}
