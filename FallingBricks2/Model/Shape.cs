using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;

namespace FallingBricks2
{
    public abstract class Shape
    {
        public Shape()
        {
        }
        public Tile[] Tiles;
        public Colour Colour { get; set; }
        protected RotationState RotationState { get; set; }

        protected virtual void RotateNorth() { RotationState = RotationState.North; }
        protected virtual void RotateEast() { RotationState = RotationState.East; }
        protected virtual void RotateSouth() { RotationState = RotationState.South; }
        protected virtual void RotateWest() { RotationState = RotationState.West; }

        //public abstract List<Point> GetNextClockwiseRotationCoordinates();
        //public abstract List<Point> GetNextAntiClockwiseRotationCoordinates();

        protected abstract List<Point> EastCoordinates();
        protected abstract List<Point> SouthCoordinates();
        protected abstract List<Point> WestCoordinates();
        protected abstract List<Point> NorthCoordinates();

        public List<Point> GetNextClockwiseRotationCoordinates()
        {
            switch (RotationState)
            {
                case RotationState.North: return EastCoordinates();
                case RotationState.East: return SouthCoordinates();
                case RotationState.South: return WestCoordinates();
                case RotationState.West: return NorthCoordinates();
            }
            throw new Exception("No such rotation state exists");
        }

        public List<Point> GetNextAntiClockwiseRotationCoordinates()
        {
            switch (RotationState)
            {
                case RotationState.North: return WestCoordinates();
                case RotationState.West: return SouthCoordinates();
                case RotationState.South: return EastCoordinates();
                case RotationState.East: return NorthCoordinates();
            }
            throw new Exception("No such rotation state exists");
        }

        public virtual void RotateClockWise() 
        {
            switch (RotationState)
            {
                case RotationState.North: RotateEast(); 
                    break;
                case RotationState.East: RotateSouth(); 
                    break;
                case RotationState.South: RotateWest(); 
                    break;
                case RotationState.West: RotateNorth(); 
                    break;
            }
        }

        public virtual void RotateAntiClockWise()
        {
            switch (RotationState)
            {
                case RotationState.North: RotateWest();
                    break;
                case RotationState.West: RotateSouth();
                    break;
                case RotationState.South: RotateEast();
                    break;
                case RotationState.East: RotateNorth();
                    break;
            }
        }

        public void MoveDown()
        {
            foreach (var tile in Tiles)
                tile.Position.Y++;
        }

        public void MoveRight()
        {
            foreach (var tile in Tiles)
                tile.Position.X++;
        }

        public void MoveLeft()
        {
            foreach (var tile in Tiles)
                tile.Position.X--;
        }
    }

    public enum RotationState
    {
        North,
        East,
        South,
        West
    }
}
