using Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    internal class Point
    {
        public Double X { get; set; }
        public Double Y { get; set; }
        public Point(Double x, Double y) {  X = x; Y = y; }
        public static bool operator ==(Point l, Point r)
        {

            return (l.X == r.X && r.Y == l.Y);
        }
        public static bool operator !=(Point l, Point r)
        {
            return !(l == r);

        }
    }
}
