using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class IBall : IDisposable
    {
        public virtual Double R { get; set; }
        public abstract Vector2 Position { get; set;}
        public abstract Vector2 Speed { get; set;}
        public abstract void SetPosition(Vector2 pos);
        public abstract void SetVelocity(Vector2 sped);
        public abstract void Notify();
        public abstract void Dispose();
    }
}
