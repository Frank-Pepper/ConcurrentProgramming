using System.Collections.ObjectModel;


namespace Presentation.Model
{
    public abstract class AbstractModel
    {
        public abstract int RectangleWidth { get; }
        public abstract int RectangleHeigth { get; }
        public abstract int BallRadius { get; }
        public abstract List<IPoint> Points { get; set; }

        public abstract void startGame(int BallNumber, ObservableCollection<IPoint> Points);
        public abstract void StopGame();
        public abstract void EndGame();
        public abstract void move();
        public static AbstractModel GetModel()
        {
            return new ModelProperties();
        }
        public static IPoint CreatePoint(Double x, Double y)
        {
            return new Point(x, y);
        }
    }
}
