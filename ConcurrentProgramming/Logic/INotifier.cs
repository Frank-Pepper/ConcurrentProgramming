﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal interface INotifier
    {
        List<Tuple<Double, Double>> SendData();
    }
}