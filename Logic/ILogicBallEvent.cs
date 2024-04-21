using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{
    public interface ILogicBallEvent : IDisposable
    {
        void SetPosition(Double x, Double y);
    }
}
