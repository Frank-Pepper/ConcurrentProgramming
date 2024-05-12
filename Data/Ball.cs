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
        private int R { get; }
        private Vector2 Position { get; set; }
        private Vector2 Speed { get; set; }
        private Boolean isRunning { get; set; }
        private Object lockObject = new Object();
        public override event EventHandler<EventArgs>? ChangedPosition;

        private readonly Action<Vector2>? _subscriber;
        public Ball(int r, Vector2 pos, Vector2 sped, Action<Vector2>? subscriber)
        {
            R = r;
            Position = pos;
            Speed = sped;
            _subscriber = subscriber;
            isRunning = true;
            Thread thread1 = new Thread(StartMoving);
            thread1.Start();
            Thread thread2 = new Thread(CheckPosition);
            thread2.Start();
        }

        public override void StartMoving()
        {
            while(isRunning)
            {
                lock (lockObject)
                {
                    Move();
                }
                Notify();
                Thread.Sleep(5);
            }
        }

        public override void Move()
        {
            Position += Speed;
        }
        public override void CheckPosition()
        {
            while (isRunning)
            {
                lock (lockObject)
                {
                    ChangedPosition?.Invoke(this, new EventArgs());
                }
                Thread.Sleep(5);
            }
        }
        public override Vector2 GetPosition()
        {
            return Position;
        }
        public override Vector2 GetVeolcity()
        {
            return Speed;
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
            isRunning = false;
            //this.Dispose();
            Debug.WriteLine("HEHE Dispose");
        }
    }
}
