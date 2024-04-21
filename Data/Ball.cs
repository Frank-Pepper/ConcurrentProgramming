using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Data
{
    internal class Ball : IBall
    {
        public override Double R { get; set; }
        public override Double X { get; set; }
        public override Double Y { get; set; }
        private Double VX { get; set; }
        private Double VY { get; set; }
        private Action<Double, Double> _subscriber;
        public Ball(Double r, Double x, Double y, Double vx, Double vy, Action<Double, Double> subscriber)
        {
            R = r;
            X = x;
            Y = y;
            VX = vx;
            VY = vy;
            _subscriber = subscriber;
        }
        public override Tuple<Double, Double> GetPosition()
        {
            return Tuple.Create(X, Y);
        }

        public override void SetPosition(Double x, Double y)
        {
            X = x;
            Y = y;
        }

        public override void SetVelocity(Double vx, Double vy)
        {
            VX = vx;
            VY = vy;
        }

        public override Tuple<Double, Double> GetVelocity()
        {
            return Tuple.Create(VX, VY);
        }

        public override void notify()
        {
            if (_subscriber != null)
            {
                _subscriber(X, Y);
            }
        }
        public override void Dispose()
        {
            Debug.WriteLine("HEHE Dispose");
        }
    }
}
