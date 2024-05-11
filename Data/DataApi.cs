using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Data
{
    internal class DataApi : IDataAPI
    {
        public IBall GetBall(float r, float x, float y, float vx, float vy, Action<Vector2>? _subscriber = null)
        {
            return new Ball(r, x, y, vx, vy, _subscriber);
        }
    }
}
