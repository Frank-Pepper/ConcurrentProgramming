using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallChecker : IChecker
    {
        public BallChecker() { }

        void IChecker.Check(List<IBall> Balls)
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                int ballRadius = 0; // TODO Find nice number
                IBall thisBall = Balls[i];
                Tuple<Double, Double> coordinates = thisBall.GetPosition();
                for (int j = i + 1; j < Balls.Count; j++)
                {
                    IBall otherBall = Balls[j];
                    Tuple<Double, Double> otherCoordinates = otherBall.GetPosition();
                    Double x = (coordinates.Item1 - otherCoordinates.Item1);
                    Double y = (coordinates.Item2 - otherCoordinates.Item2);
                    Double distance = x * x + y * y;
                    if (distance < (4 * ballRadius * ballRadius))
                    {
                        // TODO wait for sync change direction velocity
                    }
                }
            }
        }
    }
}
