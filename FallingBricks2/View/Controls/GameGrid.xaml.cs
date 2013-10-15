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
    }

    public static class GridDimensions
    {
        public static int MaxYValue;
        public static int MinXValue;
        public static int MaxXValue;
    }

    public partial class GameGrid : UserControl, IGameGrid
    {
        private IGameGridController _controller;
        public GameGrid()
        {
            InitializeComponent();
            _controller = (IGameGridController)new GameGridController((IGameGrid)this);
            PopulateGridWithBackgroundTiles();
            GridDimensions.MaxXValue = this.grid.ColumnDefinitions.Count();
            GridDimensions.MinXValue = 1;
            GridDimensions.MaxYValue = this.grid.RowDefinitions.Count();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _controller.StartGame();
        }
    }
}
