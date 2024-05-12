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
        public abstract Vector2 GetPosition();
        public abstract Vector2 GetVeolcity();
        public abstract void SetVelocity(Vector2 sped);
        public abstract event EventHandler<EventArgs>? ChangedPosition;
        public abstract void StartMoving();
        public abstract void Move();
        public abstract void CheckPosition();
        public abstract void Notify();
        public abstract void Dispose();
    }
}
