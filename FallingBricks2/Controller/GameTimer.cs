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
        public GameTimer()
        {
            SlowDown();
        }

        public void SpeedUp()
        {
            Interval = TimeSpan.FromMilliseconds(400);
        }

        public void SlowDown()
        {
            Interval = TimeSpan.FromMilliseconds(800);
        }
    }
}
