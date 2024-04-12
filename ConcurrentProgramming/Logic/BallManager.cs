using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallManager : IBallManager
    {
        private readonly IBallRepository _ballRepository;
        private readonly IBallFactory _ballFactory;
        private readonly Random _random = new Random();
        public BallManager(IBallRepository ballRepository, IBallFactory ballFactory) 
        { 
            _ballRepository = ballRepository;
            _ballFactory = ballFactory;
        }

        public void Create(int number, Double width, Double height)
        {
            Double xPosition;
            Double yPosition;
            for (int i = 0; i < number; i++)
            {
                xPosition = _random.NextDouble() * width;
                yPosition = _random.NextDouble() * height;
                _ballRepository.Add(_ballFactory.Create(xPosition, yPosition));
            }
        }
        public void Reset()
        {
            _ballRepository.Dispose();
        }
    }
}
