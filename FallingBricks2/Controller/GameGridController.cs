using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.View.Controls;
using FallingBricks2.Model;
using System.Windows.Media;
using System.Windows.Threading;

namespace FallingBricks2.Controller
{
    public interface IGameGridController
    {
        void RotateClockwise();
        void MoveRight();
        void MoveLeft();
        void StartGame();
    }
    
    public class GameGridController: IGameGridController
    {
        private IGameGrid _gameGrid;
        private Shape _fallingShape;
        private DispatcherTimer GameTimer { get; set; }
        private ICollisionDetector _collisionDetector;
        private Dictionary<int, Tile> _fallenTiles;
        
        public GameGridController(IGameGrid gameGrid)
        {
            _gameGrid = gameGrid;
            _collisionDetector = (ICollisionDetector)new CollisionDetector();
            _fallenTiles = new Dictionary<int, Tile>();

            GameTimer = new DispatcherTimer();
            GameTimer.Interval = TimeSpan.FromMilliseconds(800);
            GameTimer.Tick += new EventHandler(TetrisTick);
        }

        private void TetrisTick(object sender, EventArgs e)
        {
            ClearShape(_fallingShape);
            MoveDown();
            PaintShape(_fallingShape);
        }

        public void RotateClockwise()
        {
            if (!_collisionDetector.CollisionRotatingClockwise(_fallingShape, _fallenTiles))
            {

                ClearShape(_fallingShape);
                _fallingShape.RotateClockWise();
                PaintShape(_fallingShape);
            }
        }

        private void RotateAntiClockwise()
        {
            if (!_collisionDetector.CollisionRotatingAntiClockwise(_fallingShape, _fallenTiles))
                _fallingShape.RotateAntiClockWise();
        }
        
        private void MoveDown()
        {
            if (!_collisionDetector.CollisionMovingDown(_fallingShape, _fallenTiles))
            {
                _fallingShape.MoveDown();
            }
            else
            {
                foreach(var tile in _fallingShape.Tiles)
                {
                    if (_fallenTiles.ContainsKey(tile.Position.Index))
                    {
                        GameTimer.Stop();
                        return;
                    }

                    _fallenTiles.Add(tile.Position.Index, tile);
                }
                PaintFallenTiles();
                _fallingShape = ShapeFactory.GetRandomShape();
            }
        }

        public void MoveLeft()
        {
            if (!_collisionDetector.CollisionMovingLeft(_fallingShape, _fallenTiles))
            {
                ClearShape(_fallingShape);
                _fallingShape.MoveLeft();
                PaintShape(_fallingShape);
            }
        }

        public void MoveRight()
        {
            if (!_collisionDetector.CollisionMovingRight(_fallingShape, _fallenTiles))
            {
                ClearShape(_fallingShape);
                _fallingShape.MoveRight();
                PaintShape(_fallingShape);
            }
        }

        private void PaintFallenTiles()
        {
            foreach (var entry in _fallenTiles)
            {
                var tile = entry.Value;
                _gameGrid.PaintTile(tile.Position, GetColour(tile.Colour));
            }
        }
        
        private void PaintShape(Shape shape)
        {
            foreach (var tile in shape.Tiles)
            {
                _gameGrid.PaintTile(tile.Position, GetColour(shape.Colour));
            }
        }

        private void ClearShape(Shape shape)
        {
            foreach (var tile in shape.Tiles)
            {
                _gameGrid.ClearTile(tile.Position);
            }
        }

        public void StartGame()
        {
            _fallingShape = ShapeFactory.GetRandomShape();
            GameTimer.Start();
        }

        private Color GetColour(Colour colour)
        {
            switch (colour)
            {
                case Colour.Blue: return Colors.Blue;
                case Colour.Green: return Colors.Green;
                case Colour.Orange: return Colors.Orange;
                case Colour.Red: return Colors.Red;
                case Colour.Yellow: return Colors.Yellow;
            }

            return Colors.Blue;
        }
    }
}
