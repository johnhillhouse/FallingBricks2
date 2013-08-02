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
                var uiTile = (Control)grid.Children[GetGridIndex(tile.Position)];
                uiTile.Background = new SolidColorBrush(GetColour(shape.Colour));
            }
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

        private int GetGridIndex(Point position)
        {
            return (position.Y * 10) + position.X;
        }
    }
}
