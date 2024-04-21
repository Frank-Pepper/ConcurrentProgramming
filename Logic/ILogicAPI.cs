using Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public interface ILogicAPI
    {
        public static IBallManager GetBallManager(IBallRepository? ballRepository = default)
        {
            return new BallManager(ballRepository);
        }

        //public static ILogicBallEvent GetLogicBallEvent(Double x, Double y, Action<double, double> subscriber)
        //{
        //    return new LogicBallEvent(x, y, subscriber);
        //}

        public static ILogicBallEvent GetLogicBallEventSubOnly(Action<double, double>? subscriber = null)
        {
            return new LogicBallEvent(subscriber);
        }

    }
}
