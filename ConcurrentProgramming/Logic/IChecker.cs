using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Logic
{
    internal interface IChecker
    {
        void Check(List<IBall> Balls);
    }
}
