using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2
{
    public class Line : Shape
    {
        public Line(Point startingPoint)
            : base()
        {
            BuildLine(startingPoint);
        }
        
        public Line(Point startingPoint, int tileWidth, int tileHeight)
            : base(tileWidth, tileHeight)
        {
            BuildLine(startingPoint);
        }

        private void BuildLine(Point startingPoint)
        {
            Tiles = new Tile[4];
            Tiles[0] = GetNewTile();
            Point pivotPoint = new Point(startingPoint.X + Tiles[0].Width, startingPoint.Y);
            Tiles[1] = GetNewTile();
            Tiles[1].TopLeftPoint = pivotPoint;
            Tiles[2] = GetNewTile();
            Tiles[3] = GetNewTile();
            RotateEast();
        }

        protected override void RotateNorth() 
        {
            base.RotateNorth();
            var tileHeight = Tiles[0].Height;
            var pivotPoint = Tiles[1].TopLeftPoint;

            Tiles[0].TopLeftPoint.Y = pivotPoint.Y + tileHeight;
            Tiles[2].TopLeftPoint.Y = pivotPoint.Y - tileHeight;
            Tiles[3].TopLeftPoint.Y = pivotPoint.Y - (tileHeight * 2);

            SetPointXToPivotPointX(pivotPoint);
        }
        
        protected override void RotateEast() 
        {
            base.RotateEast();
            var tileWidth = Tiles[0].Width;
            var pivotPoint = Tiles[1].TopLeftPoint;

            Tiles[0].TopLeftPoint.X = pivotPoint.X - tileWidth;
            Tiles[2].TopLeftPoint.X = pivotPoint.X + tileWidth;
            Tiles[3].TopLeftPoint.X = pivotPoint.X + (tileWidth * 2);

            SetPointYToPivotPointY(pivotPoint);
        }

        protected override void RotateSouth() 
        {
            base.RotateSouth();
            var tileHeight = Tiles[0].Height;
            var pivotPoint = Tiles[1].TopLeftPoint;

            Tiles[0].TopLeftPoint.Y = pivotPoint.Y - tileHeight;
            Tiles[2].TopLeftPoint.Y = pivotPoint.Y + tileHeight;
            Tiles[3].TopLeftPoint.Y = pivotPoint.Y + (tileHeight * 2);

            SetPointXToPivotPointX(pivotPoint);
        }

        protected override void RotateWest() 
        {
            base.RotateWest();
            var tileWidth = Tiles[0].Width;
            var pivotPoint = Tiles[1].TopLeftPoint;

            Tiles[0].TopLeftPoint.X = pivotPoint.X + tileWidth;
            Tiles[2].TopLeftPoint.X = pivotPoint.X - tileWidth;
            Tiles[3].TopLeftPoint.X = pivotPoint.X - (tileWidth * 2);

            SetPointYToPivotPointY(pivotPoint);
        }

        private void SetPointXToPivotPointX(Point pivotPoint)
        {
            Tiles[0].TopLeftPoint.X = pivotPoint.X;
            Tiles[2].TopLeftPoint.X = pivotPoint.X;
            Tiles[3].TopLeftPoint.X = pivotPoint.X;
        }

        private void SetPointYToPivotPointY(Point pivotPoint)
        {
            Tiles[0].TopLeftPoint.Y = pivotPoint.Y;
            Tiles[2].TopLeftPoint.Y = pivotPoint.Y;
            Tiles[3].TopLeftPoint.Y = pivotPoint.Y;
        }
    }
}
