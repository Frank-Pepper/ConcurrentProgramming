using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{
    public class LogicBall : IDisposable
    {
        private Double X { get; set; }
        private Double Y { get; set; }
        private Action<Double, Double> _subscriber;
        public LogicBall(Action<double, double> subscriber)
        {
            _subscriber = subscriber;
        }
        public LogicBall(Double x, Double y, Action<double, double> subscriber)
        {
            X = x;
            Y = y;
            _subscriber = subscriber;
        }
        public void SetPosition(Double x, Double y)
        {
            X = x;
            Y = y;
            _subscriber(X, Y);
        }

        public void Dispose()
        {
            Debug.WriteLine("HEHE logika here");
        }
    }
}
