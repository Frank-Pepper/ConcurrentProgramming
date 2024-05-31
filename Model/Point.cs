using System.ComponentModel;
using System.Numerics;

namespace Presentation.Model
{
    internal class Point : IPoint
    {
        public Vector2 Position { get; set; }
        private Double XScale {get; set;}
        private Double YScale { get; set;}
        public Point() { }
        public Point(float _x, float _y) { Position = new Vector2(_x, _y); XScale = 1; YScale = 1; }
        public Double X { get => Position.X * XScale; }
        public Double Y { get => Position.Y * YScale; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetXScale(Double scale)
        {
            XScale = scale;
        }
        public void SetYScale(Double scale)
        {
            YScale = scale;
        }
        public void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        public void SetPosition(Vector2 pos)
        {
            Position = pos;
            NotifyPropertyChanged(nameof(X));
            NotifyPropertyChanged(nameof(Y));
        }
    }
}
