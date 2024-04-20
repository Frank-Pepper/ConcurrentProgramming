using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class PointFactory : IPointFactory
    {
        public IPoint CreatePoint(Double x, Double y)
        {
            return new Point(x, y);
        }
    }
}
