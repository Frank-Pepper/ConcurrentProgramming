using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBallFactory
    {
        IBall Create(Double x, Double y);
    }
}
