using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;

namespace FallingBricks2
{
    public class ShapeO : Shape
    {
        public ShapeO(Point startingPoint)
        {
            BuildShape(startingPoint);
        }

        protected override List<Point> SouthCoordinates() { return SquareCoordinates(); }
        protected override List<Point> EastCoordinates() { return SquareCoordinates(); }
        protected override List<Point> WestCoordinates() { return SquareCoordinates(); }
        protected override List<Point> NorthCoordinates() { return SquareCoordinates(); }

        private List<Point> SquareCoordinates()
        {
            var coordinates = new List<Point>();
            foreach (var tile in Tiles)
                coordinates.Add(tile.Position);

            return coordinates;
        }

        private void BuildShape(Point startingPoint)
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
