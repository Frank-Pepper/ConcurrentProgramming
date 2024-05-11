using Data;
using System;
using System.Collections.Generic;
using System.Numerics;
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
        public void Create(int number, float width, float height, List<ILogicBallEvent> points)
        {
            _width = width;
            _height = height;
            float xPosition;
            float yPosition;
            float xVelocity;
            float yVelocity;
            float xRightLimit = width - 10;
            float yBottomLimit = height - 10;
            _balls = points;
            for (int i = 0; i < number; i++)
            {
                xPosition = (float)(xRightLimit * _random.NextDouble());
                yPosition = (float)(yBottomLimit * _random.NextDouble());
                xVelocity = 0.5f * (_random.Next(0, 2) * 2 - 1);
                yVelocity = 0.5f * (_random.Next(0, 2) * 2 - 1);
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
            Vector2 pos = ball.Position;
            Vector2 sped = ball.Speed;
            Vector2 npos = pos + sped;

            float newX = npos.X;
            float newY = npos.Y;
            float newVX = sped.X;
            float newVY = sped.Y;

            if (newX < 0 || newX > _width - 10)
            {
                newX -= 2 * newVX;
                newVX = -newVX;
            }

            if (newY < 0 || newY > _height - 10)
            {
                newY -= 2 * newVY;
                newVY = -newVY;
            }

            npos = new Vector2(newX, newY);
            sped = new Vector2(newVX, newVY);

            ball.SetPosition(npos);
            ball.SetVelocity(sped);
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
