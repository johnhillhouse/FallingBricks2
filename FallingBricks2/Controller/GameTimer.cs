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
        private const int _speedUpTimeSpan = 400;
        private double _difficultyIncrease;
        private double _difficulty = 1;
        private int _slowTimeSpan;
        private int _minTimeSpan = 50;

        public GameTimer(Level level)
        {
            SetLevel(level);
        }

        public void IncreaseDifficulty()
        {
            _difficulty += (_difficulty * _difficultyIncrease);
            SetInterval(Interval.Milliseconds);
        }

        public void SpeedUp()
        {
            SetInterval(Interval.Milliseconds - _speedUpTimeSpan);
        }

        public void SlowDown()
        {
            SetInterval(Interval.Milliseconds + _speedUpTimeSpan);
        }

        private void SetInterval(double milliseconds)
        {
            if (Interval.Milliseconds > _minTimeSpan)
                Interval = TimeSpan.FromMilliseconds(Interval.Milliseconds - _difficulty);
        }

        private void SetLevel(Level level)
        {
            switch(level)
            {
                case Level.Easy:
                    _slowTimeSpan = 1000;
                    _difficultyIncrease = 0.01;
                    break;
                case Level.Middle: 
                    _slowTimeSpan = 800;
                    _difficultyIncrease = 0.05;
                    break;
                case Level.Difficult: 
                    _slowTimeSpan = 600;
                    _difficultyIncrease = 0.1;
                    break;
            }
            Interval = TimeSpan.FromMilliseconds(_slowTimeSpan);
        }
    }

    public enum Level
    {
        Easy,
        Middle,
        Difficult
    }
}
