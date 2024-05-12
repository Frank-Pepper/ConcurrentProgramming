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
        private int _radius;
        private int _mass;
        private object table = new object();
        private List<IBall> balls;

        private List<ILogicBallEvent> _balls;

        public BallManager(IDataAPI? api = null)
        {
            _api = api ?? IDataAPI.GetDataApi();
            _balls = new List<ILogicBallEvent>();
            balls = new List<IBall>();
        }
        public void Create(int number, int radius, int mass, float width, float height, List<ILogicBallEvent> points)
        {
            _width = width;
            _height = height;
            _radius = radius;
            _mass = mass;
            float xVelocity;
            float yVelocity;
            _balls = points;
            for (int i = 0; i < number; i++)
            {
                xVelocity = (float)(0.5 * (_random.Next(0, 2) * 2 - 1));
                yVelocity = (float)(0.5 * (_random.Next(0, 2) * 2 - 1));
                Vector2 pos = _balls[i].Position;
                Vector2 sped = new Vector2(xVelocity, yVelocity);
                IBall ball = _api.GetBall(_radius, _mass, i, pos, sped, _balls[i].SetPosition);
                ball.ChangedPosition += CheckCollisionWithWall;

                balls.Add(ball);
            }
        }

        private void CheckCollisionWithWall(Object s, EventArgs e)
        {
            IBall ball = (IBall) s;
            Vector2 pos = ball.GetPosition();
            Vector2 sped = ball.GetVeolcity();
            Vector2 npos = pos + sped;

            float newX = npos.X;
            float newY = npos.Y;
            float newVX = sped.X;
            float newVY = sped.Y;

            if (newX < 0 || newX > _width - _radius)
            {
                newX -= 2 * newVX;
                newVX = -newVX;
            }

            if (newY < 0 || newY > _height - _radius)
            {
                newY -= 2 * newVY;
                newVY = -newVY;
            }
            sped = new Vector2(newVX, newVY);
            ball.SetVelocity(sped);

        }
        private void CheckCollisionWithBalls(Object s, EventArgs e)
        {
            lock (table)
            {
                IBall myball = (IBall)s;
                Vector2 pos = myball.GetPosition();
                Vector2 sped = myball.GetVeolcity();
                int id = myball.GetId();


            }

        }
        public void StopBalls()
        {
            //motion = false;
        }
        public void Reset()
        {
            //motion = false;
            foreach (var ball in balls)
            {
                ball.Dispose();
            }
            balls.Clear();
        }
    }
}
