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
        private int R;
        private Vector2 Position;
        private Vector2 Speed;
        private Boolean isRunning;
        public override event EventHandler<DataEventArgs>? ChangedPosition;

        private readonly Action<Vector2>? _subscriber;
        public Ball(int r, Vector2 pos, float vx, float vy, Action<Vector2>? subscriber)
        {
            R = r;
            Position = pos;
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
