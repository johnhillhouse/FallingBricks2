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
        bool CollisionDown(Shape shape, List<Shape> fallenShapes);
    }

    public class CollisionDetector : ICollisionDetector
    {
        private int _maxYValue;
        public CollisionDetector(int maxYValue)
        {
            _maxYValue = maxYValue;
        }

        public bool CollisionDown(Shape fallingShape, List<Shape> fallenShapes)
        {
            if (HitBottomOfGrid(fallingShape) || HitFallenShapes(fallingShape, fallenShapes))
                return true;

            return false;
        }

        private bool HitFallenShapes(Shape shape, List<Shape> fallenShapes)
        {
            foreach (var fallenShape in fallenShapes)
            {
                foreach (var tile in fallenShape.Tiles)
                {
                    if (shape.Tiles.Any(t => t.Position.Y + 1 == tile.Position.Y))
                        return true;
                }
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
