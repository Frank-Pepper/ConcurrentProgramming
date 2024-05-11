using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Data
{
    public class DataEventArgs
    {
        public Vector2 Position;
        public Vector2 Speed;
        public readonly Action<Vector2>? VeolcityUpdate;
        public readonly Action<Vector2>? PositionUpdate;
        public readonly Action? BallSmasher;


        public DataEventArgs(Vector2 pos, Vector2 sped, Action<Vector2>? changePos, Action<Vector2>? changeSpeed, Action? killBalls)
        {
            Position = pos;
            Speed = sped;
            PositionUpdate = changePos;
            VeolcityUpdate = changeSpeed;
            BallSmasher = killBalls;
        }
    }

}