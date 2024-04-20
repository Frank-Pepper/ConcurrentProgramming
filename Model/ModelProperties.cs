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
            throw new NotImplementedException();
        }
        public override void startGame(int BallNumber, ObservableCollection<IPoint> Points)
        {
            //Points = new List<Point>();
            List<LogicBall> lBall = new List<LogicBall>();
            for (int i = 0; i < BallNumber; i++)
            {
                //Point p = new Point();
                //Points.Add(p);
                lBall.Add(new LogicBall(Points[i].SetPosition));
            }
            manager.Create(BallNumber, RectangleWidth, RectangleHeigth, lBall);
        }
        public override void move()
        {
            manager.Move();
        }
    }
}
