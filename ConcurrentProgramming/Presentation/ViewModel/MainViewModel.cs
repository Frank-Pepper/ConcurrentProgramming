using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Accessibility;
using Presentation.ViewModel.Command;
using Presentation.Model;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            var model = AbstractModel.GetModel();
            _ballRadius = model.BallRadius;
            _rectHeigth = model.RectangleHeigth;
            _rectWidth = model.RectangleWidth;

            _coordinates = new ObservableCollection<Tuple<double, double>>();
            _coordinates.Add(Tuple.Create(230.0, 154.0));
            _coordinates.Add(Tuple.Create(330.0, 354.0));

            StartCommand = new StartCommand();
   
            
            
            //AddButton = new IncreaseCommand(ref Number);
            //MinusButton = new DecreaseCommand(ref Number);
        }
        private readonly ObservableCollection<Tuple<Double, Double>> _coordinates;
        private int _number;
        public int Number
        {
            get => _number;
            set
            {
                if (value == _number) return;
                _number = value;
                RaisePropertyChanged();
            }
        }
        public int _ballRadius { get; }
        public int _rectWidth { get; }
        public int _rectHeigth { get; }

        public int BallRadius
        {
            get => _ballRadius;
        }

        public ObservableCollection<Tuple<Double, Double>> Coordinates
        {
            get => _coordinates;
            set
            {
                if (value == _coordinates) return;
                RaisePropertyChanged();
            }
        }
        public ICommand AddButton { get; set; }
        public ICommand MinusButton { get; set; }
        public ICommand StartCommand { get; set; }
    }
}
