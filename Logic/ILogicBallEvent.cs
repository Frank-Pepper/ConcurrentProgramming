using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Logic
{
    public abstract class ILogicBallEvent : IDisposable
    {
        public abstract Vector2 Position { get; set; }
        public abstract Vector2 Speed { get; set; }
        public abstract void Dispose();
        public abstract void SetValues(Object s, EventArgs e);
    }
}
