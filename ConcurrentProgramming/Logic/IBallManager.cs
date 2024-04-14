using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IBallManager
    {
        void generate(int number, Double width, Double height);
        void Create(int number, Double width, Double height);
        void Move();
        List<Tuple<Double, Double>> GetCoordinates();
        void Reset();
    }
}