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

        // public abstract void RotateAntiClockwise() { }

        public void MoveDown()
        {
            Tiles[0].Position.Y = Tiles[0].Position.Y + 1;
            Tiles[1].Position.Y = Tiles[1].Position.Y + 1;
            Tiles[2].Position.Y = Tiles[2].Position.Y + 1;
            Tiles[3].Position.Y = Tiles[3].Position.Y + 1;
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
