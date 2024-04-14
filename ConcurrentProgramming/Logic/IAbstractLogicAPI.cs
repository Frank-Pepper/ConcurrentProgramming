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
            public BallManager(IBallRepository? ballRepository = default(IBallRepository))
            {
                _ballRepository = ballRepository ?? IAbstractDataAPI.GetBallRepository();
            }
            public void generate(int number, Double width, Double height)
            {
                Double xPosition;
                Double yPosition;
                for (int i = 0; i < number; i++)
                {
                    xPosition = _random.NextDouble() * width;
                    yPosition = _random.NextDouble() * height;
                    _ballRepository.Add(IAbstractDataAPI.GetBall(xPosition, yPosition, _random.NextDouble(), _random.NextDouble(), width, height));
                }
            }
            public void Create(int number, Double width, Double height)
            {
                Double xPosition;
                Double yPosition;
                for (int i = 0; i < number; i++)
                {
                    xPosition = _random.NextDouble() * width;
                    yPosition = _random.NextDouble() * height;
                    _ballRepository.Add(IAbstractDataAPI.GetBall(xPosition, yPosition, _random.NextDouble(), _random.NextDouble(), width, height));
                }
            }
            public void Move()
            {
                List<IBall> balls = _ballRepository.GetAll();
                for (int i = 0; i < balls.Count; i++)
                {
                    balls[i].Move();
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
