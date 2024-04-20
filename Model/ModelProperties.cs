using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    internal class ModelProperties : AbstractModel
    {
        public ModelProperties(IBallManager? ballManager = default(IBallManager), IPointFactory? pointFactory = default(IPointFactory))
        {
            manager = ballManager ?? IAbstractLogicAPI.GetBallManager();
            factory = pointFactory ?? AbstractModel.GetPointFactory();
        }
        public override int RectangleWidth => 500;

        public override int RectangleHeigth => 400;
        public override int BallRadius => 10;
        public override List<IPoint> Points { get; set; }
        public IBallManager manager { get; set; }
        public IPointFactory factory { get; set; }
        public override IPoint CreatePoint(Double x, Double y)
        {
            return factory.CreatePoint(x, y);
        }
        public override void startGame(int BallNumber, ObservableCollection<IPoint> Points)
        {
            List<LogicBallEvent> lBall = new();
            for (int i = 0; i < BallNumber; i++)
            {
                lBall.Add(new LogicBallEvent(Points[i].SetPosition));
            }
            manager.Create(BallNumber, RectangleWidth, RectangleHeigth, lBall);
        }
        public override void StopGame()
        {
            manager.StopBalls();
        }

        public override void move()
        {
            manager.Move();
        }
    }
}
