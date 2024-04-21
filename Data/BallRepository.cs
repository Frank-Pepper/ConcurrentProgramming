using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class BallRepository : IBallRepository
    {
        private readonly List<IBall> _ballRepository = new List<IBall>();
        public List<IBall> GetAll()
        {
            return new List<IBall>(_ballRepository);
        }
        public void Add(IBall ball)
        {
            _ballRepository.Add(ball);
        }
        public void Remove(IBall ball)
        {
            _ballRepository.Remove(ball);
        }
        public void Dispose()
        {
            _ballRepository.Clear();
        }
    }
}
