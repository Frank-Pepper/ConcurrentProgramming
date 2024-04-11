using Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal interface IBallFactory
    {
        List<IBall> Create(int number, Double width, Double height);
      
    }
}
