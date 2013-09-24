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
        int MaxYValue { get; }
    }


    public partial class GameGrid : UserControl, IGameGrid
    {
        public int MaxYValue { get { return grid.RowDefinitions.Count(); } }
        public GameGrid()
        {
            InitializeComponent();
            PopulateGridWithBackgroundTiles();
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
            ((Control)grid.Children[GetGridIndex(tilePosition)]).Background = new SolidColorBrush(colour);
        }

        public void ClearTile(Point tilePosition)
        {
            ((Control)grid.Children[GetGridIndex(tilePosition)]).Background = new SolidColorBrush(Colors.Transparent);
        }

        private int GetGridIndex(Point position)
        {
            return (position.Y * 10) + position.X;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var controller = new GameGridController((IGameGrid)this);
            controller.StartGame();
        }
    }
}
