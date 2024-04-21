using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Data
{
    public interface IDataAPI
    {
        public static IBall GetBall(Double r, Double x, Double y, Double vx, Double vy, Action<Double, Double>? _subscriber = null)
        {
            return new Ball(r, x, y, vx, vy, _subscriber);
        }

        public static IBallRepository GetBallRepository()
        {
            return new BallRepository();
        }

    }
}
