﻿using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    internal class ModelProperties : AbstractModel
    {
        public ModelProperties(IBallManager? ballManager = null)
        {
            Manager = ballManager ?? ILogicAPI.GetBallManager(RectangleWidth, RectangleHeight);
            Points = new();
        }
        public override int RectangleWidth => 500;

        public override int RectangleHeight => 400;
        public override int BallRadius => 20;
        public override int BallMass => 5;
        public override List<IPoint> Points { get; set; }
        public IBallManager Manager { get; set; }
        public override void StartGame(int BallNumber, ObservableCollection<IPoint> Points)
        {
            List<ILogicBallEvent> lBall = new();
            for (int i = 0; i < BallNumber; i++)
            {
                lBall.Add(ILogicAPI.GetLogicBallEventSubOnly(Points[i].Position, Points[i].SetPosition));
            }
            Manager.Create(BallNumber, BallRadius, BallMass, lBall);
        }
        public override void StopGame()
        {
            Manager.StopBalls();
        }
        public override void EndGame()
        {
            Manager.Reset();
        }
        //public override void Move()
        //{
        //    Manager.Move();
        //}
    }
}
