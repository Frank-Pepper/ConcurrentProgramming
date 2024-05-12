using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallManager : IBallManager
    {
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
            lock (table)
            {
                for (int i = 0; i < number; i++)
                {
                    xVelocity = (float)(0.5 * (_random.NextDouble() * 2 - 1));
                    yVelocity = (float)(0.5 * (_random.NextDouble() * 2 - 1));
                    Vector2 pos = _balls[i].Position;
                    Vector2 sped = new Vector2(xVelocity, yVelocity);
                    IBall ball = _api.GetBall(_radius, _mass, i, pos, sped, _balls[i].SetPosition);
                    ball.ChangedPosition += CheckCollisionWithWall;
                    ball.ChangedPosition += CheckCollisionWithBalls;

                    balls.Add(ball);
                }
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
                Vector2 npos = pos + sped;
                int id = myball.GetId();
                Vector2 distance;
                float centreDistance = 4 * _radius * _radius;
                foreach(var ball in balls)
                {
                    Vector2 ball2pos = ball.GetPosition();
                    distance = ball2pos - npos;
                    float cartesian = distance.X * distance.X + distance.Y * distance.Y;
                    int ballId = ball.GetId();
                    if ( cartesian <= centreDistance)
                    {
                        if (id != ballId)
                        {
                            float myBallXSpeed = myball.GetVeolcity().X * (myball.GetM() - ball.GetM()) / (myball.GetM() + ball.GetM())
                                           + ball.GetM() * ball.GetVeolcity().X * 2f / (myball.GetM() + ball.GetM());
                            float myBallYSpeed = myball.GetVeolcity().Y * (myball.GetM() - ball.GetM()) / (myball.GetM() + ball.GetM())
                                                   + ball.GetM() * ball.GetVeolcity().Y * 2f / (myball.GetM() + ball.GetM());

                            float ballXSpeed = ball.GetVeolcity().X * (ball.GetM() - myball.GetM()) / (ball.GetM() + ball.GetM())
                                              + myball.GetM() * myball.GetVeolcity().X * 2f / (ball.GetM() + myball.GetM());
                            float ballYSpeed = ball.GetVeolcity().Y * (ball.GetM() - myball.GetM()) / (ball.GetM() + ball.GetM())
                                              + myball.GetM() * myball.GetVeolcity().Y * 2f / (ball.GetM() + myball.GetM());

                            myball.SetVelocity(new Vector2(myBallXSpeed, myBallYSpeed));
                            ball.SetVelocity(new Vector2(ballXSpeed, ballYSpeed));
                            Debug.WriteLine(ballId + " Zderzenie kull " + id);
                        }
                    }
                }


            }

        }
        public void StopBalls()
        {
            //motion = false;
        }
        public void Reset()
        {
            //motion = false;
            lock (table)
            {
                foreach (var ball in balls)
                {
                    ball.Dispose();
                }
                balls.Clear();
            }
        }
    }
}
