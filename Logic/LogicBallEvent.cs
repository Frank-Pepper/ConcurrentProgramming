using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Logic
{
    internal class LogicBallEvent : ILogicBallEvent
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Speed { get; set; }
        private readonly Action<Vector2>? _subscriber;
        public LogicBallEvent(Vector2 pos, Action<Vector2>? subscriber)
        {
            Position = pos;
            _subscriber = subscriber;
        }
        public override void SetValues(Object s, EventArgs e)
        {
            IBall ball = (IBall) s;
            Position = ball.GetPosition();
            Speed = ball.GetVelocity();
            _subscriber?.Invoke(Position);
        }
        public override void Dispose()
        {
            Debug.WriteLine("HEHE logika here");
        }
    }
}