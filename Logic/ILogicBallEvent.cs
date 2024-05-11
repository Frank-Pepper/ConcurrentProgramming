using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Logic
{
    public interface ILogicBallEvent : IDisposable
    {
        void SetPosition(Vector2 pos);
    }
}
