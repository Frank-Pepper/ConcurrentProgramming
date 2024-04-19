namespace Presentation.Model
{
    internal class Point
    {
        public Double X { get; set; }
        public Double Y { get; set; }
        public Point() { }
        public Point(Double x, Double y) {  X = x; Y = y; }
        public void SetPosition(Double x, Double y)
        {
            X = x;
            Y = y;
        }
    }
}
