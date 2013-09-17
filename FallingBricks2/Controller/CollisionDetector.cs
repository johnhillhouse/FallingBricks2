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
        bool Collision(Shape shape);
    }

    public class CollisionDetector : ICollisionDetector
    {
        private int _maxYValue;
        private IGameGrid _gameGrid;
        public CollisionDetector(int maxYValue)
        {
            _maxYValue = maxYValue;
        }

        public bool Collision(Shape shape)
        {
            if (shape.Tiles[0].Position.Y >= _maxYValue - 1 ||
                shape.Tiles[1].Position.Y >= _maxYValue - 1 ||
                shape.Tiles[2].Position.Y >= _maxYValue - 1 ||
                shape.Tiles[3].Position.Y >= _maxYValue - 1)
                return true;

            return false;
        }
    }
}
