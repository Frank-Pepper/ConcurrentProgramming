using System;
using System.Collections.Generic;
using System.Text;


namespace Data
{
    public abstract class LoggerApi : IDisposable
    {
        public abstract void AddBallToQueue(BallData ball);
        public abstract void Dispose();
    }
}
