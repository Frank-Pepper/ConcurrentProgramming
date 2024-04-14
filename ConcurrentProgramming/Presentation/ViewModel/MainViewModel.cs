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
using Logic;
using Data;

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

            //_coordinates = new ObservableCollection<Tuple<double, double>>();
            //_coordinates.Add(Tuple.Create(230.0, 154.0));
            //_coordinates.Add(Tuple.Create(330.0, 354.0));

            var manager = IAbstractLogicAPI.GetBallManager();
            _coordinates = new ObservableCollection<Point>();
            _coordinates.Add(new Point(0, 0));
            _coordinates.Add(new Point(10, 10));
            _coordinates.Add(new Point(110, 110));
            //_coordinates = new ObservableCollection<Tuple<Double, Double>>();
            SetCommand = new RelayCommand(() => model.startGame(_number));
            StartCommand = new RelayCommand(() => model.move(_coordinates));

            _coordinates.Add(new Point(0, 0));
            _coordinates.Add(new Point(10, 10));
            _coordinates.Add(new Point(110, 110));
        }
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
        private ObservableCollection<Point> _coordinates;
        public ObservableCollection<Point> Coordinates
        {
            get => _coordinates;
            set
            {
                if (value == _coordinates) return;
                RaisePropertyChanged();
            }
        }



        public ICommand SetCommand { get; set; }
        public ICommand StartCommand { get; set; }
    }
}
