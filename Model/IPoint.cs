﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public interface IPoint : INotifyPropertyChanged
    {
        Vector2 Position { get; set; }
        Double X { get;  }
        Double Y { get; }
        new event PropertyChangedEventHandler? PropertyChanged;

        void NotifyPropertyChanged(string p);

        void SetPosition(Vector2 pos);
    }
}
