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

            var tile = new Square();

            Rectangle rect = new Rectangle { Width = tile.Width, Height = tile.Height, Fill = GetBrush(tile) };
            board.Children.Add(rect);
            Canvas.SetLeft(rect, tile.Left);
            Canvas.SetTop(rect, tile.Top);

        }

        private SolidColorBrush GetBrush(Tile tile)
        {
            switch (tile.Colour)
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
