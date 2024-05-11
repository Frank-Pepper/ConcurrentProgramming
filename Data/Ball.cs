using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Data
{
    internal class Ball : IBall
    {
        public override Double R { get; set; }
        public override Vector2 Position { get; set; }
        public override Vector2 Speed { get; set; }
        //public override float X { get; set; }
        //public override float Y { get; set; }
        //public override Double VX { get; set; }
        //public override Double VY { get; set; }
        private readonly Action<Vector2>? _subscriber;
        public Ball(Double r, float x, float y, float vx, float vy, Action<Vector2>? subscriber)
        {
            R = r;
            Position = new Vector2(x, y);
            Speed = new Vector2(vx, vy);
            _subscriber = subscriber;
        }
        public override void SetPosition(Vector2 pos)
        {
            Position = pos;
        }

        public override void SetVelocity(Vector2 sped)
        {
            Speed = sped;
        }
        public override void Notify()
        {
            _subscriber?.Invoke(Position);
        }
        public override void Dispose()
        {
            Debug.WriteLine("HEHE Dispose");
        }
    }
}
