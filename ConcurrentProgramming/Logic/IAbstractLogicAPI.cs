using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Logic
{
    public interface IAbstractLogicAPI
    {
        public static IBallManager GetBallManager(IBallRepository? ballRepository = default)
        {
            return new BallManager(ballRepository);
        }

        private class BallManager : IBallManager
        {
            private readonly IBallRepository _ballRepository;
            private readonly Random _random = new Random();
            private Double _width;
            private Double _height;
            public BallManager(IBallRepository? ballRepository = default(IBallRepository))
            {
                _ballRepository = ballRepository ?? IAbstractDataAPI.GetBallRepository();
            }
            public void Create(int number, Double width, Double height)
            {
                _width = width;
                _height = height;
                Double xPosition;
                Double yPosition;
                Double xLeftLimit = width + 10;
                Double xRightLimit = width - 10;
                Double yTopLimit = height + 10;
                Double yBottomLimit = height - 10;

                for (int i = 0; i < number; i++)
                {
                    xPosition = xLeftLimit + (xRightLimit - xLeftLimit) * _random.NextDouble();
                    yPosition = yTopLimit + (yBottomLimit - yTopLimit) * _random.NextDouble();
                    _ballRepository.Add(IAbstractDataAPI.GetBall(10, xPosition, yPosition, _random.NextDouble(), _random.NextDouble()));
                }
            }
            public void Move()
            {
                List<IBall> balls = _ballRepository.GetAll();
                Tuple<Double, Double> coordinates;
                Tuple<Double, Double> velocity;
                Double newX;
                Double newY;
                Double newVX;
                Double newVY;
                for (int i = 0; i < balls.Count; i++)
                {
                    coordinates = balls[i].GetPosition();
                    velocity = balls[i].GetVelocity();
                    if(coordinates.Item1 + velocity.Item1 > _width || coordinates.Item1 + velocity.Item1 < 10)
                    {
                        newX = coordinates.Item1 - velocity.Item1;
                        newVX = velocity.Item1 * (-1);
                        balls[i].SetPositionX(newX);
                        balls[i].SetVelocityX(newVX);

                    }
                    if(coordinates.Item2 + velocity.Item2 > _height || coordinates.Item2 + velocity.Item2 < 10)
                    {
                        newY = coordinates.Item2 - velocity.Item2;
                        newVY = velocity.Item2 * (-1);
                        balls[i].SetPositionX(newY);
                        balls[i].SetVelocityX(newVY);
                    }
                }
            }
            public void Reset()
            {
                _ballRepository.Dispose();
            }

            public List<Tuple<double, double>> GetCoordinates()
            {
                List<IBall> balls = _ballRepository.GetAll();
                List<Tuple<Double, Double>> coords = new List<Tuple<double, double>>();
                for (int i = 0; i < balls.Count; i++)
                {
                    coords.Add(balls[i].GetPosition());
                }
                return coords;
            }
        }
    }
}
