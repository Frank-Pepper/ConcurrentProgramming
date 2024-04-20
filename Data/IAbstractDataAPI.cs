using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Data
{
    public interface IAbstractDataAPI
    {
        public static IBall GetBall(Double r, Double x, Double y, Double vx, Double vy, Action<Double, Double> _subscriber)
        {
            return new Ball(r, x, y, vx, vy, _subscriber);
        }

        public static IBallRepository GetBallRepository()
        {
            return new BallRepository();
        }

        private class Ball : IBall
        {
            public override Double R { get; set; }
            public override Double X { get; set; }
            public override Double Y { get; set; }
            private Double VX { get; set; }
            private Double VY { get; set; }
            private Action<Double, Double> _subscriber;
            public Ball(Double r, Double x, Double y, Double vx, Double vy, Action<Double, Double> subscriber)
            {
                R = r;
                X = x;
                Y = y;
                VX = vx; 
                VY = vy;
                _subscriber = subscriber;
            }
            public override Tuple<Double, Double> GetPosition()
            {
                return Tuple.Create(X, Y);
            }

            public override void SetPosition(Double x, Double y)
            {
                X = x;
                Y = y;
            }

            public override void SetVelocity(Double vx, Double vy)
            {
                VX = vx;
                VY = vy;
            }

            public override Tuple<Double, Double> GetVelocity()
            {
                return Tuple.Create(VX, VY);
            }
            
            public override void notify()
            {
                _subscriber(X, Y);
            }
            public override void Dispose()
            {
                Debug.WriteLine("HEHE Dispose");
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
