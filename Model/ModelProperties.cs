using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    internal class ModelProperties : AbstractModel
    {
        public ModelProperties(IBallManager? ballManager = null)
        {
            Manager = ballManager ?? ILogicAPI.GetBallManager();
            Points = new();
        }
        public override int RectangleWidth => 500;

        public override int RectangleHeigth => 400;
        public override int BallRadius => 10;
        public override List<IPoint> Points { get; set; }
        public IBallManager Manager { get; set; }
        public override void StartGame(int BallNumber, ObservableCollection<IPoint> Points)
        {
            List<ILogicBallEvent> lBall = new();
            for (int i = 0; i < BallNumber; i++)
            {
                lBall.Add(ILogicAPI.GetLogicBallEventSubOnly(Points[i].SetPosition));
            }
            Manager.Create(BallNumber, RectangleWidth, RectangleHeigth, lBall);
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
