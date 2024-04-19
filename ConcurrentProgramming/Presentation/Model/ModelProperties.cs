using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    internal class ModelProperties : AbstractModel
    {
        public ModelProperties(IBallManager? _manager)
        {
            manager = _manager;
        }
        public override int RectangleWidth => 500;

        public override int RectangleHeigth => 400;
        public override int BallRadius => 10;
        public override List<Point> Points { get; set; }
        public IBallManager manager { get; set; }
        public override void startGame(int BallNumber, ObservableCollection<Point> Points)
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
