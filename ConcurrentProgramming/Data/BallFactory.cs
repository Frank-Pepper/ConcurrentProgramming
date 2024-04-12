using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallFactory : IBallFactory
    {
        public IBall Create(double x, double y)
        {
            return new Ball(x, y);
        }
    }
}
