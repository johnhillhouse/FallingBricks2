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
            PaintShape();
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
                var uiTile = grid.Children.Cast<Control>().Where(e => Grid.GetRow(e) == tile.TopLeftPoint.Y && Grid.GetColumn(e) == tile.TopLeftPoint.X).Single();
                uiTile.Background = new SolidColorBrush(Colors.DarkKhaki);
                //uiTile.Background = new SolidColorBrush(shape.Colour);
            }
            
            //foreach (Part p in Tetris.CurrentBlock.Parts)
            //{
            //    var __uiPart = grid.Children.Cast<Control>().Where(e => Grid.GetRow(e) == p.PosY && Grid.GetColumn(e) == p.PosX).Single();
            //    __uiPart.Background = new SolidColorBrush(p.ParentBlock.Color);
            //}
        }
    }
}
