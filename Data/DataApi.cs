using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Data
{
    internal class DataApi : IDataAPI
    {
        public static readonly Logger _logger = Logger.GetInstance();
        public IBall GetBall(int r, int mass, int id, Vector2 pos, Vector2 sped)
        {
            return new Ball(r, mass, id, pos, sped);
        }
        public ITable GetTable(int width, int height)
        {
            return new Table(width, height);
        }
    }
}
