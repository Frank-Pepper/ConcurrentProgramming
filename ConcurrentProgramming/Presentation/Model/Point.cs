using System.ComponentModel;

namespace Presentation.Model
{
    internal class Point : INotifyPropertyChanged
    {
        public Double _x { get; set; }
        public Double _y { get; set; }
        public Point() { }
        public Point(Double x, Double y) { _x = x; _y = y; }

        public Double X { get => _x; }
        public Double Y { get => _y; }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public void SetPosition(Double x, Double y)
        {
            _x = x;
            _y = y;
            NotifyPropertyChanged(nameof(X));
            NotifyPropertyChanged(nameof(Y));
        }
    }
}
