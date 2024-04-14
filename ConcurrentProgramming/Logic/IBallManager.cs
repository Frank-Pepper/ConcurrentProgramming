﻿using Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IBallManager
    {
        void Create(int number, Double width, Double height);
        void Reset();
    }
}