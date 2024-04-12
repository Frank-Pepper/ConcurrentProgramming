using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallRepository : IBallRepository
    {
        private readonly List<IBall> _ballRepository = new List<IBall>();
        public IEnumerable<IBall> GetAll()
        {
            return new ReadOnlyCollection<IBall>(_ballRepository);
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
