using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    internal class Ball : IBall
    {
        public override Double R { get; set; }
        public override Vector2 Position { get; set; }
        public override Vector2 Speed { get; set; }
        public override Boolean isRunning { get; set; }
        public override event EventHandler<DataEventArgs>? ChangedPosition;

        private readonly Action<Vector2>? _subscriber;
        public Ball(Double r, float x, float y, float vx, float vy, Action<Vector2>? subscriber)
        {
            R = r;
            Position = new Vector2(x, y);
            Speed = new Vector2(vx, vy);
            _subscriber = subscriber;
            isRunning = true;
            Task.Run(StartMoving);
        }

        public override void StartMoving()
        {
            while(isRunning)
            {
                Move();
                Thread.Sleep(5);
                Notify();
            }
        }

        public override void Move()
        {
            Position += Speed;
            DataEventArgs args = new DataEventArgs(Position, Speed, SetPosition, SetVelocity, Dispose);
            ChangedPosition?.Invoke(this, args);
        }
        private void SetPosition(Vector2 pos)
        {
            Position = pos;
        }

        private void SetVelocity(Vector2 sped)
        {
            Speed = sped;
        }
        public override void Notify()
        {
            _subscriber?.Invoke(Position);
        }
        public override void Dispose()
        {
            isRunning = false;
            //this.Dispose();
            Debug.WriteLine("HEHE Dispose");
        }
    }
}
