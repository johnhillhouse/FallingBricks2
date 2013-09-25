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
        bool CollisionDown(Shape shape, Dictionary<int, Tile> fallenTiles);
    }

    public class CollisionDetector : ICollisionDetector
    {
        private int _maxYValue;
        public CollisionDetector(int maxYValue)
        {
            _maxYValue = maxYValue;
        }

        public bool CollisionDown(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            if (HitBottomOfGrid(fallingShape) || HitFallenShapes(fallingShape, fallenTiles))
                return true;

            return false;
        }

        private bool HitFallenShapes(Shape fallingShape, Dictionary<int, Tile> fallenTiles)
        {
            foreach(var tile in fallingShape.Tiles)
            {
                if(fallenTiles.ContainsKey((new Point(tile.Position.X, tile.Position.Y + 1)).Index))
                    return true;
            }
            
            return false;
        }
        
        private bool HitBottomOfGrid(Shape shape)
        {
            foreach (var tile in shape.Tiles)
            {
                if (tile.Position.Y >= _maxYValue - 1)
                    return true;
            }
            
            return false;
        }
    }
}
