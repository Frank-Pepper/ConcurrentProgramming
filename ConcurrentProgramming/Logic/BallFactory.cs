using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallFactory : IBallFactory
    {
        public BallFactory() { }

        public List<IBall> Create(int number, Double width, Double height)
        {
            Random random = new Random();
            List<IBall> list = new List<IBall>();
            Double xPosition;
            Double yPosition;
            for (int i = 0; i < number; i++)
            {
                xPosition = random.NextDouble() * width;
                yPosition = random.NextDouble() * height;
                list.Add(new Ball(xPosition, yPosition));
            }
            return list;

        }
    }
}
