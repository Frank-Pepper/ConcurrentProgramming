using Data;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Logic
{
    public interface IBallManager
    {
        void Create(int number, int radius, int mass, List<ILogicBallEvent> points);
        Vector2 GetTable();
        void StopBalls();
        void Reset();
    }
}