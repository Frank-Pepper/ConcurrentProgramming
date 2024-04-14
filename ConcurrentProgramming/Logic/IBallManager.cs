using Data;
using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IBallManager
    {
        void Create(int number, Double width, Double height);
        void Move();
        List<Tuple<Double, Double>> GetCoordinates();
        void Reset();
    }
}