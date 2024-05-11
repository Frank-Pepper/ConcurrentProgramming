using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Data
{
    public interface IDataAPI
    {
        public static IBall GetBall(float r, float x, float y, float vx, float vy, Action<Vector2>? _subscriber = null)
        {
            return new Ball(r, x, y, vx, vy, _subscriber);
        }

        public static IBallRepository GetBallRepository()
        {
            return new BallRepository();
        }

    }
}
