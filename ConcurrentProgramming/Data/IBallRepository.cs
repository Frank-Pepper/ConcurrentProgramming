using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBallRepository : IDisposable
    {
        IEnumerable<IBall> GetAll();
        void Add(IBall b);
        void Remove(IBall b);
    }
}
