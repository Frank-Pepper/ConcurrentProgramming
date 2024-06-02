using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Data
{
    internal struct BallData
    {
        public int Id;
        public Vector2 Position;
        public Vector2 Speed;
        public long Timestamp;
        public BallData(Vector2 pos, Vector2 sped, long timestamp, int id) 
        {
            Position = pos;
            Speed = sped;
            Timestamp = timestamp;
            Id = id;
        }
    }
}
