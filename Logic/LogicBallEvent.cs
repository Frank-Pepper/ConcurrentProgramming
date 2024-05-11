using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Logic
{
    internal class LogicBallEvent : ILogicBallEvent
    {
        private Vector2 Position;
        private readonly Action<Vector2>? _subscriber;
        public LogicBallEvent(Action<Vector2>? subscriber)
        {
            Position = new Vector2(0, 0);
            _subscriber = subscriber;
        }
        //public LogicBallEvent(Double x, Double y, Action<double, double> subscriber)
        //{
        //    X = x;
        //    Y = y;
        //    _subscriber = subscriber;
        //}
        public void SetPosition(Vector2 pos)
        {
            Position = pos;
            _subscriber?.Invoke(pos);
        }

        public void Dispose()
        {
            Debug.WriteLine("HEHE logika here");
        }
    }
}