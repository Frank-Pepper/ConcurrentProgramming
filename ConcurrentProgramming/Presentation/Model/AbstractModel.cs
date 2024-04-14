using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Presentation.Model
{
    internal abstract class AbstractModel
    {
        public abstract int RectangleWidth { get; }
        public abstract int RectangleHeigth { get; }
        public abstract int BallRadius { get; }
        public abstract List<Tuple<Double, Double>> Points { get; set; }

        public abstract void startGame(int BallNumber);
        public abstract void move(ObservableCollection<Point> col);
        public abstract ObservableCollection<Point> GetCoordinates();
        public static AbstractModel GetModel()
        {
            return new ModelProperties(IAbstractLogicAPI.GetBallManager());
        }
    }
}
