using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Logic
{
    public interface IChecker
    {
        void Check(IBallRepository Balls);
    }
}
