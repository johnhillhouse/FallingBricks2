﻿using System;
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
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            this.KeyUp += new KeyEventHandler(OnButtonKeyUp);
        }

        private void OnButtonKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
                gameView.SlowDescent();
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right: gameView.MoveRight();
                    break;
                case Key.Left: gameView.MoveLeft();
                    break;
                case Key.Up: gameView.RotateClockwise();
                    break;
                case Key.Down: gameView.SpeedDescent();
                    break;
            }
        }
    }
}
