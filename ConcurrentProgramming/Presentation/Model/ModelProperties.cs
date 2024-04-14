using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            manager.generate(BallNumber, RectangleWidth, RectangleHeigth);
        }
        public override ObservableCollection<Point> move(ObservableCollection<Point> col)
        {
            manager.Move();
            this.Points = manager.GetCoordinates();
            col.Clear();
            return GetCoordinates();
        }
        public override ObservableCollection<Point> GetCoordinates()
        {
            ObservableCollection<Point> col = new ObservableCollection<Point>();
            if (Points.Count != 0)
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    col.Add(new Point(Points[i].Item1, Points[i].Item2));
                }
            }
            return col;
        }
    }
}
