using System.ComponentModel;
using System.Numerics;

namespace Presentation.Model
{
    internal class Point : IPoint
    {
        public Vector2 Position { get; set; }
        public Double Xx { get; set; }
        public Double Yy { get; set; }
        public Point() { }
        public Point(float _x, float _y) { Position = new Vector2(_x, _y); }

        public Double X { get => Position.X; }
        public Double Y { get => Position.Y; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        public void SetPosition(Vector2 pos)
        {
            //Xx = pos.X;
            //Yy = pos.Y;
            Position = pos;
            NotifyPropertyChanged(nameof(X));
            NotifyPropertyChanged(nameof(Y));
        }
    }
}
