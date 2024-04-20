using System;
using System.Collections.Generic;

namespace Data
{
    public interface IBallRepository : IDisposable
    {
        List<IBall> GetAll();
        void Add(IBall b);
        void Remove(IBall b);
    }
}
