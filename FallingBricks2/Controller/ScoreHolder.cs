using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FallingBricks2.Controller
{
    public class ScoreHolder : INotifyPropertyChanged
    {
        private const int _multiple = 50;
        public const string NamePropertyName = "Score";
        private static int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score += value * _multiple;
                RaisePropertyChanged(NamePropertyName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(propertyName));

            }
        }

        private static ScoreHolder _instance;
        private static object syncLock = new object();

        public static ScoreHolder GetScoreHolder()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ScoreHolder();
                    }
                }
            }

            return _instance;
        }

        private ScoreHolder()
        {
            _score = 0;
        }
    }
}
