using Data;
using System;
using System.Collections.Generic;
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

            public void Create(int number, Double width, Double height)
            {
                Double xPosition;
                Double yPosition;
                for (int i = 0; i < number; i++)
                {
                    xPosition = _random.NextDouble() * width;
                    yPosition = _random.NextDouble() * height;
                    _ballRepository.Add(IAbstractDataAPI.GetBall(xPosition, yPosition));
                }
            }
            public void Reset()
            {
                _ballRepository.Dispose();
            }
        }
    }
}
