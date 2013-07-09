using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace FallingBricks2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RunGame();
        }

        private void RunGame()
        {
            var shape = ShapeFactory.GetRandomShape();
            DrawShape(shape);
            Thread.Sleep(10000);
            ClearShape(shape);
            shape.RotateClockWise();
            DrawShape(shape);
        }

        private void DrawShape(Shape shape)
        {
            foreach (var tile in shape.Tiles)
            {
                Rectangle rect = new Rectangle { Width = tile.Width, Height = tile.Height, Fill = GetBrush(shape.Colour) };
                board.Children.Add(rect);
                Canvas.SetLeft(rect, tile.TopLeftPoint.X);
                Canvas.SetTop(rect, tile.TopLeftPoint.Y);
            }
        }

        private void ClearShape(Shape shape)
        {
            foreach (var tile in shape.Tiles)
            {
                Rectangle rect = new Rectangle { Width = tile.Width, Height = tile.Height, Fill = Brushes.White };
                board.Children.Add(rect);
                Canvas.SetLeft(rect, tile.TopLeftPoint.X);
                Canvas.SetTop(rect, tile.TopLeftPoint.Y);
            }
        }
        
        private SolidColorBrush GetBrush(Colour colour)
        {
            switch (colour)
            {
                case Colour.Blue: return Brushes.Blue;
                case Colour.Green: return Brushes.Green;
                case Colour.Orange: return Brushes.Orange;
                case Colour.Red: return Brushes.Red;
                case Colour.Yellow: return Brushes.Yellow;
                default: return Brushes.Brown;
            }
        }
    }
}
