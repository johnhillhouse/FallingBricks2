using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FallingBricks2.Controller;

namespace FallingBricks2.View.Controls
{
    public interface IGameGrid
    {
        void PaintTile(Point tilePosition, Color colour);
        void ClearTile(Point tilePosition);
        void AlertUser(string alert);
        void ChangeScore(int score);
    }

    public static class GridDimensions
    {
        public static int MinYValue;
        public static int MaxYValue;
        public static int MinXValue;
        public static int MaxXValue;
        public static int NumberXColumns;        
    }

    public partial class GameGrid : UserControl, IGameGrid
    {
        private IGameGridController _controller;
        public GameGrid()
        {
            InitializeComponent();
            _controller = (IGameGridController)new GameGridController((IGameGrid)this);
            PopulateGridWithBackgroundTiles();
            GridDimensions.NumberXColumns = this.grid.ColumnDefinitions.Count();
            GridDimensions.MaxXValue = GridDimensions.NumberXColumns - 1;
            GridDimensions.MinXValue = 0;
            GridDimensions.MaxYValue = this.grid.RowDefinitions.Count();
            GridDimensions.MinYValue = 1;
        }

        private void PopulateGridWithBackgroundTiles()
        {
            for (int i = 0; i < grid.RowDefinitions.Count(); i++)
            {
                for (int j = 0; j < grid.ColumnDefinitions.Count(); j++)
                {
                    //Create a new label as "part" and add it to the grid
                    Label label = new Label {
                        Background = new SolidColorBrush(Colors.Transparent),
                        BorderBrush = new SolidColorBrush(Colors.Transparent),
                        BorderThickness = new Thickness(1.0)
                    };
                    grid.Children.Add(label);
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                }
            }
        }

        public void PaintTile(Point tilePosition, Color colour)
        {
            ((Control)grid.Children[tilePosition.Index]).Background = new SolidColorBrush(colour);
        }

        public void ClearTile(Point tilePosition)
        {
            ((Control)grid.Children[tilePosition.Index]).Background = new SolidColorBrush(Colors.Transparent);
        }

        public void MoveRight()
        {
            _controller.MoveRight();
        }

        public void MoveLeft()
        {
            _controller.MoveLeft();
        }

        public void RotateClockwise()
        {
            _controller.RotateClockwise();
        }

        public void SpeedDescent()
        {
            _controller.SpeedDescent();
        }

        public void SlowDescent()
        {
            _controller.SlowDescent();
        }

        public void AlertUser(string alert)
        {
            MessageBox.Show(alert);
        }

        public void StartGame()
        {
            _controller.StartGame();
        }

        public void ChangeScore(int score)
        {
            //_gameView.ChangeScore(score);
        }
    }
}
