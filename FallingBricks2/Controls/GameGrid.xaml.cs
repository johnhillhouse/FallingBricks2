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

namespace FallingBricks2.Controls
{
    /// <summary>
    /// Interaction logic for GameGrid.xaml
    /// </summary>
    public partial class GameGrid : UserControl
    {
        private Shape _currentShape;
        private DispatcherTimer GameTimer { get; set; }
        public GameGrid()
        {
            InitializeComponent();

            // Setting up game timer
            GameTimer = new DispatcherTimer();
            GameTimer.Interval = TimeSpan.FromMilliseconds(800);
            GameTimer.Tick += new EventHandler(TetrisTick);

            _currentShape = ShapeFactory.GetRandomShape();
        }

        private void TetrisTick(object sender, EventArgs e)
        {
            ClearShape();
            _currentShape.MoveDown();
            PaintShape();
        }

        private void StartGame()
        {
            PopulateGridWithBackgroundTiles();
            GameTimer.Start();
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

        private void PaintShape()
        {

            foreach (var tile in _currentShape.Tiles)
            {
                var uiTile = (Control)grid.Children[GetGridIndex(tile.Position)];
                uiTile.Background = new SolidColorBrush(GetColour(_currentShape.Colour));
            }
        }

        private void ClearShape()
        {

            foreach (var tile in _currentShape.Tiles)
            {
                var uiTile = (Control)grid.Children[GetGridIndex(tile.Position)];
                uiTile.Background = new SolidColorBrush(Colors.Transparent);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
    }
}
