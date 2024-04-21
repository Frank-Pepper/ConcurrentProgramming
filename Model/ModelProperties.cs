using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    internal class ModelProperties : AbstractModel
    {
        public ModelProperties(IBallManager? ballManager = default(IBallManager))
        {
            manager = ballManager ?? ILogicAPI.GetBallManager();
        }
        public override int RectangleWidth => 500;

        public override int RectangleHeigth => 400;
        public override int BallRadius => 10;
        public override List<IPoint> Points { get; set; }
        public IBallManager manager { get; set; }
        public override void startGame(int BallNumber, ObservableCollection<IPoint> Points)
        {
            List<ILogicBallEvent> lBall = new();
            for (int i = 0; i < BallNumber; i++)
            {
                lBall.Add(ILogicAPI.GetLogicBallEventSubOnly(Points[i].SetPosition));
            }
            manager.Create(BallNumber, RectangleWidth, RectangleHeigth, lBall);
        }
        public override void StopGame()
        {
            manager.StopBalls();
        }
        public override void EndGame()
        {
            manager.Reset();
        }
        public override void move()
        {
            manager.Move();
        }
    }
}
