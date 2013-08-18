using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.Controls;

namespace FallingBricks2
{
    public class Line : Shape
    {
        public Line(GameGrid gameGrid, Point startingPoint): base(gameGrid)
        {
            BuildLine(startingPoint);
        }

        private void BuildLine(Point startingPoint)
        {
            Colour = Colour.Green;

            Tiles = new Tile[4];
            Tiles[0] = new Tile();
            Point pivotPoint = new Point(startingPoint.X + 1, startingPoint.Y);
            Tiles[1] = new Tile();
            Tiles[1].Position = pivotPoint;
            Tiles[2] = new Tile();
            Tiles[3] = new Tile();
            RotateEast();
        }

        protected override void RotateNorth() 
        {
            base.RotateNorth();
            var pivotPoint = Tiles[1].Position;

            Tiles[0].Position.Y = pivotPoint.Y + 1;
            Tiles[2].Position.Y = pivotPoint.Y - 1;
            Tiles[3].Position.Y = pivotPoint.Y - 2;

            SetPointXToPivotPointX(pivotPoint);
        }
        
        protected override void RotateEast() 
        {
            base.RotateEast();
            var pivotPoint = Tiles[1].Position;

            Tiles[0].Position.X = pivotPoint.X - 1;
            Tiles[2].Position.X = pivotPoint.X + 1;
            Tiles[3].Position.X = pivotPoint.X + 2;

            SetPointYToPivotPointY(pivotPoint);
        }

        protected override void RotateSouth() 
        {
            base.RotateSouth();
            var pivotPoint = Tiles[1].Position;

            Tiles[0].Position.Y = pivotPoint.Y - 1;
            Tiles[2].Position.Y = pivotPoint.Y + 1;
            Tiles[3].Position.Y = pivotPoint.Y + 2;

            SetPointXToPivotPointX(pivotPoint);
        }

        protected override void RotateWest() 
        {
            base.RotateWest();
            var pivotPoint = Tiles[1].Position;

            Tiles[0].Position.X = pivotPoint.X + 1;
            Tiles[2].Position.X = pivotPoint.X - 1;
            Tiles[3].Position.X = pivotPoint.X - 2;

            SetPointYToPivotPointY(pivotPoint);
        }

        private void SetPointXToPivotPointX(Point pivotPoint)
        {
            Tiles[0].Position.X = pivotPoint.X;
            Tiles[2].Position.X = pivotPoint.X;
            Tiles[3].Position.X = pivotPoint.X;
        }

        private void SetPointYToPivotPointY(Point pivotPoint)
        {
            Tiles[0].Position.Y = pivotPoint.Y;
            Tiles[2].Position.Y = pivotPoint.Y;
            Tiles[3].Position.Y = pivotPoint.Y;
        }
    }
}
