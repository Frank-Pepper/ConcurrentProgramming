using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Data
{
    public interface IAbstractDataAPI
    {
        public static IBall GetBall(Double x, Double y, Double vx, Double vy, Double width, Double height)
        {
            return new Ball(x, y, vx, vy, width, height);
        }

        public static IBallRepository GetBallRepository()
        {
            return new BallRepository();
        }

        private class Ball : IBall
        {
            public Double X { get; set; }
            public Double Y { get; set; }
            private Double VX;
            private Double VY;
            private Double W;
            private Double H;
            public Ball(Double x, Double y, Double vx, Double vy, Double width, Double height)
            {
                X = x;
                Y = y;
                VX = vx; 
                VY = vy;
                W = width;
                H = height;
            }
            public Tuple<Double, Double> GetPosition()
            {
                return Tuple.Create(X, Y);
            }
            public void Move()
            {
                X += VX;
                Y += VY;
                if (X > W || X < 0)
                {
                    VX = - VX;
                }
                if (Y > H || Y < 0)
                {
                    VX -= VX;
                }
            }
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
