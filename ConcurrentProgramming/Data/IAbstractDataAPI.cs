using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Data
{
    public interface IAbstractDataAPI
    {
        public static IBall GetBall(Double x, Double y)
        {
            return new Ball(x, y);
        }

        public static IBallRepository GetBallRepository()
        {
            return new BallRepository();
        }

        private class Ball : IBall
        {
            private Double X;
            private Double Y;
            //private Double VX;
            //private Double VY;
            public Ball(Double x, Double y)
            {
                X = x;
                Y = y;

            }
            public Tuple<Double, Double> GetPosition()
            {
                return Tuple.Create(X, Y);
            }
            //public void Move()
            //{
                //X += VX;
                //Y += VY;
            //}
        }

        private class BallRepository : IBallRepository
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
}
