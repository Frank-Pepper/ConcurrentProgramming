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
        private int Mass { get; }
        private int Id { get; }
        private long PrevTime;
        private Vector2 Position { get; set; }
        private Vector2 Speed { get; set; }
        private Boolean IsRunning { get; set; }
        private readonly Object lockObject = new Object();
        private readonly LoggerApi? Logger;
        public Ball(int r, int mass, int id, Vector2 pos, Vector2 sped, LoggerApi? logger = null)
        {
            R = r;
            Mass = mass;
            Id = id;
            Position = pos;
            Speed = sped;
            IsRunning = true;
            Logger = logger;
            PrevTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Thread thread = new Thread(StartMoving)
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void StartMoving()
        {
            while(IsRunning)
            {
                ChangedPosition?.Invoke(this, new EventArgs());
                Move();
                Logger?.AddBallToQueue(new BallData(Position, Speed, PrevTime, Id));
                Thread.Sleep(1);
            }
        }

        private void Move() 
        {
            long CurrentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Position += Speed * (CurrentTime - PrevTime);
            PrevTime = CurrentTime;
        }
        public override event EventHandler<EventArgs>? ChangedPosition;
        public override int GetId() { return Id; }
        public override int GetR() {  return R; }
        public override int GetM() {  return Mass; }
        public override Vector2 GetPosition() { return Position; }
        public override Vector2 GetVelocity() 
        { 
            lock(lockObject)
            {
                return Speed;
            }
        }
        public override void SetVelocity(Vector2 sped) 
        { 
            lock (lockObject)
            {
                Speed = sped;
            }
        }
        public override void Dispose()
        {
            IsRunning = false;
            //this.Dispose();
            Debug.WriteLine("HEHE Dispose");
        }
    }
}
