﻿using System;
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
        
        public GameGridController(IGameGrid gameGrid)
        {
            _gameGrid = gameGrid;
            _collisionDetector = (ICollisionDetector)new CollisionDetector();
            _fallenTiles = (IFallenTiles)new FallenTiles();
            

            GameTimer = new DispatcherTimer();
            GameTimer.Interval = TimeSpan.FromMilliseconds(800);
            GameTimer.Tick += new EventHandler(TetrisTick);
        }

        private void TetrisTick(object sender, EventArgs e)
        {
            MoveDown();
        }

        //private void RotateAntiClockwise()
        //{
        //    if (!_collisionDetector.CollisionRotatingAntiClockwise(_fallingShape, _fallenTiles))
        //        _fallingShape.RotateAntiClockWise();
        //}
        
        private void MoveDown()
        {
            if(!MoveIfPossible(() => _fallingShape.MoveDown(), _collisionDetector.CollisionMovingDown))
            {
                foreach(var tile in _fallingShape.Tiles)
                {
                    if (_fallenTiles.Has(tile))
                    {
                        GameTimer.Stop();
                        return;
                    }

                    _fallenTiles.Add(tile);
                }

                ClearFallenTiles();
                _fallenTiles.RemoveCompletedRowIfRequired(_fallingShape, GridDimensions.MaxXValue);
                PaintFallenTiles();
                _fallingShape = ShapeFactory.GetRandomShape();
            }
        }

        public void SpeedDescent()
        {
            GameTimer.Interval = TimeSpan.FromMilliseconds(400);
            MoveDown();
        }

        public void SlowDescent()
        {
            GameTimer.Interval = TimeSpan.FromMilliseconds(800);
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
