using Data;
using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IBallManager
    {
        void Create(int number, Double width, Double height, List<ILogicBallEvent> points);
        void Move();
        void MoveBall(IBall ball);
        void StopBalls();
        void Reset();
    }
}