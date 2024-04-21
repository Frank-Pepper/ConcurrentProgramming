using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{
    internal class LogicBallEvent : ILogicBallEvent
    {
        private Double X { get; set; }
        private Double Y { get; set; }
        private Action<Double, Double> _subscriber;
        public LogicBallEvent(Action<double, double> subscriber)
        {
            X = 0;
            Y = 0;
            _subscriber = subscriber;
        }
        public LogicBallEvent(Double x, Double y, Action<double, double> subscriber)
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
