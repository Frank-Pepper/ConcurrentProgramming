using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Data
{
    internal class DataApi : IDataAPI
    {
        public IBall GetBall(int r, int mass, int id, Vector2 pos, Vector2 sped, LoggerApi? logger = null)
        {
            return new Ball(r, mass, id, pos, sped, logger);
        }
        public ITable GetTable(int width, int height)
        {
            return new Table(width, height);
        }
        public LoggerApi GetBallLoger()
        {
            return Logger.GetInstance();
        }
    }
}
