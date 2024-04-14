using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ball : IBall
    {
        private Double X;
        private Double Y;
        private Double VX;
        private Double VY;
        public Ball(Double x, Double y)
        {
            X = x;
            Y = y;

        }
        public Tuple<Double, Double> GetPosition()
        {
            return Tuple.Create(X, Y);
        }
        public void Move()
        {
            X += VX;
            Y += VY;
        }
    }
}
