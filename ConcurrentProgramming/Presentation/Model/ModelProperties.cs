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
        public override List<Tuple<Double, Double>> Points { get; set; }
        public IBallManager manager { get; set; }
        public override void startGame(int BallNumber)
        {
            manager.Create(BallNumber, RectangleWidth, RectangleHeigth);
        }
        public override void move(ObservableCollection<Point> col)
        {
            manager.Move();
        }
    }
}
