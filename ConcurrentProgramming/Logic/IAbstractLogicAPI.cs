using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Logic
{
    public interface IAbstractLogicAPI
    {
        public static IBallManager GetBallManager(IBallRepository? ballRepository = default(IBallRepository))
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
            public void generate(ObservableCollection<IBall> colection, int number, Double width, Double height)
            {
                Double xPosition;
                Double yPosition;
                for (int i = 0; i < number; i++)
                {
                    xPosition = _random.NextDouble() * width;
                    yPosition = _random.NextDouble() * height;
                    colection.Add(IAbstractDataAPI.GetBall(xPosition, yPosition, _random.NextDouble(), _random.NextDouble(), width, height));
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
                IEnumerator<IBall> balls = (IEnumerator<IBall>)_ballRepository.GetAll();
                while (balls.MoveNext())
                {
                    balls.Current.Move();
                }
            }
            public void Reset()
            {
                _ballRepository.Dispose();
            }
        }
    }
}
