using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPoint : INotifyPropertyChanged
    {
        Double X { get;  }
        Double Y { get; }
        event PropertyChangedEventHandler? PropertyChanged;

        void NotifyPropertyChanged(string p);

        void SetPosition(Double x, Double y);
    }
}
