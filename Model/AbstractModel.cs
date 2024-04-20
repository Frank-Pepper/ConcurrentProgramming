using System.Collections.ObjectModel;


namespace Model
{
    public abstract class AbstractModel
    {
        public abstract int RectangleWidth { get; }
        public abstract int RectangleHeigth { get; }
        public abstract int BallRadius { get; }
        public abstract List<IPoint> Points { get; set; }
        public abstract IPoint CreatePoint(Double x, Double y);

        public abstract void startGame(int BallNumber, ObservableCollection<IPoint> Points);
        public abstract void StopGame();
        public abstract void move();
        public static AbstractModel GetModel()
        {
            return new ModelProperties();
        }
        public static IPointFactory GetPointFactory()
        {
            return new PointFactory();
        }
    }
}
