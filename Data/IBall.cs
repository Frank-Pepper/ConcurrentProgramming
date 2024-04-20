using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class IBall : IDisposable
    {
        public virtual Double R { get; set; }
        public virtual Double X { get; set; }
        public virtual Double Y { get; set; }
        private Double VX { get; set; }
        private Double VY { get; set; }
        public abstract void SetPosition(Double x, Double y);
        public abstract void SetVelocity(Double vx, Double vy);
        public abstract Tuple<Double, Double> GetPosition();
        public abstract Tuple<Double, Double> GetVelocity();

        public abstract void notify();
        public abstract void Dispose();
    }
}
