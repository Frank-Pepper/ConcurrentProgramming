using Data;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public interface ILogicAPI
    {
        public static IBallManager GetBallManager(IDataAPI? DataApi = default)
        {
            return new BallManager(DataApi);
        }
        public static ILogicBallEvent GetLogicBallEventSubOnly(Action<Vector2>? subscriber = null)
        {
            return new LogicBallEvent(subscriber);
        }

    }
}
