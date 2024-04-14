using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBall
    {
        void SetPosition(Double x, Double y);
        void SetVelocity(Double vx, Double vy);
        Tuple<Double, Double> GetPosition();
        Tuple<Double, Double> GetVelocity();
    }
}
