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
    public class GameGridController
    {
        private IGameGrid _gameGrid;
        private Shape _fallingShape;
        private DispatcherTimer GameTimer { get; set; }
        private ICollisionDetector _collisionDetector;
        private List<Shape> _fallenShapes;
        
        public GameGridController(IGameGrid gameGrid)
        {
            _gameGrid = gameGrid;
            _collisionDetector = (ICollisionDetector)new CollisionDetector(_gameGrid.MaxYValue);
            _fallenShapes = new List<Shape>();

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

        private void MoveDown()
        {
            if (!_collisionDetector.CollisionDown(_fallingShape, _fallenShapes))
            {
                _fallingShape.MoveDown();
            }
            else
            {
                var clonedShape = _fallingShape.Clone();
                _fallenShapes.Add(clonedShape);
                PaintFallenShapes();
                _fallingShape = ShapeFactory.GetRandomShape();
            }
        }

        private void PaintFallenShapes()
        {
            foreach (var shape in _fallenShapes)
            {
                PaintShape(shape);
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
