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
        private readonly Action<Vector2>? _subscriber;
        public LogicBallEvent(Vector2 pos, Action<Vector2>? subscriber)
        {
            Position = pos;
            _subscriber = subscriber;
        }
        public override void SetPosition(Vector2 pos)
        {
            Position = pos;
            _subscriber?.Invoke(pos);
        }

        public override void Dispose()
        {
            Debug.WriteLine("HEHE logika here");
        }
    }
}