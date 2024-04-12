using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BallChecker : IChecker
    {
        public BallChecker() { }

        void IChecker.Check(IBallRepository Balls)
        {
            List<IBall> BallsList = (List<IBall>)Balls.GetAll();
            for (int i = 0; i < BallsList.Count; i++)
            {
                int ballRadius = 0; // TODO Find nice number
                IBall thisBall = BallsList[i];
                Tuple<Double, Double> coordinates = thisBall.GetPosition();
                for (int j = i + 1; j < BallsList.Count; j++)
                {
                    IBall otherBall = BallsList[j];
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
