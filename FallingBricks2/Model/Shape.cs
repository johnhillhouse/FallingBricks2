﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2
{
    public abstract class Shape
    {
        public Shape(int tileWidth = 20, int tileHeight = 20)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            //    RotationState = RotationState.North;
        }
        
        //public Point TopLeftPosition { get; set; }
        public Tile[] Tiles;
        public Colour Colour { get; set; }
        protected RotationState RotationState { get; set; }
        protected int TileWidth { get; set; }
        protected int TileHeight { get; set; }
        protected Tile GetNewTile()
        {
            return new Tile(TileWidth, TileHeight);
        }

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
    }

    public enum RotationState
    {
        North,
        East,
        South,
        West
    }
}