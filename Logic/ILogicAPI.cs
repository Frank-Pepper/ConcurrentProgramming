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
        public static IBallManager GetBallManager(int width, int height, IDataAPI? DataApi = default)
        {
            return new BallManager(width, height, DataApi);
        }
        public static ILogicBallEvent GetLogicBallEventSubOnly(Vector2 pos, Action<Vector2>? subscriber = null)
        {
            return new LogicBallEvent(pos, subscriber);
        }

    }
}
