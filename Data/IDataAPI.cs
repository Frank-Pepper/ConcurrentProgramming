using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Data
{
    public interface IDataAPI
    {
        public abstract IBall GetBall(int r, int mass, int id, Vector2 pos, Vector2 sped, LoggerApi? logger = null);
        public abstract ITable GetTable(int width, int height);
        public abstract LoggerApi GetBallLoger();
        public  static IDataAPI GetDataApi()
        {
            return new DataApi();
        }
    }
}
