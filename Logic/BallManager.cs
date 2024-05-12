﻿using Data;
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
        private ITable _table;
        private int _radius;
        private int _mass;
        private object table = new object();
        private List<IBall> balls;

        private List<ILogicBallEvent> _balls;

        public BallManager(int width, int height, IDataAPI? api = null)
        {
            _api = api ?? IDataAPI.GetDataApi();
            _balls = new List<ILogicBallEvent>();
            balls = new List<IBall>();
            _table = _api.GetTable(width, height);
        }
        public void Create(int number, int radius, int mass, List<ILogicBallEvent> points)
        {
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
                    IBall ball = _api.GetBall(_radius, _mass, i, pos, sped);
                    ball.ChangedPosition += _balls[i].SetValues;
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
            Vector2 sped = ball.GetVelocity();
            Vector2 npos = pos + sped;

            float newX = npos.X;
            float newY = npos.Y;
            float newVX = sped.X;
            float newVY = sped.Y;

            if (newX < 0 || newX > _table.GetRectangleWidth() - _radius)
            {
                newX -= 2 * newVX;
                newVX = -newVX;
            }

            if (newY < 0 || newY > _table.GetRectangleHeight() - _radius)
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
                IBall myBall = (IBall)s;
                Vector2 myBallPos = myBall.GetPosition();
                Vector2 myBallSpe = myBall.GetVelocity();
                Vector2 npos = myBallPos + myBallSpe;
                int myBallID = myBall.GetId();
                float distance;
                foreach(var ball in balls)
                {
                    int currentBallID = ball.GetId();
                    Vector2 currentBallPos = ball.GetPosition();
                    Vector2 currentBallSpe = ball.GetVelocity();
                    distance = Vector2.Distance(myBallPos, currentBallPos);
                    if(distance <= (myBall.GetR())/2 + (ball.GetR())/2)
                    {
                        if(myBallID != currentBallID)
                        {
                            if (distance > Vector2.Distance(myBallPos + myBallSpe, currentBallPos + currentBallSpe))
                            {
                                float myBallXSpeed = myBall.GetVelocity().X * (myBall.GetM() - ball.GetM()) / (myBall.GetM() + ball.GetM())
                                           + ball.GetM() * ball.GetVelocity().X * 2f / (myBall.GetM() + ball.GetM());
                                float myBallYSpeed = myBall.GetVelocity().Y * (myBall.GetM() - ball.GetM()) / (myBall.GetM() + ball.GetM())
                                                       + ball.GetM() * ball.GetVelocity().Y * 2f / (myBall.GetM() + ball.GetM());

                                float ballXSpeed = ball.GetVelocity().X * (ball.GetM() - myBall.GetM()) / (ball.GetM() + ball.GetM())
                                                  + myBall.GetM() * myBall.GetVelocity().X * 2f / (ball.GetM() + myBall.GetM());
                                float ballYSpeed = ball.GetVelocity().Y * (ball.GetM() - myBall.GetM()) / (ball.GetM() + ball.GetM())
                                                  + myBall.GetM() * myBall.GetVelocity().Y * 2f / (ball.GetM() + myBall.GetM());
                                myBall.SetVelocity(new Vector2(myBallXSpeed, myBallYSpeed));
                                ball.SetVelocity(new Vector2(ballXSpeed, ballYSpeed));
                                Debug.WriteLine(myBallID + " Zderzenie kull " + currentBallID);
                            }
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
