using System.ComponentModel;
using System.Numerics;

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
