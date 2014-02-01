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
using FallingBricks2.Model.UI;
using System.ComponentModel;
using FallingBricks2.Controller;

namespace FallingBricks2.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : OverlayUserControl
    {
        private ScoreHolder scoreHolder = ScoreHolder.GetScoreHolder();

        public GameView()
        {
            InitializeComponent();
            this.DataContext = scoreHolder;
        }

        public int ScoreTest {get; set;}

        public void MoveRight()
        {
            gameGrid.MoveRight();
        }

        public void MoveLeft()
        {
            gameGrid.MoveLeft();
        }

        public void RotateClockwise()
        {
            gameGrid.RotateClockwise();
        }

        public void SpeedDescent()
        {
            gameGrid.SpeedDescent();
        }

        public void SlowDescent()
        {
            gameGrid.SlowDescent();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            gameGrid.StartGame();
        }
    }
}
