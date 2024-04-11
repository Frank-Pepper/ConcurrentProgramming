using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Logic
{
    internal class Ball : IBall
    {
        private Double x;
        private Double y;
        private Double vx;
        private Double vy;
        public Ball(Double width, Double height)
        {
            x = width;
            y = height;

        }

        public Tuple<Double, Double> GetPosition()
        {
            return Tuple.Create(x, y);
        }
        public void Move()
        {
            x += vx;
            y += vy;
        }
    }
}
