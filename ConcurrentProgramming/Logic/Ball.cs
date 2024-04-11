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
        private float x;
        private float y;
        private float vx;
        private float vy;
        public Ball(float width, float height)
        {
            x = Random.NextDouble() * width;
            y = Random.NextDouble() * height;
            
        }

        public void Move()
        {
            x += vx;
            y += vy;
        }
    }
}
