using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Data
{
    public interface IAbstractDataAPI
    {
        public static IBall GetBall(Double r, Double x, Double y, Double vx, Double vy)
        {
            return new Ball(r, x, y, vx, vy);
        }

        public static IBallRepository GetBallRepository()
        {
            return new BallRepository();
        }

        private class Ball : IBall
        {
            public Double R { get; set; }
            public Double X { get; set; }
            public Double Y { get; set; }
            private Double VX { get; set; }
            private Double VY { get; set; }
            public Ball(Double r, Double x, Double y, Double vx, Double vy)
            {
                R = r;
                X = x;
                Y = y;
                VX = vx; 
                VY = vy;
            }
            public Tuple<Double, Double> GetPosition()
            {
                return Tuple.Create(X, Y);
            }

            public void SetPosition(Double x, Double y)
            {
                X = x;
                Y = y;
            }

            public void SetVelocity(Double vx, Double vy)
            {
                VX = vx;
                VY = vy;
            }

            public Tuple<Double, Double> GetVelocity()
            {
                return Tuple.Create(VX, VY);
            }

        }

        private class BallRepository : IBallRepository
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
}
