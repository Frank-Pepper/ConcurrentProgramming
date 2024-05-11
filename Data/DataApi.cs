using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Data
{
    internal class DataApi : IDataAPI
    {
        public IBall GetBall(int r, Vector2 pos, float vx, float vy, Action<Vector2>? _subscriber = null)
        {
            return new Ball(r, pos, vx, vy, _subscriber);
        }
    }
}
