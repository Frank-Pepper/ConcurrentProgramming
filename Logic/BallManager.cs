using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallManager : IBallManager
    {
        private readonly IBallRepository _ballRepository;
        private readonly Random _random = new Random();
        private Double _width;
        private Double _height;
        private bool motion;

        private List<ILogicBallEvent> _balls;

        public BallManager(IBallRepository? ballRepository = null)
        {
            _ballRepository = ballRepository ?? IDataAPI.GetBallRepository();
            _balls = new List<ILogicBallEvent>();
        }
        public void Create(int number, Double width, Double height, List<ILogicBallEvent> points)
        {
            _width = width;
            _height = height;
            Double xPosition;
            Double yPosition;
            Double xVelocity;
            Double yVelocity;
            Double xRightLimit = width - 10;
            Double yBottomLimit = height - 10;
            _balls = points;
            for (int i = 0; i < number; i++)
            {
                xPosition = xRightLimit * _random.NextDouble();
                yPosition = yBottomLimit * _random.NextDouble();
                xVelocity = 0.5 * (_random.Next(0, 2) * 2 - 1);
                yVelocity = 0.5 * (_random.Next(0, 2) * 2 - 1);
                _ballRepository.Add(IDataAPI.GetBall(10, xPosition, yPosition, xVelocity, yVelocity, _balls[i].SetPosition));
            }
        }
        public void Move()
        {
            if (motion)
            {
                return;
            }

            motion = true;
            List<IBall> balls = _ballRepository.GetAll();

            foreach (IBall ball in balls)
            {
                Task.Run(() =>
                {
                    while (motion)
                    {
                        MoveBall(ball);
                        Thread.Sleep(5);
                    }
                });
            }
        }
        public void MoveBall(IBall ball)
        {
            double newX;
            double newY;
            double newVX;
            double newVY;
            double x = ball.GetPosition().Item1;
            double y = ball.GetPosition().Item2;
            double vx = ball.GetVelocity().Item1;
            double vy = ball.GetVelocity().Item2;

            newX = x + vx;
            newY = y + vy;


            if (newX < 0 || newX > _width - 10)
            {
                newX = x - vx;
                newVX = -vx;
            }
            else
            {
                newVX = vx;
            }

            if (newY < 0 || newY > _height - 10)
            {
                newY = y - vy;
                newVY = -vy;
            }
            else
            {
                newVY = vy;
            }

            ball.SetPosition(newX, newY);
            ball.SetVelocity(newVX, newVY);
            ball.Notify();
        }
        public void StopBalls()
        {
            motion = false;
        }
        public void Reset()
        {
            motion = false;
            _ballRepository.Dispose();
        }
    }
}
