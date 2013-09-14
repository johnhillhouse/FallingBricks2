using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallingBricks2.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace FallingBricks2.Controller
{
    public class GameGridController
    {
        private IGameGrid _gameGrid;
        private Shape _activeShape;
        private DispatcherTimer GameTimer { get; set; }
        
        public GameGridController(IGameGrid gameGrid)
        {
            _gameGrid = gameGrid;
            _activeShape = ShapeFactory.GetRandomShape();

            GameTimer = new DispatcherTimer();
            GameTimer.Interval = TimeSpan.FromMilliseconds(800);
            GameTimer.Tick += new EventHandler(TetrisTick);
        }

        private void TetrisTick(object sender, EventArgs e)
        {
            ClearShape();
            MoveDown();
            PaintShape();
        }

        private void MoveDown()
        {
            if(!Collision())
                _activeShape.MoveDown();
        }

        private void PaintShape()
        {

            foreach (var tile in _activeShape.Tiles)
            {
                _gameGrid.PaintShape(tile.Position, GetColour(_activeShape.Colour));
            }
        }

        private void ClearShape()
        {
            foreach (var tile in _activeShape.Tiles)
            {
                _gameGrid.ClearShape(tile.Position);
            }
        }

        private bool Collision()
        {
            if (_activeShape.Tiles[0].Position.Y >= _gameGrid.MaxYValue - 1 ||
                _activeShape.Tiles[1].Position.Y >= _gameGrid.MaxYValue - 1 ||
                _activeShape.Tiles[2].Position.Y >= _gameGrid.MaxYValue - 1 ||
                _activeShape.Tiles[3].Position.Y >= _gameGrid.MaxYValue - 1)
                return true;

            return false;
        }

        public void StartGame()
        {
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
