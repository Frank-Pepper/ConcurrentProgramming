using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Data
{
    internal readonly struct BallData
    {
        public int Id { get; }
        public Vector2 Position { get; }
        public Vector2 Speed { get; }
        public long Timestamp { get; }
        public BallData(Vector2 pos, Vector2 sped, long timestamp, int id) 
        {
            Position = pos;
            Speed = sped;
            Timestamp = timestamp;
            Id = id;
        }
    }
}
