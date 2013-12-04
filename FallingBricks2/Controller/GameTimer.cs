using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FallingBricks2.Controller
{
    public class GameTimer : DispatcherTimer
    {
        private double _difficulty;
        public GameTimer()
        {
            _difficulty = 1;
            SlowDown();
        }

        //public void IncreaseDifficulty()
        //{
        //    _difficulty += (_difficulty * 3);
        //}

        public void SpeedUp()
        {
            Interval = TimeSpan.FromMilliseconds(400 - _difficulty);
        }

        public void SlowDown()
        {
            Interval = TimeSpan.FromMilliseconds(800 - _difficulty);
        }
    }
}
