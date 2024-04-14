using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBall
    {
        void SetPositionX(Double x);
        void SetPositionY(Double y);
        void SetVelocityX(Double vx);
        void SetVelocityY(Double xy);
        Tuple<Double, Double> GetPosition();
        Tuple<Double, Double> GetVelocity();
    }
}
