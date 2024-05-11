using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Data
{
    public interface IDataAPI
    {
        public abstract IBall GetBall(float r, float x, float y, float vx, float vy, Action<Vector2>? _subscriber = null);
        public  static IDataAPI GetDataApi()
        {
            return new DataApi();
        }
    }
}
