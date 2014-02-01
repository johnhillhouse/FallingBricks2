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
        void SpeedDescent();
        void SlowDescent();
    }
    
    public class GameGridController: IGameGridController
    {
        private IGameGrid _gameGrid;
        private Shape _fallingShape;
        private DispatcherTimer GameTimer { get; set; }
        private ICollisionDetector _collisionDetector;
        private IFallenTiles _fallenTiles;
        private GameTimer _gameTimer;
        private ScoreHolder _scoreHolder;
        
        public GameGridController(IGameGrid gameGrid)
        {
            _gameGrid = gameGrid;
            _collisionDetector = (ICollisionDetector)new CollisionDetector();
            _fallenTiles = (IFallenTiles)new FallenTiles();
            _gameTimer = new GameTimer();
            _gameTimer.Tick += new EventHandler(TetrisTick);
            _scoreHolder = ScoreHolder.GetScoreHolder();
        }

        private void TetrisTick(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void MoveDown()
        {
            if(!MoveIfPossible(() => _fallingShape.MoveDown(), _collisionDetector.CollisionMovingDown))
            {
                foreach(var tile in _fallingShape.Tiles)
                {
                    if (_fallenTiles.Has(tile))
                    {
                        _gameTimer.Stop();
                        _gameGrid.AlertUser("Game Over.  Score: " + _scoreHolder.Score);
                        return;
                    }

                    _fallenTiles.Add(tile);
                }

                ClearFallenTiles();
                var numberOfRowsRemoved = 0;
                _fallenTiles.RemoveCompletedRowIfRequired(_fallingShape, GridDimensions.NumberXColumns, out numberOfRowsRemoved);
                _scoreHolder.Score = numberOfRowsRemoved;
                PaintFallenTiles();
                _fallingShape = ShapeFactory.GetRandomShape();
                //_gameTimer.IncreaseDifficulty();
            }
        }

        public void SpeedDescent()
        {
            _gameTimer.SpeedUp();
            MoveDown();
        }

        public void SlowDescent()
        {
            _gameTimer.SlowDown();
            MoveDown();
        }

        public void RotateClockwise()
        {
            MoveIfPossible(() => _fallingShape.RotateClockWise(), _collisionDetector.CollisionRotatingClockwise);
        }

        public void MoveLeft()
        {
            MoveIfPossible(() => _fallingShape.MoveLeft(), _collisionDetector.CollisionMovingLeft);
        }

        public void MoveRight()
        {
            MoveIfPossible(() => _fallingShape.MoveRight(), _collisionDetector.CollisionMovingRight);
        }

        public bool MoveIfPossible(Action moveShape, Func<Shape, Dictionary<int,Tile>, bool> collisionDetected)
        {
            if (!collisionDetected(_fallingShape, _fallenTiles.Tiles))
            {
                ClearShape(_fallingShape);
                moveShape();
                PaintShape(_fallingShape);
                return true;
            }
            return false;
        }

        private void PaintFallenTiles()
        {
            foreach (var entry in _fallenTiles.Tiles)
            {
                var tile = entry.Value;
                _gameGrid.PaintTile(tile.Position, GetColour(tile.Colour));
            }
        }

        private void ClearFallenTiles()
        {
            foreach (var entry in _fallenTiles.Tiles)
            {
                var tile = entry.Value;
                _gameGrid.ClearTile(tile.Position);
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
            _gameTimer.Start();
        }

        private Color GetColour(Colour colour)
        {
            switch (colour)
            {
                case Colour.Blue: return Colors.Blue;
                case Colour.Green: return Colors.Green;
                case Colour.Orange: return Colors.Orange;
                case Colour.Red: return Colors.Red;
                case Colour.Gray: return Colors.DarkGray;
                case Colour.Purple: return Colors.Purple;
                case Colour.Brown: return Colors.Brown;
            }

            return Colors.Blue;
        }
    }
}
