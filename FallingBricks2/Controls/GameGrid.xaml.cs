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

namespace FallingBricks2.Controls
{
    /// <summary>
    /// Interaction logic for GameGrid.xaml
    /// </summary>
    public partial class GameGrid : UserControl
    {
        public GameGrid()
        {
            InitializeComponent();
            PopulateGridWithBackgroundTiles();
            PaintShape();
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

        /// <summary>
        /// Draw the CurrentBlock on the grid
        /// Not a good method to get the UIElements, because the complete Grid gets iterated through)
        /// </summary>
        private void PaintShape()
        {
            var shape = ShapeFactory.GetRandomShape();

            foreach (var tile in shape.Tiles)
            {
                var uiTile = grid.Children.Cast<Control>().Where(e => Grid.GetRow(e) == tile.Position.Y && Grid.GetColumn(e) == tile.Position.X).Single();
                uiTile.Background = new SolidColorBrush(Colors.Red);
                //uiTile.Background = new SolidColorBrush(shape.Colour);
            }
        }
    }
}
