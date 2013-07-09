using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2
{
    public class Line : Shape
    {
        public Line()
        {
            RotateEast();
        }

        //public override void RotateClockWise()
        //{
        //    base.RotateClockWise();
        //}

        protected override void RotateNorth() 
        {
            base.RotateNorth();
            //RotateNorthOrSouth(); 
        }

        protected override void RotateEast() 
        {
            base.RotateEast();
            //Tiles = new Tile[4];
            //Tiles[0].TopLeftPoint.X

            Tiles[0] = new Tile { TopLeftPoint = new Point(100, 100) };
            Tiles[1] = new Tile { TopLeftPoint = new Point(Tiles[0].TopLeftPoint.X + Tiles[0].Width, 100) };
            Tiles[2] = new Tile { TopLeftPoint = new Point(Tiles[1].TopLeftPoint.X + Tiles[1].Width, 100) };
            Tiles[3] = new Tile { TopLeftPoint = new Point(Tiles[2].TopLeftPoint.X + Tiles[2].Width, 100) };
        }

        protected override void RotateSouth() 
        {
            base.RotateSouth();
            //RotateNorthOrSouth(); 
        }

        protected override void RotateWest() 
        {
            base.RotateWest();
            //RotateEastOrWest(); 
        }

        /*private void RotateEastOrWest()
        {
            Tiles = new Tile[4];
            Tiles[0] = new Tile { TopLeftPoint = new Point(100, 100) };
            Tiles[1] = new Tile { TopLeftPoint = new Point(Tiles[0].TopLeftPoint.X + Tiles[0].Width, 100) };
            Tiles[2] = new Tile { TopLeftPoint = new Point(Tiles[1].TopLeftPoint.X + Tiles[1].Width, 100) };
            Tiles[3] = new Tile { TopLeftPoint = new Point(Tiles[2].TopLeftPoint.X + Tiles[2].Width, 100) };
        }

        private void RotateNorthOrSouth()
        {
            Tiles = new Tile[4];
            Tiles[0] = new Tile { TopLeftPoint = new Point(100, 100) };
            Tiles[1] = new Tile { TopLeftPoint = new Point(100, Tiles[0].TopLeftPoint.Y + Tiles[0].Height) };
            Tiles[2] = new Tile { TopLeftPoint = new Point(100, Tiles[1].TopLeftPoint.Y + Tiles[1].Height) };
            Tiles[3] = new Tile { TopLeftPoint = new Point(100, Tiles[2].TopLeftPoint.Y + Tiles[2].Height) };
        }

        private void RotateEastOrWest()
        {
            Tiles = new Tile[4];
            Tiles[0] = new Tile { TopLeftPoint = new Point(100, 100) };
            Tiles[1] = new Tile { TopLeftPoint = new Point(Tiles[0].TopLeftPoint.X + Tiles[0].Width, 100) };
            Tiles[2] = new Tile { TopLeftPoint = new Point(Tiles[1].TopLeftPoint.X + Tiles[1].Width, 100) };
            Tiles[3] = new Tile { TopLeftPoint = new Point(Tiles[2].TopLeftPoint.X + Tiles[2].Width, 100) };
        }

        private void RotateNorthOrSouth()
        {
            Tiles = new Tile[4];
            Tiles[0] = new Tile { TopLeftPoint = new Point(100, 100) };
            Tiles[1] = new Tile { TopLeftPoint = new Point(100, Tiles[0].TopLeftPoint.Y + Tiles[0].Height) };
            Tiles[2] = new Tile { TopLeftPoint = new Point(100, Tiles[1].TopLeftPoint.Y + Tiles[1].Height) };
            Tiles[3] = new Tile { TopLeftPoint = new Point(100, Tiles[2].TopLeftPoint.Y + Tiles[2].Height) };
        }*/
    }
}
