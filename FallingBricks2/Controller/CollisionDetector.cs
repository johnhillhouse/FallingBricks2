using FallingBricks2.View.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2.Controller
{
    public interface ICollisionDetector
    {
        bool CollisionMovingDown(Shape fallingShape, Dictionary<int, Tile> fallenTiles);
        bool CollisionMovingLeft(Shape fallingShape, Dictionary<int, Tile> fallenTiles);
        bool CollisionMovingRight(Shape fallingShape, Dictionary<int, Tile> fallenTiles);
        bool CollisionRotatingClockwise(Shape fallingShape, Dictionary<int, Tile> fallenTiles);
        bool CollisionRotatingAntiClockwise(Shape fallingShape, Dictionary<int, Tile> fallenTiles);
    }

    public class CollisionDetector : ICollisionDetector
    {
        public bool CollisionRotatingClockwise(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            return CollisionRotating(fallenTiles, fallingShape.GetNextClockwiseRotationCoordinates());
        }

        public bool CollisionRotatingAntiClockwise(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            return CollisionRotating(fallenTiles, fallingShape.GetNextAntiClockwiseRotationCoordinates());
        }

        public bool CollisionMovingDown(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            if (HitBottomOfGrid(fallingShape) || HitFallenShapesMovingDownwards(fallingShape, fallenTiles))
                return true;

            return false;
        }

        public bool CollisionMovingLeft(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            if (HitLeftSideOfGrid(fallingShape) || HitFallenShapesMovingLeft(fallingShape, fallenTiles))
                return true;

            return false;
        }

        public bool CollisionMovingRight(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            if (HitRightSideOfGrid(fallingShape) || HitFallenShapesMovingRight(fallingShape, fallenTiles))
                return true;

            return false;
        }

        private bool HitLeftSideOfGrid(Shape fallingShape)
        {
            foreach (var tile in fallingShape.Tiles)
            {
                if (tile.Position.X == GridDimensions.MinXValue)
                    return true;
            }
            return false;
        }

        private bool HitRightSideOfGrid(Shape fallingShape)
        {
            foreach (var tile in fallingShape.Tiles)
            {
                if (tile.Position.X == GridDimensions.MaxXValue)
                    return true;
            }
            return false;
        }

        private bool HitFallenShapesMovingDownwards(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            foreach(var tile in fallingShape.Tiles)
            {
                if(fallenTiles.ContainsKey((new Point(tile.Position.X, tile.Position.Y + 1)).Index))
                    return true;
            }
            
            return false;
        }

        private bool HitFallenShapesMovingLeft(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            foreach (var tile in fallingShape.Tiles)
            {
                if (fallenTiles.ContainsKey((new Point(tile.Position.X - 1, tile.Position.Y)).Index))
                    return true;
            }

            return false;
        }

        private bool HitFallenShapesMovingRight(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            foreach (var tile in fallingShape.Tiles)
            {
                if (fallenTiles.ContainsKey((new Point(tile.Position.X + 1, tile.Position.Y)).Index))
                    return true;
            }

            return false;
        }
        
        private bool HitBottomOfGrid(Shape shape)
        {
            foreach (var tile in shape.Tiles)
            {
                if (tile.Position.Y >= GridDimensions.MaxYValue - 1)
                    return true;
            }
            
            return false;
        }

        private static bool CollisionRotating(Dictionary<int, Tile> fallenTiles, List<Point> rotationPoints)
        {
            foreach (var point in rotationPoints)
            {
                if (fallenTiles.ContainsKey((point.Index)))
                    return true;

                if (point.X >= GridDimensions.MaxXValue)
                    return true;

                if (point.X <= GridDimensions.MinXValue)
                    return true;

                if (point.Y >= GridDimensions.MaxYValue)
                    return true;
            }

            return false;
        }
    }
}
