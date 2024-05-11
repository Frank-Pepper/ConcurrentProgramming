using System.ComponentModel;
using System.Numerics;

namespace Presentation.Model
{
    internal class Point : IPoint
    {
        public Double Xx { get; set; }
        public Double Yy { get; set; }
        public Point() { }
        public Point(Double _x, Double _y) { Xx = _x; Yy = _y; }

        public Double X { get => Xx; }
        public Double Y { get => Yy; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        public void SetPosition(Vector2 pos)
        {
            Xx = pos.X;
            Yy = pos.Y;
            NotifyPropertyChanged(nameof(X));
            NotifyPropertyChanged(nameof(Y));
        }
    }
}
