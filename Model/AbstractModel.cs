using System.Collections.ObjectModel;


namespace Presentation.Model
{
    public abstract class AbstractModel
    {
        public abstract int RectangleWidth { get; }
        public abstract int RectangleHeigth { get; }
        public abstract int BallRadius { get; }
        public abstract List<IPoint> Points { get; set; }

        public abstract void StartGame(int BallNumber, ObservableCollection<IPoint> Points);
        public abstract void StopGame();
        public abstract void EndGame();
        //public abstract void Move();
        public static AbstractModel GetModel()
        {
            return new ModelProperties();
        }
        public static IPoint CreatePoint(float x, float y)
        {
            return new Point(x, y);
        }
    }
}
