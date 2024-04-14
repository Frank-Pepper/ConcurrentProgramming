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
                Double xLeftLimit = 10;
                Double xRightLimit = width - 10;
                Double yTopLimit = 10;
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
                double newX;
                double newY;
                double newVX;
                double newVY;
                foreach (IBall ball in balls)
                {
                    double x = ball.GetPosition().Item1;
                    double y = ball.GetPosition().Item2;
                    double vx = ball.GetVelocity().Item1;
                    double vy = ball.GetVelocity().Item2;

                    newX = x + vx;
                    newY = y + vy;

                    
                    if (newX < 10 || newX > _width - 10)
                    {
                        newX = x - vx; 
                        newVX = -vx; 
                    }
                    else
                    {
                        newVX = vx; 
                    }

                    if (newY < 10 || newY > _height - 10)
                    {
                        newY = y - vy; 
                        newVY = -vy; 
                    }
                    else
                    {
                        newVY = vy; 
                    }

                    ball.SetPosition(newX, newY);
                    ball.SetVelocity(newVX, newVY);
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
