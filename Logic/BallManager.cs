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
        //private readonly IBallRepoddsitory _ballRepository;
        private readonly IDataAPI _api;
        private readonly Random _random = new Random();
        private Double _width;
        private Double _height;
        private bool motion;
        private List<IBall> balls;

        private List<ILogicBallEvent> _balls;

        public BallManager(IDataAPI? api = null)
        {
            //_ballRepository = ballRepository ?? IDataAPI.GetBallRepository();
            _api = api ?? IDataAPI.GetDataApi();
            _balls = new List<ILogicBallEvent>();
            balls = new List<IBall>();
        }
        public void Create(int number, float width, float height, List<ILogicBallEvent> points)
        {
            motion = true;
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
                //_ballRepository.Add(IDataAPI.GetBall(10, xPosition, yPosition, xVelocity, yVelocity, _balls[i].SetPosition));
                IBall ball = _api.GetBall(10, xPosition, yPosition, xVelocity, yVelocity, _balls[i].SetPosition);
                ball.ChangedPosition += CheckCollisionWithWall;
                ball.ChangedPosition += Killballs;

                balls.Add(ball);
            }
        }

        private void CheckCollisionWithWall(Object s, DataEventArgs e)
        {
            DataEventArgs ball = e as DataEventArgs;
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
            sped = new Vector2(newVX, newVY);
            ball.VeolcityUpdate?.Invoke(sped);

        }
        public void StopBalls()
        {
            motion = false;
        }

        public void Killballs(Object s, DataEventArgs e)
        {
            if (!motion)
            {
                DataEventArgs ball = e as DataEventArgs;
                ball.BallSmasher?.Invoke();
            }
        }
        public void Reset()
        {
            motion = false;
        }
    }
}
